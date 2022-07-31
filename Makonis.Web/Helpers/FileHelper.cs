using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Makonis.Web.Helpers.IHelpers;
using Makonis.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Makonis.Web.Helpers
{
    public class FileHelper : IFileHelper
    {
        private string filePath;
        public FileHelper(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this.filePath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("FilePath").Value);
        }

        public void WriteFile(List<CustomerViewModel> customers)
        {            
            File.WriteAllTextAsync(this.filePath, JsonConvert.SerializeObject(customers));
        }

        public async Task<List<CustomerViewModel>> ReadFile()
        {
            if (File.Exists(this.filePath))
            {
                var text = await File.ReadAllTextAsync(this.filePath);
                return JsonConvert.DeserializeObject<List<CustomerViewModel>>(text);
            }
            else return null;
        }
    }
}
