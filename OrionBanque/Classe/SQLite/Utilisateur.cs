using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    public class Utilisateur
    {
        static public void Delete(int id)
        {
            Classe.Log.Logger.Debug("Debut Utilisateur.Delete(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Classe.SQLite.Sql.UTILISATEURS_DELETE_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.UTILISATEURS_DELETE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("id=" + id);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
        }

        static public void Delete(Classe.Utilisateur u)
        {
            Utilisateur.Delete(u.Id);
        }

        static public Classe.Utilisateur Charge(int id)
        {
            Classe.Log.Logger.Debug("Debut Utilisateur.Charge(" + id + ")");
            Classe.Utilisateur u = new Classe.Utilisateur();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Classe.SQLite.Sql.UTILISATEURS_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.UTILISATEURS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("id=" + id);
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
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return u;
        }

        static public Classe.Utilisateur Charge(string login)
        {
            Classe.Log.Logger.Debug("Debut Utilisateur.Charge(" + login + ")");
            Classe.Utilisateur u = new Classe.Utilisateur();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.UTILISATEURS_LOGIN, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.UTILISATEURS_LOGIN);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@login", login);
                Classe.Log.Logger.Debug("login=" + login);
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
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return u;
        }

        static public void Maj(Classe.Utilisateur u)
        {
            Classe.Log.Logger.Debug("Debut Utilisateur.Maj(" + u.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.UTILISATEURS_UPDATE_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_UPDATE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", u.Id);
                Classe.Log.Logger.Debug("id=" + u.Id);
                cmd.Parameters.AddWithValue("@login", u.Login);
                Classe.Log.Logger.Debug("login=" + u.Login);
                cmd.Parameters.AddWithValue("@mdp", u.Mdp);
                Classe.Log.Logger.Debug("mdp=" + u.Mdp);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
        }

        static public void Sauve(Classe.Utilisateur u)
        {
            Classe.Log.Logger.Debug("Debut Utilisateur.Sauve(" + u.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.UTILISATEURS_INSERT, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.UTILISATEURS_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@login", u.Login);
                Classe.Log.Logger.Debug("login=" + u.Login);
                cmd.Parameters.AddWithValue("@mdp", u.Mdp);
                Classe.Log.Logger.Debug("mdp=" + u.Mdp);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
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
