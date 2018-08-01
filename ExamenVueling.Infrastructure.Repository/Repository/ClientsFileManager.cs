using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using ExamenVueling.Common.Layer;
using ExamenVueling.Infrastructure.Repository.Contracts;
using Newtonsoft.Json;
using System.IO;
using ExamenVueling.Common.Layer.Log4net;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    /// <summary>
    /// This class manages the reading and writing of the files
    /// </summary>
    public class ClientsFileManager : FileManager
    {
        private readonly ICustomLogger Log;
        public ClientsFileManager(ICustomLogger logger)
        {
            this.Log = logger;
            FileName = FileResources.ClientsFileName;
            FilePath = FileResources.FilePath + FileName;
        }
        //public override void CreateFile()
        //{
        //    if (!FileExists())
        //    {
        //        try
        //        {
        //            using (StreamWriter file = new StreamWriter(FilePath, true)) { }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //public override bool FileExists()
        //{
        //    return File.Exists(FilePath);
        //}

        //public override string RetrieveData()
        //{
        //    try
        //    {
        //        var jsonData = File.ReadAllText(FilePath);
        //        return jsonData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public override void WriteToFile(string fileData)
        //{
        //    try
        //    {
        //        File.WriteAllText(FilePath, fileData);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    //catch (UnauthorizedAccessException ex)
        //    //{

        //    //    throw new VuelingException(FMResources.Unauthorized, ex);
        //    //}
        //    //catch (ArgumentNullException ex)
        //    //{
        //    //    throw new VuelingException(FMResources.ArgumentNull, ex);
        //    //}
        //    //catch (ArgumentException ex)
        //    //{
        //    //    throw new VuelingException(FMResources.Argument, ex);
        //    //}
        //    //catch (DirectoryNotFoundException ex)
        //    //{
        //    //    throw new VuelingException(FMResources.NotFound, ex);
        //    //}
        //    //catch (PathTooLongException ex)
        //    //{
        //    //    throw new VuelingException(FMResources.PathTooLong, ex);
        //    //}
        //    //catch (IOException ex)
        //    //{
        //    //    throw new VuelingException(FMResources.IO, ex);
        //    //}
        //    //catch (NotSupportedException ex)
        //    //{
        //    //    throw new VuelingException(FMResources.NotSupported, ex);
        //    //}
        //}

        public override List<T> ProcessData<T>(List<T> data)
        {
            //List<T> auxiliarClients = null;
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
            //return null;
            //return base.ProcessData(data);
        }
    }
}
