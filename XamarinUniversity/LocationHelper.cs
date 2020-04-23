using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinUniversity
{
    class LocationHelper : Java.Lang.Object, ILocationListener
    {
        LocationManager locMan;

        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        public bool StartLocationUpdates()
        {
            StopLocationUpdates();

            locMan = Application.Context.GetSystemService("location") as LocationManager;

            if (locMan == null)
                return false;

            var locationCriteria = new Criteria()
            {
                Accuracy = Accuracy.NoRequirement,
                PowerRequirement = Power.NoRequirement
            };

            var locationProvider = locMan.GetBestProvider(locationCriteria, true);
            locMan.RequestLocationUpdates(locationProvider, 2000, 0, this);

            return true;
        }

        public void StopLocationUpdates()
        {
            if (locMan != null)
                locMan.RemoveUpdates(this);

            locMan = null;
        }

        public void OnLocationChanged(Location location)
        {
            LocationChanged?.Invoke(this, new LocationChangedEventArgs(location));
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }
    }
}