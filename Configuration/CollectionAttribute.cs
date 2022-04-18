namespace ControleCompras.Configuration
{
	[System.AttributeUsage(System.AttributeTargets.Class)]
	public class CollectionAttribute : Attribute
	{
		public string Collection { get; private set; }

		public CollectionAttribute(string collection)
		{
			Collection = collection;
		}
	}
}
