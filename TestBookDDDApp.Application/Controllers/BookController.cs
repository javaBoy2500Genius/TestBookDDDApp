using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestBookDDDApp.Book.GetBook;

namespace TestBookDDDApp.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IMediator _sender;

    public BookController(IMediator sender)
    {
        _sender = sender;
    }


    [HttpGet]

    public async Task<IActionResult> GetAllBooks()
    {
           var query = new GetAllBookQuery();
            var result = await _sender.Send(query);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Error);
      

    }
}