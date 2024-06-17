using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vintage.Repositories.Interfaces;
using Vintage.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Vintage.Models;
using Microsoft.AspNetCore.Authorization;

public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;
    private readonly UserManager<Users> _userManager;

    public OrderController(IOrderRepository orderRepository, UserManager<Users> userManager)
    {
        _orderRepository = orderRepository;
        _userManager = userManager;
    }

    private string GetUserId()
    {
        return _userManager.GetUserId(User);
    }
    [Authorize]
    public IActionResult OrderHistory()
    {
        var userId = GetUserId();
        var orders = _orderRepository.GetOrders(userId);

        var viewModel = new OrderViewModel
        {
            Order = orders
        };

        return View(viewModel);
    }
}
