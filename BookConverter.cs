using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Openlib_Dumpers
{
    public class BookConverter : Newtonsoft.Json.JsonConverter
    {
        string cover_url = "https://covers.openlibrary.org/a/id/";

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            Book book = new Book();
            List<string> authors = new List<string>();
            List<string> works = new List<string>();
            List<string> toc = new List<string>();
            List<string> genres = new List<string>();
            List<string> series = new List<string>();
            List<string> lcclassification = new List<string>();
            List<string> contributions = new List<string>();
            List<string> othertitles = new List<string>();
            List<string> worktitles = new List<string>();
            List<string> sourcerecords = new List<string>();
            List<string> languages = new List<string>();
            List<string> subjects = new List<string>();
            List<JObject> identifiers = new List<JObject>();
            List<string> deweydecimalclass = new List<string>();
            List<string> oclcnumbers = new List<string>();
            List<string> lccnnumbers = new List<string>();
            List<string> isbnlist10 = new List<string>();
            List<string> isbnlist13 = new List<string>();
            List<string> coverslist = new List<string>();
            List<string> publisherslist = new List<string>();
            List<string> publishplaces = new List<string>();
            List<string> uris = new List<string>();
            List<string> uridescriptions = new List<string>();
            List<string> translatedfrom = new List<string>();

            while (reader.Read())
            {
                if (reader.TokenType.ToString() != "PropertyName")
                {
                    if (reader.Path == "key")
                        book.Key = Convert.ToString(reader.Value).Replace("/books/", "");
                    if (reader.Path == "title")
                        book.Title = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("authors[") && reader.Path.Contains(".key"))
                        authors.Add(Convert.ToString(reader.Value).Replace("/authors/", ""));
                    else if (reader.Path.Contains("works") && reader.Path.Contains(".key"))
                        works.Add(Convert.ToString(reader.Value).Replace("/works/", ""));
                    else if (reader.Path.Contains("table_of_contents") &&
                        (reader.Path.Contains(".value") || reader.Path.Contains(".title")))
                        toc.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("genres["))
                        genres.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("series["))
                        series.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("lc_classifications["))
                        lcclassification.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("contributions["))
                        contributions.Add(Convert.ToString(reader.Value));
                    else if (reader.Path == "edition_name")
                        book.EditionName = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("other_titles["))
                        othertitles.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("work_titles["))
                        worktitles.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("source_records["))
                        sourcerecords.Add(Convert.ToString(reader.Value));
                    else if (reader.Path == "subtitle")
                        book.Subtitle = Convert.ToString(reader.Value);
                    else if (reader.Path == "title_prefix")
                        book.TitlePrefix = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("description.value"))
                        book.Description = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("first_sentence.value"))
                        book.FirstSentence = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("languages") && reader.Path.Contains(".key"))
                        languages.Add(Convert.ToString(reader.Value).Replace("/languages/", ""));
                    else if (reader.Path.Contains("subjects["))
                        subjects.Add(Convert.ToString(reader.Value));
                    else if (reader.Path == "by_statement")
                        book.ByStatement = Convert.ToString(reader.Value);
                    else if (reader.Path == "revision")
                        book.Revision = Convert.ToInt32(reader.Value);
                    else if (reader.Path == "latest_revision")
                        book.LatestRevision = (!string.IsNullOrEmpty(Convert.ToString(reader.Value)) ? Convert.ToInt32(reader.Value) : null);
                    else if (reader.Path == "last_modified.value")
                        book.LastModified = Convert.ToDateTime(reader.Value);
                    else if (reader.Path == "created.value")
                        book.Created = Convert.ToDateTime(reader.Value);
                    else if (reader.Path.Contains("identifiers.") && reader.Path.Contains('['))
                    {
                        string ident_var = reader.Path.Split('.')[1];
                        string iname = ident_var.Remove(ident_var.IndexOf('['), 3);

                        JObject o = new JObject();
                        o.Add("name", iname);
                        o.Add("value", Convert.ToString(reader.Value));
                        identifiers.Add(o);
                    }
                    else if (reader.Path == "pagination")
                        book.Pagination = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("dewey_decimal_class["))
                        deweydecimalclass.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("notes.value"))
                        book.Notes = Convert.ToString(reader.Value);
                    else if (reader.Path == "number_of_pages")
                        book.NumberOfPages = (!string.IsNullOrEmpty(Convert.ToString(reader.Value)) ? Convert.ToInt32(reader.Value) : null);
                    else if (reader.Path.Contains("oclc_number["))
                        oclcnumbers.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("lccn["))
                        lccnnumbers.Add(Convert.ToString(reader.Value));
                    else if (reader.Path == "ocaid")
                        book.OCAID = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("isbn_10["))
                        isbnlist10.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("isbn_13["))
                        isbnlist13.Add(Convert.ToString(reader.Value));
                    else if (reader.Path == "weight")
                        book.Weight = Convert.ToString(reader.Value);
                    else if (reader.Path == "physical_dimensions")
                        book.PhysicalDimensions = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("covers["))
                        coverslist.Add($"{cover_url}{Convert.ToString(reader.Value)}.jpg");
                    else if (reader.Path == "physical_format")
                        book.PhysicalFormat = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("publishers["))
                        publisherslist.Add(Convert.ToString(reader.Value));
                    else if (reader.Path == "publish_country")
                        book.PublishCountry = Convert.ToString(reader.Value);
                    else if (reader.Path.Contains("publish_places["))
                        publishplaces.Add(Convert.ToString(reader.Value));
                    else if (reader.Path == "publish_date")
                        book.PublishDate = parse_date(Convert.ToString(reader.Value));
                    else if (reader.Path == "copyright_date")
                        book.CopyrightDate = parse_date(Convert.ToString(reader.Value));
                    else if (reader.Path == "scan_on_demand")
                        book.ScanOnDemand = string.IsNullOrEmpty(Convert.ToString(reader.Value)) ? Convert.ToBoolean(reader.Value) : null;
                    else if (reader.Path.Contains("uris["))
                        uris.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("uri_descriptions["))
                        uridescriptions.Add(Convert.ToString(reader.Value));
                    else if (reader.Path.Contains("translated_from["))
                        translatedfrom.Add(Convert.ToString(reader.Value));
                    else if (reader.Path == "translation_of")
                        book.TranslationOf = Convert.ToString(reader.Value);
                }
            }

            if (authors.Count > 0) book.Authors = authors.ToArray();
            if (works.Count > 0) book.Works = works.ToArray();
            if (toc.Count > 0) book.TOC = toc.ToArray();
            if (genres.Count > 0) book.Genres = genres.ToArray();
            if (series.Count > 0) book.Series = series.ToArray();
            if (lcclassification.Count > 0) book.LCClassifications = lcclassification.ToArray();
            if (contributions.Count > 0) book.Contributions = contributions.ToArray();
            if (othertitles.Count > 0) book.OtherTitles = othertitles.ToArray();
            if (worktitles.Count > 0) book.WorkTitles = worktitles.ToArray();
            if (sourcerecords.Count > 0) book.SourceRecords = sourcerecords.ToArray();
            if (languages.Count > 0) book.Languages = languages.ToArray();
            if (subjects.Count > 0) book.Subjects = subjects.ToArray();
            if (identifiers.Count > 0) book.Identifiers = identifiers;
            if (deweydecimalclass.Count > 0) book.DeweyDecimalClass = deweydecimalclass.ToArray();
            if (oclcnumbers.Count > 0) book.OCLCNumber = oclcnumbers.ToArray();
            if (lccnnumbers.Count > 0) book.LCCN = lccnnumbers.ToArray();
            if (isbnlist10.Count > 0) book.ISBN10 = isbnlist10.ToArray();
            if (isbnlist13.Count > 0) book.ISBN13 = isbnlist13.ToArray();
            if (coverslist.Count > 0) book.Covers = coverslist.ToArray();
            if (publisherslist.Count > 0) book.Publishers = publisherslist.ToArray();
            if (publishplaces.Count > 0) book.PublishPlaces = publishplaces.ToArray();
            if (uris.Count > 0) book.URIs = uris.ToArray();
            if (uridescriptions.Count > 0) book.URIDescriptions = uridescriptions.ToArray();
            if (translatedfrom.Count > 0) book.TranslatedFrom = translatedfrom.ToArray();

            return book;
        }

        int? parse_date(string pdate)
        {
            if (!string.IsNullOrEmpty(pdate))
            {
                string[] arr = pdate.Split(' ');
                foreach (string a in arr)
                {
                    int i;
                    bool t = Int32.TryParse(a, out i);
                    if (t)
                    {
                        if (i > 100 && i < 2022)
                        {
                            return i;
                        }
                    }
                }
            }
            return null;
        }

        public override bool CanRead => base.CanRead;
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Book);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
