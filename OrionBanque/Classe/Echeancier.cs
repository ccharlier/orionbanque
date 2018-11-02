using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Echeancier", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Echeancier
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public DateTime Prochaine { get; set; }
        [DataMember()]
        public string Tiers { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public double Montant { get; set; }
        [DataMember()]
        public ModePaiement ModePaiement { get; set; }
        [DataMember()]
        public Categorie Categorie { get; set; }
        [DataMember()]
        public Compte Compte { get; set; }
        [DataMember()]
        public int Repete { get; set; }
        [DataMember()]
        public string TypeRepete { get; set; }
        [DataMember()]
        public DateTime? DateFin { get; set; }

        public static int InsereEcheance(DateTime DateInsereEch, int idCompte)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Echeancier.InsereEcheance(DateInsereEch, idCompte);
                case KEY.BD_BINARY:
                    return Binary.Echeancier.InsereEcheance(DateInsereEch, idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Echeancier Sauve(Echeancier e)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Echeancier.Sauve(e);
                case KEY.BD_BINARY:
                    return Binary.Echeancier.Sauve(e);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Echeancier> ChargeTout(int idCompte)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Echeancier.ChargeTout(idCompte);
                case KEY.BD_BINARY:
                    return Binary.Echeancier.ChargeTout(idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Echeancier> ChargeToutUtilisateur(Utilisateur u)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Echeancier.ChargeToutUtilisateur(u);
                case KEY.BD_BINARY:
                    return Binary.Echeancier.ChargeToutUtilisateur(u);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Echeancier Maj(Echeancier e)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Echeancier.Maj(e);
                case KEY.BD_BINARY:
                    return Binary.Echeancier.Maj(e);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static DataSet ChargeGrilleEcheance(int idCompte)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Echeancier.ChargeGrilleEcheance(idCompte);
                case KEY.BD_BINARY:
                    return Binary.Echeancier.ChargeGrilleEcheance(idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Echeancier Charge(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Echeancier.Charge(id);
                case KEY.BD_BINARY:
                    return Binary.Echeancier.Charge(id);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    SQLite.Echeancier.Delete(id);
                    break;
                case KEY.BD_BINARY:
                    Binary.Echeancier.Delete(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
