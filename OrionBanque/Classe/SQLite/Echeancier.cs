using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace OrionBanque.Classe.SQLite
{
    class Echeancier
    {
        static public Int32 InsereEcheance(DateTime DateInsereEch, Int32 idCompte)
        {
            Classe.Log.Logger.Debug("Debut Compte.Delete(" + DateInsereEch + ", " + idCompte + ")");
            List<Classe.Echeancier> lec = new List<Classe.Echeancier>();
           
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.ECHEANCIERS_APPLIQUE, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_APPLIQUE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idCompte);
                Classe.Log.Logger.Debug("idCompte=" + idCompte);
                cmd.Parameters.AddWithValue("@date", DateInsereEch);
                Classe.Log.Logger.Debug("DateInsereEch=" + DateInsereEch);
                
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
                        IdCategorie = ec.IdCategorie,
                        IdCompte = ec.IdCompte,
                        IdModePaiement = ec.IdModePaiement,
                        Libelle = ec.Libelle,
                        Montant = ec.Montant,
                        Tiers = ec.Tiers
                    };

                    Classe.Operation.Sauve(o);

                    if (ec.TypeRepete == "J")
                        ec.Prochaine = ec.Prochaine.AddDays(ec.Repete);
                    if (ec.TypeRepete == "M")
                        ec.Prochaine = ec.Prochaine.AddMonths(ec.Repete);
                    if (ec.TypeRepete == "A")
                        ec.Prochaine = ec.Prochaine.AddYears(ec.Repete);

                    Classe.Echeancier.Maj(ec);
                }

                
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Debut Compte.Delete() avec " + lec.Count + " elements");
            return lec.Count();
        }

        static public void Sauve(Classe.Echeancier e)
        {
            Classe.Log.Logger.Debug("Debut Compte.Sauve(" + e.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.ECHEANCIERS_INSERT, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id_mode_paiement", e.IdModePaiement);
                Classe.Log.Logger.Debug("IdModePaiement=" + e.IdModePaiement);
                cmd.Parameters.AddWithValue("@tiers", e.Tiers);
                Classe.Log.Logger.Debug("Tiers=" + e.Tiers);
                cmd.Parameters.AddWithValue("@libelle", e.Libelle);
                Classe.Log.Logger.Debug("Libelle=" + e.Libelle);
                cmd.Parameters.AddWithValue("@id_categories", e.IdCategorie);
                Classe.Log.Logger.Debug("IdCategorie=" + e.IdCategorie);
                cmd.Parameters.AddWithValue("@montant", e.Montant);
                Classe.Log.Logger.Debug("Montant=" + e.Montant);
                cmd.Parameters.AddWithValue("@id_compte", e.IdCompte);
                Classe.Log.Logger.Debug("IdCompte=" + e.IdCompte);
                cmd.Parameters.AddWithValue("@repete", e.Repete);
                Classe.Log.Logger.Debug("Repete=" + e.Repete);
                cmd.Parameters.AddWithValue("@date_fin", e.DateFin);
                Classe.Log.Logger.Debug("DateFin=" + e.DateFin);
                cmd.Parameters.AddWithValue("@type_repete", e.TypeRepete);
                Classe.Log.Logger.Debug("TypeRepete=" + e.TypeRepete);
                cmd.Parameters.AddWithValue("@prochaine", e.Prochaine);
                Classe.Log.Logger.Debug("Prochaine=" + e.Prochaine);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Debut Compte.Sauve()");
        }

        static public void Maj(Classe.Echeancier e)
        {
            Classe.Log.Logger.Debug("Debut Compte.Maj(" + e.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.ECHEANCIERS_UPDATE, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_UPDATE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id_mode_paiement", e.IdModePaiement);
                Classe.Log.Logger.Debug("IdModePaiement=" + e.IdModePaiement);
                cmd.Parameters.AddWithValue("@tiers", e.Tiers);
                Classe.Log.Logger.Debug("Tiers=" + e.Tiers);
                cmd.Parameters.AddWithValue("@libelle", e.Libelle);
                Classe.Log.Logger.Debug("Libelle=" + e.Libelle);
                cmd.Parameters.AddWithValue("@id_categories", e.IdCategorie);
                Classe.Log.Logger.Debug("IdCategorie=" + e.IdCategorie);
                cmd.Parameters.AddWithValue("@montant", e.Montant);
                Classe.Log.Logger.Debug("Montant=" + e.Montant);
                cmd.Parameters.AddWithValue("@id_compte", e.IdCompte);
                Classe.Log.Logger.Debug("IdCompte=" + e.IdCompte);
                cmd.Parameters.AddWithValue("@id", e.Id);
                Classe.Log.Logger.Debug("Id=" + e.Id);
                cmd.Parameters.AddWithValue("@repete", e.Repete);
                Classe.Log.Logger.Debug("Repete=" + e.Repete);
                cmd.Parameters.AddWithValue("@date_fin", e.DateFin);
                Classe.Log.Logger.Debug("DateFin=" + e.DateFin);
                cmd.Parameters.AddWithValue("@type_repete", e.TypeRepete);
                Classe.Log.Logger.Debug("TypeRepete=" + e.TypeRepete);
                cmd.Parameters.AddWithValue("@prochaine", e.Prochaine);
                Classe.Log.Logger.Debug("Prochaine=" + e.Prochaine);

                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Debut Compte.Maj(" + e.Id + ")");
        }

        static public DataSet ChargeGrilleEcheance(Int32 idCompte)
        {
            Classe.Log.Logger.Debug("Debut Compte.ChargeGrilleEcheance(" + idCompte + ")");
            DataSet retour = new DataSet();
            try
            {
                SQLiteDataAdapter dsOpe = new SQLiteDataAdapter(String.Format(SQLite.Sql.ECHEANCIERS_GRILLE, idCompte), SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_GRILLE);
                SQLiteCommandBuilder cb = new SQLiteCommandBuilder(dsOpe);

                dsOpe.Fill(retour, "Echeancier");
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Debut Compte.ChargeGrilleEcheance()");
            return retour;
        }

        static public Classe.Echeancier Charge(int id)
        {
            Classe.Log.Logger.Debug("Debut Compte.Charge(" + id + ")");
            Classe.Echeancier e = new Classe.Echeancier();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.ECHEANCIERS_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("Id=" + id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    e.Id = rdr.GetInt32(0);
                    e.Prochaine = rdr.GetDateTime(1);
                    e.IdCategorie = rdr.GetInt32(5);
                    e.IdCompte = rdr.GetInt32(7);
                    e.IdModePaiement = rdr.GetInt32(2);
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
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Debut Compte.Charge()");
            return e;
        }

        static public List<Classe.Echeancier> ChargeTout(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Compte.ChargeTout(" + idC + ")");
            List<Classe.Echeancier> ls = new List<Classe.Echeancier>();
            
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.ECHEANCIERS_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", idC);
                Classe.Log.Logger.Debug("Id=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(Classe.Echeancier.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Compte.ChargeTout() avec " + ls.Count + " elements");
            return ls;
        }

        static public void Delete(Classe.Echeancier ec)
        {
            Classe.Log.Logger.Debug("Debut Compte.Delete(" + ec.Id + ")");
            Classe.SQLite.Echeancier.Delete(ec.Id);
            Classe.Log.Logger.Debug("Fin Compte.Delete()");
        }

        static public void Delete(int id)
        {
            Classe.Log.Logger.Debug("Debut Compte.Delete(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.ECHEANCIERS_DELETE_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.ECHEANCIERS_DELETE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("Id=" + id);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            Classe.Log.Logger.Debug("Fin Compte.Delete()");
        }
    }
}
