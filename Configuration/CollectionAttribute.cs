namespace ControleCompras.Configuration
{
	[System.AttributeUsage(System.AttributeTargets.Class)]
	public class CollectionAttribute : Attribute
	{
		public string Collection { get; private set; }
		public string DataBase { get; private set; }

		public CollectionAttribute(string collection, string dataBase)
		{
			Collection = collection;
			DataBase = dataBase;
		}
	}
}
