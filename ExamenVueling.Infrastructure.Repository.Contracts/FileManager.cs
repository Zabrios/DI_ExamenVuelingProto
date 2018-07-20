using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Contracts
{
    /// <summary>
    /// This class manages the reading and writing of the files
    /// </summary>
    public abstract class FileManager
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public virtual bool FileExists()
        {
            return File.Exists(FilePath);
        }
        public virtual void CreateFile()
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
        public virtual string RetrieveData()
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
        public virtual void WriteToFile(string fileData)
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
        public virtual List<T> ProcessData<T>(List<T> data)
        {
            return data;
        }
    }
}
