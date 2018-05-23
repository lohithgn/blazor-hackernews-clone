using BlazorHackerNewsClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace BlazorHackerNewsClone.Services
{
    public class HackerNewsServiceClient
    {
        private string baseUrl = "https://node-hnapi.herokuapp.com";
        private HttpClient _client=null;

        public HackerNewsServiceClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<List<FeedItem>> GetFeed(string topic, int page)
        {
            var feedUrl = GetFeedUrl(topic, page);
            var items = await _client.GetJsonAsync<List<FeedItem>>(feedUrl);
            return items;
        }
        public async Task<HNUser> GetUser(string userId)
        {
            var userDataUrl = $"{baseUrl}/user/{userId}";
            var items = await _client.GetJsonAsync<HNUser>(userDataUrl);
            return items;
        }

        public async Task<FeedItem> GetItem(string itemId)
        {
            var itemDataUrl = $"{baseUrl}/item/{itemId}";
            var item = await _client.GetJsonAsync<FeedItem>(itemDataUrl);
            return item;
        }

        private string GetFeedUrl(string topic, int page)
        {
            var feedUrl = $"{baseUrl}/{topic}";
            if (page > 1)
            {
                feedUrl = $"{feedUrl}?page={page}";
            }
            return feedUrl;
        }
    }
}
