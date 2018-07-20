using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenVueling.Common.Layer;
using ExamenVueling.Infrastructure.Repository.Contracts;
using Newtonsoft.Json;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class PoliciesFileManager : FileManager
    {
        public PoliciesFileManager()
        {
            FileName = FileResources.PoliciesFileName;
            FilePath = FileResources.FilePath + FileName;
        }

        public override void CreateFile()
        {
            if (!FileExists())
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(FilePath, true)) { }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public override bool FileExists()
        {
            return File.Exists(FilePath);
        }

        public override string RetrieveData()
        {
            try
            {
                var jsonData = File.ReadAllText(FilePath);
                return jsonData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override void WriteToFile(string fileData)
        {
            try
            {
                File.WriteAllText(FilePath, fileData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<T> ProcessData<T>(List<T> data)
        {
            try
            {
                CreateFile();
                var resultJSONList = JsonConvert.SerializeObject(data, Formatting.Indented);
                WriteToFile(resultJSONList);
                //var fileData = RetrieveData();
                //auxiliarClients = JsonConvert.DeserializeObject<List<T>>(fileData);
                //if (auxiliarClients != null)
                //{
                //if (!data.OrderBy(x => x).SequenceEqual(auxiliarClients.OrderBy(x => x)))
                //{

                //}
                //}
                //else
                //{
                //var resultJSONList = JsonConvert.SerializeObject(data, Formatting.Indented);
                //WriteToFile(resultJSONList);
                //}
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new VuelingException(FileResources.ArgumentNull, ex);
            }
            return data;
        }
    }
}
