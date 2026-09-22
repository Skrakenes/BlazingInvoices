namespace BlazingInvoices.Models;

public record ToastOptions(string Message, ToastType ToastType)
{
    public static ToastOptions Success(string massage) => new(massage, ToastType.Success);
    public static ToastOptions Error(string massage) => new(massage, ToastType.Error);
}
