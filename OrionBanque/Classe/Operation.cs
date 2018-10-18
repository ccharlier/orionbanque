using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace OrionBanque.Classe
{
    class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Tiers { get; set; }
        public string Libelle { get; set; }
        public double Montant { get; set; }
        public DateTime? DatePointage { get; set; }
        public int IdModePaiement { get; set; }
        public int IdCategorie { get; set; }
        public int IdCompte { get; set; }

        static public List<Classe.Operation> ChargeTout(Int32 idCompte)
        {
            List<Classe.Operation> ls = new List<Operation>();
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    ls = OrionBanque.Classe.SQLite.Operation.ChargeTout(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return ls;
        }

        static public Int32 ChercheChequeSuivant(Int32 idCompte)
        {
            Int32 retour = 0;
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.ChercheChequeSuivant(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return retour;
        }

        static public void MajCategorieOperations(Int32 idCompte, Int32 idCatOri, Int32 idCatDest)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Operation.MajCategorieOperations(idCompte, idCatOri, idCatDest);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public double SoldeCompteAt(DateTime dt, Int32 idC)
        {
            double retour = 0.0;
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.SoldeCompteAt(dt, idC);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return retour;
        }

        static public DateTime GetMaxDate(Int32 idC)
        {
            DateTime retour = DateTime.Now;
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.GetMaxDate(idC);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return retour;
        }

        static public DateTime GetMinDate(Int32 idC)
        {
            DateTime retour = DateTime.Now;
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.GetMinDate(idC);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return retour;
        }

        static public void Sauve(Classe.Operation o)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Operation.Sauve(o);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public List<String> ChargeToutTiers(Int32 idCompte)
        {
            List<String> ls = new List<String>();
            
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    ls = OrionBanque.Classe.SQLite.Operation.ChargeToutTiers(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            
            return ls;
        }

        static public double CalculAVenir(Int32 idCompte)
        {
            double retour = 0.0;

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.CalculAVenir(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public double CalculSoldOpePoint(Int32 idCompte)
        {
            double retour = 0.0;

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.CalculSoldOpePoint(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public void Maj(Classe.Operation o)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Operation.Maj(o);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public List<string[]> GroupByTiers(Int32 idC)
        {
            List<string[]> retour = new List<string[]>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.GroupByTiers(idC);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public List<string[]> GroupByTiersDC(Int32 idC)
        {
            List<string[]> retour = new List<string[]>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.GroupByTiersDC(idC);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public List<string[]> GroupByCategories(Int32 idC)
        {
            List<string[]> retour = new List<string[]>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.GroupByCategories(idC);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public List<string[]> GroupByCategoriesDC(Int32 idC)
        {
            List<string[]> retour = new List<string[]>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.GroupByCategoriesDC(idC);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public DataSet ChargeGrilleOperation(Int32 idCompte)
        {
            DataSet retour = new DataSet();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.ChargeGrilleOperation(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public DataSet ChargeGrilleOperationFiltre(int idCompte,
                                bool bDate, string cbFiltreDate, DateTime txtFiltreDate,
                                bool bModePaiement, string txtFiltreModePaiement,
                                bool bTiers, string txtFiltreTiers,
                                bool bCategorie, string txtFiltreCategorie,
                                bool bMontant, string cbFiltreMontant, double txtFiltreMontant, bool bNonPointe)
        {
            DataSet retour = new DataSet();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.ChargeGrilleOperationFiltre(idCompte,
                                bDate, cbFiltreDate, txtFiltreDate,
                                bModePaiement, txtFiltreModePaiement,
                                bTiers, txtFiltreTiers,
                                bCategorie, txtFiltreCategorie,
                                bMontant, cbFiltreMontant, txtFiltreMontant, bNonPointe);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public List<Classe.Operation> ChargeGrilleListeOperation(Int32 idCompte)
        {
            List<Classe.Operation> retour = new List<Classe.Operation>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    retour = OrionBanque.Classe.SQLite.Operation.ChargeGrilleListeOperation(idCompte);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return retour;
        }

        static public Operation Charge(int id)
        {
            Operation o = new Operation();
            
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    o = OrionBanque.Classe.SQLite.Operation.Charge(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            
            return o;
        }

        static public void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Operation.Delete(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
