using System.Threading.Tasks;
using BlazorHackerNewsClone.Models;
using BlazorHackerNewsClone.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorHackerNewsClone.Pages
{
    public class UserModel : BlazorComponent
    {
        [Parameter]
        string UserId { get; set; }

        [Inject()]
        HackerNewsServiceClient Client { get; set; }

        public HNUser CurrentUser;

        protected override async Task OnInitAsync()
        {
            CurrentUser = await Client.GetUser(UserId);
        }
    }
}