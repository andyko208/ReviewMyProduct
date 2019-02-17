using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.Mock
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> Products = new List<Product>();

        public Product Create(Product newProduct)
        {
            newProduct.Id = Products.OrderByDescending(p => p.Id).Single().Id + 1;
            Products.Add(newProduct);

            return newProduct;
        }

        public bool DeleteById(int productId)
        {
            var product = GetById(productId);
            Products.Remove(product);

            return true;
        }

        public ICollection<Product> GetByCommentId(int commentId)
        {
            return Products.FindAll(p => p.CommentId == commentId);
        }

        public Product GetById(int productId)
        {
            return Products.Single(p => p.Id == productId);
        }

        public Product Update(Product updatedProduct)
        {
            DeleteById(updatedProduct.Id);
            Products.Add(updatedProduct);

            return updatedProduct;
        }
    }
}
