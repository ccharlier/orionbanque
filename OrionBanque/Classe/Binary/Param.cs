using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace OrionBanque.Classe.Binary
{
    /// <summary>
    /// Classe permettant de gerer les parametres
    /// </summary>
    class Param
    {
        /// <summary>
        /// Chargement de tous les parametres
        /// </summary>
        /// <returns>Lsite de Param</returns>
        public static List<Classe.Param> ChargeTout()
        {
            Log.Logger.Debug("Debut Param.ChargeTout()");
            List<Classe.Param> lp = new List<Classe.Param>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lp = ob.Params;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lp;
        }

        /// <summary>
        /// Chargement d'un parametre
        /// </summary>
        /// <param name="id">Id du parametre</param>
        /// <returns>Parametre charge</returns>
        public static Classe.Param Charge(int id)
        {
            Log.Logger.Debug("Debut Categorie.Charge("+ id +")");
            Classe.Param p = new Classe.Param();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                p = ob.Params.Find(pt => pt.Id == id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return p;
        }

        /// <summary>
        /// Chargement d'une liste de parametre
        /// </summary>
        /// <param name="ident">Identifiant de la liste de parametre a charger</param>
        /// <returns>Liste de Parametre</returns>
        public static List<Classe.Param> Charge(string ident)
        {
            Log.Logger.Debug("Debut Categorie.Charge(" + ident + ")");
            List<Classe.Param> lp = new List<Classe.Param>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lp = ob.Params.Where(pt => pt.Ident == ident).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Param.Charge(ident)");
            return lp;
        }

        /// <summary>
        /// Pouvoir supprimer un parametre celon son id
        /// </summary>
        /// <param name="id">Id du parametre a supprimer</param>
        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Param.Delete(" + id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                ob.Params.RemoveAll((p) => p.Id == id);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Param.Delete");
        }

        /// <summary>
        /// Pouvoir supprimer un ou plusieurs parametre celon l'identifiant
        /// </summary>
        /// <param name="ident">Identifiant du ou des parametre a supprimer</param>
        public static void Delete(string ident)
        {
            Log.Logger.Debug("Debut Param.Delete(" + ident + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                ob.Params.RemoveAll((p) => p.Ident == ident);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Param.Delete(ident)");
        }
        
        /// <summary>
        /// Permet de mettre a jour un parametre
        /// </summary>
        /// <param name="p">Parametre a mettre a jour</param>
        public static Classe.Param Maj(Classe.Param pA)
        {
            Log.Logger.Debug("Debut Param.Maj(" + pA.Id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                Classe.Param p = ob.Params.Find((ptemp) => ptemp.Id == pA.Id);
                p.Ident = pA.Ident;
                p.Val1 = pA.Val1;
                p.Val2 = pA.Val2;
                p.Val3 = pA.Val3;
                p.Int1 = pA.Int1;
                p.Int2 = pA.Int2;
                p.Int3 = pA.Int3;
                p.Dec1 = pA.Dec1;
                p.Dec2 = pA.Dec2;
                p.Dec3 = pA.Dec3;
                p.Dat1 = pA.Dat1;
                p.Dat2 = pA.Dat2;
                p.Dat3 = pA.Dat3;
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return pA;
        }
 
        /// <summary>
        /// Permet de creer un parametre
        /// </summary>
        /// <param name="p">Parametre a creer</param>
        public static Classe.Param Sauve(Classe.Param p)
        {
            Log.Logger.Debug("Debut Param.Sauve(" + p.Ident + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                p.Id = ob.Params.Count != 0 ? ob.Params.Max(u => u.Id) + 1 : 1;
                ob.Params.Add(p);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return p;
        }
    }
}