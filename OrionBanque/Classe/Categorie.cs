using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Categorie", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Categorie
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public Categorie CategorieParent { get; set; }

        /// <summary>
        /// Récupère l'ensemble des catégories
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        public static List<Categorie> ChargeTout()
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Categorie.ChargeTout();
                case Configuration.BD_BINARY:
                    return Binary.Categorie.ChargeTout();
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Récupère l'ensemble des catégories dont le libellé affiche le chemin avec le parent
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        public static List<Categorie> ChargeToutIdent()
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Categorie.ChargeToutIdent();
                case Configuration.BD_BINARY:
                    return Binary.Categorie.ChargeToutIdent();
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Récupère l'ensemble des catégories de premier niveau
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        public static List<Categorie> ChargeCategorieParent()
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Categorie.ChargeCategorieParent();
                case Configuration.BD_BINARY:
                    return Binary.Categorie.ChargeCategorieParent();
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Récupère l'ensemble des catégoeie enfant de la catégorie passée en paramètre
        /// </summary>
        /// <param name="idCat">Identifiant de la catégorie Parente</param>
        /// <returns>Liste de Categorie</returns>
        public static List<Categorie> ChargeCategorieDeParent(int idCat)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Categorie.ChargeCategorieDeParent(idCat);
                case Configuration.BD_BINARY:
                    return Binary.Categorie.ChargeCategorieDeParent(idCat);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Récupère la catégorie dont l'identifiant est passé en paramêtre
        /// </summary>
        /// <param name="id">Identifiant de la catégorie</param>
        /// <returns>Categorie</returns>
        public static Categorie Charge(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Categorie.Charge(id);
                case Configuration.BD_BINARY:
                    return Binary.Categorie.Charge(id);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        /// <summary>
        /// Récupère la catégorie dont le nom est passé en paramêtre
        /// </summary>
        /// <param name="nom">Nom de la catégorie</param>
        /// <returns>Categorie</returns>
        public static Categorie ChargeParNom(string nom)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    return SQLite.Categorie.ChargeParNom(nom);
                case Configuration.BD_BINARY:
                    return Binary.Categorie.ChargeParNom(nom);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        public static void DeletePossible(int id)
        {
            switch (ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    SQLite.Categorie.DeletePossible(id);
                    break;
                case Configuration.BD_BINARY:
                    Binary.Categorie.DeletePossible(id);
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
                case Configuration.BD_BINARY:
                    Binary.Categorie.Delete(id);
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
                case Configuration.BD_BINARY:
                    return Binary.Categorie.Maj(c);
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
                case Configuration.BD_BINARY:
                    return Binary.Categorie.Sauve(c);
                default:
                    throw new Exception(string.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
