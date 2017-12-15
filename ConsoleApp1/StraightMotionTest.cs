using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StraightMotionTest : ITest
    {
        const double x0 = 2;
   
        const double v = 5; 
        public double SuggestedFinalTime => 10;

        public bool Compare(State state, double t)
        {
            double theoretical_x = x0 + v * t;
            if (Math.Abs(state.x[1] - theoretical_x)<0.1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public State GenerateInitialState()
        {
            State s = new State
            {
                n = 2,
                m = new List<double> { 0, 0 },
                vx = new List<double> { 0, v },
                vy = new List<double> { 0, 0 },
                vz = new List<double> { 0, 0 },
                x = new List<double> { 0, x0 },
                y = new List<double> { 1, 0 },
                z = new List<double> { 0, 0 },
            };

            s.SaveToFile(@"d:\qqq.txt");

            return s;
        }
    }
}
