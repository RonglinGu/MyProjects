using UnityEngine;
using Newtonsoft.Json;

public class JsonTest : MonoBehaviour
{
    private readonly string json = @"
          {
             ""d"":""d"",
            ""album"" : {    
             ""cc"":""cc"",          
              ""name""   : ""The Dark Side of the Moon"",
              ""artist"" : ""Pink Floyd"",
              ""year""   : 1973,         
              ""tracks"" : [
                ""Speak To Me"",
                ""Breathe"",
                ""On The Run""
              ],
              ""tt"":""tt"",
             ""tracksOb"":[{""trackOb"":""11""},{""trackOb"":""22""}],
             ""bb"":""bb""         
            }
          }
        ";

    private void Start()
    {
        Test o = GetData2<Test>(json);
        Debug.LogWarning("o.d = " + o.d);
        Debug.LogWarning("o.album.name  = " + o.album.name);
        Debug.LogWarning("o.album.bb = " + o.album.bb);
    }

    /// <summary>
    ///     三种json解析方法
    ///     1一一对应
    ///     2推荐使用 不用一一对应
    ///     3不能解析复杂的json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="text"></param>
    /// <returns></returns>
    public static T GetData2<T>(string text) where T : class
    {
        //JsonData table = AnalysisJson.Analy<JsonData>(text);
        //   T t = JsonMapper.ToObject<T>(text);

        T t = JsonConvert.DeserializeObject<T>(text);
        //T t = JsonUtility.FromJson<T>(text);
        return t;
    }

    public class Test
    {
        public string d;
        public TestModel album;
    }

    public class TestModel
    {
        public string name;
        public string artist;
        public int year;
        public string[] tracks;
        public TestModel2[] tracksOb;
        public string bb;
    }

    public class TestModel2
    {
        public string trackOb;
    }
}