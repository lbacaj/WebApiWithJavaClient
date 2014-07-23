using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiServiceEndpoints.Models;

namespace WebApiServiceEndpoints
{
    interface IFileServer
    {
        IList<FileInformation> GetFiles();

        FileInformation GetFileInfo(int id);

        byte[] GetFileData(int id);
    }
}
