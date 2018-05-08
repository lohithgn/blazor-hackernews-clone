using BlazorHackerNewsClone.Models;
using BlazorHackerNewsClone.Services;
using Microsoft.AspNetCore.Blazor.Components;
using System.Threading.Tasks;

namespace BlazorHackerNewsClone.Pages.Item
{
    public class ItemModel : BlazorComponent
    {
        [Parameter]
        string ItemId { get; set; }

        [Inject()]
        private HackerNewsServiceClient Client { get; set; }

        protected FeedItem Item = null;

        protected override async Task OnInitAsync()
        {
            Item = await Client.GetItem(ItemId);
            StateHasChanged();
        }
    }
}