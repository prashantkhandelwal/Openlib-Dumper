using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Openlib_Dumpers;

string file = "ol_cdump_2022-09-30.txt";

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
    author_id = str[1].Replace("/authors/", "");
    obj = JObject.Parse(str[4]);
}
