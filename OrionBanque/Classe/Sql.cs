using System;
using System.Configuration;
using System.Runtime.Remoting.Messaging;

namespace OrionBanque.Classe
{
    class Sql
    {
        public static void InitialiseBD(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            if (!System.IO.File.Exists(Classe.KEY.BINARY_PATH_COMPLETE))
            {
                try
                {
                    Classe.OB ob = new Classe.OB();
                    var c1 = new Classe.Categorie { Id = 1, Libelle = "Aucune", CategorieParent = new Classe.Categorie() };
                    var c2 = new Classe.Categorie { Id = 2, Libelle = "Alimentation", CategorieParent = new Classe.Categorie() };
                    var c3 = new Classe.Categorie { Id = 3, Libelle = "Epicerie", CategorieParent = c2 };
                    var c4 = new Classe.Categorie { Id = 4, Libelle = "Restaurant", CategorieParent = c2 };
                    var c5 = new Classe.Categorie { Id = 5, Libelle = "Loisirs", CategorieParent = new Classe.Categorie() };
                    var c6 = new Classe.Categorie { Id = 6, Libelle = "Sortie spectacle", CategorieParent = c5 };
                    var c7 = new Classe.Categorie { Id = 7, Libelle = "Sports", CategorieParent = c5 };
                    var c8 = new Classe.Categorie { Id = 8, Libelle = "Hifi vidéo", CategorieParent = c5 };
                    var c9 = new Classe.Categorie { Id = 9, Libelle = "Téléphonie", CategorieParent = c5 };
                    var c10 = new Classe.Categorie { Id = 10, Libelle = "Habillement", CategorieParent = new Classe.Categorie() };
                    var c11 = new Classe.Categorie { Id = 11, Libelle = "Habitation", CategorieParent = new Classe.Categorie() };
                    var c12 = new Classe.Categorie { Id = 12, Libelle = "Loyer", CategorieParent = c11 };
                    var c13 = new Classe.Categorie { Id = 13, Libelle = "Téléphone", CategorieParent = c11 };
                    var c14 = new Classe.Categorie { Id = 14, Libelle = "Electricité", CategorieParent = c11 };
                    var c15 = new Classe.Categorie { Id = 15, Libelle = "Equipement", CategorieParent = c11 };
                    var c16 = new Classe.Categorie { Id = 16, Libelle = "Décoration", CategorieParent = c11 };
                    var c17 = new Classe.Categorie { Id = 17, Libelle = "Abonnement", CategorieParent = c11 };
                    var c18 = new Classe.Categorie { Id = 18, Libelle = "Assurance", CategorieParent = c11 };
                    var c19 = new Classe.Categorie { Id = 19, Libelle = "Santé", CategorieParent = new Classe.Categorie() };
                    var c20 = new Classe.Categorie { Id = 20, Libelle = "Médecine", CategorieParent = c19 };
                    var c21 = new Classe.Categorie { Id = 21, Libelle = "Pharmacie", CategorieParent = c19 };
                    var c22 = new Classe.Categorie { Id = 22, Libelle = "Transport", CategorieParent = new Classe.Categorie() };
                    var c23 = new Classe.Categorie { Id = 23, Libelle = "Essence", CategorieParent = c22 };
                    var c24 = new Classe.Categorie { Id = 24, Libelle = "Assurance", CategorieParent = c22 };
                    var c25 = new Classe.Categorie { Id = 25, Libelle = "Réparation", CategorieParent = c22 };
                    var c26 = new Classe.Categorie { Id = 26, Libelle = "Public", CategorieParent = c22 };
                    var c27 = new Classe.Categorie { Id = 27, Libelle = "Parking", CategorieParent = c22 };
                    var c28 = new Classe.Categorie { Id = 28, Libelle = "Péage", CategorieParent = c22 };
                    var c29 = new Classe.Categorie { Id = 29, Libelle = "Revenus", CategorieParent = new Classe.Categorie() };
                    var c30 = new Classe.Categorie { Id = 30, Libelle = "Paye", CategorieParent = c29 };
                    var c31 = new Classe.Categorie { Id = 31, Libelle = "Autre", CategorieParent = c29 };

                    ob.Categories.Add(c1);
                    ob.Categories.Add(c2);
                    ob.Categories.Add(c3);
                    ob.Categories.Add(c4);
                    ob.Categories.Add(c5);
                    ob.Categories.Add(c6);
                    ob.Categories.Add(c7);
                    ob.Categories.Add(c8);
                    ob.Categories.Add(c9);
                    ob.Categories.Add(c10);
                    ob.Categories.Add(c11);
                    ob.Categories.Add(c12);
                    ob.Categories.Add(c13);
                    ob.Categories.Add(c14);
                    ob.Categories.Add(c15);
                    ob.Categories.Add(c16);
                    ob.Categories.Add(c17);
                    ob.Categories.Add(c18);
                    ob.Categories.Add(c19);
                    ob.Categories.Add(c20);
                    ob.Categories.Add(c21);
                    ob.Categories.Add(c22);
                    ob.Categories.Add(c23);
                    ob.Categories.Add(c24);
                    ob.Categories.Add(c25);
                    ob.Categories.Add(c26);
                    ob.Categories.Add(c27);
                    ob.Categories.Add(c28);
                    ob.Categories.Add(c29);
                    ob.Categories.Add(c30);
                    ob.Categories.Add(c31);

                    ob.ModePaiements.Add(new Classe.ModePaiement { Id = 1, Libelle = "Carte", Type = Classe.KEY.MODEPAIEMENT_DEBIT });
                    ob.ModePaiements.Add(new Classe.ModePaiement { Id = 2, Libelle = "Retrait DAB", Type = Classe.KEY.MODEPAIEMENT_DEBIT });
                    ob.ModePaiements.Add(new Classe.ModePaiement { Id = 3, Libelle = "Prélèvement", Type = Classe.KEY.MODEPAIEMENT_DEBIT });
                    ob.ModePaiements.Add(new Classe.ModePaiement { Id = 4, Libelle = "Virement émis", Type = Classe.KEY.MODEPAIEMENT_DEBIT });
                    ob.ModePaiements.Add(new Classe.ModePaiement { Id = 5, Libelle = "Virement reçu", Type = Classe.KEY.MODEPAIEMENT_CREDIT });
                    ob.ModePaiements.Add(new Classe.ModePaiement { Id = 6, Libelle = "Versement", Type = Classe.KEY.MODEPAIEMENT_CREDIT });
                    ob.ModePaiements.Add(new Classe.ModePaiement { Id = 7, Libelle = "Dépôt de chèque", Type = Classe.KEY.MODEPAIEMENT_CREDIT });
                    ob.ModePaiements.Add(new Classe.ModePaiement { Id = 8, Libelle = "Chèque émis", Type = Classe.KEY.MODEPAIEMENT_DEBIT });

                    CallContext.SetData(Classe.KEY.OB, ob);
                }
                catch (Exception ex)
                {
                    Classe.Log.Logger.Error(ex.Message);
                    throw;
                }
            }
            else
            {
                Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
            }
        }
    }
}
