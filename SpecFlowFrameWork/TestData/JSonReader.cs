using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowFrameWork.Utility
{

    public class JSonReader
    {
        public JSonReader()
        {

        }

        public string TestData(string TokenName, string Path)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + $@"{Path}");

            var JsonObject = JToken.Parse(MyJsonString);

           // return JsonObject;

            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName)); 
            return temp.Trim('\"');
            //return JsonConvert.DeserializeObject(JsonObject.ToString());

        }
        public string[] TestDataArray(string TokenName, string Path)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + $@"{Path}");
            JObject JsonObject = JObject.Parse(MyJsonString);
            string[] ReturnValue = JsonObject[TokenName].ToObject<string[]>().ToArray();
            return ReturnValue;

        }
        public string TestData_Path(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\\TestData\\TestData_Path.json");
            var JsonObject = JToken.Parse(MyJsonString);
            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }
        public JObject GetJSonObjectFromFile(String JsonFileUrl)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + JsonFileUrl);
            return (JObject)JsonConvert.DeserializeObject(MyJsonString);
        }
    }
}