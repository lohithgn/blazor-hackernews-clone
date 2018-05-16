using BlazorHackerNewsClone.Models;
using BlazorHackerNewsClone.Services;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlazorHackerNewsClone.Pages
{
    public class IndexModel : BlazorComponent
    {
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Inject]
        HackerNewsServiceClient Client { get; set; }

        [Parameter]
        string Feed { get; set; } = "news";

        public List<FeedItem> FeedItems { get; set; } = null;

        protected bool IsBusy = false;

        protected int Page { get; set; } = 1;

        protected readonly int PageSize = 30;

        protected override async Task OnInitAsync()
        {
            UriHelper.OnLocationChanged += OnLocationChanged;
            await LoadFeed(Feed, Page);
        }

        private async Task LoadFeed(string topic, int page)
        {
            IsBusy = true;
            StateHasChanged();
            FeedItems = await Client.GetFeed(topic, page);
            Page = page;
            IsBusy = false;
            StateHasChanged();
        }

        private async void OnLocationChanged(object sender, string e)
        {
            Debug.WriteLine($"Feed:{Feed}");
            Debug.WriteLine($"e:{e}");
            await LoadFeed(Feed, 1);
        }

        public async Task OnMoreClick()
        {
            await LoadFeed(Feed, Page + 1);
        }

        public async Task OnPrevClick()
        {
            await LoadFeed(Feed, Page - 1);
        }

        public void Dispose() => UriHelper.OnLocationChanged -= OnLocationChanged;
    }
}
