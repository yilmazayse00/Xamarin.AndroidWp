using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refractored.Fab;

namespace XamarinUniversity
{
	[Activity(Label = "Chat" , Icon = "@drawable/icon")]			
	public class ChatDetailsActivity : Activity
	{
		public static List<string> list = new List<string>();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ChatDetails);

			var position   = Intent.GetIntExtra("position", -1);
			var chat = ChatData.Chats[position];
		
			var content = FindViewById<TextView >(Resource.Id.contentTextView);
			content.Text = chat.Content;

			FloatingActionButton fab2 = FindViewById<FloatingActionButton>(Resource.Id.sendFab);
			fab2.Click += sendFab_Click;

			EditText msg = FindViewById<EditText>(Resource.Id.messageEditText);
			

			FindViewById<Button>(Resource.Id.buttonLocation).Click += (s, e) => StartActivity(typeof(LocationActivity));
		    FindViewById<Button>(Resource.Id.cameraButton).Click += (s, e) => StartActivity(typeof(CameraActivity));
		}

		private void sendFab_Click(object sender, EventArgs e)
		{
			EditText msg = FindViewById<EditText>(Resource.Id.messageEditText);
			TextView messageList = FindViewById<TextView>(Resource.Id.messageListView);
			messageList.Text =  msg.Text;
		}
	}
}