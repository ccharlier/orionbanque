using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    /// <summary>
    /// Classe permettant de gerer les parametres
    /// </summary>
    class Param
    {
        /// <summary>
        /// Chargement de tous les parametres
        /// </summary>
        /// <returns>Lsite de Param</returns>
        public static List<Classe.Param> ChargeTout()
        {
            Log.Logger.Debug("Debut Param.ChargeTout()");
            List<Classe.Param> lp = new List<Classe.Param>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.PARAM_ALL, Sql.GetConnection());
                Log.Logger.Debug("Execution requete : " + Sql.PARAM_ALL);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Classe.Param p = new Classe.Param();
                    p.Id = rdr.GetInt32(0);
                    p.Ident = rdr.GetString(1);
                    p.Val1 = rdr.GetString(2);
                    p.Val2 = rdr.GetString(3);
                    p.Val3 = rdr.GetString(4);
                    p.Int1 = rdr.GetInt32(5);
                    p.Int2 = rdr.GetInt32(6);
                    p.Int3 = rdr.GetInt32(7);
                    p.Dec1 = rdr.GetDouble(8);
                    p.Dec2 = rdr.GetDouble(9);
                    p.Dec3 = rdr.GetDouble(10);
                    p.Dat1 = rdr.GetDateTime(11);
                    p.Dat2 = rdr.GetDateTime(12);
                    p.Dat3 = rdr.GetDateTime(13);
                    lp.Add(p);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Param.ChargeTout()");
            return lp;
        }

        /// <summary>
        /// Chargement d'un parametre
        /// </summary>
        /// <param name="id">Id du parametre</param>
        /// <returns>Parametre charge</returns>
        public static Classe.Param Charge(int id)
        {
            Log.Logger.Debug("Debut Param.Charge(" + id + ")");
            Classe.Param p = new Classe.Param();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.PARAM_ID, Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Log.Logger.Debug("Execution requete : " + Sql.PARAM_ID);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if(rdr.Read())
                {
                    p.Id = rdr.GetInt32(0);
                    p.Ident = rdr.GetString(1);
                    p.Val1 = rdr.GetString(2);
                    p.Val2 = rdr.GetString(3);
                    p.Val3 = rdr.GetString(4);
                    p.Int1 = rdr.GetInt32(5);
                    p.Int2 = rdr.GetInt32(6);
                    p.Int3 = rdr.GetInt32(7);
                    p.Dec1 = rdr.GetDouble(8);
                    p.Dec2 = rdr.GetDouble(9);
                    p.Dec3 = rdr.GetDouble(10);
                    p.Dat1 = rdr.GetDateTime(11);
                    p.Dat2 = rdr.GetDateTime(12);
                    p.Dat3 = rdr.GetDateTime(13);
                }
                rdr.Close();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Param.Charge()");
            return p;
        }

        /// <summary>
        /// Chargement d'une liste de parametre
        /// </summary>
        /// <param name="ident">Identifiant de la liste de parametre a charger</param>
        /// <returns>Liste de Parametre</returns>
        public static List<Classe.Param> Charge(string ident)
        {
            Log.Logger.Debug("Debut Param.Charge(" + ident + ")");
            List<Classe.Param> lp = new List<Classe.Param>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.PARAM_IDENT, Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ident", ident);
                Log.Logger.Debug("Execution requete : " + Sql.PARAM_IDENT);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Classe.Param p = new Classe.Param
                    {
                        Id = rdr.GetInt32(0),
                        Ident = rdr.GetString(1),
                        Val1 = rdr.GetString(2),
                        Val2 = rdr.GetString(3),
                        Val3 = rdr.GetString(4),
                        Int1 = rdr.GetInt32(5),
                        Int2 = rdr.GetInt32(6),
                        Int3 = rdr.GetInt32(7),
                        Dec1 = rdr.GetDouble(8),
                        Dec2 = rdr.GetDouble(9),
                        Dec3 = rdr.GetDouble(10),
                        Dat1 = rdr.GetDateTime(11),
                        Dat2 = rdr.GetDateTime(12),
                        Dat3 = rdr.GetDateTime(13)
                    };
                    lp.Add(p);
                }
                rdr.Close();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Param.Charge() avec " + lp.Count() + " elements");
            return lp;
        }

        /// <summary>
        /// Pouvoir supprimer un parametre celon son id
        /// </summary>
        /// <param name="id">Id du parametre a supprimer</param>
        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Param.Delete(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.PARAM_DELETE_ID, Sql.GetConnection());
                
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();

                Log.Logger.Debug("Execution requete : " + Sql.PARAM_DELETE_ID);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            catch(Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Param.Delete()");
        }

        /// <summary>
        /// Pouvoir supprimer un ou plusieurs parametre celon l'identifiant
        /// </summary>
        /// <param name="ident">Identifiant du ou des parametre a supprimer</param>
        public static void Delete(string ident)
        {
            Log.Logger.Debug("Debut Param.Delete(" + ident + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.PARAM_DELETE_IDENT, Sql.GetConnection());

                cmd.Parameters.AddWithValue("@ident", ident);
                cmd.Prepare();

                Log.Logger.Debug("Execution requete : " + Sql.PARAM_DELETE_IDENT);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            catch(Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Param.Delete()");
        }
        
        /// <summary>
        /// Permet de mettre a jour un parametre
        /// </summary>
        /// <param name="p">Parametre a mettre a jour</param>
        public static Classe.Param Maj(Classe.Param p)
        {
            Log.Logger.Debug("Debut Param.Maj()");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.PARAM_UPDATE_ID, Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ident", p.Ident);
                cmd.Parameters.AddWithValue("@val1", p.Val1); cmd.Parameters.AddWithValue("@val2", p.Val2); cmd.Parameters.AddWithValue("@val3", p.Val3);
                cmd.Parameters.AddWithValue("@int1", p.Int1); cmd.Parameters.AddWithValue("@int2", p.Int2); cmd.Parameters.AddWithValue("@int3", p.Int3);
                cmd.Parameters.AddWithValue("@dec1", p.Dec1); cmd.Parameters.AddWithValue("@dec2", p.Dec2); cmd.Parameters.AddWithValue("@dec3", p.Dec3);
                cmd.Parameters.AddWithValue("@dat1", p.Dat1); cmd.Parameters.AddWithValue("@dat2", p.Dat2); cmd.Parameters.AddWithValue("@dat3", p.Dat3);
                cmd.Parameters.AddWithValue("@id", p.Id);
                Log.Logger.Debug("Execution requete : " + Sql.PARAM_UPDATE_ID);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Param.Maj()");
            return p;
        }
 
        /// <summary>
        /// Permet de creer un parametre
        /// </summary>
        /// <param name="p">Parametre a creer</param>
        public static Classe.Param Sauve(Classe.Param p)
        {
            Log.Logger.Debug("Debut Param.Sauve()");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.PARAM_INSERT, Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ident", p.Ident);
                cmd.Parameters.AddWithValue("@val1", p.Val1); cmd.Parameters.AddWithValue("@val2", p.Val2); cmd.Parameters.AddWithValue("@val3", p.Val3);
                cmd.Parameters.AddWithValue("@int1", p.Int1); cmd.Parameters.AddWithValue("@int2", p.Int2); cmd.Parameters.AddWithValue("@int3", p.Int3);
                cmd.Parameters.AddWithValue("@dec1", p.Dec1); cmd.Parameters.AddWithValue("@dec2", p.Dec2); cmd.Parameters.AddWithValue("@dec3", p.Dec3);
                cmd.Parameters.AddWithValue("@dat1", p.Dat1); cmd.Parameters.AddWithValue("@dat2", p.Dat2); cmd.Parameters.AddWithValue("@dat3", p.Dat3);
                Log.Logger.Debug("Execution requete : " + Sql.PARAM_INSERT);
                cmd.ExecuteNonQuery();
                p.Id = Sql.GetLastInsertId();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Param.Sauve()");
            return p;
        }
    }
}
