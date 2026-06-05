

using BlazingInvoices.Models;

namespace BlazingInvoices.Services;

public class UiService
{
    public event Action<ConfirmationModel>? ConfirmationTriggered;
    public void Confirm(ConfirmationModel confirmationModel) =>
        ConfirmationTriggered?.Invoke(confirmationModel);
    
}
