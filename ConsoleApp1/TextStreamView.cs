using System.IO;

namespace ConsoleApp1
{
    public class TextStreamView : IView
    {
        private TextWriter outputStream;

        public TextStreamView(TextWriter @out)
        {
            this.outputStream = @out;
        }

        public void Show(State state, double t)
        {
            outputStream.WriteLine("{0} {1}", t, state);
        }
    }
}