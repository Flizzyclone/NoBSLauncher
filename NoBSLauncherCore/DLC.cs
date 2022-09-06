using System.IO;

namespace NoBSLauncherCore
{
    internal class DLC
    {
        private string name;
        private string path;
        private string dlcPath;

        public DLC(string filePath)
        {
            path = filePath;
            dlcPath = filePath.Substring(filePath.LastIndexOf("dlc\\"));
            dlcPath = dlcPath.Replace("\\", "/");
            string fullText = File.ReadAllText(filePath);
            fullText = fullText.Substring(fullText.IndexOf("name = \"") + 8);
            fullText = fullText.Substring(0, fullText.IndexOf("\""));
            name = fullText;
        }

        public string getName()
        {
            return name;
        }

        public string getdlcPath()
        {
            return dlcPath;
        }
    }
}
