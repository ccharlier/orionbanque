using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    public class ModePaiement
    {
        static public List<Classe.ModePaiement> ChargeTout()
        {
            Classe.Log.Logger.Debug("Debut Compte.ChargeTout()");
            List<Classe.ModePaiement> lmp = new List<Classe.ModePaiement>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.MODEPAIMENTS_ALL, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.MODEPAIMENTS_ALL);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Classe.ModePaiement mp = new Classe.ModePaiement
                    {
                        Id = rdr.GetInt32(0),
                        Libelle = rdr.GetString(1),
                        Type = rdr.GetString(2)
                    };

                    lmp.Add(mp);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Compte.ChargeTout() avec " + lmp.Count + " element");
            return lmp;
        }

        static public Classe.ModePaiement Charge(Int32 id)
        {
            Classe.Log.Logger.Debug("Debut Compte.Charge(" + id + ")");
            Classe.ModePaiement mp = new Classe.ModePaiement();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.MODEPAIMENTS_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.MODEPAIMENTS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("id=" + id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    mp.Id = rdr.GetInt32(0);
                    mp.Libelle = rdr.GetString(1);
                    mp.Type = rdr.GetString(2);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Compte.Charge() : Id :"  + mp.Id + ", Libelle :" + mp.Libelle + ", Type :" + mp.Type);
            return mp;
        }

        static public Classe.ModePaiement ChargeParNom(string nom)
        {
            Log.Logger.Debug("Debut Compte.ChargeParNom(" + nom + ")");
            Classe.ModePaiement mp = new Classe.ModePaiement();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.MODEPAIMENTS_NOM, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.MODEPAIMENTS_NOM);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", nom);
                Log.Logger.Debug("libelle=" + nom);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    mp.Id = rdr.GetInt32(0);
                    mp.Libelle = rdr.GetString(1);
                    mp.Type = rdr.GetString(2);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Charge() : Id :" + mp.Id + ", Libelle :" + mp.Libelle + ", Type :" + mp.Type);
            return mp;
        }

        static public void DeletePossible(Int32 id)
        {
            Classe.Log.Logger.Debug("Debut Compte.DeletePossible(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.MODEPAIMENTS_DELETE_POSSIBLE, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.MODEPAIMENTS_DELETE_POSSIBLE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id_mode_paiement", id);
                Classe.Log.Logger.Debug("id_mode_paiement=" + id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    throw new Exception("Vous devez d'abord modifier vos Opérations pour qu'elles ne pointent plus sur ce Mode de Paiement.");
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            catch (Exception ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw;
            }
            Classe.Log.Logger.Debug("Fin Compte.DeletePossible()");
        }

        static public void Delete(int id)
        {
            Classe.Log.Logger.Debug("Debut Compte.Delete(" + id + ")");
            try
            {
                ModePaiement.DeletePossible(id);
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.MODEPAIMENTS_DELETE_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.MODEPAIMENTS_DELETE_ID);
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
            catch (Exception ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw;
            }
            Classe.Log.Logger.Debug("Fin Compte.Delete()");
        }

        static public void Maj(Classe.ModePaiement mp)
        {
            Classe.Log.Logger.Debug("Debut Compte.Maj(" + mp.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.MODEPAIMENTS_UPDATE_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.MODEPAIMENTS_UPDATE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", mp.Libelle);
                Classe.Log.Logger.Debug("libelle=" + mp.Libelle);
                cmd.Parameters.AddWithValue("@type", mp.Type);
                Classe.Log.Logger.Debug("type=" + mp.Type);
                cmd.Parameters.AddWithValue("@id", mp.Id);
                Classe.Log.Logger.Debug("id=" + mp.Id);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Compte.Maj()");
        }

        static public void Sauve(Classe.ModePaiement mp)
        {
            Classe.Log.Logger.Debug("Debut Compte.Sauve(" + mp.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.MODEPAIMENTS_INSERT, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.MODEPAIMENTS_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", mp.Libelle);
                Classe.Log.Logger.Debug("libelle=" + mp.Libelle);
                cmd.Parameters.AddWithValue("@type", mp.Type);
                Classe.Log.Logger.Debug("type=" + mp.Type);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Compte.Sauve()");
        }
    }
}
