using FinalProject_OnlineShop_BLL.VMs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Interfaces
{
    interface IProductService
    {
        bool CreateProduct(CreateOrUpdateProductVM newProduct);
        OpenProductVM GetProduct(Guid productId);
        List<OpenProductListVM> GetAllProducts();
        bool DeleteProduct(Guid productId);
        bool UpdateProductName(Guid productId, string updatedName);
        bool UpdateProductPrice(Guid productId, decimal updatedPrice);
        bool UpdateProductDescr(Guid productId, string newDescr);
        bool UpdateProductCountry(Guid productId, string newCountry);
    }
}
