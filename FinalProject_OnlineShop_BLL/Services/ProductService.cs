using FinalProject_OnlineShop_BLL.Interfaces;
using FinalProject_OnlineShop_BLL.VMs.Product;
using FinalProject_OnlineShop_DAL;
using FinalProject_OnlineShop_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Services
{
    public class ProductService : IProductService
    {
        readonly AppDbContext db;

        public ProductService()
        {
            db = new AppDbContext();
        }
        public ProductService(AppDbContext _db)
        {
            db = _db;
        }


        public bool CreateProduct(CreateOrUpdateProductVM newProduct)
        {
            try
            {
                db.Products.Add(new Product()
                { 
                    ProductName = newProduct.ProductName, 
                    ProductPrice = newProduct.ProductPrice, 
                    CountryOfOrigin = newProduct.CountryOfOrigin, 
                    Description = newProduct.Description, 
                    Id = Guid.NewGuid() 
                });

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid productId)
        {
            try
            {
                db.Products.Remove(new Product() { Id = productId });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<OpenProductListVM> GetAllProducts()
        {
            List<OpenProductListVM> result = new List<OpenProductListVM>();

            var dbProducts = db.Products.ToList();

            foreach (var dbProduct in dbProducts)
            {
                result.Add(new OpenProductListVM() { ProductPrice = (decimal)dbProduct.ProductPrice, Id = dbProduct.Id, ProductName = dbProduct.ProductName});
              
            }

            

            for (int i = 0; i < result.Count; i++)
            {
                string output = String.Format("Product ID: {0, 16} | Product Name: {1, -15} | Product price: {2, -7} |", result[i].Id, result[i].ProductName, result[i].ProductPrice);
                Console.WriteLine(output);
            }
            


            return result;
        }

        public OpenProductVM GetProduct(Guid productId)
        {
            var ProductsDB = db.Products.ToList();
            var productF = ProductsDB.FirstOrDefault(m => m.Id == productId);
            OpenProductVM result = new OpenProductVM()
            {
                Id = productF.Id,
                CountryOfOrigin = productF.CountryOfOrigin,
                Description = productF.Description,
                ProductName = productF.ProductName,
                ProductPrice = productF.ProductPrice
            };
            
            return result;
        }

        public bool UpdateProductName(Guid productId, string updatedName)
        {
            var productDB = db.Products.ToList();
            var updatedProduct = productDB.FirstOrDefault(m => m.Id == productId);
            updatedProduct.ProductName = updatedName;
            db.SaveChanges();

            return true;
        }

        public bool UpdateProductPrice(Guid productId, decimal updatedPrice)
        {
            var productDB = db.Products.ToList();
            var updatedProduct = productDB.FirstOrDefault(m => m.Id == productId);
            updatedProduct.ProductPrice = updatedPrice;
            db.SaveChanges();

            return true;
        }

        public bool UpdateProductDescr(Guid productId, string newDescr)
        {
            var productDB = db.Products.ToList();
            var updatedProduct = productDB.FirstOrDefault(m => m.Id == productId);
            updatedProduct.Description = newDescr;
            db.SaveChanges();

            return true;
        }

        public bool UpdateProductCountry(Guid productId, string newCountry)
        {
            var productDB = db.Products.ToList();
            var updatedProduct = productDB.FirstOrDefault(m => m.Id == productId);
            updatedProduct.CountryOfOrigin = newCountry;
            db.SaveChanges();

            return true;
        }

    }
}
