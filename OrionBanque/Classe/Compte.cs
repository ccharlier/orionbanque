using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Compte", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Compte
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public double SoldeInitial { get; set; }
        [DataMember()]
        public Utilisateur Utilisateur { get; set; }
        [DataMember()]
        public string Banque { get; set; }
        [DataMember()]
        public string Guichet { get; set; }
        [DataMember()]
        public string NoCompte { get; set; }
        [DataMember()]
        public string Clef { get; set; }
        [DataMember()]
        public DateTime MinGraphSold { get; set; }
        [DataMember()]
        public DateTime MaxGraphSold { get; set; }
        [DataMember()]
        public double SeuilAlerte { get; set; }
        [DataMember()]
        public double SeuilAlerteFinal { get; set; }
        [DataMember()]
        public string TypEvol { get; set; }

        public static void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    SQLite.Compte.Delete(id);
                    break;
                case Configuration.BD_BINARY:
                    Binary.Compte.Delete(id);
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
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Compte.Charge(id);
                case Configuration.BD_BINARY:
                    return Binary.Compte.Charge(id);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Compte> ChargeTout()
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Compte.ChargeTout();
                case Configuration.BD_BINARY:
                    return Binary.Compte.ChargeTout();
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Compte> ChargeTout(Utilisateur u)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Compte.ChargeTout(u);
                case Configuration.BD_BINARY:
                    return Binary.Compte.ChargeTout(u);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Compte Maj(Compte c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Compte.Maj(c);
                case Configuration.BD_BINARY:
                    return Binary.Compte.Maj(c);
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
                case Configuration.BD_BINARY:
                    return Binary.Compte.Sauve(c);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
