namespace TestBookDDDAPP.Domain.Order.Enum;

public enum OrderStatus
{
    Pending, // Ожидает оплаты
    Paid, // Оплачен
    Shipped, // Отправлен
    Completed, // Завершен
    Canceled // Отменен
}