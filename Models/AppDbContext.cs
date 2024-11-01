using Microsoft.EntityFrameworkCore;
using oppiekoppie.Models;

namespace oppiekoppie.Models;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
    public DbSet<Booking> Bookings {get; set;}
    public DbSet<Payment> Payments {get; set;}
}