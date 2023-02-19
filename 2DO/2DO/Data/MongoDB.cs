using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace _2DO.Data;

public class MongoDB {
    private MongoClient client;
    private IMongoDatabase db;
    private string pass;

    public MongoDB() {
    }

    public async Task ConnectToDB() {
        Debug.WriteLine("Din Mor 1");
        pass = DecodeCred(await GetCredentials());
        client = new MongoClient("mongodb://2DO-DB-Credentials:" + pass + "@2do-db.bgzuswr.mongodb.net/?retryWrites=true&w=majority");
        db = client.GetDatabase("2DO-Main_DB");
        Debug.WriteLine("Din Mor 2");
    }

    public List<BsonDocument> QueryDB(FilterDefinition<BsonDocument> filter, string collectionName) {
        IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>(collectionName);

        return collection.Find(filter).ToList();
    }

    public async Task<string> GetCredentials() {
        Stream stream = await FileSystem.OpenAppPackageFileAsync("wwwroot/cred.txt");
        StreamReader reader = new StreamReader(stream);

        return await reader.ReadToEndAsync();
    }

    public string DecodeCred(string strToDecode) {
        byte[] data = Convert.FromBase64String(strToDecode);

        return Encoding.UTF8.GetString(data);
    }

    //<--------------Test Function-------------->
    public void Test() {
        Debug.WriteLine("Din Mor 3");
        db.ListCollections();
        Debug.WriteLine("Din Mor 4");

        //var dbList = client.ListDatabases().ToList();

        //Debug.WriteLine("Printing database list:");

        //foreach(var db in dbList) {
        //    Debug.WriteLine(db);
        //}
        //Debug.WriteLine("Din Mor 4");
    }
}
