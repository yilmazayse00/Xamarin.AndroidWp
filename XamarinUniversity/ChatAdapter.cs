using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace XamarinUniversity
{
	public class ChatAdapter : BaseAdapter<Chat>, ISectionIndexer
	{
		List<Chat>     chats;
		Java.Lang.Object[]   sectionHeaders;
		Dictionary<int, int> positionForSectionMap;
		Dictionary<int, int> sectionForPositionMap;

		public ChatAdapter(List<Chat> chats)
		{
			this.chats = chats;

			sectionHeaders        = SectionIndexerBuilder.BuildSectionHeaders       (chats);
			positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(chats);
			sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(chats);
		}

		public override Chat this[int position]
		{
			get
			{
				return chats[position];
			}
		}

		public override int Count
		{
			get
			{
				return chats.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;

			if (view == null)
			{
				view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ChatRow, parent, false);

				var p = view.FindViewById<ImageView>(Resource.Id.photoImageView);
				var n = view.FindViewById<TextView >(Resource.Id.nameTextView);
				var c = view.FindViewById<TextView >(Resource.Id.contentTextView);

				view.Tag = new ViewHolder() { Photo = p, Name = n, Content = c };
			}

			var holder = (ViewHolder)view.Tag;

			holder.Photo.SetImageDrawable(ImageAssetManager.Get(parent.Context, chats[position].ImageUrl));
			holder.Name     .Text = chats[position].Name;
			holder.Content.Text = chats[position].Content;

			return view;
		}

		public Java.Lang.Object[] GetSections()
		{
			return sectionHeaders;
		}

		public int GetPositionForSection(int section)
		{
			return positionForSectionMap[section];
		}

		public int GetSectionForPosition(int position)
		{
			return sectionForPositionMap[position];
		}
	}
}