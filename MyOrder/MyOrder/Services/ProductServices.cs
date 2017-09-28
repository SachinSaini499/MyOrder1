using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrder.Model;
using Plugin.RestClient;

namespace MyOrder.Services
{
  public  class   ProductServices
    {
        async public Task<List<ProductDetail>> GetUsersAsync()
        {

            RestClient<ProductDetail> restClient = new RestClient<ProductDetail>();
            var lstUser = await restClient.GetAsync();
            return lstUser;
        }

        async public Task<bool> postUsersAsync(ProductDetail productDetail)
        {
            RestClient<ProductDetail> restClient = new RestClient<ProductDetail>();
            bool isSuccessPost = productDetail != null && await restClient.PostAsync(productDetail);
            return isSuccessPost;
        }

    }
}
