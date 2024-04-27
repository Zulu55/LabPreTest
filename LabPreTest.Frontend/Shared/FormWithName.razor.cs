﻿using LabPreTest.Shared.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;

namespace LabPreTest.Frontend.Shared
{
    public partial class FormWithName<TModel> where TModel : IEntityWithName
    {
        private EditContext editContext = null!;

        [EditorRequired, Parameter] public TModel Model { get; set; } = default!;
        [EditorRequired, Parameter] public string Label { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit {  get; set; }
        [EditorRequired, Parameter] public EventCallback ReturnAction {  get; set; }

        //TODO: sweet alert 
        public bool FormPostedSuccessfully {  get; set; }

        protected override void OnInitialized()
        {
            editContext = new(Model);
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            // TODO: sweet alert
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
