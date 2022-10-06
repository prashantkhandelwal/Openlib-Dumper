using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Openlib_Dumpers;

string file = @"C:\Users\prash\Downloads\ol_cdump_2022-09-30\ol_cdump_2022-09-30.txt\ol_cdump_2022-09-30.txt";

string type = string.Empty;
string author_id = string.Empty;
JObject obj;

using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
{
    string? line;
    string[] all_data;
    while ((line = sr.ReadLine()) != null)
    {
        all_data = line.Split("\t");
        type = all_data[0].Replace("/type/", "");
        switch (type)
        {
            case "author":
                parse_author(all_data);
                break;

            default:
                break;
        }
    }
}

void parse_author(string[] str)
{
    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
    {
        Formatting = Formatting.Indented,
    };

    author_id = str[1].Replace("/authors/", "");
    obj = JObject.Parse(str[4]);
    Author a = JsonConvert.DeserializeObject<Author>(str[4]);
    string s = JsonConvert.SerializeObject(a);

    //save_db(s, "authors");
}

void save_db(string data, string col)
{
    IMongoClient client = new MongoClient("mongodb://127.0.0.1");
    IMongoDatabase database = client.GetDatabase("openlibdb");

    JObject j = JObject.Parse(data);
    BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(j.ToString(Newtonsoft.Json.Formatting.Indented));
    IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(col);
    collection.InsertOne(document);

}

void parse_edition(string[] str)
{

}
