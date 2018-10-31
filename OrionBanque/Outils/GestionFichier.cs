using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Runtime.Remoting.Messaging;

namespace OrionBanque.Outils
{
    public class GestionFichier
    {
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
