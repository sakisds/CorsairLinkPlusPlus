﻿using Hardcodet.Wpf.TaskbarNotification;
using CorsairLinkPlusPlus.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CorsairLinkPlusPlus.Common.Sensor;

namespace CorsairLinkPlusPlus.TrayApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The tray icon of our app
        /// </summary>
        public static TaskbarIcon trayIcon;

        /// <summary>
        /// The root Corsair Link device
        /// </summary>
        public static RootDevice rootDevice;

        /// <summary>
        /// The list of all LEDs available
        /// </summary>
        public static List<ILED> leds;

        /// <summary>
        /// The list of all fans available
        /// </summary>
        public static List<IFan> fans;

        /// <summary>
        /// The list of sensors that are not fans or LEDs
        /// </summary>
        public static List<ISensor> sensors;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Check if we can find any corsair link devices
            rootDevice = RootDevice.GetInstance();
            if (!rootDevice.Valid || !rootDevice.Present)
            {
                MessageBox.Show(
                    "No Corsair Link devices found. The app will now exit.",
                    "CorsairLinkPlusPlus",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
            }

            // Categorize subdevices
            leds = new List<ILED>();
            fans = new List<IFan>();
            sensors = new List<ISensor>();

            var devices = rootDevice.GetSubDevices();

            foreach (BaseDevice device in devices)
            {
                AddSubdevicesToLists(device);
            }

            // Create tray icon
            trayIcon = (TaskbarIcon)FindResource("TrayIcon");
            base.OnStartup(e);
        }

        /// <summary>
        /// This method sorts the given device into the correct list.
        /// </summary>
        /// <param name="device">Device to sort. If this device is not a sensor this method will
        /// try to recursively sort it's children.</param>
        private void AddSubdevicesToLists(BaseDevice device)
        {
            // Is this device a sensor?
            if (device is ISensor)
            {
                // Add it to the correct list
                if (device is ILED) leds.Add((ILED)device);
                else if (device is IFan && device is IControllableSensor) fans.Add((IFan)device);
                else sensors.Add((ISensor)device);
            }
            else
            {
                // This device is not a sensor, check it's children
                foreach (BaseDevice subdevice in device.GetSubDevices())
                {
                    AddSubdevicesToLists(subdevice);
                }
            }
        }
    }
}
