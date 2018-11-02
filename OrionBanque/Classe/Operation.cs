using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Operation", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Operation
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public DateTime Date { get; set; }
        [DataMember()]
        public string Tiers { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public double Montant { get; set; }
        [DataMember()]
        public DateTime? DatePointage { get; set; }
        [DataMember()]
        public ModePaiement ModePaiement { get; set; }
        [DataMember()]
        public Categorie Categorie { get; set; }
        [DataMember()]
        public Compte Compte { get; set; }

        public static List<Operation> ChargeTout(int idCompte)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.ChargeTout(idCompte);
                case KEY.BD_BINARY:
                    return Binary.Operation.ChargeTout(idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<Operation> ChargeToutUtilisateur(Utilisateur u)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.ChargeToutUtilisateur(u);
                case KEY.BD_BINARY:
                    return Binary.Operation.ChargeToutUtilisateur(u);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static int ChercheChequeSuivant(int idCompte)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.ChercheChequeSuivant(idCompte);
                case KEY.BD_BINARY:
                    return Binary.Operation.ChercheChequeSuivant(idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void MajCategorieOperations(int idCompte, int idCatOri, int idCatDest)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    SQLite.Operation.MajCategorieOperations(idCompte, idCatOri, idCatDest);
                    break;
                case KEY.BD_BINARY:
                    Binary.Operation.MajCategorieOperations(idCompte, idCatOri, idCatDest);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static double SoldeCompteAt(DateTime dt, int idC)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.SoldeCompteAt(dt, idC);
                case KEY.BD_BINARY:
                    return Binary.Operation.SoldeCompteAt(dt, idC);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static DateTime GetMaxDate(int idC)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.GetMaxDate(idC);
                case KEY.BD_BINARY:
                    return Binary.Operation.GetMaxDate(idC);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static DateTime GetMinDate(int idC)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.GetMinDate(idC);
                case KEY.BD_BINARY:
                    return Binary.Operation.GetMinDate(idC);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Sauve(Operation o)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    SQLite.Operation.Sauve(o);
                    break;
                case KEY.BD_BINARY:
                    Binary.Operation.Sauve(o);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<string> ChargeToutTiers(int idCompte)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.ChargeToutTiers(idCompte);
                case KEY.BD_BINARY:
                    return Binary.Operation.ChargeToutTiers(idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static double CalculAVenir(int idCompte)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.CalculAVenir(idCompte);
                case KEY.BD_BINARY:
                    return Binary.Operation.CalculAVenir(idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static double CalculSoldOpePoint(int idCompte)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.CalculSoldOpePoint(idCompte);
                case KEY.BD_BINARY:
                    return Binary.Operation.CalculSoldOpePoint(idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Maj(Operation o)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    SQLite.Operation.Maj(o);
                    break;
                case KEY.BD_BINARY:
                    Binary.Operation.Maj(o);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<string[]> GroupByTiers(int idC)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.GroupByTiers(idC);
                case KEY.BD_BINARY:
                    return Binary.Operation.GroupByTiers(idC);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<string[]> GroupByTiersDC(int idC)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.GroupByTiersDC(idC);
                case KEY.BD_BINARY:
                    return Binary.Operation.GroupByTiersDC(idC);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<string[]> GroupByCategories(int idC)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.GroupByCategories(idC);
                case KEY.BD_BINARY:
                    return Binary.Operation.GroupByCategories(idC);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static List<string[]> GroupByCategoriesDC(int idC)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.GroupByCategoriesDC(idC);
                case KEY.BD_BINARY:
                    return Binary.Operation.GroupByCategoriesDC(idC);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static DataSet ChargeGrilleOperation(int idCompte)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.ChargeGrilleOperation(idCompte);
                case KEY.BD_BINARY:
                    return Binary.Operation.ChargeGrilleOperation(idCompte);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static DataSet ChargeGrilleOperationFiltre(int idCompte,
                                bool bDate, string cbFiltreDate, DateTime txtFiltreDate,
                                bool bModePaiement, string txtFiltreModePaiement,
                                bool bTiers, string txtFiltreTiers,
                                bool bCategorie, string txtFiltreCategorie,
                                bool bMontant, string cbFiltreMontant, double txtFiltreMontant, bool bNonPointe)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.ChargeGrilleOperationFiltre(idCompte,
                                bDate, cbFiltreDate, txtFiltreDate,
                                bModePaiement, txtFiltreModePaiement,
                                bTiers, txtFiltreTiers,
                                bCategorie, txtFiltreCategorie,
                                bMontant, cbFiltreMontant, txtFiltreMontant, bNonPointe);
                case KEY.BD_BINARY:
                    return Binary.Operation.ChargeGrilleOperationFiltre(idCompte,
                                bDate, cbFiltreDate, txtFiltreDate,
                                bModePaiement, txtFiltreModePaiement,
                                bTiers, txtFiltreTiers,
                                bCategorie, txtFiltreCategorie,
                                bMontant, cbFiltreMontant, txtFiltreMontant, bNonPointe);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static Operation Charge(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    return SQLite.Operation.Charge(id);
                case KEY.BD_BINARY:
                    return Binary.Operation.Charge(id);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case KEY.BD_SQLITE:
                    SQLite.Operation.Delete(id);
                    break;
                case KEY.BD_BINARY:
                    Binary.Operation.Delete(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Delete(Operation o)
        {
            Operation.Delete(o.Id);
        }
    }
}