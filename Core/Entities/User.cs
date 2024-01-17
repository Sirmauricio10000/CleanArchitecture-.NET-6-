using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string userName, string password)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public User()
        {
            Id = string.Empty; 
            UserName = string.Empty; 
            Password = string.Empty; 
        }
    }
}