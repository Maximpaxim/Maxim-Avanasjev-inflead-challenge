using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Coordinates> Coordinates { get; set; }
    public DbSet<Employment> Employment { get; set; }
    public DbSet<CreditCard> CreditCard { get; set; }
    public DbSet<Subscription> Subscription { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
}
public class User
{
    public int Id { get; set; }
    public string Uid { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string SocialInsuranceNumber { get; set; }
    public string DateOfBirth { get; set; }
    public Employment Employment { get; set; }
    public Address Address { get; set; }
    public CreditCard CreditCard { get; set; }
    public Subscription Subscription { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
public class Address
{
    public int Id { get; set; }
    public string City { get; set; }
    public string StreetName { get; set; }
    public string StreetAddress { get; set; }
    public string ZipCode { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public Coordinates Coordinates { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

}
public class Employment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string KeySkill { get; set; }
}
public class Coordinates
{
    public int Id { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
}
public class CreditCard
{
    public int Id { get; set; }
    public string CcNumber { get; set; }
}
public class Subscription
{
    public int Id { get; set; }
    public string Plan { get; set; }
    public string Status { get; set; }
    public string PaymentMethod { get; set; }
    public string Term { get; set; }
}
