﻿
namespace OrionBanque.Classe
{
    class KEY
    {
        public const string VERSION = "2.0.0";
        public const string KEY_USER_CONNECTED = "KEY_USER_CONNECTED";
        public const string KEY_APPLI_VERSION = "KEY_APPLI_VERSION";
        public const string KEY_OB = "OB";
        public const string ECHEANCIER_JOUR = "J";
        public const string ECHEANCIER_JOUR_TEXTE = "J";
        public const string ECHEANCIER_MOIS = "M";
        public const string ECHEANCIER_MOIS_TEXTE = "M";
        public const string ECHEANCIER_ANNEE = "A";
        public const string ECHEANCIER_ANNEE_TEXTE = "A";
        public const string MODEPAIEMENT_DEBIT = "D";
        public const string MODEPAIEMENT_CREDIT = "C";
        public static string BINARY_PATH_COMPLETE = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\orionbanque.obq";
    }
}
