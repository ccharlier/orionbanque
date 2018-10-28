using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    public class ModePaiement
    {
        public static List<Classe.ModePaiement> ChargeTout()
        {
            Log.Logger.Debug("Debut Compte.ChargeTout()");
            List<Classe.ModePaiement> lmp = new List<Classe.ModePaiement>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.MODEPAIMENTS_ALL, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.MODEPAIMENTS_ALL);
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
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.ChargeTout() avec " + lmp.Count + " element");
            return lmp;
        }

        public static Classe.ModePaiement Charge(int id)
        {
            Log.Logger.Debug("Debut Compte.Charge(" + id + ")");
            Classe.ModePaiement mp = new Classe.ModePaiement();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.MODEPAIMENTS_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.MODEPAIMENTS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Log.Logger.Debug("id=" + id);
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
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Charge() : Id :"  + mp.Id + ", Libelle :" + mp.Libelle + ", Type :" + mp.Type);
            return mp;
        }

        public static Classe.ModePaiement ChargeParNom(string nom)
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
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Charge() : Id :" + mp.Id + ", Libelle :" + mp.Libelle + ", Type :" + mp.Type);
            return mp;
        }

        public static void DeletePossible(int id)
        {
            Log.Logger.Debug("Debut Compte.DeletePossible(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.MODEPAIMENTS_DELETE_POSSIBLE, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.MODEPAIMENTS_DELETE_POSSIBLE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id_mode_paiement", id);
                Log.Logger.Debug("id_mode_paiement=" + id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    throw new Exception("Vous devez d'abord modifier vos Opérations pour qu'elles ne pointent plus sur ce Mode de Paiement.");
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Compte.DeletePossible()");
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Compte.Delete(" + id + ")");
            try
            {
                ModePaiement.DeletePossible(id);
                SQLiteCommand cmd = new SQLiteCommand(Sql.MODEPAIMENTS_DELETE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.MODEPAIMENTS_DELETE_ID);
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
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Compte.Delete()");
        }

        public static Classe.ModePaiement Maj(Classe.ModePaiement mp)
        {
            Log.Logger.Debug("Debut Compte.Maj(" + mp.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.MODEPAIMENTS_UPDATE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.MODEPAIMENTS_UPDATE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", mp.Libelle);
                Log.Logger.Debug("libelle=" + mp.Libelle);
                cmd.Parameters.AddWithValue("@type", mp.Type);
                Log.Logger.Debug("type=" + mp.Type);
                cmd.Parameters.AddWithValue("@id", mp.Id);
                Log.Logger.Debug("id=" + mp.Id);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Maj()");
            return mp;
        }

        public static Classe.ModePaiement Sauve(Classe.ModePaiement mp)
        {
            Log.Logger.Debug("Debut Compte.Sauve(" + mp.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.MODEPAIMENTS_INSERT, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.MODEPAIMENTS_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", mp.Libelle);
                Log.Logger.Debug("libelle=" + mp.Libelle);
                cmd.Parameters.AddWithValue("@type", mp.Type);
                Log.Logger.Debug("type=" + mp.Type);
                cmd.ExecuteNonQuery();
                mp.Id = Sql.GetLastInsertId();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Compte.Sauve()");
            return mp;
        }
    }
}
