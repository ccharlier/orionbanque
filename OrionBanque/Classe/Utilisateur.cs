using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Utilisateur", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Utilisateur
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Login { get; set; }
        [DataMember()]
        public string Mdp { get; set; }

        public static void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    SQLite.Utilisateur.Delete(id);
                    break;
                case KEY.BD_BINARY:
                    Binary.Utilisateur.Delete(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Delete(Utilisateur u)
        {
            Utilisateur.Delete(u.Id);
        }

        public static Utilisateur Charge(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Utilisateur.Charge(id);
                case KEY.BD_BINARY:
                    return Binary.Utilisateur.Charge(id);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Utilisateur Charge(string login)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Utilisateur.Charge(login);
                case KEY.BD_BINARY:
                    return Binary.Utilisateur.Charge(login);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Utilisateur Maj(Utilisateur u)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Utilisateur.Maj(u);
                case KEY.BD_BINARY:
                    return Binary.Utilisateur.Maj(u);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Utilisateur Sauve(Utilisateur u)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Utilisateur.Sauve(u);
                case KEY.BD_BINARY:
                    return Binary.Utilisateur.Sauve(u);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Utilisateur> ChargeTout()
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Utilisateur.ChargeTout();
                case KEY.BD_BINARY:
                    return Binary.Utilisateur.ChargeTout();
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
