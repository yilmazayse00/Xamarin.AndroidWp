using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Locations;

namespace XamarinUniversity
{
    class LocationService : Service
    {
        LocationHelper locationHelper;
        public event EventHandler<LocationChangedEventArgs> LocationChanged
        {
            add { locationHelper.LocationChanged += value; }
            remove { locationHelper.LocationChanged -= value; }
        }
        public DateTime StartTime { get; private set; } = DateTime.Now;

        public override void OnCreate()
        {
            locationHelper = new LocationHelper();

            locationHelper.StartLocationUpdates();

            base.OnCreate();
        }
        public override IBinder OnBind(Intent intent)
        {
            return new LocationServiceBinder(this);
        }

        public override void OnDestroy()
        {
            locationHelper.StopLocationUpdates();
        }
    }
}