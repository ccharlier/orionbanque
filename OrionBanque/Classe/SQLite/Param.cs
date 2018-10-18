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
        /// Chargement d'un parametre
        /// </summary>
        /// <param name="id">Id du parametre</param>
        /// <returns>Parametre charge</returns>
        static public Classe.Param Charge(Int32 id)
        {
            Classe.Log.Logger.Debug("Debut Param.Charge(" + id + ")");
            Classe.Param p = new Classe.Param();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Classe.SQLite.Sql.PARAM_ID, SQLite.Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.PARAM_ID);
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
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Param.Charge()");
            return p;
        }

        /// <summary>
        /// Chargement d'une liste de parametre
        /// </summary>
        /// <param name="ident">Identifiant de la liste de parametre a charger</param>
        /// <returns>Liste de Parametre</returns>
        static public List<Classe.Param> Charge(String ident)
        {
            Classe.Log.Logger.Debug("Debut Param.Charge(" + ident + ")");
            List<Classe.Param> lp = new List<Classe.Param>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Classe.SQLite.Sql.PARAM_IDENT, SQLite.Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ident", ident);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.PARAM_IDENT);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Classe.Param p = new OrionBanque.Classe.Param
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
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Param.Charge() avec " + lp.Count() + " elements");
            return lp;
        }

        /// <summary>
        /// Pouvoir supprimer un parametre celon son id
        /// </summary>
        /// <param name="id">Id du parametre a supprimer</param>
        static public void Delete(int id)
        {
            Classe.Log.Logger.Debug("Debut Param.Delete(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.PARAM_DELETE_ID, SQLite.Sql.GetConnection());
                
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();

                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.PARAM_DELETE_ID);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            catch(Exception ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw;
            }
            Classe.Log.Logger.Debug("Fin Param.Delete()");
        }

        /// <summary>
        /// Pouvoir supprimer un ou plusieurs parametre celon l'identifiant
        /// </summary>
        /// <param name="ident">Identifiant du ou des parametre a supprimer</param>
        static public void Delete(String ident)
        {
            Classe.Log.Logger.Debug("Debut Param.Delete(" + ident + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.PARAM_DELETE_IDENT, SQLite.Sql.GetConnection());

                cmd.Parameters.AddWithValue("@ident", ident);
                cmd.Prepare();

                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.PARAM_DELETE_IDENT);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            catch(Exception ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw;
            }
            Classe.Log.Logger.Debug("Fin Param.Delete()");
        }
        
        /// <summary>
        /// Permet de mettre a jour un parametre
        /// </summary>
        /// <param name="p">Parametre a mettre a jour</param>
        static public void Maj(Classe.Param p)
        {
            Classe.Log.Logger.Debug("Debut Param.Maj()");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.PARAM_UPDATE_ID, SQLite.Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ident", p.Ident);
                cmd.Parameters.AddWithValue("@val1", p.Val1); cmd.Parameters.AddWithValue("@val2", p.Val2); cmd.Parameters.AddWithValue("@val3", p.Val3);
                cmd.Parameters.AddWithValue("@int1", p.Int1); cmd.Parameters.AddWithValue("@int2", p.Int2); cmd.Parameters.AddWithValue("@int3", p.Int3);
                cmd.Parameters.AddWithValue("@dec1", p.Dec1); cmd.Parameters.AddWithValue("@dec2", p.Dec2); cmd.Parameters.AddWithValue("@dec3", p.Dec3);
                cmd.Parameters.AddWithValue("@dat1", p.Dat1); cmd.Parameters.AddWithValue("@dat2", p.Dat2); cmd.Parameters.AddWithValue("@dat3", p.Dat3);
                cmd.Parameters.AddWithValue("@id", p.Id);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.PARAM_UPDATE_ID);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Param.Maj()");
        }
 
        /// <summary>
        /// Permet de creer un parametre
        /// </summary>
        /// <param name="p">Parametre a creer</param>
        static public void Sauve(Classe.Param p)
        {
            Classe.Log.Logger.Debug("Debut Param.Sauve()");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.PARAM_INSERT, SQLite.Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ident", p.Ident);
                cmd.Parameters.AddWithValue("@val1", p.Val1); cmd.Parameters.AddWithValue("@val2", p.Val2); cmd.Parameters.AddWithValue("@val3", p.Val3);
                cmd.Parameters.AddWithValue("@int1", p.Int1); cmd.Parameters.AddWithValue("@int2", p.Int2); cmd.Parameters.AddWithValue("@int3", p.Int3);
                cmd.Parameters.AddWithValue("@dec1", p.Dec1); cmd.Parameters.AddWithValue("@dec2", p.Dec2); cmd.Parameters.AddWithValue("@dec3", p.Dec3);
                cmd.Parameters.AddWithValue("@dat1", p.Dat1); cmd.Parameters.AddWithValue("@dat2", p.Dat2); cmd.Parameters.AddWithValue("@dat3", p.Dat3);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.PARAM_INSERT);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Param.Sauve()");
        }
    }
}
