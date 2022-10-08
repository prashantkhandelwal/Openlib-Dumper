using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Openlib_Dumpers
{
    [JsonConverter(typeof(AuthorConverter))]
    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Id { get; set; }

        [JsonProperty("eastern_order", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EasternOrder { get; set; }

        [JsonProperty("personal_name", NullValueHandling = NullValueHandling.Ignore)]
        public string PersonalName { get; set; }

        [JsonProperty("entity_type", NullValueHandling = NullValueHandling.Ignore)]
        public string EntityType { get; set; }

        [JsonProperty("enumeration", NullValueHandling = NullValueHandling.Ignore)]
        public string Enumeration { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("alternate_names", NullValueHandling = NullValueHandling.Ignore)]
        public string[] AlternateNames { get; set; }

        //[JsonProperty("uris", NullValueHandling = NullValueHandling.Ignore)]
        //public string[] Uris { get; set; }

        [JsonProperty("bio", NullValueHandling = NullValueHandling.Ignore)]
        public string Bio { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty("death_date", NullValueHandling = NullValueHandling.Ignore)]
        public int? DeathDate { get; set; }

        [JsonProperty("birth_date", NullValueHandling = NullValueHandling.Ignore)]
        public int? BirthDate { get; set; }
       
        [JsonProperty("last_modified")]
        public DateTime LastModified { get; set; }

        //[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        //[JsonProperty("last_modified", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTime LastModified
        //{
        //    get
        //    {
        //        return _last_modified;
        //    }
        //    set
        //    {
        //        _last_modified = new DateTime(value.Ticks, DateTimeKind.Utc);
        //    }
        //}

        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDate { get; set; } 

        [JsonProperty("wikipedia", NullValueHandling = NullValueHandling.Ignore)]
        public string Wikipedia { get; set; }

        [JsonProperty("photos", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Photos { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public List<JObject> Links { get; set; }

        [JsonProperty("revision", NullValueHandling = NullValueHandling.Ignore)]
        public int Revision { get; set; }

    }


    public class Links
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }

}
