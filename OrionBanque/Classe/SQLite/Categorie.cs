using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    public class Categorie
    {
        static public List<Classe.Categorie> ChargeTout()
        {
            Classe.Log.Logger.Debug("Debut Categorie.ChargeTout()");
            List<Classe.Categorie> lc = new List<Classe.Categorie>();
            try
            {
                Classe.Categorie c = new Classe.Categorie();
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.CATEGORIES_ALL, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.CATEGORIES_ALL);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Classe.Log.Logger.Info("Chargement de la Categorie n°" + rdr.GetInt32(0) + ", Libelle " + rdr.GetString(1) + ", IdParent " + rdr.GetInt32(2));
                    c = new Classe.Categorie
                    {
                        Id = rdr.GetInt32(0),
                        IdParent = rdr.GetInt32(2),
                        Libelle = rdr.GetString(1)
                    };

                    lc.Add(c);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Categorie.ChargeTout() avec " + lc.Count + " elements");
            return lc;
        }

        static public List<Classe.Categorie> ChargeToutIdent()
        {
            Classe.Log.Logger.Debug("Debut Categorie.ChargeToutIdent()");
            List<Classe.Categorie> retour = new List<OrionBanque.Classe.Categorie>();
            List<Classe.Categorie> lcParent = Classe.SQLite.Categorie.ChargeCategorieParent();
            foreach (Classe.Categorie c in lcParent)
            {
                retour.Add(c);
                Classe.Log.Logger.Info("Chargement de la Categorie Parent n°" + c.Id + ", Libelle " + c.Libelle + ", IdParent " + c.IdParent);
                List<Classe.Categorie> lcEnfant = Classe.Categorie.ChargeCategorieDeParent(c.Id);
                foreach (Classe.Categorie c2 in lcEnfant)
                {
                    Classe.Log.Logger.Info("Chargement de la Categorie Enfant n°" + c2.Id + ", Libelle " + c2.Libelle + ", IdParent " + c2.IdParent);
                    c2.Libelle = "\t-> " + c2.Libelle;
                    retour.Add(c2);
                }
            }
            Classe.Log.Logger.Debug("Fin Categorie.ChargeToutIdent() avec " + retour.Count + " elements");
            return retour;
        }

        static public List<Classe.Categorie> ChargeCategorieParent()
        {
            Classe.Log.Logger.Debug("Debut Categorie.ChargeCategorieParent()");
            List<Classe.Categorie> lc = new List<Classe.Categorie>();
            try
            {
                Classe.Categorie c = new Classe.Categorie();
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.CATEGORIES_PARENT, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.CATEGORIES_PARENT);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Classe.Log.Logger.Info("Chargement de la Categorie n°" + rdr.GetInt32(0) + ", Libelle " + rdr.GetString(1) + ", IdParent " + rdr.GetInt32(2));
                    c = new Classe.Categorie
                    {
                        Id = rdr.GetInt32(0),
                        IdParent = rdr.GetInt32(2),
                        Libelle = rdr.GetString(1)
                    };

                    lc.Add(c);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Categorie.ChargeCategorieParent() avec " + lc.Count + " elements");
            return lc;
        }

        static public List<Classe.Categorie> ChargeCategorieDeParent(int idCat)
        {
            Classe.Log.Logger.Debug("Debut Categorie.ChargeCategorieDeParent(" + idCat + ")");
            List<Classe.Categorie> lc = new List<Classe.Categorie>();
            Classe.Categorie c = new Classe.Categorie();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.CATEGORIES_DE_PARENT,SQLite.Sql.GetConnection());
                
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id_parent", idCat);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.CATEGORIES_DE_PARENT);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Classe.Log.Logger.Info("Chargement de la Categorie n°" + rdr.GetInt32(0) + ", Libelle " + rdr.GetString(1) + ", IdParent " + rdr.GetInt32(2));
                    c = new Classe.Categorie
                    {
                        Id = rdr.GetInt32(0),
                        IdParent = rdr.GetInt32(2),
                        Libelle = rdr.GetString(1)
                    };

                    lc.Add(c);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Categorie.ChargeCategorieDeParent() avec " + lc.Count + " elements");
            return lc;
        }

        static public Classe.Categorie Charge(Int32 id)
        {
            Classe.Log.Logger.Debug("Debut Categorie.Charge(" + id + ")");
            Classe.Categorie c = new Classe.Categorie();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Classe.SQLite.Sql.CATEGORIES_ID, SQLite.Sql.GetConnection());
                
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.CATEGORIES_ID);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    c.Id = rdr.GetInt32(0);
                    c.Libelle = rdr.GetString(1);
                    c.IdParent = rdr.GetInt32(2);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Categorie.Charge() : n°" + c.Id + ", Libelle " + c.Libelle + ", IdParent " + c.IdParent);
            return c;
        }

        static public Classe.Categorie ChargeParNom(string nom)
        {
            Log.Logger.Debug("Debut Categorie.ChargeParNom(" + nom + ")");
            Classe.Categorie c = new Classe.Categorie();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.CATEGORIES_PARENT_NOM, Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", nom);
                Log.Logger.Debug("Execution requete : " + Sql.CATEGORIES_PARENT_NOM);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    c.Id = rdr.GetInt32(0);
                    c.Libelle = rdr.GetString(1);
                    c.IdParent = rdr.GetInt32(2);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Log.Logger.Debug("Fin Categorie.ChargeParNom() : n°" + c.Id + ", Libelle " + c.Libelle + ", IdParent " + c.IdParent);
            return c;
        }

        static public void DeletePossible(Int32 id)
        {
            Classe.Log.Logger.Debug("Debut Categorie.DeletePossible(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.CATEGORIES_DELETE_POSSIBLE, SQLite.Sql.GetConnection());

                cmd.Prepare();
                cmd.Parameters.Add("@id_categories", DbType.Int32);
                cmd.Parameters["@id_categories"].Value = id;
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.CATEGORIES_DELETE_POSSIBLE);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    throw new Exception("Vous devez d'abord modifier vos Opérations pour qu'elles ne pointent plus sur cette Catégorie.");
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
            Classe.Log.Logger.Debug("Fin Categorie.DeletePossible()");
        }

        static public void Delete(int id)
        {
            Classe.Log.Logger.Debug("Debut Categorie.Delete(" + id + ")");
            try
            {
                Classe.Categorie.DeletePossible(id);
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.CATEGORIES_DELETE_ID, SQLite.Sql.GetConnection());

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.CATEGORIES_DELETE_ID);
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
            Classe.Log.Logger.Debug("Fin Categorie.DeletePossible()");
        }

        static public void Maj(Classe.Categorie c)
        {
            Classe.Log.Logger.Debug("Debut Categorie.Maj() : id " + c.Id + ", libelle " + c.Libelle + ", idparent " + c.IdParent );
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.CATEGORIES_UPDATE_ID, SQLite.Sql.GetConnection());
                
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", c.Libelle);
                cmd.Parameters.AddWithValue("@id_parent", c.IdParent);
                cmd.Parameters.AddWithValue("@id", c.Id);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.CATEGORIES_UPDATE_ID);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Categorie.Maj()");
        }

        static public void Sauve(Classe.Categorie c)
        {
            Classe.Log.Logger.Debug("Debut Categorie.Sauve() : id " + c.Id + ", libelle " + c.Libelle + ", idparent " + c.IdParent);
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.CATEGORIES_INSERT, SQLite.Sql.GetConnection());
                
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@libelle", c.Libelle);
                cmd.Parameters.AddWithValue("@id_parent", c.IdParent);
                Classe.Log.Logger.Debug("Execution requete : " + SQLite.Sql.CATEGORIES_INSERT);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Categorie.Sauve()");
        }
    }
}
