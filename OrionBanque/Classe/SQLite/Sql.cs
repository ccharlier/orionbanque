using System;
using System.Data.SQLite;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using System.Configuration;

namespace OrionBanque.Classe.SQLite
{
    class Sql
    {
        #region Requete
        /** Requête SQL Param */
        public const string PARAM_ID = "SELECT * FROM param WHERE id=@id";
        public const string PARAM_IDENT = "SELECT * FROM param WHERE Ident=@ident";
        public const string PARAM_DELETE_ID = "DELETE FROM param WHERE id=@id";
        public const string PARAM_DELETE_IDENT = "DELETE FROM param WHERE Ident=@ident";
        public const string PARAM_UPDATE_ID = "UPDATE param SET Ident=@ident, Val1=@val1, Val2=@val2, Val3=@val3, Int1=@int1, Int2=@int2, Int3=@int3, Dec1=@dec1, Dec2=@dec2, Dec3=@dec2, Dat1=@dat1, Dat2=@dat2, Dat3=@dat3 WHERE id=@id";
        public const string PARAM_INSERT = "INSERT INTO param(id,ident,val1,val2,val3,int1,int2,int3,dec1,dec2,dec3,dat1,dat2,dat3) VALUES(null,@ident,@val1,@val2,@val3,@int1,@int2,@int3,@dec1,@dec2,@dec3,@dat1,@dat2,@dat3)";

        /** Requête SQL Categorie */
        public const string CATEGORIES_ALL = "SELECT * FROM categories ORDER BY libelle";
        public const string CATEGORIES_PARENT = "SELECT * FROM categories WHERE id_parent=0 ORDER BY libelle";
        public const string CATEGORIES_DE_PARENT = "SELECT * FROM categories WHERE id_parent=@id_parent ORDER BY libelle";
        public const string CATEGORIES_ID = "SELECT * FROM categories WHERE id=@id";
        public const string CATEGORIES_PARENT_NOM = "SELECT * FROM categories WHERE libelle=@libelle AND id_parent=0";
        public const string CATEGORIES_DELETE_POSSIBLE = "SELECT * FROM operations WHERE id_categories = @id_categories";
        public const string CATEGORIES_DELETE_ID = "DELETE FROM categories WHERE id=@id";
        public const string CATEGORIES_UPDATE_ID = "UPDATE categories SET libelle=@libelle, id_parent=@id_parent WHERE id=@id";
        public const string CATEGORIES_INSERT = "INSERT INTO categories(id,libelle,id_parent) VALUES(null,@libelle,@id_parent)";

        /** Requête SQL Utilisateur */
        public const string UTILISATEURS_ALL = "SELECT * FROM utilisateurs";
        public const string UTILISATEURS_ID = "SELECT * FROM utilisateurs WHERE id=@id";
        public const string UTILISATEURS_LOGIN = "SELECT * FROM utilisateurs WHERE login=@login";
        public const string UTILISATEURS_DELETE_ID = "DELETE FROM utilisateurs WHERE id=@id";
        public const string UTILISATEURS_UPDATE_ID = "UPDATE utilisateurs SET login=@login, mdp=@mdp WHERE id=@id";
        public const string UTILISATEURS_INSERT = "INSERT INTO utilisateurs(id,login,mdp) VALUES(null,@login,@mdp)";

        /** Requête SQL Compte */
        public const string COMPTES_ALL = "SELECT * FROM comptes WHERE id_utilisateur=@idU ORDER BY libelle";
        public const string COMPTES_ID = "SELECT * FROM comptes WHERE id=@id";
        public const string COMPTES_DELETE_ID = "DELETE FROM comptes WHERE id=@id";
        public const string COMPTES_UPDATE_ID = "UPDATE comptes SET soldeseuilfinal=@soldeseuilfinal,soldeseuil=@soldeseuil,mingraphsold=@mingraphsold,maxgraphsold=@maxgraphsold,libelle=@libelle, solde_initial=@SoldeInitial, banque=@banque, guichet=@guichet, compte=@compte, clef=@clef, typevol=@typevol WHERE id=@id";
        public const string COMPTES_INSERT = "INSERT INTO comptes(id,libelle,solde_initial,id_utilisateur,banque,guichet,compte,clef,mingraphsold,maxgraphsold,soldeseuil,typevol,soldeseuilfinal) VALUES(null,@libelle,@solde_initial,@id_utilisateur,@banque,@guichet,@compte,@clef,@mingraphsold,@maxgraphsold,@soldeseuil,@typevol,@soldeseuilfinal)";

