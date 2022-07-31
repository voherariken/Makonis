using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Makonis.Web.Helpers.IHelpers;
using Makonis.Web.Models;
using Makonis.Web.Services.IServices;

namespace Makonis.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IFileHelper _fileHelper;
        public CustomerService(IFileHelper fileHelper)
        {
            this._fileHelper = fileHelper;
        }

        public async void AddCustomer(CustomerViewModel customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var customers = await this.GetCustomers();
            if (customers == null) 
            {
                customers = new List<CustomerViewModel>();
            }

            customers.Add(customer);
            _fileHelper.WriteFile(customers);
        }
        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            return await _fileHelper.ReadFile();
        }
    }
}
