using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    public class JSON
    {
        public void SaveFile(List<imgOBJECT> imgs)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, imgs);
            }
        }
        public List<imgOBJECT> LoadFile()
        {


            return JsonConvert.DeserializeObject<List<imgOBJECT>>
                (File.ReadAllText("json.txt"));

        }
    }

}
