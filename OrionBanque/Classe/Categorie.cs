using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public string LibelleIdent { get => CategorieParent.Id == 0 ? Libelle : "\t->" + Libelle; }

        public static List<Categorie> ChargeTout()
        {
            Log.Logger.Debug("Categorie.ChargeTout()");
            List<Categorie> lc = new List<Categorie>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lc = ob.Categories.OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static List<Categorie> ChargeToutIdent()
        {
            List<Categorie> retour = new List<Categorie>();
            List<Categorie> lcParent = ChargeCategorieParent();
            foreach (Categorie c in lcParent)
            {
                retour.Add(c);
                List<Categorie> lcEnfant = ChargeCategorieDeParent(c);
                foreach (Categorie c2 in lcEnfant)
                {
                    retour.Add(c2);
                }
            }
            return retour;
        }

        public static List<Categorie> ChargeCategorieParent()
        {
            Log.Logger.Debug("Debut Categorie.ChargeCategorieParent()");
            List<Categorie> lc = new List<Categorie>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lc = ob.Categories.Where(c => c.CategorieParent.Id == 0).OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static List<Categorie> ChargeCategorieDeParent(Categorie c)
        {
            Log.Logger.Debug("Debut Categorie.ChargeCategorieDeParent()");
            List<Categorie> lc = new List<Categorie>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lc = ob.Categories.Where(ct => ct.CategorieParent.Id == c.Id).OrderBy(ct => ct.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Categorie.ChargeCategorieParent() avec " + lc.Count + " elements");
            return lc;
        }

        public static Categorie Charge(int id)
        {
            Log.Logger.Debug("Debut Categorie.Charge(" + id + ")");
            if (id.Equals(0))
            {
                return new Categorie();
            }
            Categorie c = new Categorie();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                c = ob.Categories.Where(ct => ct.Id == id).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return c;
        }

        public static Categorie ChargeParNom(string nom)
        {
            Log.Logger.Debug("Debut Categorie.Charge(" + nom + ")");
            Categorie c;
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                c = ob.Categories.Where(ct => ct.Libelle == nom).DefaultIfEmpty().First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            c = c ?? new Categorie();
            return c;
        }

        public static void DeletePossible(Categorie c)
        {
            Log.Logger.Debug("Debut Categorie.DeletePossible(" + c.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                List<Operation> lo = ob.Operations.Where(ct => ct.Categorie.Id == c.Id).ToList();
                if (lo.Count != 0)
                {
                    throw new Exception("Vous devez d'abord modifier vos Opérations pour qu'elles ne pointent plus sur cette Catégorie.");
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static void Delete(Categorie c)
        {
            Log.Logger.Debug("Debut Categorie.Delete(" + c.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Categories.RemoveAll(ct => ct.Id == c.Id);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static Categorie Maj(Categorie cA)
        {
            Log.Logger.Debug("Debut Categorie.Maj(" + cA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                Categorie c = ob.Categories.Find((ctemp) => ctemp.Id == cA.Id);
                c.Libelle = cA.Libelle;
                c.CategorieParent = cA.CategorieParent;
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return cA;
        }

        public static Categorie Sauve(Categorie cA)
        {
            Log.Logger.Debug("Debut Categorie.Sauve(" + cA.Libelle + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                cA.Id = ob.Categories.Count != 0 ? ob.Categories.Max(u => u.Id) + 1 : 1;
                ob.Categories.Add(cA);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return cA;
        }
    }
}