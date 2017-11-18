using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AcceleratedMotionTest : ITest
    {
        const double v0 = 0.1;
        const double t0 = 0;
        const double alpha = 45;
        double vx0 = v0 * Math.Cos(alpha);
        double vy0 = v0 * Math.Sin(alpha);
        double vz0 = 0;
        const double MEarth = 5.972E24;
        const double REarth = 6400000;
        const double G = 6.67408E-11;
        double g = G * MEarth / (REarth * REarth);
        double x0 = 0;
        double y0 = 0;


        public double SuggestedFinalTime => 10;

        public bool Compare(State state, double t)
        {
            double vx = v0 * Math.Cos(alpha);
            double vy = v0 * Math.Sin(alpha) - g * t;
            double vz = 0;
            double x = x0 + v0 * t * Math.Cos(alpha);
            double y = y0 + v0 * t * Math.Sin(alpha) - ((g * t * t) / 2);

            if ((Math.Abs(2 * (state.x[0] - x) / (state.x[0] + x)) > 0.1))

            {
                return false;
            }

            if ((Math.Abs(2 * (state.y[0] - y) / (state.y[0] + y)) > 0.1))

            {
                return false;
            }

            if ((Math.Abs(2 * (state.vx[0] - vx) / (state.vx[0] + vx)) > 0.1))

            {
                return false;
            }

            if ((Math.Abs(2 * (state.vy[0] - vy) / (state.vy[0] + vy)) > 0.1))

            {
                return false;
            }

            return true;

        }

        public State Generalinitialstate()
        {
            //[0]-BODY, [1]-Earth
            return new State
            {
                n = 2,
                vx = new List<double> { vx0, 0 },
                vy = new List<double> { vy0, 0 },
                vz = new List<double> { 0, 0 },
                x = new List<double> { 0, 0 },
                y = new List<double> { 0, -REarth },
                z = new List<double> { 0, 0 },
                m = new List<double> { 1, MEarth },
            };
        }


    }
}
