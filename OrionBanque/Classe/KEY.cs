namespace OrionBanque.Classe
{
    class KEY
    {
        public const string CLE_CONNECTION = "CLE_CONNECTION";
        public const string BD_SQLITE = "SQLite";
        public const string BD_BINARY = "Binary";
        public const string BD_MYSQL = "MySQL";
        public const string OB = "DonneesOrionBanque";
        public const string VERSION = "2.0.0";
        public const string KEY_USER_CONNECTED = "KEY_USER_CONNECTED";
        public const string KEY_APPLI_VERSION = "KEY_APPLI_VERSION";
        public const string ECHEANCIER_JOUR = "J";
        public const string ECHEANCIER_JOUR_TEXTE = "J";
        public const string ECHEANCIER_MOIS = "M";
        public const string ECHEANCIER_MOIS_TEXTE = "M";
        public const string ECHEANCIER_ANNEE = "A";
        public const string ECHEANCIER_ANNEE_TEXTE = "A";
        public const string MODEPAIEMENT_DEBIT = "D";
        public const string MODEPAIEMENT_CREDIT = "C";
        public const string COMPARAISON_INF_EGALE = "<=";
        public const string COMPARAISON_EGALE = "=";
        public const string COMPARAISON_SUP_EGALE = ">=";
        public const string COMPTE_VISU_1MOIS = "1 mois";
        public const string COMPTE_VISU_3MOIS = "3 mois";
        public const string COMPTE_VISU_6MOIS = "6 mois";
        public const string COMPTE_VISU_1AN = "1 an";
        public static string BINARY_PATH_COMPLETE = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\OrionBanque\orionbanque.obq";
    }
}
