using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace OrionBanque.Classe.SQLite
{
    class Echeancier
    {
        public static int InsereEcheance(DateTime DateInsereEch, int idCompte)
        {
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
            return lec.Count();
        }

        public static Classe.Echeancier Sauve(Classe.Echeancier e)
        {
            Log.Logger.Debug("Debut Compte.Sauve(" + e.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.ECHEANCIERS_INSERT, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id_mode_paiement", e.ModePaiement.Id);
                Log.Logger.Debug("IdModePaiement=" + e.ModePaiement.Id);
                cmd.Parameters.AddWithValue("@tiers", e.Tiers);
                Log.Logger.Debug("Tiers=" + e.Tiers);
                cmd.Parameters.AddWithValue("@libelle", e.Libelle);
                Log.Logger.Debug("Libelle=" + e.Libelle);
                cmd.Parameters.AddWithValue("@id_categories", e.Categorie.Id);
                Log.Logger.Debug("IdCategorie=" + e.Categorie.Id);
                cmd.Parameters.AddWithValue("@montant", e.Montant);
                Log.Logger.Debug("Montant=" + e.Montant);
                cmd.Parameters.AddWithValue("@id_compte", e.Compte.Id);
                Log.Logger.Debug("IdCompte=" + e.Compte.Id);
                cmd.Parameters.AddWithValue("@repete", e.Repete);
                Log.Logger.Debug("Repete=" + e.Repete);
                cmd.Parameters.AddWithValue("@date_fin", e.DateFin);
                Log.Logger.Debug("DateFin=" + e.DateFin);
                cmd.Parameters.AddWithValue("@type_repete", e.TypeRepete);
                Log.Logger.Debug("TypeRepete=" + e.TypeRepete);
                cmd.Parameters.AddWithValue("@prochaine", e.Prochaine);
                Log.Logger.Debug("Prochaine=" + e.Prochaine);
                cmd.ExecuteNonQuery();
                e.Id = Sql.GetLastInsertId();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Debut Compte.Sauve()");
            return e;
        }

        public static Classe.Echeancier Maj(Classe.Echeancier e)
        {
            Log.Logger.Debug("Debut Compte.Maj(" + e.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.ECHEANCIERS_UPDATE, SQLite.Sql.GetConnection());
                Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_UPDATE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id_mode_paiement", e.ModePaiement.Id);
                Log.Logger.Debug("IdModePaiement=" + e.ModePaiement.Id);
                cmd.Parameters.AddWithValue("@tiers", e.Tiers);
                Log.Logger.Debug("Tiers=" + e.Tiers);
                cmd.Parameters.AddWithValue("@libelle", e.Libelle);
                Log.Logger.Debug("Libelle=" + e.Libelle);
                cmd.Parameters.AddWithValue("@id_categories", e.Categorie.Id);
                Log.Logger.Debug("IdCategorie=" + e.Categorie.Id);
                cmd.Parameters.AddWithValue("@montant", e.Montant);
                Log.Logger.Debug("Montant=" + e.Montant);
                cmd.Parameters.AddWithValue("@id_compte", e.Compte.Id);
                Log.Logger.Debug("IdCompte=" + e.Compte.Id);
                cmd.Parameters.AddWithValue("@id", e.Id);
                Log.Logger.Debug("Id=" + e.Id);
                cmd.Parameters.AddWithValue("@repete", e.Repete);
                Log.Logger.Debug("Repete=" + e.Repete);
                cmd.Parameters.AddWithValue("@date_fin", e.DateFin);
                Log.Logger.Debug("DateFin=" + e.DateFin);
                cmd.Parameters.AddWithValue("@type_repete", e.TypeRepete);
                Log.Logger.Debug("TypeRepete=" + e.TypeRepete);
                cmd.Parameters.AddWithValue("@prochaine", e.Prochaine);
                Log.Logger.Debug("Prochaine=" + e.Prochaine);

                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Debut Compte.Maj(" + e.Id + ")");
            return e;
        }

        public static DataSet ChargeGrilleEcheance(int idCompte)
        {
            Log.Logger.Debug("Debut Compte.ChargeGrilleEcheance(" + idCompte + ")");
            DataSet retour = new DataSet();
            try
            {
                SQLiteDataAdapter dsOpe = new SQLiteDataAdapter(string.Format(Sql.ECHEANCIERS_GRILLE, idCompte), Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.ECHEANCIERS_GRILLE);
                SQLiteCommandBuilder cb = new SQLiteCommandBuilder(dsOpe);

                dsOpe.Fill(retour, "Echeancier");
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Debut Compte.ChargeGrilleEcheance()");
            return retour;
        }

        public static Classe.Echeancier Charge(int id)
        {
            Log.Logger.Debug("Debut Compte.Charge(" + id + ")");
            Classe.Echeancier e = new Classe.Echeancier();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.ECHEANCIERS_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.ECHEANCIERS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Log.Logger.Debug("Id=" + id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    e.Id = rdr.GetInt32(0);
                    e.Prochaine = rdr.GetDateTime(1);
                    e.Categorie = Classe.Categorie.Charge(rdr.GetInt32(5));
                    e.Compte = Classe.Compte.Charge(rdr.GetInt32(7));
                    e.ModePaiement = Classe.ModePaiement.Charge(rdr.GetInt32(2));
                    e.Libelle = rdr.GetString(4);
                    e.Montant = rdr.GetDouble(6);
                    e.Tiers = rdr.GetString(3);
                    e.Repete = rdr.GetInt32(8);
                    e.TypeRepete = rdr.GetString(9);
                    try
                    {
                        e.DateFin = rdr.GetDateTime(10);
                    }
                    catch
                    {
                        e.DateFin = null;
                    }
                }

                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Debut Compte.Charge()");
            return e;
        }

        public static List<Classe.Echeancier> ChargeTout(int idC)
        {
            Log.Logger.Debug("Debut Compte.ChargeTout(" + idC + ")");
            List<Classe.Echeancier> ls = new List<Classe.Echeancier>();
            
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.ECHEANCIERS_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.ECHEANCIERS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", idC);
                Log.Logger.Debug("Id=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(Classe.Echeancier.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.ChargeTout() avec " + ls.Count + " elements");
            return ls;
        }

        public static List<Classe.Echeancier> ChargeToutUtilisateur(Classe.Utilisateur u)
        {
            Log.Logger.Debug("Debut Compte.ChargeToutUtilisateur(" + u.Id + ")");
            List<Classe.Echeancier> ls = new List<Classe.Echeancier>();

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.ECHEANCIERS_UTILISATEUR, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.ECHEANCIERS_UTILISATEUR);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idU", u.Id);
                Log.Logger.Debug("idU=" + u.Id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(Classe.Echeancier.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.ChargeToutUtilisateur() avec " + ls.Count + " elements");
            return ls;
        }

        public static void Delete(Classe.Echeancier ec)
        {
            Log.Logger.Debug("Debut Compte.Delete(" + ec.Id + ")");
            Echeancier.Delete(ec.Id);
            Log.Logger.Debug("Fin Compte.Delete()");
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Compte.Delete(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.ECHEANCIERS_DELETE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.ECHEANCIERS_DELETE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Log.Logger.Debug("Id=" + id);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Delete()");
        }
    }
}
