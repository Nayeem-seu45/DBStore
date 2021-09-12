using DBStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
  public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        int Remove(ShoppingCart shoppingCart, int count);
        int DecrementCount(ShoppingCart shoppingCart, int count);
    }
}
