using Review.Data.Context;
using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.EFCore
{
    public class EFCoreShopRepository : IShopRepository
    {
        public Shop Create(Shop newShop)
        {
            using (var context = new ReviewDbContext())
            {
                context.Shops.Add(newShop);
                context.SaveChanges();

                return newShop;
            }
        }

        public bool DeleteById(int shopId)
        {
            using (var context = new ReviewDbContext())
            {
                var shopToBeDeleted = GetById(shopId);
                context.Remove(shopToBeDeleted);
                context.SaveChanges();
            }
            if (GetById(shopId) == null)
                return true;
            return false;
        }

        public Shop GetById(int shopId)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Shops.Single(s => s.Id == shopId);
            }
        }

        public Shop Update(Shop updatedShop)
        {
            using (var context = new ReviewDbContext())
            {
                var existingShop = GetById(updatedShop.Id);


                context.Entry(existingShop).CurrentValues.SetValues(updatedShop);
                context.SaveChanges();

                return existingShop;
            }
        }
    }
}