        /** Requête SQL Echeancier */
        public const string ECHEANCIERS_APPLIQUE = "SELECT id FROM echeanciers e " +
                    "WHERE (e.date_fin is null OR e.prochaine <= e.date_fin) " +
                    "AND e.prochaine <= @date AND id_compte=@idCompte";
        public const string ECHEANCIERS_INSERT = "INSERT INTO echeanciers(id,prochaine,id_mode_paiement,tiers,libelle,id_categories,montant,id_compte,repete,date_fin,type_repete)  " + 
                    "VALUES(null,@prochaine,@id_mode_paiement,@tiers,@libelle,@id_categories,@montant,@id_compte,@repete,@date_fin,@type_repete)";
        public const string ECHEANCIERS_UPDATE = "UPDATE echeanciers SET prochaine=@prochaine,id_mode_paiement=@id_mode_paiement, tiers=@tiers, libelle=@libelle, " +
                    "id_categories=@id_categories, montant=@montant, id_compte=@id_compte, repete=@repete, date_fin=@date_fin, type_repete=@type_repete WHERE id=@id";
        public const string ECHEANCIERS_GRILLE = "SELECT o.id as \"Ident. Echeance\",o.prochaine as \"Prochaine\", mp.libelle as \"Mode de Paiement\",o.tiers as \"Tiers\",o.libelle as \"Libelle\",ca.libelle as \"Categories\",(CASE mp.type='D' WHEN 1 THEN CAST(montant as TEXT) ELSE \"\" END) as \"Debit\",(CASE mp.type='D' WHEN 1 THEN \"\" ELSE CAST(montant as TEXT) END) as \"Credit\", o.repete as \"Repetition\", o.type_repete as \"Type Repet.\", o.date_fin as \"Date de Fin\" FROM " +
                                "echeanciers o " +
                                "INNER JOIN categories ca ON o.id_categories = ca.id " +
                                "INNER JOIN comptes co ON o.id_compte = co.id " +
                                "INNER JOIN mode_paiement mp ON o.id_mode_paiement = mp.id " +
                                "WHERE id_compte={0} " +
                                "ORDER BY prochaine";
        public const string ECHEANCIERS_ID = "SELECT id,prochaine,id_mode_paiement,tiers,libelle,id_categories,montant,id_compte,repete,type_repete,date_fin FROM echeanciers WHERE id=@id";
        public const string ECHEANCIERS_DELETE_ID = "DELETE FROM echeanciers WHERE id=@id";

        /** Requête SQL Mode de paiement */
        public const string MODEPAIMENTS_ALL = "SELECT * FROM mode_paiement ORDER BY libelle";
        public const string MODEPAIMENTS_ID = "SELECT * FROM mode_paiement WHERE id=@id";
        public const string MODEPAIMENTS_NOM = "SELECT * FROM mode_paiement WHERE libelle=@libelle";
        public const string MODEPAIMENTS_DELETE_ID = "DELETE FROM mode_paiement WHERE id=@id";
        public const string MODEPAIMENTS_DELETE_POSSIBLE = "SELECT * FROM operations WHERE id_mode_paiement=@id_mode_paiement";
        public const string MODEPAIMENTS_UPDATE_ID = "UPDATE mode_paiement SET libelle=@libelle, type=@type WHERE id=@id";
        public const string MODEPAIMENTS_INSERT = "INSERT INTO mode_paiement(id,libelle,type) VALUES(null,@libelle,@type)";

