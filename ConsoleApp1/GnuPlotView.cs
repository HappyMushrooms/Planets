using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace ConsoleApp1
// IDisposable (в новый класс )
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
            // gnupStWr.WriteLine("set object 1 rectangle from screen 0,0 to screen 1,1 fillcolor rgb\"white\" behind\n");
            // gnupStWr.WriteLine("set xrange [0:1000]\n");
           gnupStWr.WriteLine("set yrange [0:10e11]\n");
           gnupStWr.WriteLine("set xrange [0:10e11]\n");
        }

        // countdown from 0001 on 1 January
        //public long Time()
        //{
        //    DateTime nw = DateTime.Now;
        //    long time1 = nw.Ticks / 10000000;    //time in seconds
        //    return time1;
        //}        
        //long c=0;

        public void Show(State state, double t)
        {
            // State s = State.LoadFromFile("E:/1.txt");
            //long b = Time();
            //if (b-c>=0)//relative to real time (sec)
            //{
            gnupStWr.WriteLine("plot '-' u 1:2 with points lc rgb 'black' pt 7");
            for (int i = 0; i < 1/* state.n*/; i++)
            {
                gnupStWr.WriteLine("{0} {1}", 3*1.496e11, 3*1.496e11);
                gnupStWr.WriteLine("{0} {1}", state.x[i], state.y[i]);
            }
            gnupStWr.WriteLine("e");
            //Console.WriteLine("b= {0}",b);
            //c = Time();
            //Console.WriteLine("c= {0}", c);
            //}
            gnupStWr.Flush();
        }

    }
}