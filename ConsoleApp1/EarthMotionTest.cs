using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    public class EarthMotionTest : ITest
    {
        const double r = 1.496e11; //Растояние от земли до солнца
        const double M_Sun = 1.989e30; //Масса Солнца
        const double M_Earth = 5.972E24;
        const double alfa0 = 0;
        const double v0y = 29000;
        const double v0x = 0;
        const double w0 = v0y / r;
        double theoretical_x;
        double theoretical_y;
        double theoretical_vx;
        double theoretical_vy;
        public double SuggestedFinalTime => 31536000;
        public bool Compare(State state, double t)
        {
            theoretical_x = r * Math.Cos(alfa0 + w0 * t);
            theoretical_y = r * Math.Sin(alfa0 + w0 * t);
            theoretical_vx = -r* w0 * Math.Sin(w0 * t);
            theoretical_vy = r * w0 * Math.Cos(w0 * t);
            if (Math.Abs(state.x[0] - theoretical_x) > 0.1)
            {
                return false;


            }
            if (Math.Abs(state.y[0] - theoretical_y) > 0.1)
            {
                return false;

            }
            if (Math.Abs(state.vx[0] - theoretical_vx) > 0.1)
            {
                return false;

            }
            if (Math.Abs(state.vy[0] - theoretical_vy) > 0.1)
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
                 m = new List<double> { M_Earth, M_Sun },
                 vx = new List<double> { v0x, 0 },
                 vy = new List<double> { v0y, 0},
                 vz = new List<double> { 0, 0 },
                 x = new List<double> { r*4, r*3 },
                 y = new List<double> { r*4, r*3 },
                 z = new List<double> { 0, 0 },

             };

             return s;
         }

     }

 }
      
