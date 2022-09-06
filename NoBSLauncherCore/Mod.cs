using System.IO;

namespace NoBSLauncherCore
{
    internal class Mod
    {
        private string name;
        private string path;
        private string modPath;

        public Mod(string filePath)
        {
            path = filePath;
            modPath = filePath.Substring(filePath.LastIndexOf("mod\\"));
            modPath = modPath.Replace("\\", "/");
            string fullText = File.ReadAllText(filePath);
            fullText = fullText.Substring(fullText.IndexOf("name=\"") + 6);
            fullText = fullText.Substring(0, fullText.IndexOf("\""));
            name = fullText;
        }

        public string getName()
        {
            return name;
        }

        public string getModPath()
        {
            return modPath;
        }
    }
}
