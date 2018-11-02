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
                case KEY.BD_SQLITE:
                    SQLite.Sql.InitialiseBD(path);
                    break;
                case KEY.BD_BINARY:
                    Binary.Sql.InitialiseBD(path);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static int GetLastInsertId()
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Sql.GetLastInsertId();
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
