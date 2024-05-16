using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using LabPreTest.Frontend.Repositories;
using LabPreTest.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace LabPreTest.Frontend.Pages.Auth
{
    public partial class RecoverPassword
    {
        private EmailDTO emailDTO = new();
        private bool loading;
        private bool wasClose;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; } = null!;

        private async Task SendRecoverPasswordEmailTokenAsync()
        {
            loading = true;
            var responseHttp = await Repository.PostAsync("/api/accounts/RecoverPassword", emailDTO);
            
            if (wasClose)
            {
                NavigationManager.NavigateTo("/");
                return;
            }

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                loading = false;
                return;
            }

            loading = false;
            await SweetAlertService.FireAsync("Confirmaci�n", "Se te ha enviado un correo electr�nico con las instrucciones para recuperar su contrase�a.", SweetAlertIcon.Info);
            NavigationManager.NavigateTo("/");
        }
        private async Task CloseModalAsync()
        {
            wasClose = true;
            await BlazoredModal.CloseAsync(ModalResult.Ok());
        }

    }
}