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

        public State()
        {

        }
        public State(int n)
        {
            this.n = n;
            m = (new double[n]).ToList();
            x = (new double[n]).ToList();
            y = (new double[n]).ToList();
            z = (new double[n]).ToList();
            vx = (new double[n]).ToList();
            vy = (new double[n]).ToList();
            vz = (new double[n]).ToList();
        }

        public void SaveToFile(string filename)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(this));
        }
       
        static public State LoadFromFile(string filename)
        {
            return JsonConvert.DeserializeObject<State>(File.ReadAllText(filename));
        }
        public override string ToString()
        {
            string stroka = "";
            stroka= n.ToString() + " ";
            foreach (double M in m)
            {
                stroka += M.ToString() + " ";
            }
            foreach (double X in x)
            {
               stroka += X.ToString() + " ";
            }
            foreach (double Y in y)
            {
                stroka += Y.ToString() + " ";
            }
            foreach (double Z in z)
            {
                stroka += Z.ToString() + " ";
            }
            foreach (double VX in vx)
            {
                stroka += VX.ToString() + " ";
            }
            foreach (double VY in vy)
            {
                stroka += VY.ToString() + " ";
            }
            foreach (double VZ in vz)
            {
                stroka += VZ.ToString() + " ";
            }
            stroka = stroka + "\n";
            return String.Format("{0}", stroka);
        }
    }
}
