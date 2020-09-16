using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace tournament_user_score_tracker.Models
{
    public class User
    {
        // primary key
        // id is a special name. any class/model with a property called 'id
        // will automatically get a primary key field in the database of the given type
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        [BsonElement("Name")]
        public string FirstName { get; set; }
    }
}
