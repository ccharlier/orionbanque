using System;
using System.Configuration;

namespace OrionBanque.Classe
{
    class Sql
    {
        public const string CLE_CONNECTION = "CLE_CONNECTION";

        public static void InitialiseBD(string path)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Sql.InitialiseBD(path);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
