using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Openlib_Dumpers
{
    public class AuthorConverter : Newtonsoft.Json.JsonConverter
    {
        string cover_url = "https://covers.openlibrary.org/a/id/";

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            Author author = new Author();
            List<string> names = new List<string>();
            List<string> photos = new List<string>();
            List<Links> alllinks = new List<Links>();

            List<JObject> links = new List<JObject>();

            while (reader.Read())
            {
                if (reader.TokenType.ToString() != "PropertyName")
                {
                    if (reader.Path == "name")
                        author.Name = Convert.ToString(reader.Value);
                    else if (reader.Path == "key")
                        author.Id = Convert.ToString(reader.Value.ToString().Split('/')[2]);
                    else if (reader.Path == "eastern_order")
                        author.EasternOrder = Convert.ToBoolean(reader.Value);
                    else if (reader.Path == "personal_name")
                        author.PersonalName = Convert.ToString(reader.Value);
                    else if (reader.Path == "entity_type")
                        author.EntityType = Convert.ToString(reader.Value);
                    else if (reader.Path == "enumeration")
                        author.Enumeration = Convert.ToString(reader.Value);
                    else if (reader.Path == "title")
                        author.Title = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("alternate_names"))
                    {
                        string name = string.Empty;
                        parse_alternate_names(reader, out name);
                        if (!string.IsNullOrEmpty(name))
                            names.Add(name);
                    }
                    else if (reader.Path == "last_modified.value")
                    {
                        //DateTime date = Convert.ToDateTime(reader.Value);
                        //string d = date.Day.ToString("00");
                        //int month = date.Month;
                        //int year = date.Year;
                        //author.LastModified = DateTime.SpecifyKind((DateTime.ParseExact($"{d}/{month}/{year}", "dd/MM/yyyy", CultureInfo.InvariantCulture)), DateTimeKind.Utc);
                        author.LastModified = Convert.ToDateTime(reader.Value);
                    }
                    else if (reader.Path == "location")
                        author.Location = Convert.ToString(reader.Value);
                    else if (reader.Path == "birth_date")
                        author.BirthDate = parse_birth_date(Convert.ToString(reader.Value));
                    else if (reader.Path == "death_date")
                    {
                        int death_year;
                        if (reader.Value == null)
                        {
                            author.DeathDate = null;
                        }
                        else
                        {
                            bool b = Int32.TryParse(Convert.ToString(reader.Value), out death_year);
                            if (b)
                            {
                                author.DeathDate = death_year;
                            }
                            else
                            {
                                author.DeathDate = null;
                            }
                        }
                    }
                    else if (reader.Path == "bio.value")
                        author.Bio = Convert.ToString(reader.Value);
                    else if (reader.Path == "created.value")
                        author.CreatedDate = (Convert.ToString(reader.Value) == Convert.ToString("0001-01-01T00:00:00") ? null : Convert.ToDateTime(reader.Value));
                    else if (reader.Path == "wikipedia")
                        author.Wikipedia = Convert.ToString(reader.Value);
                    else if (reader.Path == "revision")
                        author.Revision = Convert.ToInt32(reader.Value);
                    else if (reader.Path.Contains("photos"))
                    {
                        string id = string.Empty;
                        parse_photos(reader, out id);
                        if (!string.IsNullOrEmpty(id))
                            photos.Add(id);
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

            if (photos.Count > 0)
                author.Photos = photos.ToArray();

            if (names.Count > 0)
                author.AlternateNames = names.ToArray();

            return author;
        }

        void parse_photos(JsonReader reader, out string id)
        {
            id = string.Empty;
            if (reader.Path.Contains("photos"))
            {
                if (reader.Path.Contains("photos["))
                {
                    id = $"{cover_url}{Convert.ToString(reader.Value)}.jpg";
                }
            }
        }

        int? parse_birth_date(string bdate)
        {
            if(!string.IsNullOrEmpty(bdate))
            {
                string[] arr = bdate.Split(' ');
                foreach (string a in arr)
                {
                    int i;
                    bool t = Int32.TryParse(a, out i);
                    if(t)
                    {
                        if(i > 100 && i < 2022)
                        {
                            return i;
                        }
                    }
                }
            }
            return null;
        }

        void parse_urls(JsonReader reader, out Links link)
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

