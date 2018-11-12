using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Echeancier", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Echeancier
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public DateTime Prochaine { get; set; }
        [DataMember()]
        public string Tiers { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public double Montant { get; set; }
        [DataMember()]
        public ModePaiement ModePaiement { get; set; }
        [DataMember()]
        public Categorie Categorie { get; set; }
        [DataMember()]
        public Compte Compte { get; set; }
        [DataMember()]
        public int Repete { get; set; }
        [DataMember()]
        public string TypeRepete { get; set; }
        [DataMember()]
        public DateTime? DateFin { get; set; }
        [DataMember()]
        public bool? InsererOuvertureFichier { get; set; }
        [DataMember()]
        public bool? DecaleSamedi { get; set; }
        [DataMember()]
        public bool? DecaleDimanche { get; set; }
        
        public static int InsereEcheanceFromGest(DateTime DateInsereEch, Utilisateur u)
        {
            Log.Logger.Debug("Debut Echeancier.InsereEcheance()");
            List<Compte> lc = Compte.ChargeTout(u);
            int retour = 0;
            foreach(Compte c in lc)
            { 
                List<Echeancier> le = ChargeTout(c.Id);
                try
                {
                    le = le
                        .Where(w => w.Compte.Id == c.Id)
                        .Where(w1 => w1.DateFin is null || w1.Prochaine <= w1.DateFin)
                        .Where(w2 => w2.Prochaine <= DateInsereEch)
                        .ToList();

                    retour += InsereEcheance(le);
                   
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    throw;
                }
            }
            return retour;
        }

        public static int InsereEcheanceOpenFile(Utilisateur u)
        {
            Log.Logger.Debug("Debut Echeancier.InsereEcheanceOpenFile()");
            List<Compte> lc = Compte.ChargeTout(u);
            int retour = 0;
            foreach (Compte c in lc)
            {
                List<Echeancier> le = ChargeTout(c.Id);
                try
                {
                    le = le
                        .Where(w => w.Compte.Id == c.Id)
                        .Where(w2 => w2.Prochaine == DateTime.Today.Date)
                        .ToList();

                    retour += InsereEcheance(le);

                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    throw;
                }
            }
            return retour;
        }

        public static int InsereEcheance(List<Echeancier> le)
        {
            int retour = 0;
            foreach (Echeancier ec in le)
            {
                Operation o = new Operation
                {
                    Date = ec.Prochaine,
                    Categorie = ec.Categorie,
                    Compte = ec.Compte,
                    ModePaiement = ec.ModePaiement,
                    Libelle = ec.Libelle,
                    Montant = ec.Montant,
                    Tiers = ec.Tiers
                };

                if (o.Date.DayOfWeek == DayOfWeek.Saturday && (ec.DecaleSamedi ?? false))
                {
                    o.Date.AddDays(2);
                }
                if (o.Date.DayOfWeek == DayOfWeek.Sunday && (ec.DecaleDimanche ?? false))
                {
                    o.Date.AddDays(1);
                }

                Operation.Sauve(o);

                switch (ec.TypeRepete)
                {
                    case KEY.ECHEANCIER_JOUR:
                        ec.Prochaine = ec.Prochaine.AddDays(ec.Repete);
                        break;
                    case KEY.ECHEANCIER_MOIS:
                        ec.Prochaine = ec.Prochaine.AddMonths(ec.Repete);
                        break;
                    case KEY.ECHEANCIER_ANNEE:
                        ec.Prochaine = ec.Prochaine.AddYears(ec.Repete);
                        break;
                }

                Maj(ec);
                retour++;
            }
            return retour;
        }

        public static Echeancier Sauve(Echeancier e)
        {
            Log.Logger.Debug("Debut Echeancier.Sauve(" + e.Libelle + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                e.Id = ob.Echeanciers.Count != 0 ? ob.Echeanciers.Max(u => u.Id) + 1 : 1;
                ob.Echeanciers.Add(e);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return e;
        }

        public static Echeancier Maj(Echeancier eA)
        {
            Log.Logger.Debug("Debut Echeancier.Maj(" + eA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                Echeancier e = ob.Echeanciers.Find((etemp) => etemp.Id == eA.Id);
                e.ModePaiement = eA.ModePaiement;
                e.Tiers = eA.Tiers;
                e.Libelle = eA.Libelle;
                e.Categorie = eA.Categorie;
                e.Montant = eA.Montant;
                e.Compte = eA.Compte;
                e.Repete = eA.Repete;
                e.DateFin = eA.DateFin;
                e.TypeRepete = eA.TypeRepete;
                e.Prochaine = eA.Prochaine;
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return eA;
        }

        public static DataSet ChargeGrilleEcheance(Utilisateur u)
        {
            return ToDataSet(ChargeToutUtilisateur(u));
        }

        public static Echeancier Charge(int id)
        {
            Log.Logger.Debug("Debut Echeancier.Charge(" + id + ")");
            Echeancier e = new Echeancier();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                e = ob.Echeanciers.Find(et => et.Id == id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return e;
        }

        public static List<Echeancier> ChargeTout(int idC)
        {
            Log.Logger.Debug("Debut Echeancier.Charge(" + idC + ")");
            List<Echeancier> le = new List<Echeancier>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                le = ob.Echeanciers.Where(et => et.Compte.Id == idC).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return le;
        }

        public static List<Echeancier> ChargeToutUtilisateur(Utilisateur u)
        {
            Log.Logger.Debug("Debut Echeancier.ChargeToutUtilisateur(" + u.Login + ")");
            List<Echeancier> le = new List<Echeancier>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                le = ob.Echeanciers.Where(et => et.Compte.Utilisateur.Id == u.Id).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return le;
        }

        public static void Delete(Echeancier ec)
        {
            Delete(ec.Id);
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Echeancier.Delete(" + id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Echeanciers.RemoveAll((e) => e.Id == id);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static DataSet ToDataSet(List<Echeancier> list)
        {
            Type elementType = typeof(Echeancier);
            DataSet ds = new DataSet();
            DataTable t = new DataTable("echeancier");
            ds.Tables.Add(t);

            t.Columns.Add("Id", typeof(int));
            t.Columns.Add("Compte", typeof(string));
            t.Columns.Add("Prochaine", typeof(DateTime));
            t.Columns.Add("Tiers", typeof(string));
            t.Columns.Add("Libelle", typeof(string));
            t.Columns.Add("ModePaiement", typeof(string));
            t.Columns.Add("ModePaiementType", typeof(string));
            t.Columns.Add("Montant Débit", typeof(double));
            t.Columns.Add("Montant Crédit", typeof(double));
            t.Columns.Add("Categorie", typeof(string));
            t.Columns.Add("Répétition", typeof(string));
            t.Columns.Add("DateFin", typeof(DateTime));

            //go through each property on T and add each value to the table
            foreach (Echeancier item in list)
            {
                DataRow row = t.NewRow();

                row["Id"] = item.Id;
                row["Compte"] = item.Compte.Libelle;
                row["Prochaine"] = item.Prochaine;
                row["Tiers"] = item.Tiers;
                row["Libelle"] = item.Libelle;
                row["ModePaiement"] = item.ModePaiement.Libelle;
                row["ModePaiementType"] = item.ModePaiement.Type;

                if (item.ModePaiement.Type == KEY.MODEPAIEMENT_CREDIT)
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

                if (item.TypeRepete == Classe.KEY.ECHEANCIER_JOUR)
                {
                    row["Répétition"] = item.Repete + " " + "Jour(s)";
                }

                if (item.TypeRepete == Classe.KEY.ECHEANCIER_MOIS)
                {
                    row["Répétition"] = item.Repete + " " + "Mois";
                }

                if (item.TypeRepete == Classe.KEY.ECHEANCIER_ANNEE)
                {
                    row["Répétition"] = item.Repete + " " + "Année(s)";
                }
                if (item.DateFin == null)
                {
                    row["DateFin"] = DBNull.Value;
                }
                else
                {
                    row["DateFin"] = item.DateFin;
                }

                t.Rows.Add(row);
            }
            return ds;
        }
    }
}
