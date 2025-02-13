using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestBookDDDApp.Abstraction.Validators;
using TestBookDDDApp.Book.CreateBook;
using TestBookDDDApp.Book.CreateBook.DTO;
using TestBookDDDApp.Book.GetBook;
using TestBookDDDAPP.Domain.Abstractions;
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
        var validator = new BookValidator();

        var valid = await validator.ValidateAsync(dto);

        if (!valid.IsValid)
        {
            var errors = new List<Error>();
            foreach (var error in valid.Errors)
            {
                errors.Add(new Error("400", error.ErrorMessage));
            }

            var @return = Result.Failure(errors).Select(r => r.Error);
            return BadRequest(@return);

        }

        var command = new CreateBookCommand(dto);

        var result = await _sender.Send(command);

        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result.Error);
    }
}