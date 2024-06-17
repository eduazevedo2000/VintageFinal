using Vintage.Context;
using Vintage.Models;
using Vintage.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddOrder(Order order)
    {
        _context.Order.Add(order);
        _context.SaveChanges();
    }

    public IEnumerable<Order> GetOrders(string userId)
    {
        return _context.Order.Where(o => o.UserId == userId)
                           .Include(o => o.OrderItem)
                           .ToList();
    }
}
