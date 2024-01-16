namespace Core.Entities
{
    public class MongoDbSettingsEntity
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}