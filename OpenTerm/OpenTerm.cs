using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTerm
{
    public class Terminal : StringWriter
    {

        Bitmap bmp;
        string buffer = "";
        string ReadingStack = "";
        public bool IsReading = false;
        public Terminal(uint W,uint H) : base()
        {
            bmp = new(W,H,ColorDepth.ColorDepth32);
            bmp.Clear(Color.Black);
        }

        public override void Write(char value)
        {
            OnContentChanged(value.ToString());
        }

        public override void Write(string value)
        {
            OnContentChanged(value);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += buffer[index + i];
            }
            OnContentChanged(s);
        }

        protected virtual void OnContentChanged(string str)
        {
            if (!IsReading)
            {
                buffer += str;
            }
        }
        public string NonBlockingReadline()
        {
            IsReading = true;
            if (KeyboardManager.TryReadKey(out var key))
            {
                if (key.Key == ConsoleKeyEx.Enter)
                {
                    IsReading = false;
                    buffer += ReadingStack +"\n";
                    return ReadingStack;
                }
                else if (key.Key == ConsoleKeyEx.Backspace)
                {
                    if (ReadingStack.Length > 0)
                    {
                        ReadingStack = ReadingStack.Remove(ReadingStack.Length - 1);
                    }
                    else
                    {
                        System.Console.Beep();
                    }
                }
                else
                {
                    ReadingStack += key.KeyChar;
                }
            }
            return "";
        }

        public Bitmap Draw(Color clearColor)
        {
            if (!IsReading) ReadingStack = "";
            bmp.Clear(clearColor);
            var loclb = buffer + ReadingStack;

            var lines = loclb.Split('\n').ToList();

            var maxLines = (bmp.Height / 16) - 2;

            while (lines.Count > maxLines)
            {
                lines.RemoveAt(0);
            }

            var displayText = "";
            foreach (var item in lines)
            {
                displayText += item + "\n";
            }

            bmp.DrawString(displayText.Replace("\t", "   ").Replace("\r", ""), 5, 5);
            return bmp;
        }


    }
}
