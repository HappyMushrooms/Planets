using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class State
    {
        public int n;
        public List<double> m = new List<double>();
        public List<double> x = new List<double>();
        public List<double> y = new List<double>();
        public List<double> z = new List<double>();
        public List<double> vx = new List<double>();
        public List<double> vy = new List<double>();
        public List<double> vz = new List<double>();

        public void SaveToFile(string filename)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(this));
        }
       
        static public State LoadFromFile(string filename)
        {
            return JsonConvert.DeserializeObject<State>(File.ReadAllText(filename));
        }
    }
}
