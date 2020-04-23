using System;
using System.Linq;
using System.Collections.Generic;

namespace XamarinUniversity
{
	public static class ChatData
	{
		public static List<Chat> Chats { get; private set; }

		static ChatData()
		{
			var temp = new List<Chat>();

			AddChats(temp);

			Chats = temp.OrderBy(i => i.Name).ToList();
		}

		static void AddChats(List<Chat> chats)
		{
			chats.Add(new Chat()
			{
				Name = "Monica Geller",
				Content = "OKEY!!",
				ImageUrl = "images/monica.png",
			});

			chats.Add(new Chat()
			{
				Name = "Ross Geller",
				Content = "Im a paleontologist. And we r on a break??!!!",
				ImageUrl = "images/ross.png",
			});

			chats.Add(new Chat()
			{
				Name = "Rachel Green",
				Content = "She just a waitrest??!!!",
				ImageUrl = "images/rachel.jpg",
			});

			chats.Add(new Chat()
			{
				Name = "Chandler Bing",
				Content = "Whats my job? ",
				ImageUrl = "images/chandler.jpg",
			});

			chats.Add(new Chat()
			{
				Name = "Joey Tribbiani",
				Content = "How you doin :)",
				ImageUrl = "images/joey.jpg",
			});

			chats.Add(new Chat()
			{
				Name = "Phoebe Buffay",
				Content = "SMELLY CAAT SMELLLY CAAAT",
				ImageUrl = "images/phoebe.jpg",
			});
		}
	}
}