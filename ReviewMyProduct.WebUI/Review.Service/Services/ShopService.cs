using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Service.Services
{
    public interface IShopService
    {
        Shop GetById(int shopId);
    }
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public Shop GetById(int shopId)
        {
            return _shopRepository.GetById(shopId);
        }
    }
}
