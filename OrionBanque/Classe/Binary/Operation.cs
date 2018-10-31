using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace OrionBanque.Classe.Binary
{
    class Operation
    {
        public static Classe.Operation Sauve(Classe.Operation o)
        {
            Log.Logger.Debug("Debut Operation.Sauve(" + o.Libelle + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                o.Id = ob.Operations.Count != 0 ? ob.Operations.Max(u => u.Id) + 1 : 1;
                ob.Operations.Add(o);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return o;
        }

        public static List<Classe.Operation> ChargeTout(int idC)
        {
            Log.Logger.Debug("Debut Operation.Charge(" + idC + ")");
            List<Classe.Operation> lo = new List<Classe.Operation>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lo = ob.Operations.Where(ot => ot.Compte.Id == idC).OrderByDescending(x => x.Date).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lo;
        }

        public static List<Classe.Operation> ChargeToutUtilisateur(Classe.Utilisateur u)
        {
            Log.Logger.Debug("Debut Operation.ChargeToutUtilisateur(" + u.Login + ")");
            List<Classe.Operation> lo = new List<Classe.Operation>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lo = ob.Operations.Where(ot => ot.Compte.Utilisateur.Id == u.Id).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lo;
        }

        public static int ChercheChequeSuivant(int idC)
        {
            Log.Logger.Debug("Debut Echeancier.ChercheChequeSuivant(" + idC + ")");
            int retour = 0;
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                List<Classe.Operation> lo = ob.Operations.Where(ot => ot.Compte.Id == idC && ot.ModePaiement.Id == 8).OrderByDescending(ot => ot.Date).ToList();
                if(lo.Count > 0)
                {
                    string[] tab = lo[0].Libelle.Split('°');
                    if (tab.Length > 1)
                    {
                        bool b = int.TryParse(tab[1], out retour);
                        retour++;
                        if (!b)
                        {
                            retour = 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static List<string> ChargeToutTiers(int idC)
        {
            Log.Logger.Debug("Debut Operations.ChargeToutTiers(" + idC + ")");
            List<string> ls = new List<string>();
            List<Classe.Operation> lo = ChargeTout(idC).OrderBy(o => o.Tiers).ToList();
            foreach(Classe.Operation o in lo)
            {
                ls.Add(o.Tiers);
            }
            return ls.Distinct().ToList();
        }

        public static double CalculAVenir(int idCompte)
        {
            Log.Logger.Debug("Debut Operations.CalculAVenir(" + idCompte + ")");
            List<Classe.Operation> lo = ChargeTout(idCompte).Where(o => o.DatePointage is null).ToList();
            
            double rPositif = 0.0;
            double rNegatif = 0.0;
            
            foreach (Classe.Operation o in lo)
            {
                if (o.ModePaiement.Type.Equals("D"))
                {
                    rNegatif += o.Montant;
                }

                if (o.ModePaiement.Type.Equals("C"))
                {
                    rPositif += o.Montant;
                }
            }
                
            return rPositif - rNegatif;
        }

        public static double CalculSoldOpePoint(int idCompte)
        {
            Log.Logger.Debug("Debut Operations.CalculSoldOpePoint(" + idCompte + ")");
            List<Classe.Operation> lo = ChargeTout(idCompte).Where(o => o.DatePointage != null).ToList();

            double rPositif = 0.0;
            double rNegatif = 0.0;

            foreach (Classe.Operation o in lo)
            {
                if (o.ModePaiement.Type.Equals("D"))
                {
                    rNegatif += o.Montant;
                }

                if (o.ModePaiement.Type.Equals("C"))
                {
                    rPositif += o.Montant;
                }
            }

            return rPositif - rNegatif;
        }

        public static Classe.Operation Maj(Classe.Operation oA)
        {
            Log.Logger.Debug("Debut Operation.Maj(" + oA.Id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                Classe.Operation o = ob.Operations.Find((otemp) => otemp.Id == oA.Id);
                o.ModePaiement = oA.ModePaiement;
                o.Tiers = oA.Tiers;
                o.Libelle = oA.Libelle;
                o.Categorie = oA.Categorie;
                o.Montant = oA.Montant;
                o.Compte = oA.Compte;
                o.Date = oA.Date;
                o.DatePointage = oA.DatePointage;
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return oA;
        }

        public static List<string[]> GroupByTiers(int idC)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByTiers(" + idC + ")");

            IDictionary<string, double> dict = new Dictionary<string, double>();
            List<string[]> ls = new List<string[]>();

            foreach(Classe.Operation o in ChargeTout(idC))
            {
                string temp = o.Tiers == string.Empty ? "Sans Tiers" : o.Tiers;
                double montant = o.ModePaiement.Type == Classe.KEY.MODEPAIEMENT_DEBIT ? o.Montant * -1 : o.Montant;
                dict[temp] = dict.ContainsKey(temp) ? dict[temp] + montant : montant;
            }

            foreach (string key in dict.Keys)
            {
                string[] t = new string[2];
                t[0] = key;
                t[1] = Convert.ToString(dict[key]);
                ls.Add(t);
            }

            return ls;
        }

        public static List<string[]> GroupByTiersDC(int idC)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByTiersDC(" + idC + ")");

            Dictionary<string, double> dictC = new Dictionary<string, double>();
            Dictionary<string, double> dictD = new Dictionary<string, double>();
            List<string> lt = new List<string>();
            List<string[]> ls = new List<string[]>();

            foreach (Classe.Operation o in ChargeTout(idC))
            {
                string temp = o.Tiers == string.Empty ? "Sans Tiers" : o.Tiers;
                if(o.ModePaiement.Type == Classe.KEY.MODEPAIEMENT_DEBIT)
                {
                    dictD[temp] = dictD.ContainsKey(temp) ? dictD[temp] + o.Montant : o.Montant;
                }
                else
                {
                    dictC[temp] = dictC.ContainsKey(temp) ? dictC[temp] + o.Montant : o.Montant;
                }
                if (!lt.Contains(temp))
                {
                    lt.Add(temp);
                }
            }

            foreach (string key in lt)
            {
                string[] t = new string[3];
                t[0] = key;
                t[1] = dictD.ContainsKey(key) ? Convert.ToString(dictD[key]) : Convert.ToString(0.0);
                t[2] = dictC.ContainsKey(key) ? Convert.ToString(dictC[key]) : Convert.ToString(0.0);
                ls.Add(t);
            }
            return ls.ToList();
        }

        public static List<string[]> GroupByCategories(int idC)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByCategories(" + idC + ")");

            Dictionary<int, double> dict = new Dictionary<int, double>();
            List<string[]> ls = new List<string[]>();

            foreach (Classe.Operation o in ChargeTout(idC))
            {
                double montant = o.ModePaiement.Type == Classe.KEY.MODEPAIEMENT_DEBIT ? o.Montant * -1 : o.Montant;
                dict[o.Categorie.Id] = dict.ContainsKey(o.Categorie.Id) ? dict[o.Categorie.Id] + montant : montant;
            }

            foreach (int key in dict.Keys)
            {
                string[] t = new string[2];
                t[0] = Classe.Categorie.Charge(key).Libelle;
                t[1] = Convert.ToString(dict[key]);
                ls.Add(t);
            }

            return ls;
        }

        public static List<string[]> GroupByCategoriesDC(int idC)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByCategoriesDC(" + idC + ")");

            Dictionary<int, double> dictC = new Dictionary<int, double>();
            Dictionary<int, double> dictD = new Dictionary<int, double>();
            List<int> lt = new List<int>();
            List<string[]> retour = new List<string[]>();

            foreach (Classe.Operation o in ChargeTout(idC))
            {
                if (o.ModePaiement.Type == Classe.KEY.MODEPAIEMENT_DEBIT)
                {
                    dictD[o.Categorie.Id] = dictD.ContainsKey(o.Categorie.Id) ? dictD[o.Categorie.Id] + o.Montant : o.Montant;
                }
                else
                {
                    dictC[o.Categorie.Id] = dictC.ContainsKey(o.Categorie.Id) ? dictC[o.Categorie.Id] + o.Montant : o.Montant;
                }

                if (!lt.Contains(o.Categorie.Id))
                {
                    lt.Add(o.Categorie.Id);
                }
            }

            foreach (int key in lt)
            {
                string[] t = new string[3];
                t[0] = Classe.Categorie.Charge(key).Libelle;
                t[1] = dictD.ContainsKey(key) ? Convert.ToString(dictD[key]) : Convert.ToString(0.0);
                t[2] = dictC.ContainsKey(key) ? Convert.ToString(dictC[key]) : Convert.ToString(0.0);
                retour.Add(t);
            }
            return retour.ToList();
        }

        public static double SoldeCompteAt(DateTime dt, int idC)
        {
            Log.Logger.Debug("Debut Operation.SoldeCompteAt(" + idC + ", " + dt + ")");
            List<Classe.Operation> lo = new List<Classe.Operation>();
            double retour = 0.0;
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                retour = ob.Operations.Where(ot => ot.Compte.Id == idC && ot.Date <= dt && ot.ModePaiement.Type == Classe.KEY.MODEPAIEMENT_CREDIT).Sum(s => s.Montant);
                retour = retour - ob.Operations.Where(ot => ot.Compte.Id == idC && ot.Date <= dt && ot.ModePaiement.Type == Classe.KEY.MODEPAIEMENT_DEBIT).Sum(s => s.Montant);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static DateTime GetMaxDate(int idC)
        {
            Log.Logger.Debug("Debut Operation.SoldeCompteAt(" + idC + ")");
            DateTime retour = DateTime.Now;
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                retour = ob.Operations.Where(ot => ot.Compte.Id == idC).Max(ot => ot.Date);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static DateTime GetMinDate(int idC)
        {
            Log.Logger.Debug("Debut Operation.SoldeCompteAt(" + idC + ")");
            DateTime retour = DateTime.Now;
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                retour = ob.Operations.Where(ot => ot.Compte.Id == idC).Min(ot => ot.Date);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static DataSet ChargeGrilleOperation(int idCompte)
        {
            Log.Logger.Debug("Debut Operations.ChargeGrilleOperation(" + idCompte + ")");
            List<Classe.Operation> lo = ChargeTout(idCompte);
            return ToDataSet(lo);
        }

        public static DataSet ChargeGrilleOperationFiltre(int idCompte,
                                bool bDate, string cbFiltreDate, DateTime txtFiltreDate,
                                bool bModePaiement, string txtFiltreModePaiement,
                                bool bTiers, string txtFiltreTiers,
                                bool bCategorie, string txtFiltreCategorie,
                                bool bMontant, string cbFiltreMontant, double txtFiltreMontant, bool bNonPointe)
        {
            Log.Logger.Debug("Debut Operations.ChargeGrilleOperationFiltre()");
            DataSet retour = new DataSet();

            List<Classe.Operation> lo = ChargeTout(idCompte);
            if (bDate)
            {
                switch(cbFiltreDate)
                {
                    case Classe.KEY.COMPARAISON_INF_EGALE:
                        lo = lo.Where(x => x.Date.Date <= txtFiltreDate.Date).ToList();
                        break;
                    case Classe.KEY.COMPARAISON_EGALE:
                        lo = lo.Where(x => x.Date.Date == txtFiltreDate.Date).ToList();
                        break;
                    case Classe.KEY.COMPARAISON_SUP_EGALE:
                        lo = lo.Where(x => x.Date.Date >= txtFiltreDate.Date).ToList();
                        break;
                }
            }

            if(bModePaiement)
            {
                lo = lo.Where(x => x.ModePaiement.Id == Convert.ToInt32(txtFiltreModePaiement)).ToList();
            }

            if (bTiers)
            {
                lo = lo.Where(x => x.Tiers == txtFiltreTiers).ToList();
            }

            if (bCategorie)
            {
                lo = lo.Where(x => x.Categorie.Id == Convert.ToInt32(txtFiltreCategorie)).ToList();
            }

            if (bMontant)
            {
                switch (cbFiltreMontant)
                {
                    case Classe.KEY.COMPARAISON_INF_EGALE:
                        lo = lo.Where(x => x.Montant <= txtFiltreMontant).ToList();
                        break;
                    case Classe.KEY.COMPARAISON_EGALE:
                        lo = lo.Where(x => x.Montant == txtFiltreMontant).ToList();
                        break;
                    case Classe.KEY.COMPARAISON_SUP_EGALE:
                        lo = lo.Where(x => x.Montant >= txtFiltreMontant).ToList();
                        break;
                }
            }

            if(bNonPointe)
            {
                lo = lo.Where(x => x.DatePointage is null).ToList();
            }

            return ToDataSet(lo.OrderByDescending(x => x.Date).ToList());
        }

        public static Classe.Operation Charge(int id)
        {
            Log.Logger.Debug("Debut Operation.Charge(" + id + ")");
            Classe.Operation o = new Classe.Operation();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                o = ob.Operations.Find(ot => ot.Id == id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return o;
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Operation.Delete(" + id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                ob.Operations.RemoveAll((o) => o.Id == id);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static void MajCategorieOperations(int idCompte, int idCatOri, int idCatDest)
        {
            Log.Logger.Debug("Debut Operation.MajCategorieOperations(" + idCompte + ")");

            Classe.Categorie catOri = Classe.Categorie.Charge(idCatOri);
            Classe.Categorie catDest = Classe.Categorie.Charge(idCatOri);
            
            List<Classe.Operation> lo = new List<Classe.Operation>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lo = ob.Operations.Where(ot => ot.Compte.Id == idCompte && ot.Categorie == catOri).ToList();
                foreach(Classe.Operation o in lo)
                {
                    o.Categorie = catDest;
                    Classe.Operation.Maj(o);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static DataSet ToDataSet(List<Classe.Operation> list)
        {
            Type elementType = typeof(Classe.Operation);
            DataSet ds = new DataSet();
            DataTable t = new DataTable("Operations");
            ds.Tables.Add(t);

            t.Columns.Add("Id", typeof(int));
            t.Columns.Add("Date", typeof(DateTime));
            t.Columns.Add("Tiers", typeof(string));
            t.Columns.Add("Libelle", typeof(string));
            t.Columns.Add("ModePaiement", typeof(string));
            t.Columns.Add("ModePaiementType", typeof(string));
            t.Columns.Add("Categorie", typeof(string));
            t.Columns.Add("Montant Débit", typeof(double));
            t.Columns.Add("Montant Crédit", typeof(double));
            t.Columns.Add("DatePointage", typeof(DateTime));
            
            //go through each property on T and add each value to the table
            foreach (Classe.Operation item in list)
            {
                DataRow row = t.NewRow();

                row["Id"] = item.Id;
                row["Date"] = item.Date;
                row["Tiers"] = item.Tiers;
                row["Libelle"] = item.Libelle;
                row["ModePaiement"] = item.ModePaiement.Libelle;
                row["ModePaiementType"] = item.ModePaiement.Type;

                if (item.ModePaiement.Type == Classe.KEY.MODEPAIEMENT_CREDIT)
                {
                    row["Montant Crédit"] = item.Montant;
                    row["Montant Débit"] = DBNull.Value;
                } 
                else
                {
                    row["Montant Débit"] = item.Montant;
                    row["Montant Crédit"] = DBNull.Value;
                }
                row["Categorie"] = item.Categorie.Libelle;
                if (item.DatePointage == null)
                {
                    row["DatePointage"] = DBNull.Value;
                }
                else
                {
                    row["DatePointage"] = item.DatePointage;
                }

                t.Rows.Add(row);
            }

            return ds;
        }
    }
}