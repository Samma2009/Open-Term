# $${\color{green}Open\color{gold}Term}$$
## $${\color{lightblue}Description}$$
$${\color{green}Open\color{gold}Term}$$ is an open source teminal for Cosmos that uses C#'s default Console commands
## $${\color{lightblue}ExapleCode}$$
```csharp
public class Kernel : Sys.Kernel
{
    Canvas canv;
    Terminal term;
    protected override void BeforeRun()
    {
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
```
## $${\color{lightblue}ColorTable}$$

|Color|Name|Code|
|-----|----|----|
|![#000000](https://placehold.co/15x15/000000/000000.png)|$${\color{Black}Black}$$|$${\color{black}§0}$$|
|![#00008B](https://placehold.co/15x15/00008B/00008B.png)|$${\color{DarkBlue}DarkBlue}$$|$${\color{darkblue}§1}$$|
|![#006400](https://placehold.co/15x15/006400/006400.png)|$${\color{DarkGreen}DarkGreen}$$|$${\color{DarkGreen}§2}$$|
|![#008B8B](https://placehold.co/15x15/008B8B/008B8B.png)|$${\color{DarkCyan}DarkCyan}$$|$${\color{DarkCyan}§3}$$|
|![#8B0000](https://placehold.co/15x15/8B0000/8B0000.png)|$${\color{DarkRed}DarkRed}$$|$${\color{DarkRed}§4}$$|
|![#8B008B](https://placehold.co/15x15/8B008B/8B008B.png)|$${\color{DarkMagenta}DarkMagenta}$$|$${\color{DarkMagenta}§5}$$|
|![#FFD700](https://placehold.co/15x15/FFD700/FFD700.png)|$${\color{Gold}Gold}$$|$${\color{Gold}§6}$$|
|![#808080](https://placehold.co/15x15/808080/808080.png)|$${\color{Gray}Gray}$$|$${\color{Gray}§7}$$|
|![#A9A9A9](https://placehold.co/15x15/A9A9A9/A9A9A9.png)|$${\color{DarkGray}DarkGray}$$|$${\color{DarkGray}§8}$$|
|![#0000FF](https://placehold.co/15x15/0000FF/0000FF.png)|$${\color{Blue}Blue}$$|$${\color{Blue}§9}$$|
|![#008000](https://placehold.co/15x15/008000/008000.png)|$${\color{Green}Green}$$|$${\color{Green}§a}$$|
|![#00FFFF](https://placehold.co/15x15/00FFFF/00FFFF.png)|$${\color{Cyan}Cyan}$$|$${\color{Cyan}§b}$$|
|![#FF0000](https://placehold.co/15x15/FF0000/FF0000.png)|$${\color{Red}Red}$$|$${\color{Red}§c}$$|
|![#FF00FF](https://placehold.co/15x15/FF00FF/FF00FF.png)|$${\color{Magenta}Magenta}$$|$${\color{Magenta}§d}$$|
|![#FFFF00](https://placehold.co/15x15/FFFF00/FFFF00.png)|$${\color{Yellow}Yellow}$$|$${\color{Yellow}§e}$$|
|![#FFFFFF](https://placehold.co/15x15/FFFFFF/FFFFFF.png)|$${\color{White}White}$$|$${\color{White}§f}$$|
