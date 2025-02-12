using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestBookDDDApp.Application.Orders.Новая_папка;
using TestBookDDDAPP.Domain.Order;
using TestBookDDDApp.Orders.CanceledOrder;
using TestBookDDDApp.Orders.CreateOrder;

namespace TestBookDDDApp.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController :ControllerBase
{
    private readonly ISender _sender;

    public OrderController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder(CreateOrderDTO dto)
    {
        var command = new CreateOrderCommand(dto.id, dto.customer);

        var result = await _sender.Send(command);

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(result.Error);

    }


    [HttpPost("canceled")]
    public async Task<IActionResult> CanceledOrder(OrderId id)
    {
        var command = new CancelOrderCommand(id);

        var result = await _sender.Send(command); 
        if (result.IsSuccess) 
            return Ok(result.Value);

        return BadRequest(result.Error);
    }
    
}