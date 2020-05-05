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
	[Activity(Label = "Chat", Icon = "@drawable/icon")]
	public class ChatDetailsActivity : Activity
	{
		ListView msgLv;
		List<Chat> msgList = new List<Chat>();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ChatDetails);

			Database database = new Database();
			database.createDatabase();

			var position = Intent.GetIntExtra("position", -1);
			var chat = ChatData.Chats[position];

			msgLv = FindViewById<ListView>(Resource.Id.messageListView);
			var msgEt = FindViewById<EditText>(Resource.Id.messageEditText);

			var content = FindViewById<TextView>(Resource.Id.contentTextView);
			content.Text = chat.Content;

			FloatingActionButton fab2 = FindViewById<FloatingActionButton>(Resource.Id.sendFab);
			fab2.Click += delegate
			{
				Chat chat = new Chat()
				{
					Content = msgEt.Text,
				};
				database.InsertIntoTableChat(chat);

			};
			EditText msg = FindViewById<EditText>(Resource.Id.messageEditText);

			FindViewById<Button>(Resource.Id.buttonLocation).Click += (s, e) => StartActivity(typeof(LocationActivity));
			FindViewById<Button>(Resource.Id.cameraButton).Click += (s, e) => StartActivity(typeof(CameraActivity));
		}
	}
}