using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebMoi.Entities
{
    public class User
    {
        // {get; set; }: cho phep doc  va ghi

        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public  string? Id {get; set; }

        [BsonElement("user_name"), BsonRepresentation(BsonType.String)]
        public string? Username { get; set; }

        [BsonElement("email"), BsonRepresentation(BsonType.String)]
        public string? Email { get; set; }


        //public required string? Username { get; set; } 
        //public required string? Email { get; set; }
        //public required string? HashedPassword {get; set; } 
        //public string? AvatarUrl { get; set; } 


    }
}