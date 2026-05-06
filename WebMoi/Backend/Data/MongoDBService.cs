//quan ly ket noi mongo //
using MongoDB.Driver;
using WebMoi.Models;


namespace WebMoi.Data
{
    public class MongoDbService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase? _database;

        public MongoDbService(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetConnectionString("DbConnection");
            var mongoURL = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoURL);
            _database = mongoClient.GetDatabase(mongoURL.DatabaseName);
        }
        public IMongoDatabase? Database => _database;
    }
}