using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrionBanque.Classe;

namespace OrionBanque.Outils
{
    class ImportBP
    {
        public static bool Lance(string fileName, Compte c)
        {
            //Date;ModeDePaiement;PaiementDebitOuCredit;Tiers;Libelle;Categories;Montant;DatePointage
            if (File.Exists(fileName))
            {
                StreamReader sr;

                sr = new StreamReader(fileName, true);
                string contenu;
                while ((contenu = sr.ReadLine()) != null)
                {
                    //Date;Mode;Tiers;Libelle;Categories;Sous Categorie;Montant;Pointage
                    string[] t = contenu.Split('\t');
                    
                    Operation o = new Operation();

                    // Prise en charge du compte
                    o.IdCompte = c.Id;

                    // Prise en charge de la date
                    o.Date = new DateTime( int.Parse(t[0].Split('/')[2]), int.Parse(t[0].Split('/')[1]), int.Parse(t[0].Split('/')[0]) );

                    // Prise en charge du mode de paiement
                    o.IdModePaiement = GetModePaiement(t[1], t[6]).Id;

                    // Prise en charge du Tiers
                    o.Tiers = t[2];

                    // Prise en charge du libelle
                    o.Libelle = t[3];

                    // Prise en charge de la categorie
                    o.IdCategorie = GetCategorie(t[4], t[5]).Id;

                    // Prise en charge du montant
                    if (t[2] == "Solde initial")
                    {
                        o.Montant = double.Parse(t[6]);
                    }
                    else
                    {
                        o.Montant = Math.Abs(double.Parse(t[6]));
                    }

                    // Prise en charge du pointage
                    if (t[7] != "-")
                    {
                        o.DatePointage = DateTime.Now;
                    }

                    Operation.Sauve(o);

                }
                sr.Close();
            }
            else
            {
                throw new Exception("Le fichier d'import n'existe pas.");
            }

            return true;
        }

        public static Categorie GetCategorie(string catL, string scatL)
        {
            Categorie retour = Categorie.ChargeParNom(catL);
            if (retour.Id == 0)
            {
                // Création de la categorie elle n'existe pas
                retour.Libelle = catL;
                Categorie.Sauve(retour);
                retour = Categorie.ChargeParNom(catL);
            }

            // Exist-il une sous catégorie dans le fichier BP
            if (scatL != string.Empty)
            {
                bool found = false;
                List<Categorie> lscat = Categorie.ChargeCategorieDeParent(retour.Id);
                foreach (Categorie tempscat in lscat)
                {
                    // Est-ce qu'une sous catgorie OB est égale à une sous catégorie BP
                    if (tempscat.Libelle == scatL)
                    {
                        found = true;
                        // on effecte la sous categorie trouvée à l'operation
                        retour = tempscat;
                        break;
                    }
                }

                if (!found)
                {
                    // On n'a pas trouvé la sous catégorie, on doit la créer
                    Categorie scat = new Categorie();
                    scat.Libelle = scatL;
                    scat.IdParent = retour.Id;
                    Categorie.Sauve(scat);

                    lscat = Categorie.ChargeCategorieDeParent(retour.Id);
                    foreach (Categorie tempscat in lscat)
                    {
                        // Est-ce qu'une sous catgorie OB est égale à une sous catégorie BP
                        if (tempscat.Libelle == scatL)
                        {
                            // on effecte la sous categorie trouvée à l'operation
                            retour = tempscat;
                            break;
                        }
                    }
                }
            }
            else // La sous catégorie BP est vide, on prend donc la catégorie BP comme catégorie OB
            {
                retour = Categorie.ChargeParNom(catL);
            }
            return retour;
        }

        public static ModePaiement GetModePaiement(string mp, string mnt)
        {
            ModePaiement retour = ModePaiement.ChargeParNom(mp);
            if (retour.Id == 0)
            {
                // Création du mode de paiement car il n'existe pas
                retour.Libelle = mp;
                if (double.Parse(mnt) > 0)
                {
                    // Le montant est positif=> Crédit
                    retour.Type = "C";
                }
                else
                {
                    // le montant est négatif => Débit
                    retour.Type = "D";
                }
                ModePaiement.Sauve(retour);
                retour = ModePaiement.ChargeParNom(mp);
            }
            return retour;
        }
    }
}
