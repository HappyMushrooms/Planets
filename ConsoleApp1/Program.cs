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
            State state = State.LoadFromFile("d:/1.txt");
            IView view = new TextStreamView(Console.Out);
            double t = 0;
            const double tFinal = 10;
            const double dt = 0.1;
            view.Show(state, t);
            IMethod method = new MethodEuler();
            for (t = 0; t < tFinal; )
            {
                state = method.Calculate(state, dt);
                t += dt;

                view.Show(state, t);
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
            State state = test.Generalinitialstate();
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

