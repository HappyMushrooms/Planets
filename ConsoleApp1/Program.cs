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
            //интерфейс для читалки и сохранялки
        }

        private static void RunTests()
        {
            RunSingleTest(new AcceleratedMotionTest());
            RunSingleTest(new StraightMotionTest());
        }

        private static void RunSingleTest(ITest test)
        {
            IMethod method = null;
            const double dt = 0.1;
            State state = test.Generalinitialstate();
            double time;
            for (time = 0; time < test.SuggestedFinalTime; time += dt)
            {
                bool resulttest = test.Compare(state, time);
                if (resulttest == false)
                {
                    Console.WriteLine("Test failed");
                    break;
                }
                state = method.Calculate(state, dt);
            }
        }
    }
}

