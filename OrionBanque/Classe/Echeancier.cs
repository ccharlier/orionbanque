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

        public static int InsereEcheance(DateTime DateInsereEch, int idCompte)
        {
            int retour;
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = SQLite.Echeancier.InsereEcheance(DateInsereEch, idCompte);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return retour;
        }

        public static Echeancier Sauve(Echeancier e)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Echeancier.Sauve(e);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Echeancier> ChargeTout(int idCompte)
        {
            List<Echeancier> le = new List<Echeancier>();
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    le = SQLite.Echeancier.ChargeTout(idCompte);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return le;
        }

        public static Echeancier Maj(Echeancier e)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Echeancier.Maj(e);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static DataSet ChargeGrilleEcheance(int idCompte)
        {
            DataSet retour = new DataSet();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = SQLite.Echeancier.ChargeGrilleEcheance(idCompte);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        public static Echeancier Charge(int id)
        {
            Echeancier e = new Echeancier();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    e = SQLite.Echeancier.Charge(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return e;
        }

        public static void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    SQLite.Echeancier.Delete(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
