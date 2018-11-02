using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Remoting.Messaging;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Operation", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Param
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Ident { get; set; }
        [DataMember()]
        public string Val1 { get; set; }
        [DataMember()]
        public string Val2 { get; set; }
        [DataMember()]
        public string Val3 { get; set; }
        [DataMember()]
        public int Int1 { get; set; }
        [DataMember()]
        public int Int2 { get; set; }
        [DataMember()]
        public int Int3 { get; set; }
        [DataMember()]
        public double Dec1 { get; set; }
        [DataMember()]
        public double Dec2 { get; set; }
        [DataMember()]
        public double Dec3 { get; set; }
        [DataMember()]
        public DateTime Dat1 { get; set; }
        [DataMember()]
        public DateTime Dat2 { get; set; }
        [DataMember()]
        public DateTime Dat3 { get; set; }

        public Param()
        {
            Ident = string.Empty;
            Val1 = string.Empty;
            Val2 = string.Empty;
            Val3 = string.Empty;
            Int1 = int.MinValue;
            Int2 = int.MinValue;
            Int3 = int.MinValue;
            Dec1 = double.MinValue;
            Dec2 = double.MinValue;
            Dec3 = double.MinValue;
            Dat1 = DateTime.MinValue;
            Dat2 = DateTime.MinValue;
            Dat3 = DateTime.MinValue;
        }

        /// <summary>
        /// Chargement de tous les parametres
        /// </summary>
        /// <returns>Lsite de Param</returns>
        public static List<Param> ChargeTout()
        {
            Log.Logger.Debug("Debut Param.ChargeTout()");
            List<Param> lp = new List<Classe.Param>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
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
        public static Param Charge(int id)
        {
            Log.Logger.Debug("Debut Categorie.Charge(" + id + ")");
            Param p = new Param();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
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
        public static List<Param> Charge(string ident)
        {
            Log.Logger.Debug("Debut Categorie.Charge(" + ident + ")");
            List<Param> lp = new List<Param>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lp = ob.Params.Where(pt => pt.Ident == ident).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
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
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Params.RemoveAll((p) => p.Id == id);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
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
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Params.RemoveAll((p) => p.Ident == ident);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Permet de mettre a jour un parametre
        /// </summary>
        /// <param name="p">Parametre a mettre a jour</param>
        public static Param Maj(Param pA)
        {
            Log.Logger.Debug("Debut Param.Maj(" + pA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                Param p = ob.Params.Find((ptemp) => ptemp.Id == pA.Id);
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
                CallContext.SetData(KEY.OB, ob);
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
        public static Param Sauve(Param p)
        {
            Log.Logger.Debug("Debut Param.Sauve(" + p.Ident + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                p.Id = ob.Params.Count != 0 ? ob.Params.Max(u => u.Id) + 1 : 1;
                ob.Params.Add(p);
                CallContext.SetData(KEY.OB, ob);
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
