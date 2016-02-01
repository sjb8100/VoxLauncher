using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;

namespace VoxLauncher
{
    public partial class MainWindow : Window
    {
        Settings m_settings = new Settings();

        // Main entry point
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = m_settings;

            SetDefaultSettings();

            LoadSettings();
        }

        // Set default settings
        public void SetDefaultSettings()
        {
            // Some sensible default settings...
            m_settings.WindowWidth = 1150;
            m_settings.WindowHeight = 900;
            m_settings.VSync = false;
            m_settings.FullScreen = false;
            m_settings.DeferredRendering = false;
            m_settings.Shadows = true;
            m_settings.Blur = false;
            m_settings.SSAO = true;
            m_settings.DynamicLighting = true;
            m_settings.MSAA = true;
            m_settings.InstancedParticles = true;
            m_settings.WireframeRendering = false;

            // Landscape

            // Debug
            m_settings.DebugRendering = false;
            m_settings.FaceMerging = true;
            m_settings.StepUpdating = false;
            m_settings.ShowDebugGUI = true;
        }

        // Load settings
        public void LoadSettings()
        {
            // Load in from settings.ini
            IniReader iniFile = new IniReader(System.IO.Path.GetFullPath("media//config//settings.ini"));

            // Graphics
            m_settings.WindowWidth = iniFile.ReadInteger("Graphics", "WindowWidth");
            m_settings.WindowHeight = iniFile.ReadInteger("Graphics", "WindowHeight");
            m_settings.VSync = iniFile.ReadBoolean("Graphics", "VSync");
            m_settings.FullScreen = iniFile.ReadBoolean("Graphics", "FullScreen");
            m_settings.DeferredRendering = iniFile.ReadBoolean("Graphics", "DeferredRendering");
            m_settings.Shadows = iniFile.ReadBoolean("Graphics", "Shadows");
            m_settings.Blur = iniFile.ReadBoolean("Graphics", "Blur");
            m_settings.SSAO = iniFile.ReadBoolean("Graphics", "SSAO");
            m_settings.DynamicLighting = iniFile.ReadBoolean("Graphics", "DynamicLighting");
            m_settings.MSAA = iniFile.ReadBoolean("Graphics", "MSAA");
            m_settings.InstancedParticles = iniFile.ReadBoolean("Graphics", "InstancedParticles");
            m_settings.FaceMerging = iniFile.ReadBoolean("Graphics", "FaceMerging");

            // Landscape
            float landscapeOctaves;
            float.TryParse(iniFile.ReadString("Landscape", "LandscapeOctaves"), out landscapeOctaves);
            m_settings.LandscapeOctaves = landscapeOctaves;
            float landscapePersistence;
            float.TryParse(iniFile.ReadString("Landscape", "LandscapePersistence"), out landscapePersistence);
            m_settings.LandscapePersistence = landscapePersistence;
            float landscapeScale;
            float.TryParse(iniFile.ReadString("Landscape", "LandscapeScale"), out landscapeScale);
            m_settings.LandscapeScale = landscapeScale;
            float mountainOctaves;
            float.TryParse(iniFile.ReadString("Landscape", "MountainOctaves"), out mountainOctaves);
            m_settings.MountainOctaves = mountainOctaves;
            float mountainPersistence;
            float.TryParse(iniFile.ReadString("Landscape", "MountainPersistence"), out mountainPersistence);
            m_settings.MountainPersistence = mountainPersistence;
            float mountainScale;
            float.TryParse(iniFile.ReadString("Landscape", "MountainScale"), out mountainScale);
            m_settings.MountainScale = mountainScale;
            float mountainMultiplier;
            float.TryParse(iniFile.ReadString("Landscape", "MountainMultiplier"), out mountainMultiplier);
            m_settings.MountainMultiplier = mountainMultiplier;

            // Debug
            m_settings.WireframeRendering = iniFile.ReadBoolean("Debug", "WireframeRendering");
            m_settings.DebugRendering = iniFile.ReadBoolean("Debug", "DebugRendering");
            m_settings.StepUpdating = iniFile.ReadBoolean("Debug", "StepUpdatng");
            m_settings.ShowDebugGUI = iniFile.ReadBoolean("Debug", "ShowDebugGUI");
            m_settings.GameMode = iniFile.ReadString("Debug", "GameMode");
            SetGameModeGUI();
        }

