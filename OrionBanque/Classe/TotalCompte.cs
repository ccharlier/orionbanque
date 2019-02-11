using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "TotalCompte", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class TotalCompte
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public List<Compte> Comptes { get; set; }

        public TotalCompte()
        {
            Comptes = new List<Compte>();
        }

        public static List<TotalCompte> ChargeTout()
        {
            Log.Logger.Debug("Debut TotalCompte.ChargeTout()");
            List<TotalCompte> ltc = new List<TotalCompte>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                if(ob.ListeTotalCompte != null)
                {
                    ltc = ob.ListeTotalCompte.OrderBy(tc => tc.Libelle).ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return ltc;
        }

        public static TotalCompte Charge(int id)
        {
            Log.Logger.Debug("Debut TotalCompte.Charge(" + id + ")");
            TotalCompte tc = new TotalCompte();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                tc = ob.ListeTotalCompte.Where(ttc => ttc.Id == id).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return tc;
        }

        public static void Delete(TotalCompte tcA)
        {
            Log.Logger.Debug("Debut TotalCompte.Delete(" + tcA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.ListeTotalCompte.RemoveAll((tc) => tc.Id == tcA.Id);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static TotalCompte Maj(TotalCompte tcA)
        {
            Log.Logger.Debug("Debut TotalCompte.Maj(" + tcA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                TotalCompte tc = ob.ListeTotalCompte.Find((ttc) => ttc.Id == tcA.Id);
                tc.Libelle = tcA.Libelle;
                tc.Comptes = tcA.Comptes;

                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return tcA;
        }

        public static TotalCompte Sauve(TotalCompte tcA)
        {
            Log.Logger.Debug("Debut TotalCompte.Sauve(" + tcA.Libelle + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                if(ob.ListeTotalCompte == null)
                {
                    ob.ListeTotalCompte = new List<TotalCompte>();
                }
                tcA.Id = ob.ListeTotalCompte.Count != 0 ? ob.ListeTotalCompte.Max(u => u.Id) + 1 : 1;
                ob.ListeTotalCompte.Add(tcA);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return tcA;
        }
    }
}
