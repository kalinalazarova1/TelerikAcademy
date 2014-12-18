using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;
using _02.FileUpload.Data;
using Ionic.Zip;
using System.Text;

namespace _01.UploadSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            byte[] fileData = null;
            Stream fileStream = null;
            int length = 0;
            if (FileUploadControl.HasFile && FileUploadControl.PostedFiles.All(f => f.FileName.Substring(f.FileName.IndexOf('.') + 1).ToLower() == "zip"))
            {
                length = FileUploadControl.PostedFile.ContentLength;
                fileData = new byte[length + 1];
                fileStream = FileUploadControl.PostedFile.InputStream;
                fileStream.Read(fileData, 0, length);
            }
            else
            {
                Response.Write("Invalid File Format");
                return;
            }

            var memStream = new MemoryStream(fileData);
            var result = this.UnZipToMemory(memStream);
            var db = new FileUploadDbContext();

            foreach (var item in result)
            {
                var buffer = new byte[item.Value.Length + 1];
                item.Value.Read(buffer, 0, buffer.Length);                
                var textFile = new FileModel();
                textFile.Content = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                textFile.Name = item.Key;
                db.Files.Add(textFile);
            }

            db.SaveChanges();
            this.FilesRepeater.DataBind();
        }

        private Dictionary<string, MemoryStream> UnZipToMemory(MemoryStream LocalCatalogZip)
        {
            var result = new Dictionary<string, MemoryStream>();
            using (ZipFile zip = ZipFile.Read(LocalCatalogZip))
            {
                foreach (ZipEntry e in zip)
                {
                    MemoryStream data = new MemoryStream();
                    e.Extract(data);
                    data.Position = 0;
                    result.Add(e.FileName, data);
                }
            }
            return result;
        }

        public IEnumerable<FileModel> FilesRepeater_GetData()
        {
            var db = new FileUploadDbContext();
            return db.Files.ToList();
        }
    }
}