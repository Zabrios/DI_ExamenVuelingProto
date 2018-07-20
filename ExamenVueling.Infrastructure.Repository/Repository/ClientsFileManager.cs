using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenVueling.Infrastructure.Repository.Contracts;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    /// <summary>
    /// This class manages the reading and writing of the files
    /// </summary>
    public class ClientsFileManager : FileManager
    {
        public ClientsFileManager()
        {
            FileName = FileResources.ClientsFileName;
            FilePath = FileResources.FilePath + FileName;
        }
        public override void CreateFile()
        {
            base.CreateFile();
        }

        public override bool FileExists()
        {
            return base.FileExists();
        }

        public override string RetrieveData()
        {
            return base.RetrieveData();
        }
        public override void WriteToFile(string fileData)
        {
            base.WriteToFile(fileData);
        }

        public override T ProcessData<T>(T data)
        {
            return base.ProcessData(data);
        }
    }
}
