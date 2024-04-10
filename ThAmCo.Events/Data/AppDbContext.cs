using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Principal;

namespace ThAmCo.Events.Data;

public class AppDbContext : IdentityDbContext
{

    public DbSet<Guest> Guests { get; set; }
    public DbSet<GuestBooking> GuestBookings { get; set; } // GuestBookings
    public DbSet<Event> Events { get; set; }
    public DbSet<Staffing> Staffings { get; set; }
    public DbSet<Staff> Staffs { get; set; }

    private string DbPath { get; } = string.Empty;

    public AppDbContext()
    {
        // Make the file path configurable
        DbPath = GetDbFilePath("Events.db");
    }

    private static string GetDbFilePath(string fileName)
    {
        var folder = Environment.SpecialFolder.MyDocuments;
        var path = Environment.GetFolderPath(folder);
        return Path.Combine(path, fileName);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GuestBooking>()
             .HasKey(gb => new { gb.GuestId, gb.EventId });

        modelBuilder.Entity<GuestBooking>()
            .HasOne(gb => gb.Guest)
            .WithMany(g => g.GuestBookings)
        .HasForeignKey(gb => gb.GuestId);

        modelBuilder.Entity<GuestBooking>()
            .HasOne(gb => gb.Event)
            .WithMany(e => e.GuestBookings)
            .HasForeignKey(gb => gb.EventId);

        // Configure many-to-many relationship between Staff and Event
        modelBuilder.Entity<Staffing>()
            .HasKey(s => new { s.StaffId, s.EventId });

        modelBuilder.Entity<Staffing>()
            .HasOne(s => s.Staff)
            .WithMany(st => st.Staffings)
        .HasForeignKey(s => s.StaffId);

        modelBuilder.Entity<Staffing>()
            .HasOne(s => s.Event)
            .WithMany(e => e.Staffings)
            .HasForeignKey(s => s.EventId);


        // Seed some initial data
        var staff1 = new Staff { StaffId = 1, FirstName = "John", LastName = "Doe" };
        var staff2 = new Staff { StaffId = 2, FirstName = "Jane", LastName = "Smith" , FirstAider = true};
        modelBuilder.Entity<Staff>().HasData(staff1, staff2);


        var event1 = new Event { EventId = 1, EventName = "Event 1", FoodBookingId = "1", EventDate = DateTime.Now.AddDays(6), EventTypeId = "WED", EventTypeName = "Wedding" };
        var event2 = new Event { EventId = 2, EventName = "Event 2", FoodBookingId ="2",  EventDate = DateTime.Now.AddDays(5), EventTypeId = "CON", EventTypeName= "Conference" };
        modelBuilder.Entity<Event>().HasData(event1, event2);

        var staffing1 = new Staffing {  StaffId = staff1.StaffId, EventId = event1.EventId };
        var staffing2 = new Staffing { StaffId = staff2.StaffId, EventId = event2.EventId };
        modelBuilder.Entity<Staffing>().HasData(staffing1, staffing2);


        var guest1 = new Guest { GuestId = 1, Email = "Guest1@email.com", FirstName = "Guest1", LastName = "Last1", Phone = "09898" };
        var guest2 = new Guest { GuestId = 2, Email = "Guest2@email.com", FirstName = "Guest2", LastName = "Last2", Phone = "07477" };
        var guest3 = new Guest { GuestId = 3, Email = "Guest3@email.com", FirstName = "Guest3", LastName = "Last3", Phone = "090908" };
        var guest4 = new Guest { GuestId = 4, Email = "Guest4@email.com", FirstName = "Guest4", LastName = "Last4", Phone = "0909880" };

        modelBuilder.Entity<Guest>().HasData(guest1, guest2);

        var booking1 = new GuestBooking {  EventId = event1.EventId, GuestId = guest1.GuestId };
        var booking2 = new GuestBooking {  EventId = event2.EventId, GuestId = guest2.GuestId };
        modelBuilder.Entity<GuestBooking>().HasData(booking1, booking2);


    }
}
