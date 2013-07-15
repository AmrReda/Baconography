﻿using BaconographyPortable.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaconographyPortable.ViewModel
{
    public class ContentPreferencesViewModel : ViewModelBase
    {
        IBaconProvider _baconProvider;
        ISettingsService _settingsService;

        public ContentPreferencesViewModel(IBaconProvider baconProvider)
        {
            _baconProvider = baconProvider;
            _settingsService = baconProvider.GetService<ISettingsService>();
        }

		public bool LeftHandedMode
		{
			get
			{
				return _settingsService.LeftHandedMode;
			}
			set
			{
				_settingsService.LeftHandedMode = value;
				RaisePropertyChanged("LeftHandedMode");
			}
		}

		public string Orientation
		{
			get
			{
				return _settingsService.Orientation;
			}
			set
			{
				_settingsService.Orientation = value;
				RaisePropertyChanged("Orientation");
			}
		}

		public bool OrientationLock
		{
			get
			{
				return _settingsService.OrientationLock;
			}
			set
			{
				_settingsService.OrientationLock = value;
				RaisePropertyChanged("OrientationLock");
			}
		}

        public bool AllowNSFWContent
        {
            get
            {
                return _settingsService.AllowOver18;
            }
            set
            {
                _settingsService.AllowOver18 = value;
                RaisePropertyChanged("AllowNSFWContent");
            }
        }

        public bool OfflineOnlyGetsFirstSet
        {
            get
            {
                return _settingsService.OfflineOnlyGetsFirstSet;
            }
            set
            {
                _settingsService.OfflineOnlyGetsFirstSet = value;
                RaisePropertyChanged("OfflineOnlyGetsFirstSet");
            }
        }

        
        public int MaxTopLevelOfflineComments
        {
            get
            {
                return _settingsService.MaxTopLevelOfflineComments;
            }
            set
            {
                _settingsService.MaxTopLevelOfflineComments = value;
                RaisePropertyChanged("MaxTopLevelOfflineComments");
            }
        }

        public bool EnableLockScreenImages
        {
            get
            {
                return _settingsService.EnableLockScreenImages;
            }
            set
            {
                _settingsService.EnableLockScreenImages = value;
                RaisePropertyChanged("EnableLockScreenImages");
            }
        }

        public string LockScreenReddit
        {
            get
            {
                return _settingsService.LockScreenReddit;
            }
            set
            {
                _settingsService.LockScreenReddit = value;
                RaisePropertyChanged("LockScreenReddit");
            }
        }

        public bool HighresLockScreenOnly
        {
            get
            {
                return _settingsService.HighresLockScreenOnly;
            }
            set
            {
                _settingsService.HighresLockScreenOnly = value;
                RaisePropertyChanged("HighresLockScreenOnly");
            }
        }

        public bool EnableUpdates
        {
            get
            {
                return _settingsService.EnableUpdates;
            }
            set
            {
                _settingsService.EnableUpdates = value;
                RaisePropertyChanged("EnableUpdates");
            }
        }

        public bool UpdateImagesOnlyWifi
        {
            get
            {
                return _settingsService.UpdateImagesOnlyWifi;
            }
            set
            {
                _settingsService.UpdateImagesOnlyWifi = value;
                RaisePropertyChanged("UpdateImagesOnlyWifi");
            }
        }

        public bool UpdateOverlayOnlyWifi
        {
            get
            {
                return _settingsService.UpdateOverlayOnlyWifi;
            }
            set
            {
                _settingsService.UpdateOverlayOnlyWifi = value;
                RaisePropertyChanged("UpdateOverlayOnlyWifi");
            }
        }

        public string ImageUpdateFrequency
        {
            get
            {
                return _settingsService.ImageUpdateFrequency;
            }
            set
            {
                _settingsService.ImageUpdateFrequency = value;
                RaisePropertyChanged("ImageUpdateFrequency");
            }
        }

        public string OverlayUpdateFrequency
        {
            get
            {
                return _settingsService.OverlayUpdateFrequency;
            }
            set
            {
                _settingsService.OverlayUpdateFrequency = value;
                RaisePropertyChanged("OverlayUpdateFrequency");
            }
        }

        public bool MessagesInLockScreenOverlay
        {
            get
            {
                return _settingsService.MessagesInLockScreenOverlay;
            }
            set
            {
                _settingsService.MessagesInLockScreenOverlay = value;
                RaisePropertyChanged("MessagesInLockScreen");
            }
        }

        public int OverlayOpacity
        {
            get
            {
                return _settingsService.OverlayOpacity;
            }
            set
            {
                _settingsService.OverlayOpacity = value;
                RaisePropertyChanged("OverlayOpacity");
            }
        }


        public bool PostsInLockScreenOverlay
        {
            get
            {
                return _settingsService.PostsInLockScreenOverlay;
            }
            set
            {
                _settingsService.PostsInLockScreenOverlay = value;
                RaisePropertyChanged("PostsInLockScreenOverlay");
            }
        }
        

        public RelayCommand ClearOffline
        {
            get
            {
                return new RelayCommand(async () =>
                    {
                        await _baconProvider.GetService<IOfflineService>().Clear();
                    });
            }
        }
    }
}