        // Save settings
        public void SaveSettings()
        {
            // Write out to settings.ini file
            IniReader iniFile = new IniReader(System.IO.Path.GetFullPath("media//config//settings.ini"));

            // Graphics
            iniFile.Write("Graphics", "WindowWidth", m_settings.WindowWidth);
            iniFile.Write("Graphics", "WindowHeight", m_settings.WindowHeight);
            iniFile.Write("Graphics", "VSync", m_settings.VSync);
            iniFile.Write("Graphics", "FullScreen", m_settings.FullScreen);
            iniFile.Write("Graphics", "DeferredRendering", m_settings.DeferredRendering);
            iniFile.Write("Graphics", "Shadows", m_settings.Shadows);
            iniFile.Write("Graphics", "Blur", m_settings.Blur);
            iniFile.Write("Graphics", "SSAO", m_settings.SSAO);
            iniFile.Write("Graphics", "DynamicLighting", m_settings.DynamicLighting);
            iniFile.Write("Graphics", "MSAA", m_settings.MSAA);
            iniFile.Write("Graphics", "InstancedParticles", m_settings.InstancedParticles);
            iniFile.Write("Graphics", "FaceMerging", m_settings.FaceMerging);

            // Landscape
            iniFile.Write("Landscape", "LandscapeOctaves", m_settings.LandscapeOctaves.ToString());
            iniFile.Write("Landscape", "LandscapePersistence", m_settings.LandscapePersistence.ToString());
            iniFile.Write("Landscape", "LandscapeScale", m_settings.LandscapeScale.ToString());
            iniFile.Write("Landscape", "MountainOctaves", m_settings.MountainOctaves.ToString());
            iniFile.Write("Landscape", "MountainPersistence", m_settings.MountainPersistence.ToString());
            iniFile.Write("Landscape", "MountainScale", m_settings.MountainScale.ToString());
            iniFile.Write("Landscape", "MountainMultiplier", m_settings.MountainMultiplier.ToString());

            // Debug
            iniFile.Write("Debug", "WireframeRendering", m_settings.WireframeRendering);
            iniFile.Write("Debug", "DebugRendering", m_settings.DebugRendering);
            iniFile.Write("Debug", "StepUpdatng", m_settings.StepUpdating);
            iniFile.Write("Debug", "ShowDebugGUI", m_settings.ShowDebugGUI);
            SetGameModeSettings();
            iniFile.Write("Debug", "GameMode", m_settings.GameMode);
        }

        private void SetGameModeGUI()
        {
            if(m_settings.GameMode == "Game")
            {
                GameMode.IsChecked = true;
            }
            else if (m_settings.GameMode == "FrontEnd")
            {
                FrontEndMode.IsChecked = true;
            }
            else if (m_settings.GameMode == "Debug")
            {
                DebugMode.IsChecked = true;
            }
        }

        private void SetGameModeSettings()
        {
            if(GameMode.IsChecked.Value == true)
            {
                m_settings.GameMode = "Game";
            }
            else if (FrontEndMode.IsChecked.Value == true)
            {
                m_settings.GameMode = "FrontEnd";
            }
            else if (DebugMode.IsChecked.Value == true)
            {
                m_settings.GameMode = "Debug";
            }
        }

        // Launch game
        private void LauchGameClick(object sender, RoutedEventArgs e)
        {
            // First save the settings
            SaveSettings();

            // Create a new background worker to launch the game
            try
            {
                // Don't allow multiple instances of the Vox.exe to be run at the same time from the launcher
                LaunchButton.IsEnabled = false;

                BackgroundWorker newBackgroundWorker = new BackgroundWorker();

                object[] parameters = new object[] { };

                newBackgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
                newBackgroundWorker.WorkerReportsProgress = true;
                newBackgroundWorker.WorkerSupportsCancellation = true;
                newBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_Completed);

                newBackgroundWorker.RunWorkerAsync(parameters);
            }
            catch (Exception)
            {
                LaunchButton.IsEnabled = true;
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Launch the game executable
            try
            {
                // Create process
                Process newProcess = new Process();
                newProcess.StartInfo.UseShellExecute = false;
                newProcess.StartInfo.RedirectStandardOutput = true;
                newProcess.StartInfo.RedirectStandardError = true;
                newProcess.StartInfo.CreateNoWindow = true;

                // Arguments
                newProcess.StartInfo.FileName = "VoxGame.exe";
                newProcess.StartInfo.WorkingDirectory = "";
                newProcess.StartInfo.Domain = "";
                newProcess.StartInfo.Arguments = "";

                // Start the process
                newProcess.Start();
                newProcess.BeginOutputReadLine();
                newProcess.BeginErrorReadLine();
                newProcess.WaitForExit();
                newProcess.CancelOutputRead();
                newProcess.CancelErrorRead();
                newProcess.Close();
            }
            catch(Exception)
            {
                LaunchButton.IsEnabled = true;
            }
        }

        private void BackgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            // Once the executable is closed, allow us to launch Vox again
            LaunchButton.IsEnabled = true;
        }
    }
}
