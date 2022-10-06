using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Openlib_Dumpers
{
    public class AuthorConverter : Newtonsoft.Json.JsonConverter
    {
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            Author author = new Author();
            List<string> names = new List<string>();
            List<Links> alllinks = new List<Links>();

            List<JObject> links = new List<JObject>();

            while (reader.Read())
            {
                if (reader.TokenType.ToString() != "PropertyName")
                {
                    if (reader.Path == "name")
                        author.Name = Convert.ToString(reader.Value);
                    else if (reader.Path == "personal_name")
                        author.PersonalName = Convert.ToString(reader.Value);
                    else if (reader.Path == "eastern_order")
                        author.EasternOrder = Convert.ToBoolean(reader.Value);
                    else if (reader.Path == "entity_type")
                        author.EntityType = Convert.ToString(reader.Value);
                    else if (reader.Path == "enumeration")
                        author.Enumeration = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("alternate_names"))
                    {
                        string name = string.Empty;
                        parse_alternate_names(reader, out name);
                        if (!string.IsNullOrEmpty(name))
                            names.Add(name);
                    }
                    else if (reader.Path.Contains("links"))
                    {
                        Links? l = null;
                        parse_urls(reader, out l);
                        if (l.Url != null || l.Title != null)
                        {
                            alllinks.Add(l);
                        }
                    }
                    else if (reader.Path == "last_modified.value")
                        author.LastModified = Convert.ToDateTime(reader.Value);
                    else if (reader.Path == "key")
                        author.Id = Convert.ToString(reader.Value.ToString().Split('/')[2]);
                    else if (reader.Path == "title")
                        author.Title = Convert.ToString(reader.Value);
                }
            }

            if (alllinks.Count > 0)
            {
                JObject lobj;
                foreach (Links link in alllinks)
                {
                    lobj = new JObject();
                    lobj.Add("title", link.Title);
                    lobj.Add("url", link.Url);
                    links.Add(lobj);
                }

                author.Links = links;
            }

            if (names.Count > 0)
                author.AlternateNames = names.ToArray();

            return author;
        }

        private void parse_urls(JsonReader reader, out Links link)
        {
            link = new Links();
            while (reader.Read())
            {
                if (reader.Path.Contains("url"))
                {
                    link.Url = Convert.ToString(reader.Value);
                }
                else if (reader.Path.Contains("title"))
                {
                    link.Title = Convert.ToString(reader.Value);
                }
                else if (!reader.Path.Contains("links"))
                    break;
            }
        }

        private void parse_alternate_names(JsonReader reader, out string name)
        {
            name = string.Empty;

            if (reader.TokenType.ToString() != "PropertyName")
            {
                if (reader.Path.Contains("alternate_names"))
                {
                    if (reader.Path.Contains("alternate_names["))
                    {
                        name = Convert.ToString(reader.Value);
                    }
                }
            }
        }

        public override bool CanRead => base.CanRead;
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Author);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

