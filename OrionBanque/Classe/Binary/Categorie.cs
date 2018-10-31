using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace OrionBanque.Classe.Binary
{
    public class Categorie
    {
        public static List<Classe.Categorie> ChargeTout()
        {
            Log.Logger.Debug("Categorie.ChargeTout()");
            List<Classe.Categorie> lc = new List<Classe.Categorie>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lc = ob.Categories.OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static List<Classe.Categorie> ChargeToutIdent()
        {
            List<Classe.Categorie> retour = new List<Classe.Categorie>();
            List<Classe.Categorie> lcParent = ChargeCategorieParent();
            foreach (Classe.Categorie c in lcParent)
            {
                retour.Add(c);
                List<Classe.Categorie> lcEnfant = Classe.Categorie.ChargeCategorieDeParent(c.Id);
                foreach (Classe.Categorie c2 in lcEnfant)
                {
                    retour.Add(c2);
                }
            }
            return retour;
        }

        public static List<Classe.Categorie> ChargeCategorieParent()
        {
            Log.Logger.Debug("Debut Categorie.ChargeCategorieParent()");
            List<Classe.Categorie> lc = new List<Classe.Categorie>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lc = ob.Categories.Where(c => c.CategorieParent.Id ==0).OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static List<Classe.Categorie> ChargeCategorieDeParent(int idCat)
        {
            Log.Logger.Debug("Debut Categorie.ChargeCategorieDeParent()");
            List<Classe.Categorie> lc = new List<Classe.Categorie>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lc = ob.Categories.Where(c => c.CategorieParent.Id == idCat).OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static Classe.Categorie Charge(int id)
        {
            Log.Logger.Debug("Debut Categorie.Charge(" + id + ")");
            if (id.Equals(0))
            {
                return new Classe.Categorie();
            }

            Classe.Categorie c = new Classe.Categorie();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                c = ob.Categories.Where(ct => ct.Id == id).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return c;
        }

        public static Classe.Categorie ChargeParNom(string nom)
        {
            Log.Logger.Debug("Debut Categorie.Charge(" + nom + ")");
            Classe.Categorie c;
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                c = ob.Categories.Where(ct => ct.Libelle == nom).DefaultIfEmpty().First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            c = c ?? new Classe.Categorie();
            return c;
        }

        public static void DeletePossible(int id)
        {
            Log.Logger.Debug("Debut Categorie.DeletePossible(" + id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                List<Classe.Operation> lo = ob.Operations.Where(o => o.Categorie.Id == id).ToList();
                if (lo.Count !=0)
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

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Categorie.Delete(" + id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                ob.Categories.RemoveAll((c) => c.Id == id);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static Classe.Categorie Maj(Classe.Categorie cA)
        {
            Log.Logger.Debug("Debut Categorie.Maj(" + cA.Id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                Classe.Categorie c = ob.Categories.Find((ctemp) => ctemp.Id == cA.Id);
                c.Libelle = cA.Libelle;
                c.CategorieParent = cA.CategorieParent;
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return cA;
        }

        public static Classe.Categorie Sauve(Classe.Categorie cA)
        {
            Log.Logger.Debug("Debut Categorie.Sauve(" + cA.Libelle + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                cA.Id = ob.Categories.Count != 0 ? ob.Categories.Max(u => u.Id) + 1 : 1;
                ob.Categories.Add(cA);
                CallContext.SetData(Classe.KEY.OB, ob);
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
