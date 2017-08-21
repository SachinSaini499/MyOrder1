using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrder.Model;
using Plugin.RestClient;

namespace MyOrder.Services
{
  public  class CustomerServices
    {
        async public Task<List<CustomerDetail>> GetUsersAsync()
        {

            RestClient<CustomerDetail> restClient = new RestClient<CustomerDetail>();
            var lstUser = await restClient.GetAsync();
            return lstUser;
        }

        async public Task<bool> postUsersAsync(CustomerDetail customerDetail)
        {
            RestClient<CustomerDetail> restClient = new RestClient<CustomerDetail>();
            bool isSuccessPost = customerDetail != null && await restClient.PostAsync(customerDetail);
            return isSuccessPost;
        }

    }
}
