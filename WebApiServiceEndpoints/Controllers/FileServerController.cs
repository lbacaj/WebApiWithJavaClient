using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApiServiceEndpoints.Models;

namespace WebApiServiceEndpoints.Controllers
{
    [RoutePrefix("fileserver")]
    public class FileServerController : ApiController
    {
        private readonly IFileServer _fileServer;

        public FileServerController(IFileServer fileServer)
        {
            _fileServer = fileServer;
        }

        /// <summary>
        /// This API endpoint returns all of the files from
        /// our server.
        /// </summary>
        /// <returns>A List of files</returns>
        [Route("getallfiles")]
        [HttpGet]
        public IEnumerable<FileInformation> GetAllFiles()
        {
            return _fileServer.GetFiles();
        }

        /// <summary>
        /// This API endpoint allows us to download a file
        /// from our server.
        /// </summary>
        /// <param name="id">The ID of the file you wish to download.</param>
        /// <returns>A HttpResponseMessage containing the stream of data.</returns>
        [Route("downloadfile/{id}")]
        [HttpGet]
        public HttpResponseMessage DownloadFile(int id)
        {
            var fileInformation = _fileServer.GetFileInfo(id);
            var path = fileInformation.FullFilePath;
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = _fileServer.GetFileData(id);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(fileInformation.ContentType);
            return result;
        }

    }
}
