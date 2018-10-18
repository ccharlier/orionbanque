using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    class Operation
    {
        static public void Sauve(Classe.Operation o)
        {
            Classe.Log.Logger.Debug("Debut Operations.Sauve(" + o.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_INSERT, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@date", o.Date);
                Classe.Log.Logger.Debug("date=" + o.Date);
                cmd.Parameters.AddWithValue("@id_mode_paiement", o.IdModePaiement);
                Classe.Log.Logger.Debug("id_mode_paiement=" + o.IdModePaiement);
                cmd.Parameters.AddWithValue("@tiers", o.Tiers);
                Classe.Log.Logger.Debug("tiers=" + o.Tiers);
                cmd.Parameters.AddWithValue("@libelle", o.Libelle);
                Classe.Log.Logger.Debug("libelle=" + o.Libelle);
                cmd.Parameters.AddWithValue("@id_categories", o.IdCategorie);
                Classe.Log.Logger.Debug("id_categories=" + o.IdCategorie);
                cmd.Parameters.AddWithValue("@montant", o.Montant);
                Classe.Log.Logger.Debug("montant=" + o.Montant);
                cmd.Parameters.AddWithValue("@id_compte", o.IdCompte);
                Classe.Log.Logger.Debug("id_compte=" + o.IdCompte);
                cmd.Parameters.AddWithValue("@date_pointage", o.DatePointage);
                Classe.Log.Logger.Debug("date_pointage=" + o.DatePointage);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
        }

        static public List<Classe.Operation> ChargeTout(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.ChargeTout(" + idC + ")");
            List<Classe.Operation> ls = new List<Classe.Operation>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_ALL, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_ALL);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idC", idC);
                Classe.Log.Logger.Debug("idC=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(Classe.Operation.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return ls;
        }

        static public Int32 ChercheChequeSuivant(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.ChercheChequeSuivant(" + idC + ")");
            Int32 retour = 0;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_CHEQUE_SUIVANT, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_CHEQUE_SUIVANT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idC", idC);
                Classe.Log.Logger.Debug("idC=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if(rdr.Read())
                {
                    string[] tab = rdr.GetString(0).Split('°');
                    if(tab.Length > 1)
                    {
                        bool b = Int32.TryParse(tab[1], out retour);
                        retour++;
                        if(!b)
                            retour = 0;
                    }
                }
                rdr.Close();
            }
            catch(SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return retour;
        }

        static public List<String> ChargeToutTiers(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.ChargeToutTiers(" + idC + ")");
            List<String> ls = new List<String>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_ALL_TIERS, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_ALL_TIERS);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idC", idC);
                Classe.Log.Logger.Debug("idC=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(rdr.GetString(0));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return ls;
        }

        static public double CalculAVenir(Int32 idCompte)
        {
            Classe.Log.Logger.Debug("Debut Operations.CalculAVenir(" + idCompte + ")");
            double rPositif = 0.0;
            double rNegatif = 0.0;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_CALCUL_AVENIR, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_CALCUL_AVENIR);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idCompte);
                Classe.Log.Logger.Debug("idCompte=" + idCompte);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals("D"))
                        rNegatif += rdr.GetDouble(1);
                    if (rdr.GetString(0).Equals("C"))
                        rPositif += rdr.GetDouble(1);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return rPositif - rNegatif;
        }

        static public double CalculSoldOpePoint(Int32 idCompte)
        {
            Classe.Log.Logger.Debug("Debut Operations.CalculSoldOpePoint(" + idCompte + ")");
            double rSoldIni = Classe.SQLite.Compte.Charge(idCompte).SoldeInitial;
            double rPositif = 0.0;
            double rNegatif = 0.0;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_CALCUL_SOLD_OPE_POINT, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_CALCUL_SOLD_OPE_POINT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idCompte);
                Classe.Log.Logger.Debug("idCompte=" + idCompte);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals("D"))
                        rNegatif += rdr.GetDouble(1);
                    if (rdr.GetString(0).Equals("C"))
                        rPositif += rdr.GetDouble(1);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return rSoldIni + rPositif - rNegatif;
        }

        static public void Maj(Classe.Operation o)
        {
            Classe.Log.Logger.Debug("Debut Operations.Maj(" + o.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_UPDATE_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_UPDATE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@date", o.Date);
                Classe.Log.Logger.Debug("date=" + o.Date);
                cmd.Parameters.AddWithValue("@id_mode_paiement", o.IdModePaiement);
                Classe.Log.Logger.Debug("id_mode_paiement=" + o.IdModePaiement);
                cmd.Parameters.AddWithValue("@tiers", o.Tiers);
                Classe.Log.Logger.Debug("tiers=" + o.Tiers);
                cmd.Parameters.AddWithValue("@libelle", o.Libelle);
                Classe.Log.Logger.Debug("libelle=" + o.Libelle);
                cmd.Parameters.AddWithValue("@id_categories", o.IdCategorie);
                Classe.Log.Logger.Debug("id_categories=" + o.IdCategorie);
                cmd.Parameters.AddWithValue("@montant", o.Montant);
                Classe.Log.Logger.Debug("montant=" + o.Montant);
                cmd.Parameters.AddWithValue("@id_compte", o.IdCompte);
                Classe.Log.Logger.Debug("id_compte=" + o.IdCompte);
                cmd.Parameters.AddWithValue("@id", o.Id);
                Classe.Log.Logger.Debug("id=" + o.Id);
                cmd.Parameters.AddWithValue("@date_pointage", o.DatePointage);
                Classe.Log.Logger.Debug("date_pointage=" + o.DatePointage);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
        }

        static public List<string[]> GroupByTiers(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.GroupByTiers(" + idC + ")");   
            List<string[]> ls = new List<string[]>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_GROUP_BY_TIERS, SQLite.Sql.GetConnection());
                string[] t = new string[2];
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_GROUP_BY_TIERS);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Classe.Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    t = new string[2];
                    t[0] = rdr.GetString(0);
                    t[1] = rdr.GetDouble(1).ToString();
                    if (t[0] == null || t[0] == string.Empty)
                        t[0] = "Sans Tiers";
                    ls.Add(t);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return ls;
        }

        static public List<string[]> GroupByTiersDC(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.GroupByTiersDC(" + idC + ")"); 
            List<string[]> ls = new List<string[]>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_GROUP_BY_TIERS_DC, SQLite.Sql.GetConnection());
                string[] t = new string[3];
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_GROUP_BY_TIERS_DC);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Classe.Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    t = new string[3];
                    t[0] = rdr.GetString(0);
                    if (t[0] == null || t[0] == string.Empty)
                        t[0] = "Sans Tiers";
                    t[1] = rdr.GetDouble(1).ToString();
                    t[2] = rdr.GetDouble(2).ToString();
                    ls.Add(t);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return ls;
        }

        static public List<string[]> GroupByCategories(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.GroupByCategories(" + idC + ")");
            List<string[]> ls = new List<string[]>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_GROUP_BY_CATEGORIES, SQLite.Sql.GetConnection());
                string[] t = new string[2];
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_GROUP_BY_CATEGORIES);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Classe.Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    t = new string[2];
                    t[0] = rdr.GetString(0);
                    t[1] = rdr.GetDouble(1).ToString();
                    if (t[0] == null || t[0] == string.Empty)
                        t[0] = "Sans Catégories";
                    ls.Add(t);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return ls;
        }

        static public List<string[]> GroupByCategoriesDC(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.GroupByCategoriesDC(" + idC + ")");
            List<string[]> ls = new List<string[]>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_GROUP_BY_CATEGORIES_DC, SQLite.Sql.GetConnection());
                string[] t = new string[3];
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_GROUP_BY_CATEGORIES_DC);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Classe.Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    t = new string[3];
                    t[0] = rdr.GetString(0);
                    if (t[0] == null || t[0] == string.Empty)
                        t[0] = "Sans Catégories";
                    t[1] = rdr.GetDouble(1).ToString();
                    t[2] = rdr.GetDouble(2).ToString();
                    ls.Add(t);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return ls;
        }

        static public double SoldeCompteAt(DateTime dt, Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.SoldeCompteAt(" + dt + "," + idC + ")");
            double retour = 0.0;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_SOLDE_DATE, SQLite.Sql.GetConnection());
                string[] t = new string[3];
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_SOLDE_DATE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Classe.Log.Logger.Debug("idCompte=" + idC);
                cmd.Parameters.AddWithValue("@date", dt);
                Classe.Log.Logger.Debug("date=" + dt);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    try
                    {
                        if(rdr.GetValue(0).ToString()!= string.Empty)
                            retour = rdr.GetDouble(0);
                    }
                    catch
                    {
                        retour = 0.0;
                    }
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return retour;
        }

        static public DateTime GetMaxDate(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.GetMaxDate(" + idC + ")");
            DateTime retour = DateTime.Now;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_MAX_DATE, SQLite.Sql.GetConnection());
                string[] t = new string[3];
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_MAX_DATE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Classe.Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    retour = rdr.GetDateTime(0);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return retour;
        }

        static public DateTime GetMinDate(Int32 idC)
        {
            Classe.Log.Logger.Debug("Debut Operations.GetMinDate(" + idC + ")");   
            DateTime retour = DateTime.Now;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_MIN_DATE, SQLite.Sql.GetConnection());
                string[] t = new string[3];
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_MIN_DATE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Classe.Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    retour = rdr.GetDateTime(0);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return retour;
        }

        static public DataSet ChargeGrilleOperation(Int32 idCompte)
        {
            Classe.Log.Logger.Debug("Debut Operations.ChargeGrilleOperation(" + idCompte + ")");
            DataSet retour = new DataSet();
            try
            {
                SQLiteDataAdapter dsOpe = new SQLiteDataAdapter(String.Format(SQLite.Sql.OPERATIONS_CHARGE_GRILLE, idCompte), SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_CHARGE_GRILLE);
                SQLiteCommandBuilder cb = new SQLiteCommandBuilder(dsOpe);
                dsOpe.Fill(retour, "Operations");
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return retour;
        }

        static public List<Classe.Operation> ChargeGrilleListeOperation(Int32 idCompte)
        {
            Classe.Log.Logger.Debug("Debut Operations.ChargeGrilleListeOperation(" + idCompte + ")");
            List<Classe.Operation> retour = new List<Classe.Operation>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_CHARGE_LISTE_GRILLE, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_CHARGE_LISTE_GRILLE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", idCompte);
                Classe.Log.Logger.Debug("id=" + idCompte);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retour.Add(Classe.Operation.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return retour;
        }

        static public DataSet ChargeGrilleOperationFiltre(int idCompte,
                                bool bDate, string cbFiltreDate, DateTime txtFiltreDate,
                                bool bModePaiement, string txtFiltreModePaiement,
                                bool bTiers, string txtFiltreTiers,
                                bool bCategorie, string txtFiltreCategorie,
                                bool bMontant, string cbFiltreMontant, double txtFiltreMontant, bool bNonPointe)
        {
            Classe.Log.Logger.Debug("Debut Operations.ChargeGrilleOperationFiltre()");
            DataSet retour = new DataSet();
            try
            {
                string sql = String.Format(SQLite.Sql.OPERATIONS_CHARGE_GRILLE_FILTRE, idCompte);
                
                if (bDate)
                    sql += " AND strftime('%Y-%m-%d',o.date)" + cbFiltreDate + "'" + txtFiltreDate.Year + "-" + txtFiltreDate.Month.ToString("00") + "-" + txtFiltreDate.Day.ToString("00") + "'";
                if (bModePaiement)
                    sql += " AND mp.id=" + txtFiltreModePaiement;
                if (bTiers)
                    sql += " AND o.tiers='" + txtFiltreTiers + "'";
                if (bCategorie)
                    sql += " AND ca.id=" + txtFiltreCategorie;
                if (bMontant)
                    sql += " AND o.montant" + cbFiltreMontant + txtFiltreMontant;
                if(bNonPointe)
                    sql += " AND date_pointage IS NULL";
                sql += " ORDER BY date_pointage ASC, date ASC";
                Classe.Log.Logger.Debug("Requete :" + sql);
                SQLiteDataAdapter dsOpe = new SQLiteDataAdapter(sql, SQLite.Sql.GetConnection());
                SQLiteCommandBuilder cb = new SQLiteCommandBuilder(dsOpe);
                dsOpe.Fill(retour, "Operations");
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return retour;
        }

        static public Classe.Operation Charge(int id)
        {
            Classe.Log.Logger.Debug("Debut Operations.Charge(" + id + ")");
            Classe.Operation o = new Classe.Operation();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Classe.Log.Logger.Debug("id=" + id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    o.Id = rdr.GetInt32(0);
                    o.Date = rdr.GetDateTime(1);
                    try
                    {
                        o.DatePointage = rdr.GetDateTime(7);
                    }
                    catch
                    {
                        o.DatePointage = null;
                    }
                    o.IdCategorie = rdr.GetInt32(5);
                    o.IdCompte = rdr.GetInt32(8);
                    o.IdModePaiement = rdr.GetInt32(2);
                    o.Libelle = rdr.GetString(4);
                    o.Montant = rdr.GetDouble(6);
                    o.Tiers = rdr.GetString(3);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return o;
        }

        static public void Delete(int id)
        {
            Classe.Log.Logger.Debug("Debut Operations.Delete(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_DELETE_ID, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_DELETE_ID);
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

        static public void MajCategorieOperations(Int32 idCompte, Int32 idCatOri, Int32 idCatDest)
        {
            Classe.Log.Logger.Debug("Debut Operations.MajCategorieOperations(" + idCompte + ", " + idCatOri + ", " + idCatDest + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(SQLite.Sql.OPERATIONS_MAJ_CATEGORIE, SQLite.Sql.GetConnection());
                Classe.Log.Logger.Debug("Requete :" + SQLite.Sql.OPERATIONS_MAJ_CATEGORIE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idCompte);
                Classe.Log.Logger.Debug("idCompte=" + idCompte);
                cmd.Parameters.AddWithValue("@idCatOri", idCatOri);
                Classe.Log.Logger.Debug("idCatOri=" + idCatOri);
                cmd.Parameters.AddWithValue("@idCatDest", idCatDest);
                Classe.Log.Logger.Debug("idCatDest=" + idCatDest);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Classe.Log.Logger.Error(ex.Message);
                throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
        }
    }
}