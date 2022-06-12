using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface ICustomerServiceAsync
    {
        Task<IEnumerable<CustomerModel>> GetAllAsync();
        Task<int> AddCustomerAsync(CustomerModel customer);
        Task<CustomerModel> GetCustomerForEditAsync(int id);
        Task<int> UpdateCustomerAsync(CustomerModel customer);
        Task<int> DeleteCustomerAsync(int id);
    }
}
