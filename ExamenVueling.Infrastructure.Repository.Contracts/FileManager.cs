using System;
using System.Collections.Generic;
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
            return true;
        }
        public virtual void CreateFile() { }
        public virtual string RetrieveData()
        {
            return null;
        }
        public virtual void WriteToFile(string fileData)
        {
        }
        public virtual List<T> ProcessData<T>(List<T> data)
        {
            return data;
        }
    }
}
