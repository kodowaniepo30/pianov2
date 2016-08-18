using System;

namespace PianoV2
{
    class Program
    {
        static bool empty = true;
        static void Main(string[] args)
        {
            string[] Notes = new string[200];
            int i = 0;
            int soundLength = 300;
            bool exit = false;
            Settings();
            About();
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Q: Note(261, soundLength, ConsoleKey.Q); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.W: Note(293, soundLength, ConsoleKey.W); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.E: Note(329, soundLength, ConsoleKey.E); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.R: Note(349, soundLength, ConsoleKey.R); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.T: Note(392, soundLength, ConsoleKey.T); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.Y: Note(440, soundLength, ConsoleKey.Y); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.U: Note(493, soundLength, ConsoleKey.U); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.I: Note(523, soundLength, ConsoleKey.I); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.P: System.Threading.Thread.Sleep(200); Notes[i] += key.Key; i++; break;
                        case ConsoleKey.Escape: exit = true; break;
                        case ConsoleKey.X: Play(Notes, soundLength); break;
                        case ConsoleKey.Z: Clear(Notes); break;
                        case ConsoleKey.V: ConvToPian(Notes, soundLength); break;
                        default: break;
                    }
                }
            }
            Console.WriteLine("\n");
        }

        static void About()
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║   Q   W   E   R   T    Y   U   I    ║");
            Console.WriteLine("║                                     ║");
            Console.WriteLine("║   DO  RE  MI  FA  SOL  LA  SI  DO   ║");
            Console.WriteLine("║                                     ║");
            Console.WriteLine("╠═════════════════════════════════════╣");
            Console.WriteLine("║      V - KONWERTUJ DO PROGRAMU      ║");
            Console.WriteLine("╠═════════════════════════════════════╣");
            Console.WriteLine("║   ESC - EXIT  Z - ERASE  X - PLAY   ║");
            Console.WriteLine("╚═════════════════════════════════════╝\n");
        }

        static bool Note(int soundPitch, int soundLength, ConsoleKey key)
        {
            Console.Beep(soundPitch, soundLength);
            Console.Write(key + " ");
            return empty = false;
        }

        static bool Clear(string[] Notes)
        {
            About();
            if (empty)
            {
                Console.WriteLine("Nie ma czego skasować!");
            }
            else
            {
                Array.Clear(Notes, 0, Notes.Length);
                Console.WriteLine("Skasowane!");
            }
            System.Threading.Thread.Sleep(500);
            About();
            return empty = true;
        }

        static void Play(string[] Notes, int soundLength)
        {
            About();
            if (empty)
            {
                Console.WriteLine("Nie ma czego zagrać!");
                System.Threading.Thread.Sleep(500);
            }
            else
            {
                foreach (var n in Notes)
                {
                    if (n == "Q") Note(261, soundLength, ConsoleKey.Q);
                    if (n == "W") Note(293, soundLength, ConsoleKey.W);
                    if (n == "E") Note(329, soundLength, ConsoleKey.E);
                    if (n == "R") Note(349, soundLength, ConsoleKey.R);
                    if (n == "T") Note(392, soundLength, ConsoleKey.T);
                    if (n == "Y") Note(440, soundLength, ConsoleKey.Y);
                    if (n == "U") Note(493, soundLength, ConsoleKey.U);
                    if (n == "I") Note(523, soundLength, ConsoleKey.I);
                    if (n == "P") System.Threading.Thread.Sleep(200);
                }              
            }
            System.Threading.Thread.Sleep(500);
            About();
        }

        static void Settings()
        {
            Console.Title = "Piano ver. 0.0.2.0";
            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(40, 20);
        }

        static void ConvToPian(string[] Notes,int soundLength)
        {
            int l = 0;
            string[] NotesCTP = new string[200];
            Console.WriteLine("Poniżej wklej nuty (nie więcej niż 200)");
            Console.WriteLine("np. G-A-E-C'. Oddzielone od siebie ");
            Console.WriteLine("znakiem który podasz na chwile. Jeżeli");
            Console.WriteLine("chcesz wstawić opóźnienie między nuty,"); 
            Console.WriteLine("umieśc tam litere P.\n");
            Console.Write("Wklej tekst: ");
            string inputText = Console.ReadLine();
            inputText = inputText.ToLower();
            Console.Write("\nPodaj znak oddzielający: ");
            char separator = Convert.ToChar(Console.ReadLine());
            string[] temp = inputText.Split(separator);
            foreach (var n in temp)
            {
                NotesCTP[l] = n;
                l++;
            }
            Console.WriteLine("\n");
            for (int j = 0; j < NotesCTP.Length; j++)
            {
               Notes[j] += Change(j, NotesCTP);
                Console.Write(Notes[j]+ " ");
            }
            Console.WriteLine("\nNuty wprowadzone do programu");
            Console.WriteLine("Zaraz rozpocznie się muzyka !");
            System.Threading.Thread.Sleep(2000);
            empty = false;
            Play(Notes, soundLength);
            Clear(Notes);
        }

        static string Change(int k, string[] Notes)
        {
            string tempChange = "", charChange = "";
            tempChange = Notes[k];
            if (tempChange == "c") charChange = "Q";
            if (tempChange == "d") charChange = "W";
            if (tempChange == "e") charChange = "E";
            if (tempChange == "f") charChange = "R";
            if (tempChange == "g") charChange = "T";
            if (tempChange == "a") charChange = "Y";
            if (tempChange == "h") charChange = "U";
            if (tempChange == "c'") charChange = "I";
            if (tempChange == "p") charChange = "P";
            return charChange;
        }   
    }
}