using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Service.Services
{
    public interface IProductService
    {
        Product GetById(int productId);
        ICollection<Product> GetByCommentId(int commentId);
        ICollection<Product> GetByType(string type);
        void Create(Product newProduct);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product newProduct)
        {
            _productRepository.Create(newProduct);
        }

        public ICollection<Product> GetByCommentId(int commentId)
        {
            return _productRepository.GetByCommentId(commentId);
        }

        public Product GetById(int productId)
        {
            return _productRepository.GetById(productId);
        }

        public ICollection<Product> GetByType(string type)
        {
            return _productRepository.GetByType(type);
        }
    }
}
