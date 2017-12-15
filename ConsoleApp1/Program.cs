using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTests();
            DoCalculations();
        }

        private static void DoCalculations()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //State state = State.LoadFromFile("d:/1.txt");
            //State state = (new AcceleratedMotionTest()).GenerateInitialState();
            State state = (new EarthMotionTest()).GenerateInitialState();
            // IView view = new TextStreamView(Console.Out);
            string fileName = "d:/2.txt";
            IView view = new GnuPlotView(@"C:/gnuplot/bin/gnuplot.exe");
            long c = 0;
            long Time()
            {
                DateTime nw = DateTime.Now;
                long time1 = nw.Ticks / 10000000;    //time in seconds
                return time1;
            }
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                //IView view = new TextStreamView(writer);
                double t = 0;
                const double tFinal = 10;
                const double dt = 0.1;
                view.Show(state, t);
                IMethod method = new Runge_Kutta(state.n);
                //IMethod method = new MethodEuler();
                for (t = 0; t < tFinal;)
                {
                    state = method.Calculate(state, dt);
                    t += dt;
                    //вывести раз в секунду
                    long b = Time();
                    if (b - c >= 0)//relative to real time (sec)
                    {
                        for (int i = 0; i < state.n; i++)
                        {
                            view.Show(state, t);
                        }
                        c = Time();
                    }
                }
            }
            
        }

        private static void RunTests()
        {
            //RunSingleTest(new StraightMotionTest());
            //RunSingleTest(new AcceleratedMotionTest());
            RunSingleTest(new EarthMotionTest());            
        }

        private static void RunSingleTest(ITest test)
        {
            State state = test.GenerateInitialState();
            IMethod method = new Runge_Kutta(state.n);
            //IMethod method = new MethodEuler();
            const double dt = 0.1;
            double time;
            for (time = 0; time < test.SuggestedFinalTime; time += dt)
            {
                bool resulttest = test.Compare(state, time);
                if (resulttest == false)
                {
                    Console.WriteLine("Test {0} failed ", test.GetType().ToString());
                    Console.WriteLine(time);
                    break;
                }
               // Console.WriteLine(time);
                state = method.Calculate(state, dt);
            }
        }

    }
}

