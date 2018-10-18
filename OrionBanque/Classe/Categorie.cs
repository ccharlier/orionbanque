using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrionBanque.Classe
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int IdParent { get; set; }

        /// <summary>
        /// Récupère l'ensemble des catégories
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        static public List<Categorie> ChargeTout()
        {
            List<Categorie> lc = new List<Categorie>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = OrionBanque.Classe.SQLite.Categorie.ChargeTout();
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lc;
        }

        /// <summary>
        /// Récupère l'ensemble des catégories dont le libellé affiche le chemin avec le parent
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        static public List<Categorie> ChargeToutIdent()
        {
            List<Categorie> lc = new List<Categorie>();
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = OrionBanque.Classe.SQLite.Categorie.ChargeToutIdent();
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return lc;
        }

        /// <summary>
        /// Récupère l'ensemble des catégories de premier niveau
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        static public List<Categorie> ChargeCategorieParent()
        {
            List<Categorie> lc = new List<Categorie>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = OrionBanque.Classe.SQLite.Categorie.ChargeCategorieParent();
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lc;
        }

        /// <summary>
        /// Récupère l'ensemble des catégoeie enfant de la catégorie passée en paramètre
        /// </summary>
        /// <param name="idCat">Identifiant de la catégorie Parente</param>
        /// <returns>Liste de Categorie</returns>
        static public List<Categorie> ChargeCategorieDeParent(Int32 idCat)
        {
            List<Categorie> lc = new List<Categorie>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = OrionBanque.Classe.SQLite.Categorie.ChargeCategorieDeParent(idCat);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lc;
        }

        /// <summary>
        /// Récupère la catégorie dont l'identifiant est passé en paramêtre
        /// </summary>
        /// <param name="id">Identifiant de la catégorie</param>
        /// <returns>Categorie</returns>
        static public Categorie Charge(Int32 id)
        {
            Categorie c = new Categorie();
            
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    c = OrionBanque.Classe.SQLite.Categorie.Charge(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return c;
        }

        /// <summary>
        /// Récupère la catégorie dont le nom est passé en paramêtre
        /// </summary>
        /// <param name="nom">Nom de la catégorie</param>
        /// <returns>Categorie</returns>
        static public Categorie ChargeParNom(string nom)
        {
            Categorie c = new Categorie();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    c = SQLite.Categorie.ChargeParNom(nom);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return c;
        }

        static public void DeletePossible(Int32 id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Categorie.DeletePossible(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Supprime la Categorie dont l'identifiant est passé en paramêtre
        /// </summary>
        /// <param name="id">Identifiant de la Cateogie à supprimer</param>
        static public void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Categorie.Delete(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Met à jour la Categorie passée en paramêtre
        /// </summary>
        /// <param name="c">Categoie à mettre à jour</param>
        static public void Maj(Categorie c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Categorie.Maj(c);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Créer la Categorie passée en paramêtre
        /// </summary>
        /// <param name="c">Categorie à créer</param>
        static public void Sauve(Categorie c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Categorie.Sauve(c);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
