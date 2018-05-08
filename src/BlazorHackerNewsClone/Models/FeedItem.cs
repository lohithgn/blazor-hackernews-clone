using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHackerNewsClone.Models
{
    public class FeedItem
    {
        public int id { get; set; }
        public string title { get; set; }
        public int points { get; set; }
        public string user { get; set; }
        public int time { get; set; }
        public string time_ago { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string domain { get; set; }
        public Comment[] comments { get; set; }
        public int comments_count { get; set; }
    }

    public class Comment
    {
        public int id { get; set; }
        public int level { get; set; }
        public string user { get; set; }
        public int time { get; set; }
        public string time_ago { get; set; }
        public string content { get; set; }
        public Comment[] comments { get; set; }
        public bool deleted { get; set; }
    }
}
