using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    public class Utilisateur
    {
        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Utilisateur.Delete(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.UTILISATEURS_DELETE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.UTILISATEURS_DELETE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Log.Logger.Debug("id=" + id);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
        }

        public static Classe.Utilisateur Charge(int id)
        {
            Log.Logger.Debug("Debut Utilisateur.Charge(" + id + ")");
            Classe.Utilisateur u = new Classe.Utilisateur();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.UTILISATEURS_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.UTILISATEURS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Log.Logger.Debug("id=" + id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    u.Id = rdr.GetInt32(0);
                    u.Login = rdr.GetString(1);
                    u.Mdp = rdr.GetString(2);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return u;
        }

        public static Classe.Utilisateur Charge(string login)
        {
            Log.Logger.Debug("Debut Utilisateur.Charge(" + login + ")");
            Classe.Utilisateur u = new Classe.Utilisateur();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.UTILISATEURS_LOGIN, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.UTILISATEURS_LOGIN);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@login", login);
                Log.Logger.Debug("login=" + login);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    u.Id = rdr.GetInt32(0);
                    u.Login = rdr.GetString(1);
                    u.Mdp = rdr.GetString(2);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return u;
        }

        public static Classe.Utilisateur Maj(Classe.Utilisateur u)
        {
            Log.Logger.Debug("Debut Utilisateur.Maj(" + u.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.UTILISATEURS_UPDATE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_UPDATE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", u.Id);
                Log.Logger.Debug("id=" + u.Id);
                cmd.Parameters.AddWithValue("@login", u.Login);
                Log.Logger.Debug("login=" + u.Login);
                cmd.Parameters.AddWithValue("@mdp", u.Mdp);
                Log.Logger.Debug("mdp=" + u.Mdp);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return u;
        }

        public static Classe.Utilisateur Sauve(Classe.Utilisateur u)
        {
            Log.Logger.Debug("Debut Utilisateur.Sauve(" + u.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.UTILISATEURS_INSERT, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.UTILISATEURS_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@login", u.Login);
                Log.Logger.Debug("login=" + u.Login);
                cmd.Parameters.AddWithValue("@mdp", u.Mdp);
                Log.Logger.Debug("mdp=" + u.Mdp);
                cmd.ExecuteNonQuery();
                u.Id = Sql.GetLastInsertId();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return u;
        }

        public static List<Classe.Utilisateur> ChargeTout()
        {
            Log.Logger.Debug("Debut Utilisateur.ChargeTous()");
            List<Classe.Utilisateur> lu = new List<Classe.Utilisateur>();
            Classe.Utilisateur u = new Classe.Utilisateur();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.UTILISATEURS_ALL, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.UTILISATEURS_ALL);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Log.Logger.Info("Chargement de l'Utilisateur Id=" + rdr.GetInt32(0));
                    u = new Classe.Utilisateur
                    {
                        Id = rdr.GetInt32(0),
                        Login = rdr.GetString(1),
                        Mdp = rdr.GetString(2)
                    };
                    lu.Add(u);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return lu;
        }
    }
}
