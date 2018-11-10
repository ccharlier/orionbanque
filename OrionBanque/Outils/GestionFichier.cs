using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Runtime.Remoting.Messaging;
using System.Linq;
using System.Text;
using System.Data;
using System;

namespace OrionBanque.Outils
{
    public class GestionFichier
    {
        public static void ExportCSV(string fileName, DataTable dTable)
        {
            StreamWriter writer = File.CreateText(fileName);
            writer.AutoFlush = true;

            int intClmn = dTable.Columns.Count;

            int i = 0;
            for (i = 0; i <= intClmn - 1; i += 1)
            {
                writer.Write(@"""" + dTable.Columns[i].ColumnName.ToString() + @"""");
                if (i == intClmn - 1)
                {
                    writer.Write(" ");
                }
                else
                {
                    writer.Write(",");
                }
            }
            writer.Write(Environment.NewLine);

            foreach (DataRow row in dTable.Rows)
            {
                int ir = 0;
                for (ir = 0; ir <= intClmn - 1; ir += 1)
                {
                    writer.Write(@"""" + row[ir].ToString().Replace(@"""", @"""""") + @"""");
                    if (ir == intClmn - 1)
                    {
                        writer.Write(" ");
                    }
                    else
                    {
                        writer.Write(",");
                    }
                }
                writer.Write(Environment.NewLine);
            }
            writer.Close();
        }

        public static void Delete(string fileName)
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public static void ExportJson(string fileName)
        {
            FileStream writer = new FileStream(fileName, FileMode.Create);
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Classe.OB));
                ser.WriteObject(writer, (Classe.OB)CallContext.GetData(Classe.KEY.OB));
            }
            catch (SerializationException e)
            {
                Classe.Log.Logger.Error("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
        }

        public static void ExportXml(string fileName)
        {
            FileStream writer = new FileStream(fileName, FileMode.Create);
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Classe.OB));
                ser.Serialize(writer, (Classe.OB)CallContext.GetData(Classe.KEY.OB));
            }
            catch (SerializationException e)
            {
                Classe.Log.Logger.Error("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
        }

        public static void Sauvegarde(string fileName, Classe.OB ob)
        {
            FileStream writer = new FileStream(fileName, FileMode.Create);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writer, ob);
            }
            catch (SerializationException e)
            {
                Classe.Log.Logger.Error("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
            RoulementSauvegarde(fileName);
        }

        public static void RoulementSauvegarde(string fileName)
        {
            string fn = Path.GetFileNameWithoutExtension(fileName);
            string dir = Path.GetDirectoryName(fileName) + @"\" + Classe.KEY.REP_BACKUP;

            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            DirectoryInfo monrepertoire = new DirectoryInfo(dir);
            FileInfo[] mesfichiers = monrepertoire.GetFiles(fn + ".*");

            if(mesfichiers.Length > 20)
            {
                FileSystemInfo fileInfo = new DirectoryInfo(dir).GetFileSystemInfos().Where(x => x.Name.Contains(fn)).OrderBy(fi => fi.CreationTime).First();
                File.Delete(fileInfo.FullName);
            }

            File.Copy(fileName, dir + fn + ".obq" + System.DateTime.Now.Year + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + System.DateTime.Now.Millisecond);
        }

        public static void Charge(string fileName)
        {
            FileStream reader = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Classe.OB ob = (Classe.OB)formatter.Deserialize(reader);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (SerializationException e)
            {
                Classe.Log.Logger.Error("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
