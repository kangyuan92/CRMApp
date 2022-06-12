using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        public CustomerServiceAsync(ICustomerRepositoryAsync repo)
        {
            customerRepositoryAsync = repo;
        }
        public async Task<int> AddCustomerAsync(CustomerModel model)
        {
            Customer customer = new Customer();
            customer.Name = model.Name;
            customer.Title = model.Title;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.RegionId = model.RegionId;
            customer.PostalCode = model.PostalCode;
            customer.Country = model.Country;
            customer.Phone = model.Phone;
            return await customerRepositoryAsync.InsertAsync(customer);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await customerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            var collection = await customerRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<CustomerModel> customerModels = new List<CustomerModel>();
                foreach (var item in collection)
                {
                    CustomerModel model = new CustomerModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Title = item.Title;
                    model.Address = item.Address;
                    model.City = item.City;
                    model.RegionId = item.RegionId;
                    model.PostalCode = item.PostalCode;
                    model.Country = item.Country;
                    model.Phone = item.Phone;
                    customerModels.Add(model);
                }
                return customerModels;
            }
            return null;
        }

        public async Task<int> UpdateCustomerAsync(CustomerModel model)
        {
            Customer customer = new Customer();
            customer.Id = model.Id;
            customer.Name = model.Name;
            customer.Title = model.Title;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.RegionId = model.RegionId;
            customer.PostalCode = model.PostalCode;
            customer.Country = model.Country;
            customer.Phone = model.Phone;
            return await customerRepositoryAsync.UpdateAsync(customer);
        }

        public async Task<CustomerModel> GetCustomerForEditAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerModel model = new CustomerModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.RegionId = item.RegionId;
                model.PostalCode = item.PostalCode;
                model.Country = item.Country;
                model.Phone = item.Phone;
                return model;
            }
            return null;
        }
    }
}
