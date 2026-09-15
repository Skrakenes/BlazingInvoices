

using BlazingInvoices.Models;

namespace BlazingInvoices.Services;

public class UiService
{
    public event Action<ConfirmationModel>? ConfirmationTriggered;
    public void Confirm(ConfirmationModel confirmationModel) =>
        ConfirmationTriggered?.Invoke(confirmationModel);

    public event Action<string>? OnShowloader;
    public event Action? OnHideLoader;

    public void ShowLoader(string loadingText = "Loading") => OnShowloader?.Invoke(loadingText);
    public void HideLoader() => OnHideLoader?.Invoke();
}
