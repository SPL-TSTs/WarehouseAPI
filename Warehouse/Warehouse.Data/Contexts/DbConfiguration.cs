namespace Warehouse.Data.Contexts
{
    public class DbOptions
    {
        public const string AzureStorageAccount = "AzureStorageAccount";
        public string AccountName { get; set; }
        public string ConnectionString { get; set; }
        public string Endpoint { get; set; }
    }
}
