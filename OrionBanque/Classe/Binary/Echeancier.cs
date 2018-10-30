using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace OrionBanque.Classe.Binary
{
    public class Echeancier
    {
        public static int InsereEcheance(DateTime DateInsereEch, int idCompte)
        {
            Log.Logger.Debug("Debut Echeancier.InsereEcheance(" + idCompte + ")");
            List<Classe.Echeancier> le = ChargeTout(idCompte);
            try
            {
                le = le
                    .Where(w => w.Compte.Id == idCompte)
                    .Where( w1 => w1.DateFin is null || w1.Prochaine <= w1.DateFin)
                    .Where(w2 => w2.Prochaine <= DateInsereEch)
                    .ToList();

                foreach (Classe.Echeancier ec in le)
                {
                    Classe.Operation o = new Classe.Operation
                    {
                        Date = ec.Prochaine,
                        Categorie = ec.Categorie,
                        Compte = ec.Compte,
                        ModePaiement = ec.ModePaiement,
                        Libelle = ec.Libelle,
                        Montant = ec.Montant,
                        Tiers = ec.Tiers
                    };

                    Classe.Operation.Sauve(o);

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

                    Classe.Echeancier.Maj(ec);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            
            return le.Count;
        }

        public static Classe.Echeancier Sauve(Classe.Echeancier e)
        {
            Log.Logger.Debug("Debut Echeancier.Sauve(" + e.Libelle + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                e.Id = ob.Echeanciers.Count != 0 ? ob.Echeanciers.Max(u => u.Id) + 1 : 1;
                ob.Echeanciers.Add(e);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return e;
        }

        public static Classe.Echeancier Maj(Classe.Echeancier eA)
        {
            Log.Logger.Debug("Debut Echeancier.Maj(" + eA.Id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                Classe.Echeancier e = ob.Echeanciers.Find((etemp) => etemp.Id == eA.Id);
                e.ModePaiement = eA.ModePaiement;
                e.Tiers = eA.Tiers;
                e.Libelle = eA.Libelle;
                e.Categorie = eA.Categorie;
                e.Montant = eA.Montant;
                e.Compte = eA.Compte;
                e.Repete= eA.Repete;
                e.DateFin = eA.DateFin;
                e.TypeRepete = eA.TypeRepete;
                e.Prochaine = eA.Prochaine;
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return eA;
        }

        public static DataSet ChargeGrilleEcheance(int idCompte)
        {
            return ToDataSet(ChargeTout(idCompte));
        }

        public static Classe.Echeancier Charge(int id)
        {
            Log.Logger.Debug("Debut Echeancier.Charge(" + id + ")");
            Classe.Echeancier e = new Classe.Echeancier();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                e = ob.Echeanciers.Find(et => et.Id == id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return e;
        }

        public static List<Classe.Echeancier> ChargeTout(int idC)
        {
            Log.Logger.Debug("Debut Echeancier.Charge(" + idC + ")");
            List<Classe.Echeancier> le = new List<Classe.Echeancier>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                le = ob.Echeanciers.Where(et => et.Compte.Id == idC).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return le;
        }

        public static List<Classe.Echeancier> ChargeToutUtilisateur(Classe.Utilisateur u)
        {
            Log.Logger.Debug("Debut Echeancier.ChargeToutUtilisateur(" + u.Login + ")");
            List<Classe.Echeancier> le = new List<Classe.Echeancier>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                le = ob.Echeanciers.Where(et => et.Compte.Utilisateur.Id == u.Id).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return le;
        }

        public static void Delete(Classe.Echeancier ec)
        {
            Echeancier.Delete(ec.Id);
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Echeancier.Delete(" + id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                ob.Echeanciers.RemoveAll((e) => e.Id == id);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static DataSet ToDataSet(List<Classe.Echeancier> list)
        {

            Type elementType = typeof(Classe.Echeancier);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, propInfo.PropertyType);
            }

            //go through each property on T and add each value to the table
            foreach (Classe.Echeancier item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                }

                //This line was missing:
                t.Rows.Add(row);
            }
            return ds;
        }
    }
}
