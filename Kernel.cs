using Cosmos.Core.Memory;
using Cosmos.Debug.Kernel;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace OpenTerm
{
    public class Kernel : Sys.Kernel
    {

        Canvas canv;

        public static Debugger db;
        Terminal term;

        protected override void BeforeRun()
        {
            db = mDebugger;
            canv = FullScreenCanvas.GetFullScreenCanvas(new Mode(1280,720,ColorDepth.ColorDepth32));
            term = new Terminal(canv.Mode.Width, canv.Mode.Height);
            Console.SetOut(term);
            Console.WriteLine("§4Hello, §2World!");
            
        }

        protected override void Run()
        {
            canv.Clear();
            Console.Write("Input: ");
            var input = term.NonBlockingReadline();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
            canv.DrawImage(term.Draw(Color.Black),0,0);
            canv.Display();
            Heap.Collect();
        }
    }
}
