using System;
using System.Collections.Generic;
using System.Data;
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
        [DataMember()]
        public bool Differe { get; set; }
        [DataMember()]
        public Compte CompteGestion { get; set; }
        [DataMember()]
        public Compte CompteDebite { get; set; }
        [DataMember()]
        public int PerdiodeDebut { get; set; }
        [DataMember()]
        public string TypeDiffere { get; set; } // Fin de mois, 30 jrs fin de mois, 60 jrs fin de mois
        [DataMember()]
        public int Decalage { get; set; }
        [DataMember()]
        public bool DecalageSamedi { get; set; }
        [DataMember()]
        public bool DecalageDimanche { get; set; }
        [DataMember()]
        public bool DecalageFerie { get; set; }

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

        public static DataSet ChargeToutDS()
        {
            Log.Logger.Debug("Debut ModePaiement.ChargeToutDS()");
            try
            {
                return ToDataSet(ChargeTout());
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
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

        public static DataSet ToDataSet(List<ModePaiement> list)
        {
            Type elementType = typeof(ModePaiement);
            DataSet ds = new DataSet();
            DataTable t = new DataTable("ModePaiements");

            ds.Tables.Add(t);
            t.Columns.Add("Id", typeof(int));
            t.Columns.Add("Libelle", typeof(string));
            t.Columns.Add("Type", typeof(string));
            t.Columns.Add("Differe", typeof(string));
            
            foreach (ModePaiement item in list)
            {
                DataRow row = t.NewRow();

                row["Id"] = item.Id;
                row["Libelle"] = item.Libelle;
                row["Type"] = item.Type;
                row["Differe"] = item.Differe;
                t.Rows.Add(row);
            }

            return ds;
        }
    }
}
