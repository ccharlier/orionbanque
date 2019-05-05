using System;

namespace OrionBanque.Classe
{
    public static class OrionAide
    {
        private static string titreImport = "Aide à l'import";
        private static string textImport = "Pour qu'OrionBanque importe correctement vos opérations, vous devez les présenter d'une façon bien précise." +
            Environment.NewLine + "Voici la structure du fichier que vous devez constituer :" +
            Environment.NewLine + "* Une opération par ligne" +
            Environment.NewLine + "* Chaque champs est séparé par des ';' ce qui implique qu'aucun ';' ne dois être présent dans les libellés" +
            Environment.NewLine + "* Tous les montants sont positifs" +
            Environment.NewLine + "* Le troisième champs est : D pour débit ou C pour crédit" +
            Environment.NewLine + Environment.NewLine + "Voici la structure du fichier attendu : " +
            Environment.NewLine + "Date;ModeDePaiement;PaiementDebitOuCredit;Tiers;Libelle;Categories;Montant;DatePointage";

        public static string TitreImport { get => titreImport; }
        public static string TextImport { get => textImport; }
    }
}
