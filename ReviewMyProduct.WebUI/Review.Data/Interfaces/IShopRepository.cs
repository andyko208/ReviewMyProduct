using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Interfaces
{
    public interface IShopRepository
    {
        // Read
        Shop GetById(int shopId);

        // Create
        Shop Create(Shop newShop);

        // Update
        Shop Update(Shop updatedShop);

        // Delete
        bool DeleteById(int shopId);
    }
}