        /** Requête SQL Operation */
        public const string OPERATIONS_CHEQUE_SUIVANT = "SELECT libelle FROM operations WHERE id_mode_paiement=8 AND id_compte=@idC ORDER BY date DESC";
        public const string OPERATIONS_ALL_TIERS = "SELECT distinct tiers FROM operations WHERE id_compte=@idC order by tiers";
        public const string OPERATIONS_ALL = "SELECT * FROM operations WHERE id_compte=@idC";
        public const string OPERATIONS_CALCUL_AVENIR = "SELECT type,montant FROM" +
                            " operations o INNER JOIN mode_paiement mp ON o.id_mode_paiement = mp.id" +
                            " WHERE id_compte = @idCompte" +
                            " AND date_pointage IS NULL";
        public const string OPERATIONS_CALCUL_SOLD_OPE_POINT = "SELECT type,montant FROM" +
                            " operations o INNER JOIN mode_paiement mp ON o.id_mode_paiement = mp.id" +
                            " WHERE id_compte = @idCompte" +
                            " AND date_pointage IS NOT NULL";
        public const string OPERATIONS_GROUP_BY_TIERS = "SELECT tiers, sum(case when m.type = 'D' then montant*(-1) else montant end) as total " +
                            "FROM operations o INNER JOIN mode_paiement m ON m.id = o.id_mode_paiement " +
                            "WHERE id_compte = @idCompte " +
                            "Group By tiers";
        public const string OPERATIONS_GROUP_BY_TIERS_DC = "SELECT tiers, sum(case when m.type = 'D' then montant*(-1) else montant*0 end) as totalD, sum(case when m.type = 'C' then montant else montant*0 end) as totalC " +
                            "FROM operations o INNER JOIN mode_paiement m ON m.id = o.id_mode_paiement " +
                            "WHERE id_compte = @idCompte " +
                            "Group By tiers";
        public const string OPERATIONS_GROUP_BY_CATEGORIES = "SELECT c.libelle as libelle, sum(case when m.type = 'D' then montant*(-1) else montant end) as total " +
                            "FROM operations o INNER JOIN mode_paiement m ON m.id = o.id_mode_paiement INNER JOIN categories c ON o.id_categories = c.id " +
                            "WHERE id_compte = @idCompte " +
                            "Group By id_categories";
        public const string OPERATIONS_SOLDE_DATE = "SELECT sum(case when m.type = 'D' then montant*(-1) else montant end) as total " +
                            "FROM operations o INNER JOIN mode_paiement m ON m.id = o.id_mode_paiement " +
                            "WHERE id_compte = @idCompte AND o.date<=@date";
        public const string OPERATIONS_MIN_DATE = "SELECT min(date) FROM operations WHERE id_compte = @idCompte ";
        public const string OPERATIONS_MAX_DATE = "SELECT max(date) FROM operations WHERE id_compte = @idCompte ";
        public const string OPERATIONS_GROUP_BY_CATEGORIES_DC = "SELECT c.libelle as libelle, sum(case when m.type = 'D' then montant*(-1) else montant*0 end) as totalD, sum(case when m.type = 'C' then montant else montant*0 end) as totalC " +
                            "FROM operations o INNER JOIN mode_paiement m ON m.id = o.id_mode_paiement INNER JOIN categories c ON o.id_categories = c.id " +
                            "WHERE id_compte = @idCompte " +
                            "Group By id_categories";
        public const string OPERATIONS_ID = "SELECT * FROM operations WHERE id=@id";
        public const string OPERATIONS_DELETE_ID = "DELETE FROM operations WHERE id=@id";
        public const string OPERATIONS_UPDATE_ID = "UPDATE operations SET date=@date, id_mode_paiement=@id_mode_paiement, tiers=@tiers, libelle=@libelle," +
                            " id_categories=@id_categories, montant=@montant, id_compte=@id_compte, date_pointage=@date_pointage WHERE id=@id";
        public const string OPERATIONS_INSERT = "INSERT INTO operations(id,date,id_mode_paiement,tiers,libelle,id_categories,montant,date_pointage,id_compte) VALUES(null,@date,@id_mode_paiement,@tiers,@libelle,@id_categories,@montant,@date_pointage,@id_compte)";
        public const string OPERATIONS_CHARGE_GRILLE = "SELECT o.id as \"Id Op\", o.date as \"Date\",mp.libelle as \"Mode de Paiement\",o.tiers as \"Tiers\",o.libelle as \"Libelle\",ca.libelle as \"Categories\",(CASE mp.type='D' WHEN 1 THEN CAST(montant as TEXT) ELSE \"\" END) as \"Debit\",(CASE mp.type='D' WHEN 1 THEN \"\" ELSE CAST(montant as TEXT) END) as \"Credit\", date_pointage as \"Date de Pointage\" FROM " +
                            "operations o " +
                            "INNER JOIN categories ca ON o.id_categories = ca.id " +
                            "INNER JOIN comptes co ON o.id_compte = co.id " +
                            "INNER JOIN mode_paiement mp ON o.id_mode_paiement = mp.id " +
                            "WHERE id_compte={0} " +
                            "ORDER BY  date desc, date_pointage ASC";
        public const string OPERATIONS_CHARGE_GRILLE_FILTRE = "SELECT o.id as \"Id Op\", o.date as \"Date\",mp.libelle as \"Mode de Paiement\",o.tiers as \"Tiers\",o.libelle as \"Libelle\",ca.libelle as \"Categories\",(CASE mp.type='D' WHEN 1 THEN CAST(montant as TEXT) ELSE \"\" END) as \"Debit\",(CASE mp.type='D' WHEN 1 THEN \"\" ELSE CAST(montant as TEXT) END) as \"Credit\", date_pointage as \"Date de Pointage\" FROM " +
                           "operations o " +
                           "INNER JOIN categories ca ON o.id_categories = ca.id " +
                           "INNER JOIN comptes co ON o.id_compte = co.id " +
                           "INNER JOIN mode_paiement mp ON o.id_mode_paiement = mp.id " +
                           "WHERE id_compte={0} ";
        public const string OPERATIONS_CHARGE_LISTE_GRILLE = "SELECT o.id as \"Id Op\", o.date as \"Date\",mp.libelle as \"Mode de Paiement\",o.tiers as \"Tiers\",o.libelle as \"Libelle\",ca.libelle as \"Categories\",(CASE mp.type='D' WHEN 1 THEN CAST(montant as TEXT) ELSE \"\" END) as \"Debit\",(CASE mp.type='D' WHEN 1 THEN \"\" ELSE CAST(montant as TEXT) END) as \"Credit\", date_pointage as \"Date de Pointage\" FROM " +
                           "operations o " +
                           "INNER JOIN categories ca ON o.id_categories = ca.id " +
                           "INNER JOIN comptes co ON o.id_compte = co.id " +
                           "INNER JOIN mode_paiement mp ON o.id_mode_paiement = mp.id " +
                           "WHERE id_compte=@id " +
                           "ORDER BY date_pointage ASC, date ASC";
        public const string OPERATIONS_MAJ_CATEGORIE = "UPDATE operations SET id_categories=@idCatDest WHERE id_categories=@idCatOri AND id_compte=@idCompte";

