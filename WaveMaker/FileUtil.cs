using System;

namespace WaveMaker
{
    class FileUtil
    {
        public static string GetEXEFolderPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetCurerntFolderPath()
        {
            return Environment.CurrentDirectory;
        }
    }
}
