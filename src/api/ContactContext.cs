using Microsoft.EntityFrameworkCore;

namespace api;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {

    }
    public DbSet<Address> Address { get; set; }
}

public class Address
{
    public long Id { get; set; }
    public string Name { get; set; }

}