using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using tournament_user_score_tracker.Models;

namespace tournament_user_score_tracker.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IMongodbDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> Get() =>
            _users.Find(book => true).ToList();

        public User Get(int id) =>
            _users.Find<User>(book => book.Id == id).FirstOrDefault();

        public User Create(User book)
        {
            _users.InsertOne(book);
            return book;
        }

        public void Update(int id, User bookIn) =>
            _users.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(User bookIn) =>
            _users.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(int id) =>
            _users.DeleteOne(book => book.Id == id);
    }
}