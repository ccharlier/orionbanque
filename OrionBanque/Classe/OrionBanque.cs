using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "OB", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class OB
    {
        [DataMember()]
        public List<Categorie> Categories { get; set; }
        [DataMember()]
        public List<Compte> Comptes { get; set; }
        [DataMember()]
        public List<Echeancier> Echeanciers { get; set; }
        [DataMember()]
        public List<ModePaiement> ModePaiements { get; set; }
        [DataMember()]
        public List<Operation> Operations { get; set; }
        [DataMember()]
        public List<Param> Params { get; set; }
        [DataMember()]
        public List<Utilisateur> Utilisateurs { get; set; }
        [DataMember()]
        public List<Fichier> Fichiers { get; set; }
        [DataMember()]
        public string Theme { get; set; }

        public OB()
        {
            Categories = new List<Categorie>();
            Comptes = new List<Compte>();
            Echeanciers = new List<Echeancier>();
            ModePaiements = new List<ModePaiement>();
            Operations = new List<Operation>();
            Params = new List<Param>();
            Utilisateurs = new List<Utilisateur>();
            Fichiers = new List<Fichier>();
        }
    }
}
