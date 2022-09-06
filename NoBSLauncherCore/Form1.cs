using System.Diagnostics;
using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace NoBSLauncherCore
{
    public partial class Form1 : Form
    {
        private string hoiDirectory = "";
        private Mod[] modList = new Mod[0];
        private List<string> enabledMods = new List<string>();
        private bool initializingMods = true;
        private DLC[] dlcList = new DLC[0];
        private List<string> disabledDLC = new List<string>();
        private bool initializingDLC = true;

        public Form1()
        {
            InitializeComponent();
            checkForHOI();
            initializeMods();
            initializeDLC();
        }

        private void checkForHOI()
        {
            string steamDirectory = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "");
            if (steamDirectory == "" || steamDirectory == null)
            {
                MessageBox.Show("HOI4 not able to be detected automatically. Please select your HOI game directory.");
                showSelectModal();
                return;
            }
            string directoriesPath = steamDirectory + "\\steamapps\\libraryFolders.vdf";
            VProperty readManifest = VdfConvert.Deserialize(File.ReadAllText(directoriesPath));
            foreach (VProperty directory in readManifest.Value)
            {
                string gameString = directory.Value["apps"].ToString();
                if (gameString.IndexOf("\"394360\"") != -1)
                {
                    hoiDirectory = directory.Value["path"].ToString() + "\\steamapps\\common\\Hearts of Iron IV";
                    Console.WriteLine(hoiDirectory);
                }
            }
            if (hoiDirectory == "")
            {
                MessageBox.Show("HOI4 not able to be detected automatically. Please select your HOI game directory.");
                showSelectModal();
                return;
            }
        }

        private void showSelectModal()
        {
            FolderBrowserDialog HOISelector = new FolderBrowserDialog();
            //HOISelector.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            if (HOISelector.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(HOISelector.SelectedPath);
                hoiDirectory = HOISelector.SelectedPath;
            }
        }

        private void initializeMods()
        {
            string userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            string[] files = Directory.GetFiles(userDir + "\\Documents\\Paradox Interactive\\Hearts of Iron IV\\mod", "*.mod");
            modList = new Mod[files.Length];
            dynamic dlcLoadJson = JsonConvert.DeserializeObject(File.ReadAllText(userDir + "\\Documents\\Paradox Interactive\\Hearts of Iron IV\\dlc_load.json"));
            foreach (string enabled_mod in dlcLoadJson.enabled_mods)
            {
                enabledMods.Add(enabled_mod);
            }
            CheckedListBox modListBox = new CheckedListBox();
            modListBox.FormattingEnabled = true;
            modListBox.Location = new Point(0, 25);
            modListBox.Name = "modListBox";
            modListBox.Size = new Size(400, 385);
            modListBox.TabIndex = 1;
            modListBox.ItemCheck += new ItemCheckEventHandler(modListBox_ItemCheck);
            for (int i = 0; i < modList.Length; i++)
            {
                modList[i] = new Mod(files[i]);
                modListBox.Items.Add(modList[i].getName());
                if (enabledMods.IndexOf(modList[i].getModPath()) != -1)
                {
                    modListBox.SetItemChecked(i, true);
                }
            }
            Controls.Add(modListBox);
            initializingMods = false;
        }

        private void initializeDLC()
        {
            string userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            dynamic dlcLoadJson = JsonConvert.DeserializeObject(File.ReadAllText(userDir + "\\Documents\\Paradox Interactive\\Hearts of Iron IV\\dlc_load.json"));
            foreach (string disabled_dlc in dlcLoadJson.disabled_dlcs)
            {
                disabledDLC.Add(disabled_dlc);
            }
            string[] directories = Directory.GetDirectories(hoiDirectory + "\\dlc");
            List<string> dlcInstalled = new List<string>();
            foreach (string directory in directories)
            {
                string[] dlcfile = Directory.GetFiles(directory, "*.dlc");
                if (dlcfile.Length != 0)
                {
                    dlcInstalled.Add(dlcfile[0]);
                }
            }
            CheckedListBox dlcListBox = new CheckedListBox();
            dlcListBox.FormattingEnabled = true;
            dlcListBox.Location = new Point(400, 25);
            dlcListBox.Name = "modListBox";
            dlcListBox.Size = new Size(400, 385);
            dlcListBox.TabIndex = 1;
            dlcListBox.ItemCheck += new ItemCheckEventHandler(dlcListBox_ItemCheck);
            dlcList = new DLC[dlcInstalled.Count];
            for (int i = 0; i < dlcList.Length; i++)
            {
                dlcList[i] = new DLC(dlcInstalled[i]);
                dlcListBox.Items.Add(dlcList[i].getName());
                if (disabledDLC.IndexOf(dlcList[i].getdlcPath()) == -1)
                {
                    dlcListBox.SetItemChecked(i, true);
                }
            }
            Controls.Add(dlcListBox);
            initializingDLC = false;
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            string hoiPath = hoiDirectory + "\\hoi4.exe";
            Process.Start(hoiPath);
            Application.Exit();
        }

        private void modListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!initializingMods)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    enabledMods.Add(modList[e.Index].getModPath());
                    updateDLCLoad();
                }
                else
                {
                    enabledMods.Remove(modList[e.Index].getModPath());
                    updateDLCLoad();
                }
            }
        }

        private void dlcListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!initializingDLC)
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    disabledDLC.Add(dlcList[e.Index].getdlcPath());
                    updateDLCLoad();
                }
                else
                {
                    disabledDLC.Remove(dlcList[e.Index].getdlcPath());
                    updateDLCLoad();
                }
            }
        }

        private void updateDLCLoad()
        {
            string userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            dynamic dlcLoadJson = JsonConvert.DeserializeObject(File.ReadAllText(userDir + "\\Documents\\Paradox Interactive\\Hearts of Iron IV\\dlc_load.json"));
            dlcLoadJson["enabled_mods"] = JsonConvert.SerializeObject(enabledMods);
            dlcLoadJson["disabled_dlcs"] = JsonConvert.SerializeObject(disabledDLC);
            dlcLoadJson = JsonConvert.SerializeObject(dlcLoadJson);
            dlcLoadJson = dlcLoadJson.Replace("\":\"", "\":");
            dlcLoadJson = dlcLoadJson.Replace("\",\"disabled_dlcs", ",\"disabled_dlcs");
            dlcLoadJson = dlcLoadJson.Replace("\\\"", "\"");
            dlcLoadJson = dlcLoadJson.Replace("\"}", "}");
            File.WriteAllText(userDir + "\\Documents\\Paradox Interactive\\Hearts of Iron IV\\dlc_load.json", dlcLoadJson);
        }

        private Mod getModByName(string name)
        {
            foreach (Mod mod in modList)
            {
                if (mod.getName() == name)
                {
                    return mod;
                }
            }
            return null;
        }

        private void debugLaunchButton_Click(object sender, EventArgs e)
        {
            {
                string hoiPath = hoiDirectory + "\\hoi4.exe";
                Process.Start(hoiPath, "-debug");
                Application.Exit();
            }
        }
    }
}