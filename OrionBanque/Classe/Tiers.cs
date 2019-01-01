using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    public class Tiers
    {
        public static List<string> ChargeTout()
        {
            OB ob = (OB)CallContext.GetData(KEY.OB);
            return (ob.PredictTiers ?? true) ? ChargeToutPredict() : ChargeToutSansPredict();
        }

        public static List<string> ChargeToutPredict()
        {
            Log.Logger.Debug("Debut Tiers.ChargeToutPredict()");
            List<string> lt = new List<string>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lt = ob.Tiers ?? new List<string>();
                lt.Sort();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lt;
        }

        public static List<string> ChargeToutSansPredict()
        {
            Log.Logger.Debug("Debut Tiers.ChargeToutSansPredict()");

            List<string> ls = new List<string>();
            List<Compte> lc = Compte.ChargeTout();
            foreach(Compte c in lc)
            {
                List<Operation> lo = Compte.Charge(c.Id).Operations().OrderBy(o => o.Tiers).ToList();
                foreach (Operation o in lo)
                {
                    ls.Add(o.Tiers);
                }
            }
            ls.Sort();
            return ls.Distinct().ToList();
        }
    }
}
