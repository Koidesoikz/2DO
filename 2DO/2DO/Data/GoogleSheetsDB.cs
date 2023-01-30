//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Text;

//namespace _2DO.Data;

//public class GoogleSheetsDB {

//    //public SheetsService service { get; set; }
//    private string sheetID;










//    //----------------------------------------------------------------
//    public async Task<List<string>> GetCredentials(string path) {
//        List<string> lines = new List<string>();

//        Stream stream = await FileSystem.OpenAppPackageFileAsync("wwwroot/APIStuff.txt");
//        StreamReader reader = new StreamReader(stream);

//        while(!reader.EndOfStream) {
//            lines.Add(await reader.ReadLineAsync());
//        }

//        if(lines.Count != 2) {
//            throw new Exception("The file containing api credentials is in the wrong format.");
//        } else {
//            return lines;
//        }
//    }

//    public string DecodeCred(string strToDecode) {
//        byte[] data = Convert.FromBase64String(strToDecode);

//        return Encoding.UTF8.GetString(data);
//    }

//}
