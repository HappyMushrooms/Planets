using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StraightMotionTest : ITest
    {
        public double SuggestedFinalTime => 10;

        public bool Compare(State state, double t)
        {
            throw new NotImplementedException();
        }

        public State Generalinitialstate()
        {
            State s = new State
            {
                n = 2,
                m = new List<double> { 0, 0 },
                vx = new List<double> { 0, 1 },
                vy = new List<double> { 0, 0 },
                vz = new List<double> { 0, 0 },
                x = new List<double> { 0, 0 },
                y = new List<double> { 1, 0 },
                z = new List<double> { 0, 0 },
            };

            s.SaveToFile(@"d:\qqq.txt");

            return s;
        }
    }
}
