using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class UpdateDBContext :DbContext
{
    public UpdateDBContext()
    {
        
    }
    
    public UpdateDBContext(DbContextOptions<UpdateDBContext> options) : base(options)
    {
    }
    
    public  DbSet<Activity> Activities { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=enterpasswordhere;Database=databasename;", serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Activity>().ToTable("activities");
        builder.Entity<Activity>().HasKey(p => p.Id);
        builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Activity>().Property(c => c.Title).IsRequired().HasMaxLength(60);
        builder.Entity<Activity>().Property(c => c.Description).IsRequired().HasMaxLength(240);
        builder.Entity<Activity>().Property(c => c.Address).IsRequired().HasMaxLength(60);
        builder.Entity<Activity>().Property(c => c.Date).IsRequired().ValueGeneratedOnAdd();
        
    }



}