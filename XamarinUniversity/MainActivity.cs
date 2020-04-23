using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using Refractored.Fab;
using System;
using Xamarin.Essentials;

namespace XamarinUniversity
{
	[Activity(Label = "WhatsApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			var chatList = FindViewById<ListView>(Resource.Id.chatListView);
			chatList.FastScrollEnabled = true;
			chatList.ItemClick += OnItemClick;

			chatList.Adapter = new ChatAdapter(ChatData.Chats);

			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
			fab.Click += Fab_Click;

			Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
			Accelerometer.Start(SensorSpeed.Default);

		}

		private void Accelerometer_ShakeDetected(object sender, EventArgs e)
		{
			var intent = new Intent(this, typeof(CreateChatActivity));

			StartActivity(intent);
		}

		private void Fab_Click(object sender, EventArgs e)  //add chat act
		{
			var intent = new Intent(this, typeof(CreateChatActivity));
			StartActivity(intent);
		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var intent = new Intent(this, typeof(ChatDetailsActivity));

			intent.PutExtra("position", e.Position);

			StartActivity(intent);
		}
	}
}