namespace ControleCompras.Configuration
{
	[System.AttributeUsage(System.AttributeTargets.Class)]
	public class DataBaseAttribute : Attribute
	{
		public string DataBase { get; private set; }

		public DataBaseAttribute(string dataBase)
		{
			DataBase = dataBase;
		}
	}
}
