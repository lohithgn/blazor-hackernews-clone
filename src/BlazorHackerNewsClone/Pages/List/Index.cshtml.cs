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
        [Inject()]
        IUriHelper UriHelper { get; set; }

        [Inject()]
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
            IsBusy = false;
            StateHasChanged();
        }

        private async void OnLocationChanged(object sender, string e)
        {
            ResetPage();
            Debug.WriteLine($"Feed:{Feed}");
            Debug.WriteLine($"e:{e}");
            await LoadFeed(Feed, Page);
        }

        public async Task OnMoreClick()
        {
            IncrementPage();
            await LoadFeed(Feed, Page);
        }

        public async Task OnPrevClick()
        {
            DecrementPage();
            await LoadFeed(Feed, Page);
        }

        private void ResetPage() => Page = 1;
        private void IncrementPage() => ++Page;
        private void DecrementPage() => --Page;

        public void Dispose() => UriHelper.OnLocationChanged -= OnLocationChanged;
    }
}
