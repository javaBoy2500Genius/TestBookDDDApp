using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Book;

namespace TestBookDDDApp.Book.CreateBook;

public sealed class CreateBookCommandHandler :ICommandHandler<CreateBookCommand,TestBookDDDAPP.Domain.Book.Book>
{
    private readonly IRepository<TestBookDDDAPP.Domain.Book.Book> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateBookCommandHandler(IRepository<TestBookDDDAPP.Domain.Book.Book> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TestBookDDDAPP.Domain.Book.Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dto = request.value;
            var book = new TestBookDDDAPP.Domain.Book.Book(new BookId(Guid.NewGuid()), dto.author, dto.name,
                dto.description, dto.price);


            await _repository.AddAsync(book,cancellationToken);

            return Result.Create(book);
        }
        catch (System.Exception ex)
        {
            return Result.Failure<TestBookDDDAPP.Domain.Book.Book>(new Error("400", ex.Message));
        }

    }
}