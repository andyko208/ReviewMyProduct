using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.Mock
{
    public class MockShopRepository : IShopRepository
    {
        private List<Shop> Shops = new List<Shop>();

        public Shop Create(Shop newShop)
        {
            newShop.Id = Shops.OrderByDescending(s => s.Id).Single().Id + 1;
            Shops.Add(newShop);

            return newShop;
        }

        public bool DeleteById(int shopId)
        {
            var shop = GetById(shopId);
            Shops.Remove(shop);

            return true;
        }

        public Shop GetById(int shopId)
        {
            return Shops.Single(s => s.Id == shopId);
        }

        public Shop Update(Shop updatedShop)
        {
            DeleteById(updatedShop.Id);
            Shops.Add(updatedShop);

            return updatedShop;
        }
    }
}
