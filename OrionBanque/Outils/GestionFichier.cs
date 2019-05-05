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
using OrionBanque.Classe;
using System.Collections.Generic;

namespace OrionBanque.Outils
{
    public static class GestionFichier
    {
        public static void ExportCSV(string fileName, DataTable dTable)
        {
            StreamWriter writer = File.CreateText(fileName);
            writer.AutoFlush = true;

            int intClmn = dTable.Columns.Count;

            for (int i = 0; i <= intClmn - 1; i += 1)
            {
                writer.Write(@"""" + dTable.Columns[i].ColumnName.ToString(System.Globalization.CultureInfo.CurrentCulture) + @"""");
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
                for (int ir = 0; ir <= intClmn - 1; ir += 1)
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

        public static void Sauvegarde()
        {
            FileStream writer = new FileStream((string)CallContext.GetData(KEY.CLEFICHIER), FileMode.Create);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writer, (OB)CallContext.GetData(KEY.OB));
            }
            catch (SerializationException e)
            {
                Log.Logger.Error("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
            RoulementSauvegarde((string)CallContext.GetData(KEY.CLEFICHIER));
        }

        public static void RoulementSauvegarde(string fileName)
        {
            string fn = Path.GetFileNameWithoutExtension(fileName);
            string dir = Path.GetDirectoryName(fileName) + @"\" + KEY.FILEBACKUPPATH;

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

            File.Copy(fileName, dir + fn + ".obq_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
        }

        public static void Charge(string fileName)
        {
            if(!File.Exists(fileName))
            {
                throw new Exception("Le fichier spécifié n'existe plus.");
            }
            FileStream reader = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                OB ob = (OB)formatter.Deserialize(reader);

                if(ob.Fichiers is null)
                {
                    ob.Fichiers = new List<Classe.Fichier>();
                }

                CallContext.SetData(KEY.OB, ob);
                CallContext.SetData(KEY.CLEFICHIER, fileName);
            }
            catch (SerializationException e)
            {
                Log.Logger.Error("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                reader.Close();
            }
        }

        public static List<string> ChargeListeFichier()
        {
            List<string> retour = new List<string>();
            if (File.Exists(KEY.FILELISTPATH))
            {
                FileStream reader = new FileStream(KEY.FILELISTPATH, FileMode.Open);
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    retour = (List<string>)formatter.Deserialize(reader);
                }
                catch (SerializationException e)
                {
                    Log.Logger.Error("Failed to deserialize. Reason: " + e.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
            return retour;
        }

        public static List<string> SauveListeFichier(string fileName)
        {
            List<string> retour = ChargeListeFichier();
            FileStream writer = new FileStream(KEY.FILELISTPATH, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                retour.Add(fileName);
                formatter.Serialize(writer, retour);
            }
            catch (SerializationException e)
            {
                Log.Logger.Error("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
            return retour;
        }

        public static void SauveListeFichier(List<string> fileNames)
        {
            FileStream writer = new FileStream(KEY.FILELISTPATH, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(writer, fileNames);
            }
            catch (SerializationException e)
            {
                Log.Logger.Error("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
