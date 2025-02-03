﻿
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Entities;

public class OrderItem
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid _id { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid ProductId { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public Decimal Price { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int Quantity { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public Decimal TotalPrice { get; set; }
}
