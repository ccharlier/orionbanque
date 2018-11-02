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

            if (!System.IO.File.Exists(KEY.FILE_PATH))
            {
                try
                {
                    OB ob = new OB();
                    Categorie c1 = new Categorie { Id = 1, Libelle = "Aucune", CategorieParent = new Categorie() };
                    Categorie c2 = new Categorie { Id = 2, Libelle = "Alimentation", CategorieParent = new Categorie() };
                    Categorie c3 = new Categorie { Id = 3, Libelle = "Epicerie", CategorieParent = c2 };
                    Categorie c4 = new Categorie { Id = 4, Libelle = "Restaurant", CategorieParent = c2 };
                    Categorie c5 = new Categorie { Id = 5, Libelle = "Loisirs", CategorieParent = new Categorie() };
                    Categorie c6 = new Categorie { Id = 6, Libelle = "Sortie spectacle", CategorieParent = c5 };
                    Categorie c7 = new Categorie { Id = 7, Libelle = "Sports", CategorieParent = c5 };
                    Categorie c8 = new Categorie { Id = 8, Libelle = "Hifi vidéo", CategorieParent = c5 };
                    Categorie c9 = new Categorie { Id = 9, Libelle = "Téléphonie", CategorieParent = c5 };
                    Categorie c10 = new Categorie { Id = 10, Libelle = "Habillement", CategorieParent = new Categorie() };
                    Categorie c11 = new Categorie { Id = 11, Libelle = "Habitation", CategorieParent = new Categorie() };
                    Categorie c12 = new Categorie { Id = 12, Libelle = "Loyer", CategorieParent = c11 };
                    Categorie c13 = new Categorie { Id = 13, Libelle = "Téléphone", CategorieParent = c11 };
                    Categorie c14 = new Categorie { Id = 14, Libelle = "Electricité", CategorieParent = c11 };
                    Categorie c15 = new Categorie { Id = 15, Libelle = "Equipement", CategorieParent = c11 };
                    Categorie c16 = new Categorie { Id = 16, Libelle = "Décoration", CategorieParent = c11 };
                    Categorie c17 = new Categorie { Id = 17, Libelle = "Abonnement", CategorieParent = c11 };
                    Categorie c18 = new Categorie { Id = 18, Libelle = "Assurance", CategorieParent = c11 };
                    Categorie c19 = new Categorie { Id = 19, Libelle = "Santé", CategorieParent = new Categorie() };
                    Categorie c20 = new Categorie { Id = 20, Libelle = "Médecine", CategorieParent = c19 };
                    Categorie c21 = new Categorie { Id = 21, Libelle = "Pharmacie", CategorieParent = c19 };
                    Categorie c22 = new Categorie { Id = 22, Libelle = "Transport", CategorieParent = new Categorie() };
                    Categorie c23 = new Categorie { Id = 23, Libelle = "Essence", CategorieParent = c22 };
                    Categorie c24 = new Categorie { Id = 24, Libelle = "Assurance", CategorieParent = c22 };
                    Categorie c25 = new Categorie { Id = 25, Libelle = "Réparation", CategorieParent = c22 };
                    Categorie c26 = new Categorie { Id = 26, Libelle = "Public", CategorieParent = c22 };
                    Categorie c27 = new Categorie { Id = 27, Libelle = "Parking", CategorieParent = c22 };
                    Categorie c28 = new Categorie { Id = 28, Libelle = "Péage", CategorieParent = c22 };
                    Categorie c29 = new Categorie { Id = 29, Libelle = "Revenus", CategorieParent = new Categorie() };
                    Categorie c30 = new Categorie { Id = 30, Libelle = "Paye", CategorieParent = c29 };
                    Categorie c31 = new Categorie { Id = 31, Libelle = "Autre", CategorieParent = c29 };

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

                    ob.ModePaiements.Add(new ModePaiement { Id = 1, Libelle = "Carte", Type = KEY.MODEPAIEMENT_DEBIT });
                    ob.ModePaiements.Add(new ModePaiement { Id = 2, Libelle = "Retrait DAB", Type = KEY.MODEPAIEMENT_DEBIT });
                    ob.ModePaiements.Add(new ModePaiement { Id = 3, Libelle = "Prélèvement", Type = KEY.MODEPAIEMENT_DEBIT });
                    ob.ModePaiements.Add(new ModePaiement { Id = 4, Libelle = "Virement émis", Type = KEY.MODEPAIEMENT_DEBIT });
                    ob.ModePaiements.Add(new ModePaiement { Id = 5, Libelle = "Virement reçu", Type = KEY.MODEPAIEMENT_CREDIT });
                    ob.ModePaiements.Add(new ModePaiement { Id = 6, Libelle = "Versement", Type = KEY.MODEPAIEMENT_CREDIT });
                    ob.ModePaiements.Add(new ModePaiement { Id = 7, Libelle = "Dépôt de chèque", Type = KEY.MODEPAIEMENT_CREDIT });
                    ob.ModePaiements.Add(new ModePaiement { Id = 8, Libelle = "Chèque émis", Type = KEY.MODEPAIEMENT_DEBIT });

                    CallContext.SetData(KEY.OB, ob);

                    Outils.GestionFichier.Sauvegarde(KEY.FILE_PATH, ob);
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    throw;
                }
            }
            else
            {
                Outils.GestionFichier.Charge(KEY.FILE_PATH);
            }
        }
    }
}
