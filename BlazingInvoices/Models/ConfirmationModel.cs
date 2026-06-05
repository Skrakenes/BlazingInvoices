namespace BlazingInvoices.Models;

public class ConfirmationModel
{
    public string Message { get; set; }
    public Action OnYes { get; set; }
    public Action? OnNo { get; set; }

    public static ConfirmationModel Create(string message, Action onYes, Action? onNo = null)
    {
        return new ConfirmationModel
        {
            Message = message,
            OnYes = onYes,
            OnNo = onNo
        };
    }
}
