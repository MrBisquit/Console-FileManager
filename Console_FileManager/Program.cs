using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Console_FileManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "FileManager Console Edition - loading...";
            DriveMenu(1);
        }

        static void DriveMenu(int sd)
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("FileManager Console Edition - Drive menu");
            Console.Title = "FileManager Console Edition - Drive menu";
            //Console.WriteLine(sd);
            int rd = 0;
            foreach (var drive in DriveInfo.GetDrives())
            {
                rd++;
                int c = rd;
                if (c == sd)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                //Console.ResetColor();
                if (drive.IsReady == true)
                {
                    Console.WriteLine("{0}", drive.Name);
                }
                if (drive.IsReady == false)
                {
                    Console.WriteLine("{0} (Drive not ready)", drive.Name);
                }
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\n(Enter)drive");

            Console.ResetColor();

            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (sd == 1)
                {

                }
                else
                {
                    sd--;
                    Console.WriteLine("Down arrow pressed");
                }
            }
            if (key == ConsoleKey.DownArrow)
            {
                if (sd == DriveInfo.GetDrives().Length)
                {

                }
                else
                {
                    sd++;
                    Console.WriteLine("Up arrow pressed");
                }
            }
            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                //StartTest(DriveInfo.GetDrives()[sd - 1].Name);
                if(DriveInfo.GetDrives()[sd - 1].IsReady == false)
                {
                    DriveMenu(sd);
                }
                FileMenu(DriveInfo.GetDrives()[sd - 1].Name, 1);
                var key2 = Console.ReadKey().Key;
                if (key2 == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("Spacebar key was pressed.");
                }
            }
            DriveMenu(sd);
        }

        static void FileMenu(string loc, int sd)
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("FileManager Console Edition - " + loc);
            Console.Title = "FileManager Console Edition - " + loc;
            //Console.WriteLine(sd);
            int rd = 0;
                //rd++;
                
                string[] dirs = Directory.GetDirectories(loc);
                foreach (var dir in dirs)
                {
                rd++;
                int c = rd;
                if (c == sd)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                    Console.WriteLine(directoryInfo.Name);
                    //View.Items.Add(directoryInfo.Name);
                    //Info.Items.Add($"{directoryInfo.CreationTime} <DIR>");
                }
                /*string[] files = Directory.GetFiles(loc);
                foreach (var file in files)
                {
                rd++;
                int c = rd;
                if (c == sd)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine(fileInfo.Name);
                    //View.Items.Add(fileInfo.Name);
                    //Info.Items.Add($"{fileInfo.CreationTime} {fileInfo.Extension}");
                }*/
                //Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\n(D)rive menu (Enter)directory (Escape)Back[Coming soon]");
            Console.WriteLine("Files are not visible");

            Console.ResetColor();

            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (sd == 1)
                {

                }
                else
                {
                    sd--;
                    Console.WriteLine("Down arrow pressed");
                }
            }
            if (key == ConsoleKey.DownArrow)
            {
                if (sd == rd)
                {

                }
                else
                {
                    sd++;
                    Console.WriteLine("Up arrow pressed");
                }
            }
            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                //StartTest(DriveInfo.GetDrives()[sd - 1].Name);
                try
                {
                    FileMenu(dirs[sd - 1], 1);
                }
                catch (Exception e)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2500);
                    Console.ResetColor();
                    FileMenu(loc, sd);
                }
                FileMenu(dirs[sd], 1);
                var key2 = Console.ReadKey().Key;
                if (key2 == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("Spacebar key was pressed.");
                }
            }
            if (key == ConsoleKey.D)
            {
                DriveMenu(1);
            }
            FileMenu(loc, sd);
        }
    }
}
