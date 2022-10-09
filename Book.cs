using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Openlib_Dumpers
{
    [JsonConverter(typeof(BookConverter))]
    public class Book
    {
        [JsonProperty("authors", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Authors { get; set; }

        [JsonProperty("works", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Works { get; set; }

        [JsonProperty("table_of_contents", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? TOC { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Genres { get; set; }

        [JsonProperty("series", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Series { get; set; }

        [JsonProperty("lc_classifications", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? LCClassifications { get; set; }

        [JsonProperty("contributions", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Contributions { get; set; }

        [JsonProperty("edition_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? EditionName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("other_titles", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? OtherTitles { get; set; }

        [JsonProperty("work_titles", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? WorkTitles { get; set; }

        [JsonProperty("source_records", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? SourceRecords { get; set; }

        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public string? Subtitle { get; set; }

        [JsonProperty("title_prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string? TitlePrefix { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        [JsonProperty("first_sentence", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstSentence { get; set; }

        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Languages { get; set; }

        [JsonProperty("subjects", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Subjects { get; set; }

        [JsonProperty("by_statement", NullValueHandling = NullValueHandling.Ignore)]
        public string? ByStatement { get; set; }

        [JsonProperty("revision")]
        public int Revision { get; set; }

        [JsonProperty("latest_revision", NullValueHandling=NullValueHandling.Ignore)]
        public int? LatestRevision { get; set; }

        [JsonProperty("last_modified")]
        public DateTime LastModified { get; set; }

        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Created { get; set; }

        [JsonProperty("identifiers", NullValueHandling = NullValueHandling.Ignore)]
        public List<JObject>? Identifiers { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pagination { get; set; }

        [JsonProperty("dewey_decimal_class", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? DeweyDecimalClass { get; set; }

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string? Notes { get; set; }

        [JsonProperty("number_of_pages", NullValueHandling = NullValueHandling.Ignore)]
        public int? NumberOfPages { get; set; }

        [JsonProperty("oclc_number", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? OCLCNumber { get; set; }

        [JsonProperty("lccn", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? LCCN { get; set; }

        [JsonProperty("ocaid", NullValueHandling = NullValueHandling.Ignore)]
        public string? OCAID { get; set; }

        [JsonProperty("isbn_10", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? ISBN10 { get; set; }

        [JsonProperty("isbn_13", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? ISBN13 { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public string? Weight { get; set; }

        [JsonProperty("physical_dimensions", NullValueHandling = NullValueHandling.Ignore)]
        public string? PhysicalDimensions { get; set; }

        [JsonProperty("covers", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Covers { get; set; }

        [JsonProperty("physical_format", NullValueHandling = NullValueHandling.Ignore)]
        public string? PhysicalFormat { get; set; }

        [JsonProperty("publishers", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Publishers { get; set; }

        [JsonProperty("publish_country", NullValueHandling = NullValueHandling.Ignore)]
        public string? PublishCountry { get; set; }

        [JsonProperty("publish_places", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? PublishPlaces { get; set; }

        [JsonProperty("publish_date", NullValueHandling = NullValueHandling.Ignore)]
        public int? PublishDate { get; set; }

        [Obsolete("Seems to be a part of Publishers.")]
        [JsonProperty("distributors", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? Distributors { get; set; }

        [JsonProperty("copyright_date", NullValueHandling = NullValueHandling.Ignore)]
        public int? CopyrightDate { get; set; }

        [JsonProperty("scan_on_demand", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ScanOnDemand { get; set; }

        [JsonProperty("uris", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? URIs { get; set; }

        [JsonProperty("uri_descriptions", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? URIDescriptions { get; set; }

        [JsonProperty("translated_from", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? TranslatedFrom { get; set; }

        [JsonProperty("translation_of", NullValueHandling = NullValueHandling.Ignore)]
        public string? TranslationOf { get; set; }

        // Not using for now.
        [JsonProperty("accompanying_material", NullValueHandling = NullValueHandling.Ignore)]
        public string? AccompanyingMaterial { get; set; }
    }
}
