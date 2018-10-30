using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace OrionBanque.Classe.Binary
{
    public class ModePaiement
    {
        public static List<Classe.ModePaiement> ChargeTout()
        {
            Log.Logger.Debug("Debut ModePaiement.ChargeTout()");
            List<Classe.ModePaiement> lmp = new List<Classe.ModePaiement>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lmp = ob.ModePaiements.OrderBy(mp => mp.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lmp;
        }

        public static Classe.ModePaiement Charge(int id)
        {
            Log.Logger.Debug("Debut ModePaiement.Charge(" + id + ")");
            Classe.ModePaiement mp = new Classe.ModePaiement();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                mp = ob.ModePaiements.Where(mpt => mpt.Id == id).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return mp;
        }

        public static Classe.ModePaiement ChargeParNom(string nom)
        {
            Log.Logger.Debug("Debut ModePaiement.ChargeParNom(" + nom + ")");
            Classe.ModePaiement mp = new Classe.ModePaiement();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                mp = ob.ModePaiements.Where(mpt => mpt.Libelle == nom).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return mp;
        }

        public static void DeletePossible(int id)
        {
            Log.Logger.Debug("Debut ModePaiement.DeletePossible(" + id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                List<Classe.Operation> lo = ob.Operations.Where(o => o.ModePaiement.Id == id).ToList();
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
            Classe.Log.Logger.Debug("Fin ModePaiement.DeletePossible()");
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut ModePaiement.Delete(" + id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                ob.ModePaiements.RemoveAll((mp) => mp.Id == id);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static Classe.ModePaiement Maj(Classe.ModePaiement mpA)
        {
            Log.Logger.Debug("Debut ModePaiement.Maj(" + mpA.Id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);

                Classe.ModePaiement mp = ob.ModePaiements.Find((mptemp) => mptemp.Id == mpA.Id);
                mp.Libelle = mpA.Libelle;
                mp.Type = mpA.Type;

                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return mpA;
        }

        public static Classe.ModePaiement Sauve(Classe.ModePaiement mpA)
        {
            Log.Logger.Debug("Debut ModePaiement.Sauve(" + mpA.Libelle + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                mpA.Id = ob.ModePaiements.Count != 0 ? ob.ModePaiements.Max(u => u.Id) + 1 : 1;
                ob.ModePaiements.Add(mpA);
                CallContext.SetData(Classe.KEY.OB, ob);
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
