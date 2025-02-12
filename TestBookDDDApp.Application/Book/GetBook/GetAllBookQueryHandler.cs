using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDApp.Book.Predicate;
using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDApp.Book.GetBook;

public class GetAllBookQueryHandler :IQueryHandler<GetAllBookQuery, List<TestBookDDDAPP.Domain.Book.Book>>
{
    private readonly IRepository<TestBookDDDAPP.Domain.Book.Book> _repository;

    public GetAllBookQueryHandler(IRepository<TestBookDDDAPP.Domain.Book.Book> repository)
    {
        _repository = repository;
    }


    public async Task<Result<List<TestBookDDDAPP.Domain.Book.Book>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {

        try
        {
            var books = await _repository.GetAllAsync(new GetAllBookPredicate());
            return Result.Create(books);
        }
        catch(Exception ex)
        {

            return Result.Failure<List<TestBookDDDAPP.Domain.Book.Book>>(new Error(StatusCodes.Status400BadRequest.ToString(), ex.Message));
        }
    }
}