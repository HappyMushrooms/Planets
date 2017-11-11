using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MethodEuler : IMethod
    {
        public State Calculate(State oldState, double dt)
        {
            const double G= 6.67408E-11;
            for (int i = 0; i < oldState.n; i++)
            {
                oldState.x[i] = oldState.x[i] + oldState.vx[i] * dt;
                oldState.y[i] = oldState.y[i] + oldState.vy[i] * dt;
                oldState.z[i] = oldState.z[i] + oldState.vz[i] * dt;
                for (int j = 0; j < oldState.n; j++)
                {
                    if (i != j)
                    {
                        oldState.vx[i] = oldState.vx[i] + ((G * oldState.m[j] * (oldState.x[j] - oldState.x[i])) / (Math.Pow(Math.Sqrt(Math.Pow(oldState.x[j] - oldState.x[i], 2) + Math.Pow(oldState.y[j] - oldState.y[i], 2) + Math.Pow(oldState.z[j] - oldState.z[i], 2)), 3))) * dt;
                        oldState.vy[i] = oldState.vy[i] + ((G * oldState.m[j] * (oldState.y[j] - oldState.y[i])) / (Math.Pow(Math.Sqrt(Math.Pow(oldState.x[j] - oldState.x[i], 2) + Math.Pow(oldState.y[j] - oldState.y[i], 2) + Math.Pow(oldState.z[j] - oldState.z[i], 2)), 3))) * dt;
                        oldState.vz[i] = oldState.vz[i] + ((G * oldState.m[j] * (oldState.z[j] - oldState.z[i])) / (Math.Pow(Math.Sqrt(Math.Pow(oldState.x[j] - oldState.x[i], 2) + Math.Pow(oldState.y[j] - oldState.y[i], 2) + Math.Pow(oldState.z[j] - oldState.z[i], 2)), 3))) * dt;
                    }
                }



            }
            return oldState;
        }
    }
}
