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
            //присваевоем начальное значение теста 0
            ITest test=new StraightMotionTest ();

            //присваевоем начальное значение метода 0
            IMethod method = null;
            //шаг по времени 
            const double dt=0.1;
            // сравнение значений какого-либо состояния с аналитическим значением
            State state = test.Generalinitialstate();
            double time;
            for (time =0; time<test.SuggestedFinalTime; time+=dt)
            {
                //сравнение полученного результата с аналитическим значением
                bool resulttest =test.Compare(state, time);
                if(resulttest==false)
                {
                    Console.WriteLine("Test failed");
                    break;
                }
                state = method.Calculate(state, dt);
            }
        }
    }
}
