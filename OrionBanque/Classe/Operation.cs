using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Operation", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Operation
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public DateTime Date { get; set; }
        [DataMember()]
        public string Tiers { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public double Montant { get; set; }
        [DataMember()]
        public DateTime? DatePointage { get; set; }
        [DataMember()]
        public ModePaiement ModePaiement { get; set; }
        [DataMember()]
        public Categorie Categorie { get; set; }
        [DataMember()]
        public Compte Compte { get; set; }

        public static Operation Sauve(Operation o)
        {
            Log.Logger.Debug("Debut Operation.Sauve(" + o.Libelle + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                o.Id = ob.Operations.Count != 0 ? ob.Operations.Max(u => u.Id) + 1 : 1;
                ob.Operations.Add(o);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return o;
        }

        public static List<Operation> ChargeToutUtilisateur(Utilisateur u)
        {
            Log.Logger.Debug("Debut Operation.ChargeToutUtilisateur(" + u.Login + ")");
            List<Operation> lo = new List<Operation>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lo = ob.Operations.Where(ot => ot.Compte.Utilisateur.Id == u.Id).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lo;
        }

        public static int ChercheChequeSuivant(Compte cA)
        {
            Log.Logger.Debug("Debut Echeancier.ChercheChequeSuivant(" + cA.Id + ")");
            int retour = 0;
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                List<Operation> lo = ob.Operations.Where(ot => ot.Compte.Id == cA.Id && ot.ModePaiement.Id == 8).OrderByDescending(ot => ot.Date).ToList();
                if (lo.Count > 0)
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

        public static List<string> ChargeToutTiers(Compte cA)
        {
            Log.Logger.Debug("Debut Operations.ChargeToutTiers(" + cA.Id + ")");
            List<string> ls = new List<string>();
            List<Operation> lo = Compte.Charge(cA.Id).Operations().OrderBy(o => o.Tiers).ToList();
            foreach (Operation o in lo)
            {
                ls.Add(o.Tiers);
            }
            return ls.Distinct().ToList();
        }

        public static List<string> ChargeToutTiers(Utilisateur uA)
        {
            Log.Logger.Debug("Debut Operations.ChargeToutTiers()");
            List<string> ls = new List<string>();
            List<Operation> lo = new List<Operation>();
            foreach (Compte c in Compte.ChargeTout(uA))
            {
                ls.AddRange(ChargeToutTiers(c));
            }
            ls.Sort();
            return ls.Distinct().ToList();
        }

        public static Operation Maj(Operation oA)
        {
            Log.Logger.Debug("Debut Operation.Maj(" + oA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                Operation o = ob.Operations.Find((otemp) => otemp.Id == oA.Id);
                o.ModePaiement = oA.ModePaiement;
                o.Tiers = oA.Tiers;
                o.Libelle = oA.Libelle;
                o.Categorie = oA.Categorie;
                o.Montant = oA.Montant;
                o.Compte = oA.Compte;
                o.Date = oA.Date;
                o.DatePointage = oA.DatePointage;
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return oA;
        }

        public static List<string[]> GroupByTiers(Compte cP)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByTiers(" + cP.Id + ")");

            IDictionary<string, double> dict = new Dictionary<string, double>();
            List<string[]> ls = new List<string[]>();

            foreach (Operation o in Compte.Charge(cP.Id).Operations())
            {
                string temp = o.Tiers == string.Empty ? "Sans Tiers" : o.Tiers;
                double montant = o.ModePaiement.Type == KEY.MODEPAIEMENT_DEBIT ? o.Montant * -1 : o.Montant;
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

        public static List<string[]> GroupByTiers(Compte cP, DateTime dmin, DateTime dmax)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByTiers(" + cP.Id + ")");

            IDictionary<string, double> dict = new Dictionary<string, double>();
            List<string[]> ls = new List<string[]>();

            foreach (Operation o in Compte.Charge(cP.Id).Operations().Where(x => x.Date >= dmin).Where(y => y.Date <= dmax))
            {
                string temp = o.Tiers == string.Empty ? "Sans Tiers" : o.Tiers;
                double montant = o.ModePaiement.Type == KEY.MODEPAIEMENT_DEBIT ? o.Montant * -1 : o.Montant;
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

        public static List<string[]> GroupByCategories(Compte cP)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByCategories(" + cP.Id + ")");

            Dictionary<int, double> dict = new Dictionary<int, double>();
            List<string[]> ls = new List<string[]>();

            foreach (Operation o in Compte.Charge(cP.Id).Operations())
            {
                double montant = o.ModePaiement.Type == KEY.MODEPAIEMENT_DEBIT ? o.Montant * -1 : o.Montant;
                dict[o.Categorie.Id] = dict.ContainsKey(o.Categorie.Id) ? dict[o.Categorie.Id] + montant : montant;
            }

            foreach (int key in dict.Keys)
            {
                string[] t = new string[2];
                t[0] = Categorie.Charge(key).Libelle;
                t[1] = Convert.ToString(dict[key]);
                ls.Add(t);
            }

            return ls;
        }

        public static List<string[]> GroupByCategories(Compte cP, DateTime dmin, DateTime dmax)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByCategories(" + cP.Id + ")");

            Dictionary<int, double> dict = new Dictionary<int, double>();
            List<string[]> ls = new List<string[]>();

            foreach (Operation o in Compte.Charge(cP.Id).Operations().Where(x => x.Date >= dmin).Where(y => y.Date <= dmax))
            {
                double montant = o.ModePaiement.Type == KEY.MODEPAIEMENT_DEBIT ? o.Montant * -1 : o.Montant;
                dict[o.Categorie.Id] = dict.ContainsKey(o.Categorie.Id) ? dict[o.Categorie.Id] + montant : montant;
            }

            foreach (int key in dict.Keys)
            {
                string[] t = new string[2];
                t[0] = Categorie.Charge(key).Libelle;
                t[1] = Convert.ToString(dict[key]);
                ls.Add(t);
            }

            return ls;
        }

        public static List<string[]> GroupByTiersDC(Compte cP)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByTiersDC(" + cP.Id + ")");

            Dictionary<string, double> dictC = new Dictionary<string, double>();
            Dictionary<string, double> dictD = new Dictionary<string, double>();
            List<string> lt = new List<string>();
            List<string[]> ls = new List<string[]>();

            foreach (Operation o in Compte.Charge(cP.Id).Operations())
            {
                string temp = o.Tiers == string.Empty ? "Sans Tiers" : o.Tiers;
                if (o.ModePaiement.Type == KEY.MODEPAIEMENT_DEBIT)
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

        public static List<string[]> GroupByCategoriesDC(Compte cP)
        {
            // TODO: Passage par un GroupBy et/ou SUM sur la liste
            Log.Logger.Debug("Debut Operations.GroupByCategoriesDC(" + cP.Id + ")");

            Dictionary<int, double> dictC = new Dictionary<int, double>();
            Dictionary<int, double> dictD = new Dictionary<int, double>();
            List<int> lt = new List<int>();
            List<string[]> retour = new List<string[]>();

            foreach (Operation o in Compte.Charge(cP.Id).Operations())
            {
                if (o.ModePaiement.Type == KEY.MODEPAIEMENT_DEBIT)
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
                t[0] = Categorie.Charge(key).Libelle;
                t[1] = dictD.ContainsKey(key) ? Convert.ToString(dictD[key]) : Convert.ToString(0.0);
                t[2] = dictC.ContainsKey(key) ? Convert.ToString(dictC[key]) : Convert.ToString(0.0);
                retour.Add(t);
            }
            return retour.ToList();
        }

        public static double SoldeCompteAt(DateTime dt, Compte cP)
        {
            Log.Logger.Debug("Debut Operation.SoldeCompteAt(" + cP.Id + ", " + dt + ")");
            List<Operation> lo = new List<Operation>();
            double retour = 0.0;
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                retour = ob.Operations.Where(ot => ot.Compte.Id == cP.Id && ot.Date <= dt && ot.ModePaiement.Type == KEY.MODEPAIEMENT_CREDIT).Sum(s => s.Montant);
                retour = retour - ob.Operations.Where(ot => ot.Compte.Id == cP.Id && ot.Date <= dt && ot.ModePaiement.Type == KEY.MODEPAIEMENT_DEBIT).Sum(s => s.Montant);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static DateTime GetMaxDate(Compte cP)
        {
            Log.Logger.Debug("Debut Operation.SoldeCompteAt(" + cP.Id + ")");
            DateTime retour = DateTime.Now;
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                retour = ob.Operations.Where(ot => ot.Compte.Id == cP.Id).Max(ot => ot.Date);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static DateTime GetMinDate(Compte cP)
        {
            Log.Logger.Debug("Debut Operation.SoldeCompteAt(" + cP.Id + ")");
            DateTime retour = DateTime.Now;
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                retour = ob.Operations.Where(ot => ot.Compte.Id == cP.Id).Min(ot => ot.Date);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static DataSet ChargeGrilleOperation(Compte cP)
        {
            Log.Logger.Debug("Debut Operations.ChargeGrilleOperation(" + cP.Id + ")");
            return ToDataSet(cP.Operations(), cP.SoldeInitial);
        }

        public static DataSet ChargeGrilleOperationFiltre(Compte cP,
                                bool bDate, string cbFiltreDate, DateTime txtFiltreDate,
                                bool bModePaiement, ModePaiement mpP,
                                bool bTiers, string txtFiltreTiers,
                                bool bCategorie, Categorie catP,
                                bool bMontant, string cbFiltreMontant, double txtFiltreMontant, bool bNonPointe)
        {
            Log.Logger.Debug("Debut Operations.ChargeGrilleOperationFiltre()");
            DataSet retour = new DataSet();

            List<Operation> lo = cP.Operations();
            if (bDate)
            {
                switch (cbFiltreDate)
                {
                    case KEY.COMPARAISON_INF_EGALE:
                        lo = lo.Where(x => x.Date.Date <= txtFiltreDate.Date).ToList();
                        break;
                    case KEY.COMPARAISON_EGALE:
                        lo = lo.Where(x => x.Date.Date == txtFiltreDate.Date).ToList();
                        break;
                    case KEY.COMPARAISON_SUP_EGALE:
                        lo = lo.Where(x => x.Date.Date >= txtFiltreDate.Date).ToList();
                        break;
                }
            }

            if (bModePaiement)
            {
                lo = lo.Where(x => x.ModePaiement.Id == mpP.Id).ToList();
            }

            if (bTiers)
            {
                lo = lo.Where(x => x.Tiers == txtFiltreTiers).ToList();
            }

            if (bCategorie)
            {
                lo = lo.Where(x => x.Categorie.Id == catP.Id).ToList();
            }

            if (bMontant)
            {
                switch (cbFiltreMontant)
                {
                    case KEY.COMPARAISON_INF_EGALE:
                        lo = lo.Where(x => x.Montant <= txtFiltreMontant).ToList();
                        break;
                    case KEY.COMPARAISON_EGALE:
                        lo = lo.Where(x => x.Montant == txtFiltreMontant).ToList();
                        break;
                    case KEY.COMPARAISON_SUP_EGALE:
                        lo = lo.Where(x => x.Montant >= txtFiltreMontant).ToList();
                        break;
                }
            }

            if (bNonPointe)
            {
                lo = lo.Where(x => x.DatePointage is null).ToList();
            }

            return ToDataSet(lo.OrderByDescending(x => x.Date).ToList(), cP.SoldeInitial);
        }

        public static Operation Charge(int id)
        {
            Log.Logger.Debug("Debut Operation.Charge(" + id + ")");
            Operation o = new Operation();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                o = ob.Operations.Find(ot => ot.Id == id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return o;
        }

        public static void Delete(Operation oP)
        {
            Log.Logger.Debug("Debut Operation.Delete(" + oP.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Operations.RemoveAll((o) => o.Id == oP.Id);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static int MajCategorieOperations(Compte cP, Categorie catOriP, Categorie catDestP)
        {
            Log.Logger.Debug("Debut Operation.MajCategorieOperations(" + cP.Id + ")");

            List<Operation> lo = new List<Operation>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lo = ob.Operations.Where(ot => ot.Compte.Id == cP.Id && ot.Categorie == catOriP).ToList();
                foreach (Operation o in lo)
                {
                    o.Categorie = catDestP;
                    Maj(o);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lo.Count;
        }

        public static int MajTiersOperations(Compte cP, string tiersOriP, string tiersDestP)
        {
            Log.Logger.Debug("Debut Operation.MajTiersOperations(" + cP.Id + ")");
            List<Operation> lo = new List<Operation>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lo = ob.Operations.Where(ot => ot.Compte.Id == cP.Id && ot.Tiers == tiersOriP).ToList();
                foreach (Operation o in lo)
                {
                    o.Tiers = tiersDestP;
                    Maj(o);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lo.Count;
        }

        public static DataSet ToDataSet(List<Operation> list, double solde)
        {
            Type elementType = typeof(Operation);
            DataSet ds = new DataSet();
            DataTable t = new DataTable("Operations");
            int count = 1;

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
            t.Columns.Add("Solde", typeof(string));
            t.Columns.Add("DatePointage", typeof(DateTime));
            t.Columns.Add("ordre", typeof(int));

            list = (from o in list select o).OrderBy(x => x.Date).ToList();

            //go through each property on T and add each value to the table
            foreach (Operation item in list)
            {
                DataRow row = t.NewRow();

                row["Id"] = item.Id;
                row["Date"] = item.Date.Date;
                row["Tiers"] = item.Tiers;
                row["Libelle"] = item.Libelle;
                row["ModePaiement"] = item.ModePaiement.Libelle;
                row["ModePaiementType"] = item.ModePaiement.Type;

                if (item.ModePaiement.Type == KEY.MODEPAIEMENT_CREDIT)
                {
                    solde += item.Montant;
                    row["Montant Crédit"] = item.Montant;
                    row["Montant Débit"] = DBNull.Value;
                }
                else
                {
                    solde -= item.Montant;
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
                row["Solde"] = string.Format("{0,12:0,0.00}", solde) + " €";
                row["ordre"] = count;
                count++;
                t.Rows.Add(row);
            }

            return ds;
        }
    }
}