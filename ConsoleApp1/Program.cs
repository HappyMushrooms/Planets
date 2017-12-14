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
            State state = (new AcceleratedMotionTest()).GenerateInitialState();
            // IView view = new TextStreamView(Console.Out);
            string fileName = "d:/2.txt";
              IView view = new GnuPlotView(@"E:/gnuplot/bin/gnuplot.exe");
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
               // IView view = new TextStreamView(writer);
                double t = 0;
                const double tFinal = 10;
                const double dt = 0.01;
                view.Show(state, t);
                IMethod method = new MethodEuler();
                for (t = 0; t < tFinal;)
                {
                    state = method.Calculate(state, dt);
                    t += dt;
                    view.Show(state, t);
                }
            }
            
        }

        private static void RunTests()
        {
            RunSingleTest(new StraightMotionTest());
            RunSingleTest(new AcceleratedMotionTest());
        }

        private static void RunSingleTest(ITest test)
        {
            IMethod method = new MethodEuler();
            const double dt = 0.001;
            State state = test.GenerateInitialState();
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
                state = method.Calculate(state, dt);
            }
        }

    }
}

