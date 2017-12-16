using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    public class EarthMotionTest : ITest
    {
        const  double G = 6.6742e-11; //Гравитационная постоянная
        const double r = 1.496e11; //Растояние от земли до солнца
        const double M_c = 1.989e30; //Масса Солнца
        const double M = 5.972E24;
        const double alfa0 = 0;
        const double v0y = 29000;
        const double v0x = 0;
        const double w0 = v0y / r;
        double theoretical_x;
        double theoretical_y;
        double theoretical_vx;
        double theoretical_vy;

        public double SuggestedFinalTime => 10;



        public bool Compare(State state, double t)
        {


            theoretical_x = r * Math.Cos(alfa0 + w0 * t);
            theoretical_y = r * Math.Sin(alfa0 + w0 * t);
            theoretical_vx = -r * w0 * Math.Sin(w0 * t);
            theoretical_vy = r * w0 * Math.Cos(w0 * t);

            if (Math.Abs(state.x[1] - theoretical_x) > 0.1)
            {
                return false;


            }
            if (Math.Abs(state.y[1] - theoretical_y) > 0.1)
            {
                return false;

            }
            if (Math.Abs(state.vx[1] - theoretical_vx) > 0.1)
            {
                return false;

            }
            if (Math.Abs(state.vy[1] - theoretical_vy) > 0.1)
            {
                return false;

            }
            return true;

        }

        public State GenerateInitialState()
        {
            State s = new State
            {
                n = 2,
                m = new List<double> { M, M_c },
                vx = new List<double> { 0, 0 },
                vy = new List<double> { v0x, 0 },
               // vz = new List<double> { 0, 0 },
                x = new List<double> { r, 0 },
                y = new List<double> { 0, 0 },
               // z = new List<double> { 0, 0 },

            };

            return s;
        }
        
    }

}
