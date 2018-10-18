using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace OrionBanque.Classe
{
    class Echeancier
    {
        public int Id { get; set; }
        public DateTime Prochaine { get; set; }
        public string Tiers { get; set; }
        public string Libelle { get; set; }
        public double Montant { get; set; }
        public int IdModePaiement { get; set; }
        public int IdCategorie { get; set; }
        public int IdCompte { get; set; }
        public int Repete { get; set; }
        public string TypeRepete { get; set; }
        public DateTime? DateFin { get; set; }

        static public Int32 InsereEcheance(DateTime DateInsereEch, Int32 idCompte)
        {
            Int32 retour;
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Echeancier.InsereEcheance(DateInsereEch, idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return retour;
        }

        static public void Sauve(Echeancier e)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Echeancier.Sauve(e);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public List<Classe.Echeancier> ChargeTout(Int32 idCompte)
        {
            List<Classe.Echeancier> le = new List<Echeancier>();
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    le = OrionBanque.Classe.SQLite.Echeancier.ChargeTout(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return le;
        }

        static public void Maj(Echeancier e)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Echeancier.Maj(e);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public DataSet ChargeGrilleEcheance(Int32 idCompte)
        {
            DataSet retour = new DataSet();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Echeancier.ChargeGrilleEcheance(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public Echeancier Charge(int id)
        {
            Echeancier e = new Echeancier();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    e = OrionBanque.Classe.SQLite.Echeancier.Charge(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return e;
        }

        static public void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Echeancier.Delete(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
