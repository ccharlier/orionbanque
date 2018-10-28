using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace OrionBanque.Classe.Binary
{
    public class Echeancier
    {
        public static int InsereEcheance(DateTime DateInsereEch, int idCompte)
        {
            return 0;
            /*Log.Logger.Debug("Debut Echeancier.InsereEcheance(" + idCompte + ")");
            try
            {
                List<Classe.Echeancier> le = ChargeTout(idCompte);

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Echeancier.ChargeTout(id)");
            return le;


            Log.Logger.Debug("Debut Compte.Delete(" + DateInsereEch + ", " + idCompte + ")");
            List<Classe.Echeancier> lec = new List<Classe.Echeancier>();
           
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.ECHEANCIERS_APPLIQUE, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.ECHEANCIERS_APPLIQUE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idCompte);
                Log.Logger.Debug("idCompte=" + idCompte);
                cmd.Parameters.AddWithValue("@date", DateInsereEch);
                Log.Logger.Debug("DateInsereEch=" + DateInsereEch);
                
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lec.Add(Classe.Echeancier.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
                
                foreach (Classe.Echeancier ec in lec)
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

                    if (ec.TypeRepete == KEY.ECHEANCIER_JOUR)
                    {
                        ec.Prochaine = ec.Prochaine.AddDays(ec.Repete);
                    }

                    if (ec.TypeRepete == KEY.ECHEANCIER_MOIS)
                    {
                        ec.Prochaine = ec.Prochaine.AddMonths(ec.Repete);
                    }

                    if (ec.TypeRepete == KEY.ECHEANCIER_ANNEE)
                    {
                        ec.Prochaine = ec.Prochaine.AddYears(ec.Repete);
                    }

                    Classe.Echeancier.Maj(ec);
                }

                
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Debut Compte.Delete() avec " + lec.Count + " elements");
            return lec.Count();*/
        }

        public static Classe.Echeancier Sauve(Classe.Echeancier e)
        {
            Log.Logger.Debug("Debut Echeancier.Sauve(" + e.Libelle + ")");
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                e.Id = ob.Echeanciers.Count != 0 ? ob.Echeanciers.Max(u => u.Id) + 1 : 1;
                ob.Echeanciers.Add(e);
                Outils.GestionFichier.Sauvegarde(Classe.KEY.BINARY_PATH_COMPLETE, ob);
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
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
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
                Outils.GestionFichier.Sauvegarde(Classe.KEY.BINARY_PATH_COMPLETE, ob);
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
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                e = ob.Echeanciers.Find(et => et.Id == id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Echeancier.Charge(id)");
            return e;
        }

        public static List<Classe.Echeancier> ChargeTout(int idC)
        {
            Log.Logger.Debug("Debut Echeancier.Charge(" + idC + ")");
            List<Classe.Echeancier> le = new List<Classe.Echeancier>();
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                le = ob.Echeanciers.Where(et => et.Compte.Id == idC).ToList();

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Echeancier.ChargeTout(id)");
            return le;
        }

        public static List<Classe.Echeancier> ChargeToutUtilisateur(Classe.Utilisateur u)
        {
            Log.Logger.Debug("Debut Echeancier.ChargeToutUtilisateur(" + u.Login + ")");
            List<Classe.Echeancier> le = new List<Classe.Echeancier>();
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                le = ob.Echeanciers.Where(et => et.Compte.Utilisateur.Id == u.Id).ToList();

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Echeancier.ChargeToutUtilisateur()");
            return le;
        }

        public static void Delete(Classe.Echeancier ec)
        {
            Log.Logger.Debug("Debut Compte.Delete(" + ec.Id + ")");
            Echeancier.Delete(ec.Id);
            Log.Logger.Debug("Fin Compte.Delete()");
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Echeancier.Delete(" + id + ")");
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                ob.Echeanciers.RemoveAll((e) => e.Id == id);
                Outils.GestionFichier.Sauvegarde(Classe.KEY.BINARY_PATH_COMPLETE, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Echencier.Delete(id)");
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
