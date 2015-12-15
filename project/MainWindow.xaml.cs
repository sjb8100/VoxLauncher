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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings m_settings = new Settings();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = m_settings;

            SetDefaultSettings();

            LoadSettings();
        }

        public void SetDefaultSettings()
        {

        }

        public void LoadSettings()
        {
            // Load in from settings.ini
            IniReader iniFile = new IniReader(System.IO.Path.GetFullPath("media//config//settings.ini"));

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
            m_settings.WireframeRendering = iniFile.ReadBoolean("Graphics", "WireframeRendering");
            m_settings.DebugRendering = iniFile.ReadBoolean("Graphics", "DebugRendering");
            m_settings.FaceMerging = iniFile.ReadBoolean("Graphics", "FaceMerging");
        }

        public void SaveSettings()
        {
            // Write out to settings.ini file
            IniReader iniFile = new IniReader(System.IO.Path.GetFullPath("media//config//settings.ini"));

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
            iniFile.Write("Graphics", "WireframeRendering", m_settings.WireframeRendering);
            iniFile.Write("Graphics", "DebugRendering", m_settings.DebugRendering);
            iniFile.Write("Graphics", "FaceMerging", m_settings.FaceMerging);
        }

        private void LauchGameClick(object sender, RoutedEventArgs e)
        {
            // First save the settings
            SaveSettings();

            // Create a new background worker to launch the game
            BackgroundWorker newBackgroundWorker = new BackgroundWorker();

            object[] parameters = new object[] { };

            newBackgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            newBackgroundWorker.WorkerReportsProgress = true;
            newBackgroundWorker.WorkerSupportsCancellation = true;
            newBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_Completed);

            newBackgroundWorker.RunWorkerAsync(parameters);
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

            }
        }

        private void BackgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
        }
    }
}
