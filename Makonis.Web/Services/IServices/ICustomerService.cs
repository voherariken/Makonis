using Makonis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makonis.Web.Services.IServices
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerViewModel customerViewModel);
    }
}
