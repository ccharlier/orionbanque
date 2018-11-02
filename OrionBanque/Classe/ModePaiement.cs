using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "ModePaiement", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class ModePaiement
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public string Type { get; set; }

        public static List<ModePaiement> ChargeTout()
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.ModePaiement.ChargeTout();
                case KEY.BD_BINARY:
                    return Binary.ModePaiement.ChargeTout();
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static ModePaiement Charge(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.ModePaiement.Charge(id);
                case KEY.BD_BINARY:
                    return Binary.ModePaiement.Charge(id);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static ModePaiement ChargeParNom(string nom)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.ModePaiement.ChargeParNom(nom);
                case KEY.BD_BINARY:
                    return Binary.ModePaiement.ChargeParNom(nom);
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void DeletePossible(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    SQLite.ModePaiement.DeletePossible(id);
                    break;
                case KEY.BD_BINARY:
                    Binary.ModePaiement.DeletePossible(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    SQLite.ModePaiement.Delete(id);
                    break;
                case KEY.BD_BINARY:
                    Binary.ModePaiement.Delete(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static ModePaiement Maj(ModePaiement mp)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.ModePaiement.Maj(mp);
                case KEY.BD_BINARY:
                    return Binary.ModePaiement.Maj(mp);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static ModePaiement Sauve(ModePaiement mp)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.ModePaiement.Sauve(mp);
                case KEY.BD_BINARY:
                    return Binary.ModePaiement.Sauve(mp);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
