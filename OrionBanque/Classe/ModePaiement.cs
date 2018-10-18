using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrionBanque.Classe
{
    public class ModePaiement
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Type { get; set; }

        static public List<ModePaiement> ChargeTout()
        {
            List<ModePaiement> lmp = new List<ModePaiement>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lmp = OrionBanque.Classe.SQLite.ModePaiement.ChargeTout();
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }


            return lmp;
        }

        static public ModePaiement Charge(Int32 id)
        {
            ModePaiement mp = new ModePaiement();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    mp = OrionBanque.Classe.SQLite.ModePaiement.Charge(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return mp;
        }

        static public ModePaiement ChargeParNom(string nom)
        {
            ModePaiement mp = new ModePaiement();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    mp = SQLite.ModePaiement.ChargeParNom(nom);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return mp;
        }

        static public void DeletePossible(Int32 id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.ModePaiement.DeletePossible(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.ModePaiement.Delete(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Maj(ModePaiement mp)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.ModePaiement.Maj(mp);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Sauve(ModePaiement mp)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.ModePaiement.Sauve(mp);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
