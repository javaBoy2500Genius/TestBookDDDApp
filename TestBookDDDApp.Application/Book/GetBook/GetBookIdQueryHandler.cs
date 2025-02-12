using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDApp.Book.Exception;
using TestBookDDDApp.Book.Predicate;
using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDApp.Book.GetBook;

public sealed class GetBookIdQueryHandler :IQueryHandler<GetBookByIdQuery, TestBookDDDAPP.Domain.Book.Book>
{
    private readonly IRepository<TestBookDDDAPP.Domain.Book.Book> _repository;

    public GetBookIdQueryHandler(IRepository<TestBookDDDAPP.Domain.Book.Book> repository)
    {
        _repository = repository;
    }

    public async Task<Result<TestBookDDDAPP.Domain.Book.Book>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var book = await _repository.GetAsync(new GetBookIdPredicate(request.bookId),cancellationToken);
            return book == null ? Result.Failure<TestBookDDDAPP.Domain.Book.Book>(BookNotFoundException.GetError) : Result.Create(book);
        }
        catch (System.Exception ex)
        {
            return Result.Failure<TestBookDDDAPP.Domain.Book.Book>(new Error("400", ex.Message));
        }
    }
}