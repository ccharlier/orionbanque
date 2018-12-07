using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Remoting.Messaging;
using System.Data;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Operation", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Fichier
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public DateTime Date { get; set; }
        [DataMember()]
        public string InitialName { get; set; }
        [DataMember()]
        public string Chemin { get; set; }
        [DataMember()]
        public string Type { get; set; }
        [DataMember()]
        public Operation Operation { get; set; }

        public static Fichier Charge(int id)
        {
            Log.Logger.Debug("Debut Fichier.Charge(" + id + ")");
            Fichier f = new Fichier();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                f = ob.Fichiers.Find(ft => ft.Id == id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return f;
        }

        public static List<Fichier> ChargeTout(Operation o)
        {
            Log.Logger.Debug("Debut Fichier.ChargeTout(Operation)");
            List<Fichier> lf = new List<Fichier>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                IEnumerable<Fichier> temp = ob.Fichiers.Where(ft => ft.Operation.Id == o.Id);
                if(temp.Any())
                {
                    lf = temp.ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lf;
        }

        public static void Delete(Fichier f)
        {
            Log.Logger.Debug("Debut Fichier.Delete(" + f.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Fichiers.RemoveAll(ft => ft.Id == f.Id);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static Fichier Sauve(Fichier f)
        {
            Log.Logger.Debug("Debut Fichier.Sauve()");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                f.Id = ob.Fichiers.Count != 0 ? ob.Fichiers.Max(u => u.Id) + 1 : 1;
                ob.Fichiers.Add(f);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return f;
        }
        
        public static DataSet ToDataSet(List<Fichier> list)
        {
            DataSet ds = new DataSet();
            DataTable t = new DataTable("Fichiers");
            
            ds.Tables.Add(t);

            t.Columns.Add("Id", typeof(int));
            t.Columns.Add("Date Import", typeof(DateTime));
            t.Columns.Add("Nom", typeof(string));
            t.Columns.Add("Type", typeof(string));
            t.Columns.Add("Chemin", typeof(string));
            
            foreach (Fichier item in list)
            {
                DataRow row = t.NewRow();

                row["Id"] = item.Id;
                row["Date Import"] = item.Date;
                row["Type"] = item.Type;
                row["Nom"] = item.InitialName;
                row["Chemin"] = item.Chemin;

                t.Rows.Add(row);
            }

            return ds;
        }

        public static DataSet DataSet()
        {
            DataSet ds = new DataSet();
            DataTable t = new DataTable("Fichiers");
            ds.Tables.Add(t);

            t.Columns.Add("Id", typeof(int));
            t.Columns.Add("Date Import", typeof(DateTime));
            t.Columns.Add("Nom", typeof(string));
            t.Columns.Add("Type", typeof(string));
            t.Columns.Add("Chemin", typeof(string));
            t.Columns.Add("Tiers Op.", typeof(string));
            t.Columns.Add("Libelle Op.", typeof(string));
            t.Columns.Add("Montant Op.", typeof(double));

            OB ob = (OB)CallContext.GetData(KEY.OB);

            foreach (Fichier item in ob.Fichiers)
            {
                DataRow row = t.NewRow();

                row["Id"] = item.Id;
                row["Date Import"] = item.Date;
                row["Type"] = item.Type;
                row["Nom"] = item.InitialName;
                row["Chemin"] = item.Chemin;
                row["Tiers Op."] = item.Operation.Tiers;
                row["Libelle Op."] = item.Operation.Libelle;
                row["Montant Op."] = item.Operation.Montant;

                t.Rows.Add(row);
            }
            return ds;
        }
    }
}