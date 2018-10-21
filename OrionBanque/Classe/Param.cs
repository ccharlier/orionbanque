using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OrionBanque.Classe
{
    public class Param
    {
        public int Id { get; set; }
        public string Ident { get; set; }
        public string Val1 { get; set; }
        public string Val2 { get; set; }
        public string Val3 { get; set; }
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        public int Int3 { get; set; }
        public double Dec1 { get; set; }
        public double Dec2 { get; set; }
        public double Dec3 { get; set; }
        public DateTime Dat1 { get; set; }
        public DateTime Dat2 { get; set; }
        public DateTime Dat3 { get; set; }

        public Param()
        {
            Ident = string.Empty;
            Val1 = string.Empty;
            Val2 = string.Empty;
            Val3 = string.Empty;
            Int1 = int.MinValue;
            Int2 = int.MinValue;
            Int3 = int.MinValue;
            Dec1 = double.MinValue;
            Dec2 = double.MinValue;
            Dec3 = double.MinValue;
            Dat1 = DateTime.MinValue;
            Dat2 = DateTime.MinValue;
            Dat3 = DateTime.MinValue;
        }

        public static Param Charge(int id)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Param.Charge(id);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Param> Charge(string ident)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Param.Charge(ident);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Delete(int id)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    SQLite.Param.Delete(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Delete(string ident)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    SQLite.Param.Delete(ident);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Param Maj(Param p)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Param.Maj(p);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Param Sauve(Param p)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Param.Sauve(p);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