        #endregion

        public static void InitialiseBD(string path)
        {
            string pathComplete = "Data Source=" + path + @"\orionbanque.db3";
            // Création de la base de données si il n'existe pas
            if (!System.IO.File.Exists(path + @"\orionbanque.db3"))
            {
                #region creation fichier si pas existe
                try
                {
                    string sql = "CREATE TABLE [categories] (" +
                        "[id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                        "[libelle] VARCHAR(250)  NOT NULL," +
                        "[id_parent] INTEGER  NULL" +
                        ")";
                    string myConnectionString = path;
                    SQLiteConnection conn = new SQLiteConnection(pathComplete);
                    conn.Open();
                    CallContext.SetData(Classe.Sql.CLE_CONNECTION, conn);

                    SQLiteCommand cmd = new SQLiteCommand
                    {
                        Connection = conn,
                        CommandText = sql
                    };
                    cmd.ExecuteNonQuery();

                    sql = "CREATE TABLE [comptes] (" +
                           "[id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                           "[libelle] VARCHAR(250) NOT NULL," +
                           "[solde_initial] FLOAT NOT NULL," +
                           "[id_utilisateur] INTEGER NOT NULL," +
                           "[banque] VARCHAR(45) NOT NULL," +
                           "[guichet] VARCHAR(45) NOT NULL," +
                           "[compte] VARCHAR(45) NOT NULL," +
                           "[clef] VARCHAR(45) NOT NULL," +
                           "[mingraphsold] DATE NOT NULL, " +
                           "[maxgraphsold] DATE NOT NULL, " +
                           "[soldeseuil] FLOAT NOT NULL," +
                           "[typevol] VARCHAR(50) NULL," +
                           "[soldeseuilfinal] FLOAT DEFAULT '0.0' NOT NULL" + 
                           ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "CREATE TABLE [echeanciers] (" +
                            "[id] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "[prochaine] DATE  NOT NULL," +
                            "[id_mode_paiement] INTEGER  NOT NULL," +
                            "[tiers] VARCHAR(250)  NOT NULL," +
                            "[libelle] VARCHAR(250)  NOT NULL," +
                            "[id_categories] INTEGER  NOT NULL," +
                            "[montant] FLOAT  NOT NULL," +
                            "[id_compte] INTEGER  NOT NULL," +
                            "[repete] INTEGER  NOT NULL," +
                            "[type_repete] VARCHAR(1)  NOT NULL," +
                            "[date_fin] DATE  NULL" +
                            ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "CREATE TABLE [mode_paiement] (" +
                            "[id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                            "[libelle] VARCHAR(250)  NOT NULL," +
                            "[type] VARCHAR(1)  NOT NULL" +
                            ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "CREATE TABLE [operations] (" +
                            "[id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                            "[date] DATE  NOT NULL," +
                            "[id_mode_paiement] INTEGER  NOT NULL," +
                            "[tiers] VARCHAR(250)  NOT NULL," +
                            "[libelle] VARCHAR(250)  NULL," +
                            "[id_categories] INTEGER  NOT NULL," +
                            "[montant] FLOAT  NOT NULL," +
                            "[date_pointage] DATE  NULL," +
                            "[id_compte] INTEGER  NOT NULL" +
                            ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "CREATE TABLE [param] (" +
                            "[Id] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "[Ident] VARCHAR(250)  NULL," +
                            "[Val1] TEXT  NULL," +
                            "[Val2] TEXT  NULL," +
                            "[Val3] TEXT  NULL," +
                            "[Int1] INTEGER DEFAULT '''0''' NULL," +
                            "[Int2] INTEGER DEFAULT '''0''' NULL," +
                            "[Int3] INTEGER DEFAULT '''0''' NULL," +
                            "[Dec1] FLOAT DEFAULT '''0.0''' NULL," +
                            "[Dec2] FLOAT DEFAULT '''0.0''' NULL," +
                            "[Dec3] FLOAT DEFAULT '''0.0''' NULL," +
                            "[Dat1] DATE  NULL," +
                            "[Dat2] DATE  NULL," +
                            "[Dat3] DATE  NULL" +
                            ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "CREATE TABLE [utilisateurs] (" +
                            "[id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                            "[login] VARCHAR(250)  NOT NULL," +
                            "[mdp] VARCHAR(250)  NOT NULL" +
                            ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "INSERT INTO categories VALUES(null,\"Aucune\",0); " +
                            "INSERT INTO categories VALUES(null,\"Alimentation\",0);  " +
                            "INSERT INTO categories VALUES(null,\"Epicerie\",2); " +
                            "INSERT INTO categories VALUES(null,\"Restaurant\",2); " +
                            "INSERT INTO categories VALUES(null,\"Loisirs\",0); " +
                            "INSERT INTO categories VALUES(null,\"Sortie spectacle\",5); " +
                            "INSERT INTO categories VALUES(null,\"Sports\",5); " +
                            "INSERT INTO categories VALUES(null,\"Hifi vidéo\",5); " +
                            "INSERT INTO categories VALUES(null,\"Téléphonie\",5); " +
                            "INSERT INTO categories VALUES(null,\"Habillement\",0); " +
                            "INSERT INTO categories VALUES(null,\"Habitation\",0); " +
                            "INSERT INTO categories VALUES(null,\"Loyer\",11); " +
                            "INSERT INTO categories VALUES(null,\"Téléphone\",11); " +
                            "INSERT INTO categories VALUES(null,\"EDF\",11); " +
                            "INSERT INTO categories VALUES(null,\"Equipement\",11); " +
                            "INSERT INTO categories VALUES(null,\"Décoration\",11); " +
                            "INSERT INTO categories VALUES(null,\"Abonnement\",11); " +
                            "INSERT INTO categories VALUES(null,\"Assurance\",11); " +
                            "INSERT INTO categories VALUES(null,\"Santé\",0); " +
                            "INSERT INTO categories VALUES(null,\"Médecine\",19); " +
                            "INSERT INTO categories VALUES(null,\"Pharmacie\",19); " +
                            "INSERT INTO categories VALUES(null,\"Transport\",0); " +
                            "INSERT INTO categories VALUES(null,\"Essence\",22); " +
                            "INSERT INTO categories VALUES(null,\"Assurance\",22); " +
                            "INSERT INTO categories VALUES(null,\"Réparations\",22); " +
                            "INSERT INTO categories VALUES(null,\"Public\",22); " +
                            "INSERT INTO categories VALUES(null,\"Parking\",22); " +
                            "INSERT INTO categories VALUES(null,\"Péage\",22); " +
                            "INSERT INTO categories VALUES(null,\"Revenus\",0); " +
                            "INSERT INTO categories VALUES(null,\"Paye\",29); " +
                            "INSERT INTO categories VALUES(null,\"Autre\",29); ";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "INSERT INTO mode_paiement VALUES(null,\"Carte\",\"D\"); " +
                            "INSERT INTO mode_paiement VALUES(null,\"Retrait DAB\",\"D\"); " +
                            "INSERT INTO mode_paiement VALUES(null,\"Prélèvement\",\"D\"); " +
                            "INSERT INTO mode_paiement VALUES(null,\"Virement émis\",\"D\"); " +
                            "INSERT INTO mode_paiement VALUES(null,\"Virement reçu\",\"C\"); " +
                            "INSERT INTO mode_paiement VALUES(null,\"Versement\",\"C\"); " +
                            "INSERT INTO mode_paiement VALUES(null,\"Dépôt de chèque\",\"C\"); " +
                            "INSERT INTO mode_paiement VALUES(null,\"Chèque émis\",\"D\"); ";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    string pathUpdate =  @".\SQL\Update.txt";
                    if(System.IO.File.Exists(pathUpdate))
                    {
                        System.IO.File.Delete(pathUpdate);
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception(String.Format(Classe.SQLite.Messages.SQLite_ERROR_GENERAL, ex.ErrorCode, ex.Message));
                }
                #endregion
            }
            else
            {
                #region mise à jour du fichier si besoin
                SQLiteConnection conn = new SQLiteConnection(pathComplete); conn.Open();
                CallContext.SetData(Classe.Sql.CLE_CONNECTION, conn);

                /*int VersionFuture = int.Parse(ConfigurationManager.AppSettings["VersionAppli"]);
                int VersionActuelle = int.Parse(Classe.Param.Charge(KEY.KEY_APPLI_VERSION)[0].Val1);*/
                #endregion
            }
        }

        public static SQLiteConnection GetConnection()
        {
            if (((SQLiteConnection)CallContext.GetData(Classe.Sql.CLE_CONNECTION)).State != System.Data.ConnectionState.Open)
            {
                ((SQLiteConnection)CallContext.GetData(Classe.Sql.CLE_CONNECTION)).Open();
            }

            return (SQLiteConnection)CallContext.GetData(Classe.Sql.CLE_CONNECTION);
        }

        public static int GetLastInsertId()
        {
            SQLiteCommand cmd = new SQLiteCommand(@"select last_insert_rowid()", SQLite.Sql.GetConnection());
            var ret = cmd.ExecuteScalar();
            return int.Parse(ret.ToString());
        }
    }
}
