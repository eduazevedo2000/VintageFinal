using Vintage.Models;
using System.Collections.Generic;

namespace Vintage.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        IEnumerable<Order> GetOrders(string userId);
    }
}
