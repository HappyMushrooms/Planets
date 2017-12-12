using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Runge_Kutta : IMethod
    {
        const double G = 6.67408E-11;
        private double Fx(int i, State state)
        {
            return state.vx[i];
        }
        private double Fy(int i, State state)
        {
            return state.vy[i];
        }
        private double Fz(int i, State state)
        {
            return state.vz[i];
        }
        private double Fvx(int i, State state)
        {
            double sum = 0;

            for (int j = 0; j < state.n; j++)
            {
                if (i == j)
                {
                    continue;
                }

                sum = sum + (state.x[i] - state.x[j]) * state.m[j] / (Math.Pow(Math.Pow(state.x[j] - state.x[i], 2) + Math.Pow(state.y[j] - state.y[i], 2) + Math.Pow(state.z[j] - state.z[i], 2), 3 / 2));

            }
            return G * sum;
        }
        private double Fvy(int i, State state)
        {
            double sum = 0;

            for (int j = 0; j < state.n; j++)
            {
                if (i == j)
                {
                    continue;
                }

                sum = sum + (state.y[i] - state.y[j]) * state.m[j] / (Math.Pow(Math.Pow(state.x[j] - state.x[i], 2) + Math.Pow(state.y[j] - state.y[i], 2) + Math.Pow(state.z[j] - state.z[i], 2), 3 / 2));

            }
            return G * sum;
        }

        private double Fvz(int i, State state)
        {
            double sum = 0;

            for (int j = 0; j < state.n; j++)
            {
                if (i == j)
                {
                    continue;
                }

                sum = sum + (state.z[i] - state.z[j]) * state.m[j] / (Math.Pow(Math.Pow(state.x[j] - state.x[i], 2) + Math.Pow(state.y[j] - state.y[i], 2) + Math.Pow(state.z[j] - state.z[i], 2), 3 / 2));

            }
            return G * sum;
        }

        public State Calculate(State oldState, double dt)
        {

            List<double> kx1 = new List<double>();
            List<double> ky1 = new List<double>();
            List<double> kz1 = new List<double>();
            List<double> kvx1 = new List<double>();
            List<double> kvy1 = new List<double>();
            List<double> kvz1 = new List<double>();
            for (int i = 0; i < oldState.n; i++)
            {
                kx1[i] = Fx(i, oldState) * dt;
                ky1[i] = Fy(i, oldState) * dt;
                kz1[i] = Fz(i, oldState) * dt;
                kvx1[i] = Fvx(i, oldState) * dt;
                kvy1[i] = Fvy(i, oldState) * dt;
                kvz1[i] = Fvz(i, oldState) * dt;
            }

            State st2 = new State
            {
                n = oldState.n
            };

            List<double> kx2 = new List<double>();
            List<double> ky2 = new List<double>();
            List<double> kz2 = new List<double>();
            List<double> kvx2 = new List<double>();
            List<double> kvy2 = new List<double>();
            List<double> kvz2 = new List<double>();

            for (int i = 0; i < oldState.n; i++)
            {
                st2.x[i] = oldState.x[i] + kx1[i] / 2;
                st2.y[i] = oldState.y[i] + ky1[i] / 2;
                st2.z[i] = oldState.z[i] + kz1[i] / 2;
                st2.vx[i] = oldState.vx[i] + kvx1[i] / 2;
                st2.vy[i] = oldState.vy[i] + kvy1[i] / 2;
                st2.vz[i] = oldState.vz[i] + kvz1[i] / 2;
            }

            for (int i = 0; i < oldState.n; i++)
            {
                kx2[i] = Fx(i, st2) * dt;
                ky2[i] = Fy(i, st2) * dt;
                kz2[i] = Fz(i, st2) * dt;
                kvx2[i] = Fvx(i, st2) * dt;
                kvy2[i] = Fvy(i, st2) * dt;
                kvy2[i] = Fvy(i, st2) * dt;
            }

            State st3 = new State
            {
                n = oldState.n
            };

            List<double> kx3 = new List<double>();
            List<double> ky3 = new List<double>();
            List<double> kz3 = new List<double>();
            List<double> kvx3 = new List<double>();
            List<double> kvy3 = new List<double>();
            List<double> kvz3 = new List<double>();

            for (int i = 0; i < oldState.n; i++)
            {
                st3.x[i] = oldState.x[i] + kx2[i] / 2;
                st3.y[i] = oldState.y[i] + ky2[i] / 2;
                st3.z[i] = oldState.z[i] + kz2[i] / 2;
                st3.vx[i] = oldState.vx[i] + kvx2[i] / 2;
                st3.vy[i] = oldState.vy[i] + kvy2[i] / 2;
                st3.vz[i] = oldState.vz[i] + kvz2[i] / 2;
            }

            for (int i = 0; i < oldState.n; i++)
            {
                kx3[i] = Fx(i, st3) * dt;
                ky3[i] = Fy(i, st3) * dt;
                kz3[i] = Fz(i, st3) * dt;
                kvx3[i] = Fvx(i, st3) * dt;
                kvy3[i] = Fvy(i, st3) * dt;
                kvy3[i] = Fvy(i, st3) * dt;
            }

            State st4 = new State
            {
                n = oldState.n
            };

            List<double> kx4 = new List<double>();
            List<double> ky4 = new List<double>();
            List<double> kz4 = new List<double>();
            List<double> kvx4 = new List<double>();
            List<double> kvy4 = new List<double>();
            List<double> kvz4 = new List<double>();

            for (int i = 0; i < oldState.n; i++)
            {
                st4.x[i] = oldState.x[i] + kx3[i];
                st4.y[i] = oldState.y[i] + ky3[i];
                st4.z[i] = oldState.z[i] + kz3[i];
                st4.vx[i] = oldState.vx[i] + kvx3[i];
                st4.vy[i] = oldState.vy[i] + kvy3[i];
                st4.vz[i] = oldState.vz[i] + kvz3[i];
            }

            for (int i = 0; i < oldState.n; i++)
            {
                kx4[i] = Fx(i, st4) * dt;
                ky4[i] = Fy(i, st4) * dt;
                kz4[i] = Fz(i, st4) * dt;
                kvx4[i] = Fvx(i, st4) * dt;
                kvy4[i] = Fvy(i, st4) * dt;
                kvy4[i] = Fvy(i, st4) * dt;
            }


            State newState = new State
            {
                n = oldState.n
            };

            for (int i = 0; i < newState.n; i++)
            {
                newState.x[i] = oldState.x[i] + (kx1[i] + 2 * kx2[i] + 2 * kx3[i] + kx4[i]) / 6;
                newState.y[i] = oldState.y[i] + (ky1[i] + 2 * ky2[i] + 2 * ky3[i] + ky4[i]) / 6;
                newState.z[i] = oldState.z[i] + (kz1[i] + 2 * kz2[i] + 2 * kz3[i] + kz4[i]) / 6;
                newState.vx[i] = oldState.vx[i] + (kvx1[i] + 2 * kvx2[i] + 2 * kvx3[i] + kvx4[i]) / 6;
                newState.vy[i] = oldState.vy[i] + (kvy1[i] + 2 * kvy2[i] + 2 * kvy3[i] + kvy4[i]) / 6;
                newState.vz[i] = oldState.vz[i] + (kvz1[i] + 2 * kvz2[i] + 2 * kvz3[i] + kvz4[i]) / 6;
            }


            return newState;
        }


    }

}




