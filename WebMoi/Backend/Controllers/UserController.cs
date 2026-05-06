using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebMoi.Data;
using WebMoi.Entities;

namespace WebMoi.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User>? _usersCollection;

        public UserController(MongoDbService mongoDbService) 
        {
            _usersCollection = mongoDbService.Database?.GetCollection<User>("users");
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get() //IEnumerable: danh sach cac user, Task: async, ActionResult: tra ve 200, 404, 500, có thể là map or list
        {
            return await _usersCollection.Find(FilterDefinition<User>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetById(string id)
        { //ActionResult: những gì BE trả về: json hoặc các trạng thái

            var objectId = new ObjectId(id);
            var filter = Builders<User>.Filter.Eq("_id", objectId); //tim user theo id, giong where trong sql

            var user = _usersCollection.Find(filter).FirstOrDefault();

            Console.WriteLine(objectId);
            Console.WriteLine(user);

            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user) { 
            await _usersCollection.InsertOneAsync(user);
            return CreatedAtAction( //tra ve 201 va location header
                nameof(GetById),
                new { id = user.Id }, 
                user
                );
        }
    }
}
