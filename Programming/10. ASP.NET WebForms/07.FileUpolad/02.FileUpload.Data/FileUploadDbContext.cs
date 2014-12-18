using _02.FileUpload.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FileUpload.Data
{
    public class FileUploadDbContext: DbContext
    {
        public FileUploadDbContext() 
            : base("UploadDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FileUploadDbContext, Configuration>());
        }

        public IDbSet<FileModel> Files { get; set; }
    }
}
