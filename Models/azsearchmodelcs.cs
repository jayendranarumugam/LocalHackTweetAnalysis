using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalHackTweetAnalysis.Models
{
    public class Value
    {     
    public double tweetscore { get; set; }
    public string id { get; set; }
    public string tweet { get; set; }
    public string user { get; set; }
    public DateTime tweetat { get; set; }
    public List<object> url { get; set; }
    public List<ImageDetail> imageDetails { get; set; }
    }
    public class RootObject
    {
        [JsonProperty(PropertyName = "@OData.count")]
        public int odatacount { get; set; }
        public List<Value> value { get; set; }
}

    public class AzSearchModel
    {
        public string search { get; set; }
        public string filter { get; set; }
        public string facets { get; set; }
        public string highlightPreTag { get; set; }
        public string highlightPostTag { get; set; }
        public bool count { get; set; } = true;
        public int skip { get; set; }
        public int top { get; set; }

    }




    public class Tag
    {
        public string name { get; set; }
    }

    public class Body
    {
        public List<object> captions { get; set; }
        public List<Tag> tags { get; set; }
    }

    public class ImageDetail
    {
        public List<string> url { get; set; }
        public Body body { get; set; }
    }

    
}