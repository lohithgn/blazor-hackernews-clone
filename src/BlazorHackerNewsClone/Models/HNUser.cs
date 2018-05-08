using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHackerNewsClone.Models
{
    public class HNUser
    {
        public string id { get; set; }
        public int created_time { get; set; }
        public string created { get; set; }
        public int karma { get; set; }
        public object avg { get; set; }
        public string about { get; set; }

    }
}
