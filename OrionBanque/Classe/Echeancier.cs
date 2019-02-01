using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;

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
        [DataMember()]
        public bool? DecaleJourFerie { get; set; }

        public static List<string> InsereEcheanceFromGest(DateTime DateInsereEch, Utilisateur u)
        {
            Log.Logger.Debug("Debut Echeancier.InsereEcheance()");
            List<Compte> lc = Compte.ChargeTout(u);
            List<string> retour = new List<string>();
            foreach(Compte c in lc)
            { 
                List<Echeancier> le = ChargeTout(c);
                try
                {
                    le = le
                        .Where(w => w.Compte.Id == c.Id)
                        .Where(w1 => w1.DateFin is null || w1.Prochaine <= w1.DateFin)
                        .Where(w2 => w2.Prochaine <= DateInsereEch)
                        .ToList();

                    retour.AddRange(InsereEcheance(le));
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    throw;
                }
            }
            return retour;
        }

        public static List<string> InsereEcheanceOpenFile(Utilisateur u)
        {
            Log.Logger.Debug("Debut Echeancier.InsereEcheanceOpenFile()");
            List<Compte> lc = Compte.ChargeTout(u);
            List<string> retour = new List<string>();
            foreach (Compte c in lc)
            {
                List<Echeancier> le = ChargeTout(c);
                try
                {
                    le = le
                        .Where(w => w.Compte.Id == c.Id) // Echeance du compte courant
                        .Where(w2 => w2.Prochaine <= DateTime.Today.Date) // Prochaine date échéance du jour ou dépassée
                        .Where(w3 => w3.DateFin is null || w3.DateFin >= DateTime.Today.Date) // Date de fin de l'échéance est dépassée 
                        .ToList();

                    retour.AddRange(InsereEcheance(le));
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    throw;
                }
            }
            return retour;
        }

        public static List<string> InsereEcheance(List<Echeancier> le)
        {
            IEnumerable<SpecificDay> specificDays = HolidaySystem.Instance.All(DateTime.Now.Year, "FR", RuleType.Public);
            
            List<string> retour = new List<string>();
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
                    // Décalage si Samedi
                    o.Date.AddDays(2);
                }
                if (o.Date.DayOfWeek == DayOfWeek.Sunday && (ec.DecaleDimanche ?? false))
                {
                    // Décalage si Dimanche
                    o.Date.AddDays(1);
                }
                if (ec.DecaleJourFerie ?? false)
                {
                    foreach (SpecificDay day in specificDays)
                    {
                        if (day.Date.Date == o.Date.Date)
                        {
                            // Décalage si Jour Férié
                            o.Date.AddDays(1);
                            break;
                        }
                    }
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
                retour.Add("\t -> [" + o.Compte.Libelle + "] - " + o.Date.Day + "/" + o.Date.Month + "/" + o.Date.Year + " - " + o.Libelle);
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

        public static List<Echeancier> ChargeTout(Compte cA)
        {
            Log.Logger.Debug("Debut Echeancier.Charge(" + cA.Id + ")");
            List<Echeancier> le = new List<Echeancier>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                le = ob.Echeanciers.Where(et => et.Compte.Id == cA.Id).ToList();
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

        public static void Delete(Echeancier eA)
        {
            Log.Logger.Debug("Debut Echeancier.Delete(" + eA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Echeanciers.RemoveAll((e) => e.Id == eA.Id);
                CallContext.SetData(KEY.OB, ob);
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

            list = list.OrderBy(e => e.Prochaine).ToList();

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
