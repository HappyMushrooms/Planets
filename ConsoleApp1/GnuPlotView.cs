using System; 
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace ConsoleApp1
// IDisposable
{
    internal class GnuPlotView : IView
    {
        // 
        public string ToPathFile;
        //
        Process extPro;
        StreamWriter gnupStWr;

        public GnuPlotView(string v)
        {
            this.ToPathFile = v;
            //  string pgm = @"E:\gnuplot\bin\gnuplot.exe";
            // starting GNUPLOT
            extPro = new Process();
            extPro.StartInfo.FileName = ToPathFile;
            extPro.StartInfo.UseShellExecute = false;
            extPro.StartInfo.RedirectStandardInput = true;
            extPro.Start();
            gnupStWr = extPro.StandardInput;
        }

        // countdown from 0001 on 1 January
        public long Time()
        {
            DateTime nw = DateTime.Now;
            long time1 = nw.Ticks / 10000000;    //time in seconds
            return time1;

        }
        long c=0;

        public void Show(State state, double t)
        {
            // State s = State.LoadFromFile("E:/1.txt");
            long b = Time();
           // Console.WriteLine( b);
            if (b-c>=1)//relative to real time (sec)
            {
                //gnupStWr.WriteLine("plot \"-\" u 1:2");

                gnupStWr.WriteLine("plot sin(x)  \npause 10");
                gnupStWr.Flush();
               Console.WriteLine("b= {0}",b);
                c = Time();
                Console.WriteLine("c= {0}", c);
            }
        }

      }
}