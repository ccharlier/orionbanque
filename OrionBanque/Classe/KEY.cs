namespace OrionBanque.Classe
{
    public static class KEY
    {
        public const string ALERTESUPPRESSIONCOMPTE = "Etes-vous sur de supprimer ce Compte ? (plus aucun accès au compte ne sera possible)";
        public const string ALERTEENREGISTREMENT = "Fichier Sauvegardé sous {0}";
        public const string ALERTESUPPRESSIONOPERATIONS = "Etes-vous sur de vouloir supprimer les Opérations sélectionnées ?";
        public const string ALERTESUPPRESSIONOPERATION = "Etes-vous sur de vouloir supprimer l'Opérations sélectionnée ?";
        public const string ERREURPASDECOMPTECREE = "Vous devez d'abord créer un compte pour accéder à cette fonctionnalité.";
        public const string CLEFICHIER = "CLE_FICHIER";
        public const string MODEUPDATE = "UPDATE";
        public const string MODEINSERT = "INSERT";
        public const string REPFICHIEROP = "fichier_op";
        public const string BDSQLITE = "SQLite";
        public const string BDBINARY = "Binary";
        public const string BDMYSQL = "MySQL";
        public const string OB = "DonneesOrionBanque";
        public const string VERSION = "2.0.0";
        public const string KEYUSERCONNECTED = "KEY_USER_CONNECTED";
        public const string KEYAPPLIVERSION = "KEY_APPLI_VERSION";
        public const string ECHEANCIERJOUR = "J";
        public const string ECHEANCIERJOURLIB = "Jour(s)";
        public const string ECHEANCIERMOIS = "M";
        public const string ECHEANCIERMOISLIB = "Mois";
        public const string ECHEANCIERANNEE = "A";
        public const string ECHEANCIERANNEELIB = "Année(s)";
        public const string MODEPAIEMENTDEBIT = "D";
        public const string MODEPAIEMENTCREDIT = "C";
        public const string MODEPAIEMENTDEBITLIB = "Débit";
        public const string MODEPAIEMENTCREDITLIB = "Crédit";
        public const string COMPARAISONINFEGALE = "<=";
        public const string COMPARAISONEGALE = "=";
        public const string COMPARAISONSUPEGALE = ">=";
        public const string COMPTEVISU1MOIS = "1 mois";
        public const string COMPTEVISU3MOIS = "3 mois";
        public const string COMPTEVISU6MOIS = "6 mois";
        public const string COMPTEVISU1AN = "1 an";
        public const string FILENAME = "orionbanque.obq";
        private static string rOOTPATH = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        private static string fILEPATH = ROOTPATH + @"\OrionBanque\" + FILENAME;
        private static string fILELISTPATH = ROOTPATH + @"\OrionBanque\ListFichier.obq";
        private static string dIRECTORYPATH = ROOTPATH + @"\OrionBanque\";
        private static string fILEOPERATIONPATH = @"FILE_OPERATION\";
        private static string fILEBACKUPPATH = @"BACKUP\";
        public const string GRAPHTIERS = "tiers";
        public const string GRAPHTIERSDC = "tiersDC";
        public const string GRAPHCATEGORIES = "categories";
        public const string GRAPHCATEGORIESDC = "categoriesDC";
        public const string GRAPHTIERSLIB = "Par Tiers";
        public const string GRAPHTIERSDCLIB = "Par Tiers Dissociés";
        public const string GRAPHCATEGORIESLIB = "Par Catégories";
        public const string GRAPHCATEGORIESDCLIB = "Par Catégories Dissociées";
        public const string TYPEFICHIERFILE = "FILE";
        public const string TYPELIENOPERATIONTRANSFERT = "TRANSFERT";
        public const string TYPELIENOPERATIONCBDIFFERE = "CB_DIFFERE";

        public static string ROOTPATH { get => rOOTPATH; }
        public static string FILEPATH { get => fILEPATH; }
        public static string FILELISTPATH { get => fILELISTPATH; }
        public static string DIRECTORYPATH { get => dIRECTORYPATH; }
        public static string FILEOPERATIONPATH { get => fILEOPERATIONPATH; }
        public static string FILEBACKUPPATH { get => fILEBACKUPPATH; }
    }
}
