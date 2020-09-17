using System;

namespace tournament_user_score_tracker.Models
{
    public class MongodbDatabaseSettings
    {
        public string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        public string UsersCollectionName = Environment.GetEnvironmentVariable("USERS_COLLECTION_NAME");
        public string DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
    }
}
