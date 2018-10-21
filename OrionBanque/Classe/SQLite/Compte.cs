using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    public class Compte
    {
        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Compte.Delete(" + id + ")");
            try
            {
                // Suppression des opérations associées aux comptes
                List<Classe.Operation> lo = Classe.Operation.ChargeTout(id);
                foreach (Classe.Operation o in lo)
                {
                    Classe.Operation.Delete(o.Id);
                }

                // Suppression des échénces associées aux comptes
                List<Classe.Echeancier> le = Classe.Echeancier.ChargeTout(id);
                foreach (Classe.Echeancier e in le)
                {
                    Classe.Echeancier.Delete(e.Id);
                }
                SQLiteCommand cmd = new SQLiteCommand(Sql.COMPTES_DELETE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.COMPTES_DELETE_ID);
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

        public static void Delete(Classe.Compte c)
        {
            Log.Logger.Debug("Debut Compte.Delete(Compte : id=" + c.Id + ")");
            Compte.Delete(c.Id);
            Log.Logger.Debug("Fin Compte.Delete()");
        }

        public static Classe.Compte Charge(int id)
        {
            Log.Logger.Debug("Debut Compte.Charge(" + id + ")");
            Classe.Compte c = new Classe.Compte();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.COMPTES_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.COMPTES_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Log.Logger.Debug("Id=" + id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    c.Id = rdr.GetInt32(0);
                    c.Libelle = rdr.GetString(1);
                    c.SoldeInitial = rdr.GetDouble(2);
                    c.IdUtilisateur = rdr.GetInt32(3);
                    c.Banque = rdr.GetString(4);
                    c.Guichet = rdr.GetString(5);
                    c.NoCompte = rdr.GetString(6);
                    c.Clef = rdr.GetString(7);
                    c.MinGraphSold = rdr.GetDateTime(8);
                    c.MaxGraphSold = rdr.GetDateTime(9);
                    c.SeuilAlerte = rdr.GetDouble(10);
                    c.TypEvol = rdr.GetString(11);
                    c.SeuilAlerteFinal = rdr.GetDouble(12);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Charge()");
            return c;
        }

        public static List<Classe.Compte> ChargeTout(int idU)
        {
            Log.Logger.Debug("Debut Compte.ChargeTout(" + idU + ")");
            List <Classe.Compte> lc = new List<Classe.Compte>();
            try
            {
                Classe.Compte c = new Classe.Compte();
                SQLiteCommand cmd = new SQLiteCommand(Sql.COMPTES_ALL, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.COMPTES_ALL);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idU", idU);
                Log.Logger.Debug("IdUtilisateur=" + idU);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    c.Id = rdr.GetInt32(0);
                    c.Libelle = rdr.GetString(1);
                    c.SoldeInitial = rdr.GetDouble(2);
                    c.IdUtilisateur = rdr.GetInt32(3);
                    c.Banque = rdr.GetString(4);
                    c.Guichet = rdr.GetString(5);
                    c.NoCompte = rdr.GetString(6);
                    c.Clef = rdr.GetString(7);
                    c.MinGraphSold = rdr.GetDateTime(8);
                    c.MaxGraphSold = rdr.GetDateTime(9);
                    c.SeuilAlerte = rdr.GetDouble(10);
                    c.TypEvol = rdr.GetString(11);
                    c.SeuilAlerteFinal = rdr.GetDouble(12);
                    lc.Add(c);
                    c = new OrionBanque.Classe.Compte();
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.ChargeTout() avec " + lc.Count + " elements");
            return lc;
        }

        public static Classe.Compte Maj(Classe.Compte c)
        {
            Log.Logger.Debug("Debut Compte.Maj(Compte : id=" + c.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.COMPTES_UPDATE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.COMPTES_UPDATE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", c.Id);
                Log.Logger.Debug("Id=" + c.Id);
                cmd.Parameters.AddWithValue("@libelle", c.Libelle);
                Log.Logger.Debug("Libelle=" + c.Libelle);
                cmd.Parameters.AddWithValue("@SoldeInitial", c.SoldeInitial);
                Log.Logger.Debug("SoldeInitial=" + c.SoldeInitial);
                cmd.Parameters.AddWithValue("@id_utilisateur", c.IdUtilisateur);
                Log.Logger.Debug("IdUtilisateur=" + c.IdUtilisateur);
                cmd.Parameters.AddWithValue("@banque", c.Banque);
                Log.Logger.Debug("Banque=" + c.Banque);
                cmd.Parameters.AddWithValue("@compte", c.NoCompte);
                Log.Logger.Debug("NoCompte=" + c.NoCompte);
                cmd.Parameters.AddWithValue("@clef", c.Clef);
                Log.Logger.Debug("Clef=" + c.Clef);
                cmd.Parameters.AddWithValue("@mingraphsold", c.MinGraphSold);
                Log.Logger.Debug("MinGraphSold=" + c.MinGraphSold);
                cmd.Parameters.AddWithValue("@maxgraphsold", c.MaxGraphSold);
                Log.Logger.Debug("MaxGraphSold=" + c.MaxGraphSold);
                cmd.Parameters.AddWithValue("@soldeseuil", c.SeuilAlerte);
                Log.Logger.Debug("SeuilAlerte=" + c.SeuilAlerte);
                cmd.Parameters.AddWithValue("@soldeseuilfinal", c.SeuilAlerteFinal);
                Log.Logger.Debug("SeuilAlerteFinal=" + c.SeuilAlerteFinal);
                cmd.Parameters.AddWithValue("@typevol", c.TypEvol);
                Log.Logger.Debug("TypEvol=" + c.TypEvol);
                cmd.Parameters.AddWithValue("@guichet", c.Guichet);
                Log.Logger.Debug("Guichet=" + c.Guichet);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Maj()");
            return c;
        }

        static public Classe.Compte Sauve(Classe.Compte c)
        {
            Log.Logger.Debug("Debut Compte.Sauve(Compte : id=" + c.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.COMPTES_INSERT, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.COMPTES_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", c.Libelle);
                Log.Logger.Debug("Libelle=" + c.Libelle);
                cmd.Parameters.AddWithValue("@solde_initial", c.SoldeInitial);
                Log.Logger.Debug("SoldeInitial=" + c.SoldeInitial);
                cmd.Parameters.AddWithValue("@id_utilisateur", c.IdUtilisateur);
                Log.Logger.Debug("IdUtilisateur=" + c.IdUtilisateur);
                cmd.Parameters.AddWithValue("@banque", c.Banque);
                Log.Logger.Debug("Banque=" + c.Banque);
                cmd.Parameters.AddWithValue("@guichet", c.Guichet);
                Log.Logger.Debug("Guichet=" + c.Guichet);
                cmd.Parameters.AddWithValue("@compte", c.NoCompte);
                Log.Logger.Debug("NoCompte=" + c.NoCompte);
                cmd.Parameters.AddWithValue("@clef", c.Clef);
                Log.Logger.Debug("Clef=" + c.Clef);
                cmd.Parameters.AddWithValue("@mingraphsold", c.MinGraphSold);
                Log.Logger.Debug("MinGraphSold=" + c.MinGraphSold);
                cmd.Parameters.AddWithValue("@maxgraphsold", c.MaxGraphSold);
                Log.Logger.Debug("MaxGraphSold=" + c.MaxGraphSold);
                cmd.Parameters.AddWithValue("@soldeseuil", c.SeuilAlerte);
                Log.Logger.Debug("SeuilAlerte=" + c.SeuilAlerte);
                cmd.Parameters.AddWithValue("@typevol", c.TypEvol);
                Log.Logger.Debug("TypEvol=" + c.TypEvol);
                cmd.Parameters.AddWithValue("@soldeseuilfinal", c.SeuilAlerteFinal);
                Log.Logger.Debug("SeuilAlerteFinal=" + c.SeuilAlerteFinal);
                cmd.ExecuteNonQuery();
                c.Id = Sql.GetLastInsertId();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Sauve()");
            return c;
        }
    }
}
