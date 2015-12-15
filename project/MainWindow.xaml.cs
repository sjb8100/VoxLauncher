﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();

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

            int windowWidth = iniFile.ReadInteger("Graphics", "WindowWidth");
            int windowHeight = iniFile.ReadInteger("Graphics", "WindowHeight");
            bool vSync = iniFile.ReadBoolean("Graphics", "VSync");
            bool fullScreen = iniFile.ReadBoolean("Graphics", "FullScreen");
            bool deferredRendering = iniFile.ReadBoolean("Graphics", "DeferredRendering");
            bool shadow = iniFile.ReadBoolean("Graphics", "Shadow");
            bool blur = iniFile.ReadBoolean("Graphics", "Blur");
            bool ssao = iniFile.ReadBoolean("Graphics", "SSAO");
            bool dynamicLighting = iniFile.ReadBoolean("Graphics", "DynamicLighting");
            bool msaa = iniFile.ReadBoolean("Graphics", "MSAA");
            bool instancedParticles = iniFile.ReadBoolean("Graphics", "InstancedParticles");
            bool wireframeRendering = iniFile.ReadBoolean("Graphics", "WireframeRendering");
            bool DebugRendering = iniFile.ReadBoolean("Graphics", "DebugRendering");
            bool faceMerging = iniFile.ReadBoolean("Graphics", "FaceMerging");
        }

        public void SaveSettings()
        {
            // Write out to settings.ini file
            IniReader iniFile = new IniReader(System.IO.Path.GetFullPath("media//config//settings.ini"));

            iniFile.Write("Graphics", "WindowWidth", 1150);
            iniFile.Write("Graphics", "WindowHeight", 900);
            iniFile.Write("Graphics", "VSync", false);
            iniFile.Write("Graphics", "FullScreen", false);
            iniFile.Write("Graphics", "DeferredRendering", true);
            iniFile.Write("Graphics", "Shadows", true);
            iniFile.Write("Graphics", "Blur", false);
            iniFile.Write("Graphics", "SSAO", true);
            iniFile.Write("Graphics", "DynamicLighting", true);
            iniFile.Write("Graphics", "MSAA", true);
            iniFile.Write("Graphics", "InstancedParticles", true);
            iniFile.Write("Graphics", "WireframeRendering", false);
            iniFile.Write("Graphics", "DebugRendering", false);
            iniFile.Write("Graphics", "FaceMerging", true);
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
            catch(Exception ex)
            {

            }
        }

        private void BackgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
        }
    }
}
