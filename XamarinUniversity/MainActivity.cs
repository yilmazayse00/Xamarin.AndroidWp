using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using Refractored.Fab;
using System;

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

		}

		private void Fab_Click(object sender, EventArgs e)  //add chat act
		{
			var intent = new Intent(this, typeof(CreateChat));
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