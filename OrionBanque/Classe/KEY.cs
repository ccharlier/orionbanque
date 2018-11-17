namespace OrionBanque.Classe
{
    public class KEY
    {
        public const string CLE_CONNECTION = "CLE_CONNECTION";
        public const string MODE_UPDATE = "UPDATE";
        public const string MODE_INSERT = "INSERT";
        public const string REP_FICHIER_OP = "fichier_op";
        public const string BD_SQLITE = "SQLite";
        public const string BD_BINARY = "Binary";
        public const string BD_MYSQL = "MySQL";
        public const string OB = "DonneesOrionBanque";
        public const string VERSION = "2.0.0";
        public const string KEY_USER_CONNECTED = "KEY_USER_CONNECTED";
        public const string KEY_APPLI_VERSION = "KEY_APPLI_VERSION";
        public const string ECHEANCIER_JOUR = "J";
        public const string ECHEANCIER_JOUR_LIB = "Jour(s)";
        public const string ECHEANCIER_MOIS = "M";
        public const string ECHEANCIER_MOIS_LIB = "Mois";
        public const string ECHEANCIER_ANNEE = "A";
        public const string ECHEANCIER_ANNEE_LIB = "Année(s)";
        public const string MODEPAIEMENT_DEBIT = "D";
        public const string MODEPAIEMENT_CREDIT = "C";
        public const string MODEPAIEMENT_DEBIT_LIB = "Débit";
        public const string MODEPAIEMENT_CREDIT_LIB = "Crédit";
        public const string COMPARAISON_INF_EGALE = "<=";
        public const string COMPARAISON_EGALE = "=";
        public const string COMPARAISON_SUP_EGALE = ">=";
        public const string COMPTE_VISU_1MOIS = "1 mois";
        public const string COMPTE_VISU_3MOIS = "3 mois";
        public const string COMPTE_VISU_6MOIS = "6 mois";
        public const string COMPTE_VISU_1AN = "1 an";
        public const string FILE_NAME = "orionbanque.obq";
        public static string ROOT_PATH = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        public static string FILE_PATH = ROOT_PATH + @"\OrionBanque\" + FILE_NAME;
        public static string DIRECTORY_PATH = ROOT_PATH + @"\OrionBanque\";
        public static string FILE_OPERATION_PATH = DIRECTORY_PATH + @"FILE_OPERATION\";
        public static string FILE_BACKUP_PATH = DIRECTORY_PATH + @"BACKUP\";
        public const string GRAPH_TIERS = "tiers";
        public const string GRAPH_TIERS_DC = "tiersDC";
        public const string GRAPH_CATEGORIES = "categories";
        public const string GRAPH_CATEGORIES_DC = "categoriesDC";
        public const string GRAPH_TIERS_LIB = "Par Tiers";
        public const string GRAPH_TIERS_DC_LIB = "Par Tiers Dissociés";
        public const string GRAPH_CATEGORIES_LIB = "Par Catégories";
        public const string GRAPH_CATEGORIES_DC_LIB = "Par Catégories Dissociées";
        public const string TYPE_FICHIER_FILE = "FILE";
    }
}
