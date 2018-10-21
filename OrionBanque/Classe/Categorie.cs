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
        public static List<Categorie> ChargeTout()
        {
            List<Categorie> lc = new List<Categorie>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = SQLite.Categorie.ChargeTout();
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lc;
        }

        /// <summary>
        /// Récupère l'ensemble des catégories dont le libellé affiche le chemin avec le parent
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        public static List<Categorie> ChargeToutIdent()
        {
            List<Categorie> lc = new List<Categorie>();
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = SQLite.Categorie.ChargeToutIdent();
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return lc;
        }

        /// <summary>
        /// Récupère l'ensemble des catégories de premier niveau
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        public static List<Categorie> ChargeCategorieParent()
        {
            List<Categorie> lc = new List<Categorie>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = SQLite.Categorie.ChargeCategorieParent();
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lc;
        }

        /// <summary>
        /// Récupère l'ensemble des catégoeie enfant de la catégorie passée en paramètre
        /// </summary>
        /// <param name="idCat">Identifiant de la catégorie Parente</param>
        /// <returns>Liste de Categorie</returns>
        public static List<Categorie> ChargeCategorieDeParent(int idCat)
        {
            List<Categorie> lc = new List<Categorie>();

            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    lc = SQLite.Categorie.ChargeCategorieDeParent(idCat);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return lc;
        }

        /// <summary>
        /// Récupère la catégorie dont l'identifiant est passé en paramêtre
        /// </summary>
        /// <param name="id">Identifiant de la catégorie</param>
        /// <returns>Categorie</returns>
        public static Categorie Charge(int id)
        {
            Categorie c = new Categorie();
            
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    c = SQLite.Categorie.Charge(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }

            return c;
        }

        /// <summary>
        /// Récupère la catégorie dont le nom est passé en paramêtre
        /// </summary>
        /// <param name="nom">Nom de la catégorie</param>
        /// <returns>Categorie</returns>
        public static Categorie ChargeParNom(string nom)
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

        public static void DeletePossible(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    SQLite.Categorie.DeletePossible(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Supprime la Categorie dont l'identifiant est passé en paramêtre
        /// </summary>
        /// <param name="id">Identifiant de la Cateogie à supprimer</param>
        public static void Delete(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    SQLite.Categorie.Delete(id);
                    break;
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Met à jour la Categorie passée en paramêtre
        /// </summary>
        /// <param name="c">Categoie à mettre à jour</param>
        public static Categorie Maj(Categorie c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Categorie.Maj(c);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Créer la Categorie passée en paramêtre
        /// </summary>
        /// <param name="c">Categorie à créer</param>
        public static Categorie Sauve(Categorie c)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Categorie.Sauve(c);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
