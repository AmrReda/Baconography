﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BaconographyWP8Core;
using BaconographyWP8.ViewModel;
using Microsoft.Practices.ServiceLocation;
using BaconographyPortable.Services;
using BaconographyWP8.Common;
using GalaSoft.MvvmLight.Messaging;
using BaconographyPortable.Messages;
using BaconographyPortable.ViewModel;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using BaconographyWP8BackgroundControls.View;
using System.Text;

namespace BaconographyWP8.View
{
	[ViewUri("/View/SettingsPageView.xaml")]
	public partial class SettingsPageView : PhoneApplicationPage
	{
		public SettingsPageView()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			Messenger.Default.Send<SettingsChangedMessage>(new SettingsChangedMessage());
			base.OnNavigatedFrom(e);
		}

		private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
		{
			var _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
			var hyperlinkButton = e.OriginalSource as ContextDataButton;
			if (hyperlinkButton != null)
			{
				_navigationService.NavigateToExternalUri(new Uri((string)hyperlinkButton.ContextData));
			}
		}

		private void OrientationLock_Checked(object sender, RoutedEventArgs e)
		{
			var preferences = this.DataContext as ContentPreferencesViewModel;
			if (preferences != null)
			{
				preferences.Orientation = this.Orientation.ToString();
			}
		}

		private void OrientationLock_Unchecked(object sender, RoutedEventArgs e)
		{
			var preferences = this.DataContext as ContentPreferencesViewModel;
			if (preferences != null)
			{
				preferences.Orientation = this.Orientation.ToString();
			}
		}

        private async void ShowSystemLockScreenSettings(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
        }

        private async void ShowLockScreenPreview(object sender, RoutedEventArgs e)
        {
            var userService = ServiceLocator.Current.GetInstance<IUserService>();
            var settingsService = ServiceLocator.Current.GetInstance<ISettingsService>();

            await Utility.DoActiveLockScreen(settingsService, ServiceLocator.Current.GetInstance<IRedditService>(), userService,
                ServiceLocator.Current.GetInstance<IImagesService>(), ServiceLocator.Current.GetInstance<INotificationService>(), true);

            var _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            _navigationService.Navigate<LockScreen>(null);
        }

        

        private async void SetLockScreen(object sender, RoutedEventArgs e)
        {
            var userService = ServiceLocator.Current.GetInstance<IUserService>();
            var settingsService = ServiceLocator.Current.GetInstance<ISettingsService>();

            await Utility.DoActiveLockScreen(settingsService, ServiceLocator.Current.GetInstance<IRedditService>(), userService,
                ServiceLocator.Current.GetInstance<IImagesService>(), ServiceLocator.Current.GetInstance<INotificationService>(), false);
            
        }
	}
}