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

namespace XamarinUniversity
{
    [Activity(Label = "Create Chat")]
    public class CreateChatActivity : Activity
    {
        public static readonly int PickImageId = 1000;
        private ImageView _imageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateChat);
            
            _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            FindViewById<Button>(Resource.Id.button2).Click += OnPickImage;
            FindViewById<Button>(Resource.Id.button1).Click += OnAddContact;

        }

        private void OnAddContact(object sender, EventArgs e)
        {
            string name = FindViewById<EditText>(Resource.Id.addName).Text;

            var intent = new Intent();

            intent.PutExtra("Name", name);
            SetResult(Result.Ok, intent);

            Finish();   
        }

        private void OnPickImage(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

  
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                _imageView.SetImageURI(uri);
            }
        }
    }
}

