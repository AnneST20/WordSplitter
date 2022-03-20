using System;
using System.IO;

namespace WordSplitter
{
    internal class FileReader
    {
        string[] lines;
        string[] files;
        string currentPath;
        static string exePosition = @"bin\Debug\net5.0";

        public FileReader()
        {
            if (Directory.GetCurrentDirectory().Contains(exePosition))
            {
                currentPath = Directory.GetCurrentDirectory()
                    .Replace(exePosition, @"Texts\");
            }
            else
            {
                currentPath = Directory.GetCurrentDirectory();
            }

            // this is for the ability to enter the number of the text file
            // instead of writing the full path
            files = Directory.GetFiles(currentPath);
            if (files.Length > 0)
            {

                Console.WriteLine("\n To make the using of the program a bit " +
                    "easier here's a list of already excisting files:");
                ShowFiles();
            }

            bool pathIsEntred = false;
            string path;

            do
            {
                path = GetPath(pathIsEntred);
                pathIsEntred = true;
            }
            while (!IsRead(path, out lines));

            ShowOpenedFile(path);
        }

        /// <summary>
        /// To check if file is read or not
        /// </summary>
        /// <param name="path">The path of the file we want to read</param>
        /// <returns></returns>
        bool IsRead(string path, out string[] lines)
        {
            try
            {
                lines = File.ReadAllLines(path);
            }
            catch 
            {
                lines = null;
                return false; 
            }
            return true;
        }

        /// <summary>
        /// Due to the problem that file may not be read because the previous path was invalid
        /// this method helps to get the path until it will be valid
        /// </summary>
        /// <param name="pathIsEntered">If the path was ever entered before</param>
        /// <returns></returns>
        string GetPath(bool pathIsEntered)
        {
            if (!pathIsEntered)
            {
                Console.Write(" Path or the number of file: ") ;
            }
            else
            {
                ConsoleCleaner.ClearConsoleLine();
                Console.Write(" Path or number is invalid. Try  again: ");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string path = Console.ReadLine();
            Console.ResetColor();
            int number;

            if (Int32.TryParse(path, out number))
            {
                path = files.Length <= number ? path = files[number - 1] : null;
            }

            return path;
        }

        /// <summary>
        /// Shows the names and the numbers of all text files in Texts folder
        /// </summary>
        void ShowFiles()
        {
            Console.WriteLine();

            int counter = 1;

            foreach(string file in files)
            {
                string fileName = file.Replace(currentPath, "");
                Console.Write("\t{0} - ", counter++);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(fileName);
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Writes in Console the name of the file that was opened and read
        /// </summary>
        /// <param name="path"></param>
        void ShowOpenedFile(string path)
        {
            string fileName = path.Replace(currentPath, "");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n " + fileName);
            Console.ResetColor();
            Console.WriteLine(" was opened");
        }

        /// <summary>
        /// Returns the array of lines from the file that was read
        /// </summary>
        /// <returns></returns>
        public string[] GetLines()
        {
            return lines;
        }

    }
}
