using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(int productId);
        ICollection<Product> GetByCommentId(int commentId);
        ICollection<Product> GetByType(string type);

        Product Create(Product newProduct);

        Product Update(Product updatedProduct);

        bool DeleteById(int productId);
    }
}
