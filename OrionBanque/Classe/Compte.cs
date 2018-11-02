using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Compte", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Compte
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public double SoldeInitial { get; set; }
        [DataMember()]
        public Utilisateur Utilisateur { get; set; }
        [DataMember()]
        public string Banque { get; set; }
        [DataMember()]
        public string Guichet { get; set; }
        [DataMember()]
        public string NoCompte { get; set; }
        [DataMember()]
        public string Clef { get; set; }
        [DataMember()]
        public DateTime MinGraphSold { get; set; }
        [DataMember()]
        public DateTime MaxGraphSold { get; set; }
        [DataMember()]
        public double SeuilAlerte { get; set; }
        [DataMember()]
        public double SeuilAlerteFinal { get; set; }
        [DataMember()]
        public string TypEvol { get; set; }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Compte.Delete(" + id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Operations.RemoveAll((c) => c.Compte.Id == id);
                ob = (OB)CallContext.GetData(KEY.OB);
                ob.Echeanciers.RemoveAll((c) => c.Compte.Id == id);
                ob = (OB)CallContext.GetData(KEY.OB);
                ob.Comptes.RemoveAll((c) => c.Id == id);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static void Delete(Compte c)
        {
            Delete(c.Id);
        }

        public static Compte Charge(int id)
        {
            Log.Logger.Debug("Debut Compte.Charge(" + id + ")");
            Compte c = new Compte();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                c = ob.Comptes.Where(ct => ct.Id == id).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return c;
        }

        public static List<Compte> ChargeTout()
        {
            Log.Logger.Debug("Debut Compte.ChargeTout()");
            List<Compte> lc = new List<Compte>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lc = ob.Comptes.OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static List<Compte> ChargeTout(Utilisateur u)
        {
            Log.Logger.Debug("Debut Compte.ChargeTout()");
            List<Compte> lc = new List<Compte>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lc = ob.Comptes.Where(c => c.Utilisateur.Id == u.Id).OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static Compte Maj(Compte cA)
        {
            Log.Logger.Debug("Debut Compte.Maj(" + cA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);

                Compte c = ob.Comptes.Find((ctemp) => ctemp.Id == cA.Id);
                c.Libelle = cA.Libelle;
                c.SoldeInitial = cA.SoldeInitial;
                c.Banque = cA.Banque;
                c.Guichet = cA.Guichet;
                c.NoCompte = cA.NoCompte;
                c.Clef = cA.Clef;
                c.MinGraphSold = cA.MinGraphSold;
                c.MaxGraphSold = cA.MaxGraphSold;
                c.SeuilAlerte = cA.SeuilAlerte;
                c.SeuilAlerteFinal = cA.SeuilAlerteFinal;
                c.TypEvol = cA.TypEvol;
                c.Utilisateur = cA.Utilisateur;

                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return cA;
        }

        public static Compte Sauve(Compte c)
        {
            Log.Logger.Debug("Debut Copmpte.Sauve(" + c.Libelle + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                c.Id = ob.Comptes.Count != 0 ? ob.Comptes.Max(u => u.Id) + 1 : 1;
                ob.Comptes.Add(c);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return c;
        }
    }
}
