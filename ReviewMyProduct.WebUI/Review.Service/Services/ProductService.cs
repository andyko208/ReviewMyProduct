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
        ICollection<Product> GetByType(string type);
        void Create(Product newProduct);
        void Update(Product updatedProduct);
        void DeleteById(int productId);
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

        public void DeleteById(int productId)
        {
            _productRepository.DeleteById(productId);
        }

        public Product GetById(int productId)
        {
            return _productRepository.GetById(productId);
        }

        public ICollection<Product> GetByType(string type)
        {
            return _productRepository.GetByType(type);
        }

        public void Update(Product updatedProduct)
        {
            _productRepository.Update(updatedProduct);
        }
    }
}
