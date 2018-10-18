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

        static public void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Compte.Delete(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Delete(Compte c)
        {
            Compte.Delete(c.Id);
        }

        static public Compte Charge(int id)
        {
            Compte c = new Compte();
            
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    c = OrionBanque.Classe.SQLite.Compte.Charge(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return c;
        }

        static public List<Compte> ChargeTout(Int32 idU)
        {
            List<Compte> lc = new List<Compte>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = OrionBanque.Classe.SQLite.Compte.ChargeTout(idU);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lc;
        }

        static public void Maj(Compte c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Compte.Maj(c);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Sauve(Compte c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Compte.Sauve(c);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
