using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrionBanque.Classe
{
    public class Compte
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public double SoldeInitial { get; set; }
        public int IdUtilisateur { get; set; }
        public string Banque { get; set; }
        public string Guichet { get; set; }
        public string NoCompte { get; set; }
        public string Clef { get; set; }
        public DateTime MinGraphSold { get; set; }
        public DateTime MaxGraphSold { get; set; }
        public double SeuilAlerte { get; set; }
        public double SeuilAlerteFinal { get; set; }
        public string TypEvol { get; set; }

        public static void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    SQLite.Compte.Delete(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Delete(Compte c)
        {
            Compte.Delete(c.Id);
        }

        public static Compte Charge(int id)
        {
            Compte c = new Compte();
            
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    c = SQLite.Compte.Charge(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return c;
        }

        public static List<Compte> ChargeTout(int idU)
        {
            List<Compte> lc = new List<Compte>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = SQLite.Compte.ChargeTout(idU);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lc;
        }

        public static Compte Maj(Compte c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Compte.Maj(c);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Compte Sauve(Compte c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Compte.Sauve(c);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
