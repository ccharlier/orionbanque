using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrionBanque.Classe
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Mdp { get; set; }

        static public void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Utilisateur.Delete(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));

            }
        }

        static public void Delete(OrionBanque.Classe.Utilisateur u)
        {
            OrionBanque.Classe.Utilisateur.Delete(u.Id);
        }

        static public OrionBanque.Classe.Utilisateur Charge(int id)
        {
            OrionBanque.Classe.Utilisateur u = new OrionBanque.Classe.Utilisateur();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    u = OrionBanque.Classe.SQLite.Utilisateur.Charge(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));

            }

            return u;
        }

        static public OrionBanque.Classe.Utilisateur Charge(string login)
        {
            OrionBanque.Classe.Utilisateur u = new OrionBanque.Classe.Utilisateur();
            
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    u = OrionBanque.Classe.SQLite.Utilisateur.Charge(login);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return u;
        }

        static public void Maj(OrionBanque.Classe.Utilisateur u)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Utilisateur.Maj(u);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Sauve(OrionBanque.Classe.Utilisateur u)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Utilisateur.Sauve(u);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Utilisateur> ChargeTout()
        {
            List<Utilisateur> lu = new List<Utilisateur>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lu = SQLite.Utilisateur.ChargeTout();
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lu;
        }
    }
}
