using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tahfez.Models;
using tahfezKhalid.Models;

namespace tahfezKhalid.Data;

public class tahfezKhalidContext : IdentityDbContext<User>
{
    public tahfezKhalidContext(DbContextOptions<tahfezKhalidContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        var password = new PasswordHasher<User>();
        var uSER_ID = "1512fd48-56b8-407a-8547-271fea42ca72";
        var aDMIN_ID = "1512fd48-56b8-407a-8547-271fea42ca72";
        var mEMORIZER_ID = "db614589-c68b-4633-a0a6-5d3518eda78e";
        var pARENT_ID = "1b50282d-c47e-4873-99c0-4b0124f1c26e";
        var sUPERVISOR_ID = "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e";

        builder.Entity<UserSession>().HasKey(x => new { x.userId, x.sessionId });
        builder.Entity<DeletedUser>().HasKey(x => x.userId);

        builder.Entity<UserSession>()
            .HasOne(x => x.user)
            .WithMany(b => b.UserSessions)
            .HasForeignKey(x => x.userId);

        builder.Entity<UserSession>()
            .HasOne(x => x.session)
            .WithMany(b => b.UserSessions)
            .HasForeignKey(x => x.sessionId);

        builder.Entity<DeletedUser>()
            .HasOne(x => x.user)
            .WithMany(b => b.DeletedUsers)
            .HasForeignKey(x => x.userId);

        builder.Entity<Student>()
            .HasOne(x => x.Parent)
            .WithMany(b => b.Students)
            .HasForeignKey(x => x.ParentId);

        builder.Entity<DailyReport>()
            .HasOne(x => x.student)
            .WithMany(b => b.DailyReports)
            .HasForeignKey(x => new {  x.IdentificationNumber,x.studentId });



        builder.Entity<IdentityRole>()
            .HasData(new IdentityRole
            {
                Id = aDMIN_ID,
                Name = "admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole()
            {
                Id = mEMORIZER_ID,
                Name = "memorizer",
                NormalizedName = "MEMORIZER"
            },
            new IdentityRole()
            {
                Id = pARENT_ID,
                Name = "parent",
                NormalizedName = "PARENT"
            },
            new IdentityRole()
            {
                Id = sUPERVISOR_ID,
                Name = "supervisor",
                NormalizedName = "SUPERVISOR"
            });

        builder.Entity<User>()
            .HasData(new User()
            {
                Id = uSER_ID,
                IdentificationNumber = "407069541",
                Name = "حماده حسام العبادلة",
                PhoneNumber = "0595195186",
                UserName = "407069541",
                NormalizedUserName = "407069541",
                TypeUser = TypeUser.آدمن,
                PasswordHash = password.HashPassword(null, "407069541"),
            });

        builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.RoleId, x.UserId });

        builder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>()
            {

                RoleId = aDMIN_ID,
                UserId = uSER_ID

            });

        builder.Entity<Student>().HasKey(x => new { x.IdentificationNumber, x.Id });
        builder.Entity<Absence>().HasKey(x => new { x.dateAbsence, x.Id });
    }

    public DbSet<Session> Session { get; set; }
    public DbSet<Absence> Absences { get; set; }
    public DbSet<UserSession> UserSession { get; set; }
    public DbSet<DeletedUser> DeletedUsers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<DailyReport> DailyReport { get; set; }
}