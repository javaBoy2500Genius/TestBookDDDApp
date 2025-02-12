using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestBookDDDApp.Book.CreateBook;
using TestBookDDDApp.Book.CreateBook.DTO;
using TestBookDDDApp.Book.GetBook;
using TestBookDDDAPP.Domain.Book;

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


    [HttpGet("{id}")]

    public async Task<IActionResult> GetBookById(Guid id)
    {
        var query = new GetBookByIdQuery(new BookId(id));

        var result= await _sender.Send(query);

        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result.Error); 
    }


    [HttpPost]
    public async Task<IActionResult> CreateBook(BookCreateDto dto)
    {
        var command = new CreateBookCommand(dto);

        var result = await _sender.Send(command);

        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result.Error);
    }
}