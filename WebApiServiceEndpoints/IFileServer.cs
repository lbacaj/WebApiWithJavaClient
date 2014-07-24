using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiServiceEndpoints.Models;

namespace WebApiServiceEndpoints
{
    public interface IFileServer
    {
        IList<FileInformation> GetFiles();

        FileInformation GetFileInfo(int id);

        Stream GetFileData(int id);
    }
}
