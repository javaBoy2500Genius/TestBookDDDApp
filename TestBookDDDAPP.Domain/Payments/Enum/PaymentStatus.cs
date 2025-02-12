namespace TestBookDDDAPP.Domain.Payments.Enum;

public enum PaymentStatus
{
    Pending, // Ожидает обработки
    Completed, // Успешно выполнен
    Failed // Ошибка
}