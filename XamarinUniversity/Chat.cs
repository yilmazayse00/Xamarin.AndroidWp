namespace XamarinUniversity
{
	public class Chat
	{
		public string Name      { get; set; }
		public string ImageUrl  { get; set; }
		public string Content { get; set; }

		public override string ToString()
		{
			return Name + " " + Content;
		}
	}
}