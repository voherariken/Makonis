using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Makonis.Web.Helpers.IHelpers;
using Makonis.Web.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Makonis.Web.Helpers
{
    public class FileHelper : IFileHelper
    {
        private string filePath;
        public FileHelper(IConfiguration configuration)
        {
            this.filePath = configuration.GetSection("FilePath").Value;
        }

        public void WriteFile(List<CustomerViewModel> customers)
        {            
            File.WriteAllTextAsync(this.filePath, JsonConvert.SerializeObject(customers));
        }

        public async Task<List<CustomerViewModel>> ReadFile()
        {
            var text = await File.ReadAllTextAsync(this.filePath);
            return JsonConvert.DeserializeObject<List<CustomerViewModel>>(text);
        }
    }
}
