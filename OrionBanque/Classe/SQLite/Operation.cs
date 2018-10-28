using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace OrionBanque.Classe.SQLite
{
    class Operation
    {
        public static Classe.Operation Sauve(Classe.Operation o)
        {
            Log.Logger.Debug("Debut Operations.Sauve(" + o.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_INSERT, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_INSERT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@date", o.Date);
                Log.Logger.Debug("date=" + o.Date);
                cmd.Parameters.AddWithValue("@id_mode_paiement", o.ModePaiement.Id);
                Log.Logger.Debug("id_mode_paiement=" + o.ModePaiement.Id);
                cmd.Parameters.AddWithValue("@tiers", o.Tiers);
                Log.Logger.Debug("tiers=" + o.Tiers);
                cmd.Parameters.AddWithValue("@libelle", o.Libelle);
                Log.Logger.Debug("libelle=" + o.Libelle);
                cmd.Parameters.AddWithValue("@id_categories", o.Categorie.Id);
                Log.Logger.Debug("id_categories=" + o.Categorie.Id);
                cmd.Parameters.AddWithValue("@montant", o.Montant);
                Log.Logger.Debug("montant=" + o.Montant);
                cmd.Parameters.AddWithValue("@id_compte", o.Compte.Id);
                Log.Logger.Debug("id_compte=" + o.Compte.Id);
                cmd.Parameters.AddWithValue("@date_pointage", o.DatePointage);
                Log.Logger.Debug("date_pointage=" + o.DatePointage);
                cmd.ExecuteNonQuery();
                o.Id = Sql.GetLastInsertId();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return o;
        }

        public static List<Classe.Operation> ChargeTout(int idC)
        {
            Log.Logger.Debug("Debut Operations.ChargeTout(" + idC + ")");
            List<Classe.Operation> ls = new List<Classe.Operation>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_ALL, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_ALL);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idC", idC);
                Log.Logger.Debug("idC=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(Classe.Operation.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return ls;
        }

        public static List<Classe.Operation> ChargeToutUtilisateur(Classe.Utilisateur u)
        {
            Log.Logger.Debug("Debut Operations.ChargeToutUtilisateur(" + u.Id + ")");
            List<Classe.Operation> ls = new List<Classe.Operation>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_UTILISATEUR, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_UTILISATEUR);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idU", u.Id);
                Log.Logger.Debug("idU=" + u.Id);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(Classe.Operation.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return ls;
        }

        public static int ChercheChequeSuivant(int idC)
        {
            Log.Logger.Debug("Debut Operations.ChercheChequeSuivant(" + idC + ")");
            int retour = 0;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_CHEQUE_SUIVANT, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_CHEQUE_SUIVANT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idC", idC);
                Log.Logger.Debug("idC=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if(rdr.Read())
                {
                    string[] tab = rdr.GetString(0).Split('°');
                    if(tab.Length > 1)
                    {
                        bool b = int.TryParse(tab[1], out retour);
                        retour++;
                        if(!b)
                        {
                            retour = 0;
                        }
                    }
                }
                rdr.Close();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return retour;
        }

        public static List<string> ChargeToutTiers(int idC)
        {
            Log.Logger.Debug("Debut Operations.ChargeToutTiers(" + idC + ")");
            List<string> ls = new List<string>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_ALL_TIERS, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_ALL_TIERS);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idC", idC);
                Log.Logger.Debug("idC=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ls.Add(rdr.GetString(0));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return ls;
        }

        public static double CalculAVenir(int idCompte)
        {
            Log.Logger.Debug("Debut Operations.CalculAVenir(" + idCompte + ")");
            double rPositif = 0.0;
            double rNegatif = 0.0;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_CALCUL_AVENIR, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_CALCUL_AVENIR);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idCompte);
                Log.Logger.Debug("idCompte=" + idCompte);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals("D"))
                    {
                        rNegatif += rdr.GetDouble(1);
                    }

                    if (rdr.GetString(0).Equals("C"))
                    {
                        rPositif += rdr.GetDouble(1);
                    }
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return rPositif - rNegatif;
        }

        public static double CalculSoldOpePoint(int idCompte)
        {
            Log.Logger.Debug("Debut Operations.CalculSoldOpePoint(" + idCompte + ")");
            double rSoldIni = Compte.Charge(idCompte).SoldeInitial;
            double rPositif = 0.0;
            double rNegatif = 0.0;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_CALCUL_SOLD_OPE_POINT, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_CALCUL_SOLD_OPE_POINT);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idCompte);
                Log.Logger.Debug("idCompte=" + idCompte);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals("D"))
                    {
                        rNegatif += rdr.GetDouble(1);
                    }

                    if (rdr.GetString(0).Equals("C"))
                    {
                        rPositif += rdr.GetDouble(1);
                    }
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return rSoldIni + rPositif - rNegatif;
        }

        public static Classe.Operation Maj(Classe.Operation o)
        {
            Log.Logger.Debug("Debut Operations.Maj(" + o.Id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_UPDATE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_UPDATE_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@date", o.Date);
                Log.Logger.Debug("date=" + o.Date);
                cmd.Parameters.AddWithValue("@id_mode_paiement", o.ModePaiement.Id);
                Log.Logger.Debug("id_mode_paiement=" + o.ModePaiement.Id);
                cmd.Parameters.AddWithValue("@tiers", o.Tiers);
                Log.Logger.Debug("tiers=" + o.Tiers);
                cmd.Parameters.AddWithValue("@libelle", o.Libelle);
                Log.Logger.Debug("libelle=" + o.Libelle);
                cmd.Parameters.AddWithValue("@id_categories", o.Categorie.Id);
                Log.Logger.Debug("id_categories=" + o.Categorie.Id);
                cmd.Parameters.AddWithValue("@montant", o.Montant);
                Log.Logger.Debug("montant=" + o.Montant);
                cmd.Parameters.AddWithValue("@id_compte", o.Compte.Id);
                Log.Logger.Debug("id_compte=" + o.Compte.Id);
                cmd.Parameters.AddWithValue("@id", o.Id);
                Log.Logger.Debug("id=" + o.Id);
                cmd.Parameters.AddWithValue("@date_pointage", o.DatePointage);
                Log.Logger.Debug("date_pointage=" + o.DatePointage);
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return o;
        }

        public static List<string[]> GroupByTiers(int idC)
        {
            Log.Logger.Debug("Debut Operations.GroupByTiers(" + idC + ")");   
            List<string[]> ls = new List<string[]>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_GROUP_BY_TIERS, Sql.GetConnection());
                string[] t = new string[2];
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_GROUP_BY_TIERS);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    t = new string[2];
                    t[0] = rdr.GetString(0);
                    t[1] = rdr.GetDouble(1).ToString();
                    if (t[0] == null || t[0] == string.Empty)
                    {
                        t[0] = "Sans Tiers";
                    }

                    ls.Add(t);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return ls;
        }

        public static List<string[]> GroupByTiersDC(int idC)
        {
            Log.Logger.Debug("Debut Operations.GroupByTiersDC(" + idC + ")"); 
            List<string[]> ls = new List<string[]>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_GROUP_BY_TIERS_DC, Sql.GetConnection());
                string[] t = new string[3];
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_GROUP_BY_TIERS_DC);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    t = new string[3];
                    t[0] = rdr.GetString(0);
                    if (t[0] == null || t[0] == string.Empty)
                    {
                        t[0] = "Sans Tiers";
                    }

                    t[1] = rdr.GetDouble(1).ToString();
                    t[2] = rdr.GetDouble(2).ToString();
                    ls.Add(t);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return ls;
        }

        public static List<string[]> GroupByCategories(int idC)
        {
            Log.Logger.Debug("Debut Operations.GroupByCategories(" + idC + ")");
            List<string[]> ls = new List<string[]>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_GROUP_BY_CATEGORIES, Sql.GetConnection());
                string[] t = new string[2];
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_GROUP_BY_CATEGORIES);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    t = new string[2];
                    t[0] = rdr.GetString(0);
                    t[1] = rdr.GetDouble(1).ToString();
                    if (t[0] == null || t[0] == string.Empty)
                    {
                        t[0] = "Sans Catégories";
                    }

                    ls.Add(t);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return ls;
        }

        public static List<string[]> GroupByCategoriesDC(int idC)
        {
            Log.Logger.Debug("Debut Operations.GroupByCategoriesDC(" + idC + ")");
            List<string[]> ls = new List<string[]>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_GROUP_BY_CATEGORIES_DC, Sql.GetConnection());
                string[] t = new string[3];
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_GROUP_BY_CATEGORIES_DC);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    t = new string[3];
                    t[0] = rdr.GetString(0);
                    if (t[0] == null || t[0] == string.Empty)
                    {
                        t[0] = "Sans Catégories";
                    }

                    t[1] = rdr.GetDouble(1).ToString();
                    t[2] = rdr.GetDouble(2).ToString();
                    ls.Add(t);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return ls;
        }

        public static double SoldeCompteAt(DateTime dt, int idC)
        {
            Log.Logger.Debug("Debut Operations.SoldeCompteAt(" + dt + "," + idC + ")");
            double retour = 0.0;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_SOLDE_DATE, Sql.GetConnection());
                string[] t = new string[3];
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_SOLDE_DATE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Log.Logger.Debug("idCompte=" + idC);
                cmd.Parameters.AddWithValue("@date", dt);
                Log.Logger.Debug("date=" + dt);
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
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return retour;
        }

        public static DateTime GetMaxDate(int idC)
        {
            Log.Logger.Debug("Debut Operations.GetMaxDate(" + idC + ")");
            DateTime retour = DateTime.Now;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_MAX_DATE, Sql.GetConnection());
                string[] t = new string[3];
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_MAX_DATE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    retour = rdr.GetDateTime(0);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return retour;
        }

        public static DateTime GetMinDate(int idC)
        {
            Log.Logger.Debug("Debut Operations.GetMinDate(" + idC + ")");   
            DateTime retour = DateTime.Now;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_MIN_DATE, Sql.GetConnection());
                string[] t = new string[3];
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_MIN_DATE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idC);
                Log.Logger.Debug("idCompte=" + idC);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    retour = rdr.GetDateTime(0);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return retour;
        }

        public static DataSet ChargeGrilleOperation(int idCompte)
        {
            Log.Logger.Debug("Debut Operations.ChargeGrilleOperation(" + idCompte + ")");
            DataSet retour = new DataSet();
            try
            {
                SQLiteDataAdapter dsOpe = new SQLiteDataAdapter(string.Format(Sql.OPERATIONS_CHARGE_GRILLE, idCompte), Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_CHARGE_GRILLE);
                SQLiteCommandBuilder cb = new SQLiteCommandBuilder(dsOpe);
                dsOpe.Fill(retour, "Operations");
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return retour;
        }

        public static List<Classe.Operation> ChargeGrilleListeOperation(int idCompte)
        {
            Log.Logger.Debug("Debut Operations.ChargeGrilleListeOperation(" + idCompte + ")");
            List<Classe.Operation> retour = new List<Classe.Operation>();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_CHARGE_LISTE_GRILLE, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_CHARGE_LISTE_GRILLE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", idCompte);
                Log.Logger.Debug("id=" + idCompte);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retour.Add(Classe.Operation.Charge(rdr.GetInt32(0)));
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return retour;
        }

        public static DataSet ChargeGrilleOperationFiltre(int idCompte,
                                bool bDate, string cbFiltreDate, DateTime txtFiltreDate,
                                bool bModePaiement, string txtFiltreModePaiement,
                                bool bTiers, string txtFiltreTiers,
                                bool bCategorie, string txtFiltreCategorie,
                                bool bMontant, string cbFiltreMontant, double txtFiltreMontant, bool bNonPointe)
        {
            Log.Logger.Debug("Debut Operations.ChargeGrilleOperationFiltre()");
            DataSet retour = new DataSet();
            try
            {
                string sql = string.Format(Sql.OPERATIONS_CHARGE_GRILLE_FILTRE, idCompte);
                
                if (bDate)
                {
                    sql += " AND strftime('%Y-%m-%d',o.date)" + cbFiltreDate + "'" + txtFiltreDate.Year + "-" + txtFiltreDate.Month.ToString("00") + "-" + txtFiltreDate.Day.ToString("00") + "'";
                }

                if (bModePaiement)
                {
                    sql += " AND mp.id=" + txtFiltreModePaiement;
                }

                if (bTiers)
                {
                    sql += " AND o.tiers='" + txtFiltreTiers + "'";
                }

                if (bCategorie)
                {
                    sql += " AND ca.id=" + txtFiltreCategorie;
                }

                if (bMontant)
                {
                    sql += " AND o.montant" + cbFiltreMontant + txtFiltreMontant;
                }

                if (bNonPointe)
                {
                    sql += " AND date_pointage IS NULL";
                }

                sql += " ORDER BY date_pointage ASC, date ASC";
                Log.Logger.Debug("Requete :" + sql);
                SQLiteDataAdapter dsOpe = new SQLiteDataAdapter(sql, Sql.GetConnection());
                SQLiteCommandBuilder cb = new SQLiteCommandBuilder(dsOpe);
                dsOpe.Fill(retour, "Operations");
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
            return retour;
        }

        public static Classe.Operation Charge(int id)
        {
            Log.Logger.Debug("Debut Operations.Charge(" + id + ")");
            Classe.Operation o = new Classe.Operation();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_ID);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                Log.Logger.Debug("id=" + id);
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
                    o.Categorie = Classe.Categorie.Charge(rdr.GetInt32(5));
                    o.Compte = Classe.Compte.Charge(rdr.GetInt32(8));
                    o.ModePaiement = Classe.ModePaiement.Charge(rdr.GetInt32(2));
                    o.Libelle = rdr.GetString(4);
                    o.Montant = rdr.GetDouble(6);
                    o.Tiers = rdr.GetString(3);
                }
                rdr.Close();
            }
            catch (SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }

            return o;
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Operations.Delete(" + id + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_DELETE_ID, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_DELETE_ID);
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

        public static void MajCategorieOperations(int idCompte, int idCatOri, int idCatDest)
        {
            Log.Logger.Debug("Debut Operations.MajCategorieOperations(" + idCompte + ", " + idCatOri + ", " + idCatDest + ")");
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Sql.OPERATIONS_MAJ_CATEGORIE, Sql.GetConnection());
                Log.Logger.Debug("Requete :" + Sql.OPERATIONS_MAJ_CATEGORIE);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idCompte", idCompte);
                Log.Logger.Debug("idCompte=" + idCompte);
                cmd.Parameters.AddWithValue("@idCatOri", idCatOri);
                Log.Logger.Debug("idCatOri=" + idCatOri);
                cmd.Parameters.AddWithValue("@idCatDest", idCatDest);
                Log.Logger.Debug("idCatDest=" + idCatDest);
                cmd.ExecuteNonQuery();
            }
            catch(SQLiteException ex)
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(string.Format(Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
            }
        }
    }
}