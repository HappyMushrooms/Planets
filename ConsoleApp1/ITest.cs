using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface ITest
    {
        double SuggestedFinalTime{ get; }
        //set the initial conditions
        State Generalinitialstate();
        // compare the given state with analytical solution
        bool Compare(State state, double t);
    }
}
