using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "ModePaiement", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class ModePaiement
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public string Type { get; set; }

        public static List<ModePaiement> ChargeTout()
        {
            Log.Logger.Debug("Debut ModePaiement.ChargeTout()");
            List<ModePaiement> lmp = new List<ModePaiement>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lmp = ob.ModePaiements.OrderBy(mp => mp.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lmp;
        }

        public static ModePaiement Charge(int id)
        {
            Log.Logger.Debug("Debut ModePaiement.Charge(" + id + ")");
            ModePaiement mp = new ModePaiement();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                mp = ob.ModePaiements.Where(mpt => mpt.Id == id).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return mp;
        }

        public static ModePaiement ChargeParNom(string nom)
        {
            Log.Logger.Debug("Debut ModePaiement.ChargeParNom(" + nom + ")");
            ModePaiement mp = new ModePaiement();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                mp = ob.ModePaiements.Where(mpt => mpt.Libelle == nom).FirstOrDefault();
                if(mp is null)
                {
                    mp = new ModePaiement();
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return mp;
        }

        public static void DeletePossible(ModePaiement mpA)
        {
            Log.Logger.Debug("Debut ModePaiement.DeletePossible(" + mpA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                List<Operation> lo = ob.Operations.Where(o => o.ModePaiement.Id == mpA.Id).ToList();
                if (lo.Count != 0)
                {
                    throw new Exception("Vous devez d'abord modifier vos Opérations pour qu'elles ne pointent plus sur ce Mode de Paiement.");
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static void Delete(ModePaiement mpA)
        {
            Log.Logger.Debug("Debut ModePaiement.Delete(" + mpA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.ModePaiements.RemoveAll((mp) => mp.Id == mpA.Id);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static ModePaiement Maj(ModePaiement mpA)
        {
            Log.Logger.Debug("Debut ModePaiement.Maj(" + mpA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ModePaiement mp = ob.ModePaiements.Find((mptemp) => mptemp.Id == mpA.Id);
                mp.Libelle = mpA.Libelle;
                mp.Type = mpA.Type;

                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return mpA;
        }

        public static ModePaiement Sauve(ModePaiement mpA)
        {
            Log.Logger.Debug("Debut ModePaiement.Sauve(" + mpA.Libelle + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                mpA.Id = ob.ModePaiements.Count != 0 ? ob.ModePaiements.Max(u => u.Id) + 1 : 1;
                ob.ModePaiements.Add(mpA);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return mpA;
        }
    }
}
