using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiServiceEndpoints.Models;

namespace WebApiServiceEndpoints
{
    public class FileServer : IFileServer
    {
        private static readonly string ServerFolder = "C:\\Temp\\WebApi";
        private Dictionary<int, FileInformation> _fileDesc;

        public FileServer()
        {
            FillDictionary();
        }

        public IList<FileInformation> GetFiles()
        {
            return _fileDesc.Values.ToList();
        }

        public FileInformation GetFileInfo(int id)
        {
            FileInformation fileInfo;
            if (_fileDesc.TryGetValue(id, out fileInfo))
                return fileInfo;
            else
                return null;
        }

        public byte[] GetFileData(int id)
        {
            byte[] bytes = null;

            FileInformation fileInfo;
            bool ok = _fileDesc.TryGetValue(id, out fileInfo);

            if (ok)
            {
                bytes = File.ReadAllBytes(fileInfo.Name);
            }

            return bytes;
        }

        private void FillDictionary()
        {
            //We are going directly to the file system to
            //Fill our internal dictionary but ideally
            //We would get this from a document store.
            FileInfo fi;
            int id = 0;

            var files = Directory.GetFiles(ServerFolder).ToList();

            foreach (String file in files)
            {
                fi = new System.IO.FileInfo(file);
                _fileDesc.Add(id,
                    new FileInformation
                    {
                        Id = id,
                        Name = Path.GetFileName(file),
                        Extension = fi.Extension,
                        Description = "some image from temp folder.",
                        ContentType = "application/png",
                        CreatedTimestamp = fi.CreationTime,
                        UpdatedTimestamp = fi.LastWriteTime
                    });
                id++;
            }
        }
    }
}
