using Makonis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makonis.Web.Helpers.IHelpers
{
    public interface IFileHelper
    {
        void WriteFile(List<CustomerViewModel> customers);
        Task<List<CustomerViewModel>> ReadFile();
    }
}
