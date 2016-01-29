using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoxLauncher
{
    public class Settings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        // Graphics
        private int _WindowWidth;
        public int WindowWidth
        {
            get
            {
                return _WindowWidth;
            }
            set
            {
                _WindowWidth = value;

                OnPropertyChanged("WindowWidth");
            }
        }

        private int _WindowHeight;
        public int WindowHeight
        {
            get
            {
                return _WindowHeight;
            }
            set
            {
                _WindowHeight = value;

                OnPropertyChanged("WindowHeight");
            }
        }

        private bool _VSync;
        public bool VSync
        {
            get
            {
                return _VSync;
            }
            set
            {
                _VSync = value;

                OnPropertyChanged("VSync");
            }
        }

        private bool _FullScreen;
        public bool FullScreen
        {
            get
            {
                return _FullScreen;
            }
            set
            {
                _FullScreen = value;

                OnPropertyChanged("FullScreen");
            }
        }

        private bool _DeferredRendering;
        public bool DeferredRendering
        {
            get
            {
                return _DeferredRendering;
            }
            set
            {
                _DeferredRendering = value;

                OnPropertyChanged("DeferredRendering");
            }
        }

        private bool _Shadows;
        public bool Shadows
        {
            get
            {
                return _Shadows;
            }
            set
            {
                _Shadows = value;

                OnPropertyChanged("Shadows");
            }
        }

        private bool _Blur;
        public bool Blur
        {
            get
            {
                return _Blur;
            }
            set
            {
                _Blur = value;

                OnPropertyChanged("Blur");
            }
        }

        private bool _SSAO;
        public bool SSAO
        {
            get
            {
                return _SSAO;
            }
            set
            {
                _SSAO = value;

                OnPropertyChanged("SSAO");
            }
        }

        private bool _DynamicLighting;
        public bool DynamicLighting
        {
            get
            {
                return _DynamicLighting;
            }
            set
            {
                _DynamicLighting = value;

                OnPropertyChanged("DynamicLighting");
            }
        }

        private bool _MSAA;
        public bool MSAA
        {
            get
            {
                return _MSAA;
            }
            set
            {
                _MSAA = value;

                OnPropertyChanged("MSAA");
            }
        }

        private bool _InstancedParticles;
        public bool InstancedParticles
        {
            get
            {
                return _InstancedParticles;
            }
            set
            {
                _InstancedParticles = value;

                OnPropertyChanged("InstancedParticles");
            }
        }

        private bool _FaceMerging;
        public bool FaceMerging
        {
            get
            {
                return _FaceMerging;
            }
            set
            {
                _FaceMerging = value;

                OnPropertyChanged("FaceMerging");
            }
        }

        // Debug
        private bool _WireframeRendering;
        public bool WireframeRendering
        {
            get
            {
                return _WireframeRendering;
            }
            set
            {
                _WireframeRendering = value;

                OnPropertyChanged("WireframeRendering");
            }
        }

        private bool _DebugRendering;
        public bool DebugRendering
        {
            get
            {
                return _DebugRendering;
            }
            set
            {
                _DebugRendering = value;

                OnPropertyChanged("DebugRendering");
            }
        }

        private bool _StepUpdating;
        public bool StepUpdating
        {
            get
            {
                return _StepUpdating;
            }
            set
            {
                _StepUpdating = value;

                OnPropertyChanged("StepUpdating");
            }
        }

        // Landscape
        private float _LandscapeOctaves;
        public float LandscapeOctaves
        {
            get
            {
                return _LandscapeOctaves;
            }
            set
            {
                _LandscapeOctaves = value;

                OnPropertyChanged("LandscapeOctaves");
            }
        }

        private float _LandscapePersistence;
        public float LandscapePersistence
        {
            get
            {
                return _LandscapePersistence;
            }
            set
            {
                _LandscapePersistence = value;

                OnPropertyChanged("LandscapePersistence");
            }
        }

        private float _LandscapeScale;
        public float LandscapeScale
        {
            get
            {
                return _LandscapeScale;
            }
            set
            {
                _LandscapeScale = value;

                OnPropertyChanged("LandscapeScale");
            }
        }

        private float _MountainOctaves;
        public float MountainOctaves
        {
            get
            {
                return _MountainOctaves;
            }
            set
            {
                _MountainOctaves = value;

                OnPropertyChanged("MountainOctaves");
            }
        }

        private float _MountainPersistence;
        public float MountainPersistence
        {
            get
            {
                return _MountainPersistence;
            }
            set
            {
                _MountainPersistence = value;

                OnPropertyChanged("MountainPersistence");
            }
        }

        private float _MountainScale;
        public float MountainScale
        {
            get
            {
                return _MountainScale;
            }
            set
            {
                _MountainScale = value;

                OnPropertyChanged("MountainScale");
            }
        }

        private float _MountainMultiplier;
        public float MountainMultiplier
        {
            get
            {
                return _MountainMultiplier;
            }
            set
            {
                _MountainMultiplier = value;

                OnPropertyChanged("MountainMultiplier");
            }
        }
    }
}
