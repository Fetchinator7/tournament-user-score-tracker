using Newtonsoft.Json;
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
        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
    }
}
