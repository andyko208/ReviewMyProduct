using Review.Data.Context;
using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.EFCore
{
    public class EFCoreProductRepository : IProductRepository
    {
        public Product Create(Product newProduct)
        {
            using (var context = new ReviewDbContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();

                return newProduct;
            }
        }

        public bool DeleteById(int productId)
        {
            using (var context = new ReviewDbContext())
            {
                var productToBeDeleted = GetById(productId);
                context.Remove(productToBeDeleted);
                context.SaveChanges();
            }
            if (GetById(productId) == null)
                return true;
            return false;
        }


        public Product GetById(int productId)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Products.Single(p => p.Id == productId);
            }
        }

        public ICollection<Product> GetByType(string type)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Products
                    .Where(p => p.Type == type)
                    .ToList();
            }
        }

        public Product Update(Product updatedProduct)
        {
            using (var context = new ReviewDbContext())
            {
                var existingProduct = GetById(updatedProduct.Id);

                context.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
                context.SaveChanges();

                return existingProduct;
            }
        }
    }
}
