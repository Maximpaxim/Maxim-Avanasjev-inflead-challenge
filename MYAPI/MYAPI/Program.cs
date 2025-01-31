using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var db = new UserContext();
db.Database.ExecuteSqlRaw("delete from sqlite_sequence");   //reset the autoincrement

int delay = 1000 * 60 * 60;
var timer = new Timer(async (o) =>
{
    //reset the database
    foreach (var u in db.User) db.Remove(u);
    foreach (var a in db.Address) db.Remove(a);
    foreach (var c in db.Coordinates) db.Remove(c);
    foreach (var e in db.Employment) db.Remove(e);
    foreach (var c in db.CreditCard) db.Remove(c);
    foreach (var s in db.Subscription) db.Remove(s);

    var json = await new HttpClient().GetStringAsync("https://random-data-api.com/api/users/random_user?size=10");
    var deserializeOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        WriteIndented = true
    };
    var users = JsonSerializer.Deserialize<List<User>>(json, deserializeOptions);

    db.AddRange(users);
    db.SaveChanges();

}, null, 0, delay);

app.MapGet("users", (string? Gender = null, string? Email = null, string? Username = null) =>
{
    var users = db.User.Select(u => new UserDTO()
    {
        Id = u.Uid,
        Email = u.Email,
        Username = u.Username,
        FullName = $"{u.FirstName} {u.LastName}",
        ProfilePicUrl = u.Avatar,
        Gender = u.Gender,
        PhoneNumber = u.PhoneNumber,
        Employment = u.Employment.Title,
        KeySkill = u.Employment.KeySkill,
        AddressId = u.Address.Id.ToString(),
        CreationDate = u.CreationDate
    }).Where(u => u.Gender == (Gender ?? u.Gender) && u.Email == (Email ?? u.Email) && u.Username == (Username ?? u.Username));

    var addresses = db.Address.Select(a => new AddressDTO()
    {
        Id = a.Id.ToString(),
        City = a.City,
        Street = $"{a.StreetName} {a.StreetAddress}",
        ZipCode = a.ZipCode,
        State = a.State,
        CreationDate = a.CreationDate
    });

    //users + addresses
    var output = users.Join(addresses, u => u.AddressId, a => a.Id, (u, a) => new
    {
        u.Id,
        u.Email,
        u.Username,
        u.FullName,
        u.ProfilePicUrl,
        u.Gender,
        u.PhoneNumber,
        u.Employment,
        u.KeySkill,
        u.CreationDate,
        Address = a
    });

    var serializeOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        WriteIndented = true
    };
    return Results.Json(output, serializeOptions, "application/json");
});

app.Run("http://localhost:8080");
