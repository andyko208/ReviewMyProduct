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
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ICollection<Product> GetByCommentId(int commentId)
        {
            return _productRepository.GetByCommentId(commentId);
        }

        public Product GetById(int productId)
        {
            return _productRepository.GetById(productId);
        }
    }
}
