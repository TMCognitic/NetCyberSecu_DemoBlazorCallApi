using DemoBlazor.Models.Entities;
using DemoBlazor.Models.Respositoris;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace DemoBlazor.Pages
{
    public partial class DataComponent : ComponentBase
    {
        [Inject]        
        public IDataRepository? Repository { get; set; }

        private IEnumerable<Data>? _items = Enumerable.Empty<Data>();

        private bool _getDataError;
        private bool _shouldRender;
        private string? _errorMessage;

        protected override bool ShouldRender()
        {
            return _shouldRender;
        }

        protected override async Task OnInitializedAsync()
        {
            if(Repository is null)
                _getDataError = true;

            try
            {
                _items = await Repository!.Get();
            }
            catch (Exception ex) 
            {
                _errorMessage = ex.Message;
                _getDataError = true;
            }

            _shouldRender = true;
        }
    }
}
