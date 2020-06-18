using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GetYourMusic.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Search>              Searches            { get; set; }
        public DbSet<District>            Districts           { get; set; }
        public DbSet<City>                Cities              { get; set; }
        public DbSet<Region>              Regions             { get; set; }
        public DbSet<Musician>            Musicians           { get; set; }
        public DbSet<MusicianGenre>       MusicianGenres      { get; set; }
        public DbSet<Genre>               Genres              { get; set; }
        public DbSet<MusicianInstrument>  MusicianInstruments { get; set; }
        public DbSet<Instrument>          Instruments         { get; set; }
        public DbSet<Contract>            Contracts           { get; set; }
        public DbSet<Organizer>           Organizers          { get; set; }
        public DbSet<Account>             Accounts            { get; set; }
        public DbSet<User>                Users               { get; set; }
        public DbSet<Publication>         Publications        { get; set; }
        public DbSet<Comment>             Comments            { get; set; }
        public DbSet<Qualification>       Qualifications      { get; set; }
        public DbSet<Follow>              Follows             { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=get_your_music;user=user;password=password");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ======================= User Entity =======================
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Email)
                .IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Password)
                .IsRequired();
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 10, Email = "jaimito@gmail.com", Password = "password" },
                    new User { Id = 11, Email = "juancito@outlook.com", Password = "hola123" }
                );
            // ===========================================================

            // ===================== Locations ===========================
            modelBuilder.Entity<Region>().ToTable("Region");

            modelBuilder.Entity<Region>().HasKey(p => p.Id);
            modelBuilder.Entity<Region>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Region>()
                .HasMany(p => p.Cities)
                .WithOne(p => p.Region)
                .HasForeignKey(p => p.RegionId);
            modelBuilder.Entity<Region>().HasData(
                    new Region { Id=1,Name="Lima"}
                );

            modelBuilder.Entity<City>().ToTable("City");

            modelBuilder.Entity<City>().HasKey(p => p.Id);
            modelBuilder.Entity<City>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<City>().Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<City>()
                .HasMany(p => p.Districts)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId);
            modelBuilder.Entity<City>().HasData(
                    new City { Id=1,Name="Lima",RegionId=1}
                );

            modelBuilder.Entity<District>().ToTable("District");

            modelBuilder.Entity<District>().HasKey(p => p.Id);
            modelBuilder.Entity<District>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<District>().Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<District>()
                .HasMany(p => p.Profiles)
                .WithOne(p => p.District)
                .HasForeignKey(p => p.DistrictId);
            modelBuilder.Entity<District>().HasData(
                    new District { Id=1,Name="Lima",CityId=1}  
                );


            // ===========================================================

            // ===================== Profile Entity ======================
            modelBuilder.Entity<Account>().ToTable("Account");

            modelBuilder.Entity<Account>()
                .HasDiscriminator(p => p.AccountType)
                .HasValue<Musician>("Musician")
                .HasValue<Organizer>("Organizer");

            modelBuilder.Entity<Account>().HasKey(p => p.UserId);
            modelBuilder.Entity<Account>().Property(p => p.UserId);
            modelBuilder.Entity<Account>().Property(p => p.FirstName)
                .IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.LastName)
                .IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.Phone)
                .IsRequired(false);
            modelBuilder.Entity<Account>().Property(p => p.PersonalWeb)
                .IsRequired(false);
            modelBuilder.Entity<Account>().Property(p => p.BirthDate)
                .IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.RegisterDate)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<Account>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Account>();
            modelBuilder.Entity<Account>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.Commenter)
                .HasForeignKey(p => p.CommenterId);
            // ===========================================================

            // =================== Performer Entity ======================
            modelBuilder.Entity<Musician>().Property(p => p.Description)
                .IsRequired(false);
            modelBuilder.Entity<Musician>().Property(p => p.Rating)
                .HasDefaultValue(0);
            modelBuilder.Entity<Musician>()
                .HasMany(p => p.Publications)
                .WithOne(p => p.Musician)
                .HasForeignKey(p => p.MusicianId);
            modelBuilder.Entity<Musician>()
                .HasMany(p => p.Qualifications)
                .WithOne(p => p.Musician)
                .HasForeignKey(p => p.MusicianId);
            // ===========================================================
            // =================== Organizer Entity ======================
            modelBuilder.Entity<Organizer>()
                .HasMany(p => p.Qualifications)
                .WithOne(p => p.Organizer)
                .HasForeignKey(p => p.OrganizerId);
            // ===========================================================

            // ===================== Event Entity ========================
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Contract>().HasKey(p => p.Id);
            modelBuilder.Entity<Contract>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Contract>().Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Contract>().Property(p => p.Address)
                .IsRequired();
            modelBuilder.Entity<Contract>().Property(p => p.Reference)
                .IsRequired();
            modelBuilder.Entity<Contract>().Property(p => p.StartDate)
                .IsRequired();
            modelBuilder.Entity<Contract>().Property(p => p.EndDate)
                .IsRequired(); 
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Organizer)
                .WithMany(e => e.Contracts)
                .HasForeignKey(c => c.OrganizerId)
                .IsRequired(false);
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Musician)
                .WithMany(p => p.Contracts)
                .HasForeignKey(c => c.MusicianId)
                .IsRequired(false);
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.ContractState)
                .WithMany(s => s.Contracts)
                .HasForeignKey(c => c.ContractStateId);
            modelBuilder.Entity<Contract>().Property(p => p.ContractStateId)
                .HasDefaultValue(1);
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Qualification)
                .WithOne(q => q.Contract)
                .HasForeignKey<Qualification>(q => q.ContractId);
            // ===========================================================

            // ===================== Event Entity ========================
            modelBuilder.Entity<ContractState>().ToTable("ContractState");
            modelBuilder.Entity<ContractState>().HasKey(c => c.Id);
            modelBuilder.Entity<ContractState>().Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ContractState>().Property(c => c.Description);

            modelBuilder.Entity<ContractState>().HasData
                (
                    new ContractState { Id = 1, Description = "Finalizado" },
                    new ContractState { Id = 2, Description = "Respuesta pendiente" },
                    new ContractState { Id = 3, Description = "Trabajo pendiente" }
                );
            // ===========================================================

            // ===========================================================
            // ======================= Genre =============================

            modelBuilder.Entity<Genre>().ToTable("Genre");

            modelBuilder.Entity<Genre>().HasKey(p => p.Id);
            modelBuilder.Entity<Genre>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<MusicianGenre>().ToTable("MusicianGenre");

            modelBuilder.Entity<MusicianGenre>()
                .HasKey(pg => new { pg.MusicianId, pg.GenreId});
            modelBuilder.Entity<MusicianGenre>()
                .HasOne(pg => pg.Musician)
                .WithMany(p => p.MusicianGenres)
                .HasForeignKey(pg => pg.MusicianId);
            modelBuilder.Entity<MusicianGenre>()
                .HasOne(pg => pg.Genre)
                .WithMany(g => g.MusicianGenres)
                .HasForeignKey(pg => pg.GenreId);

            // ===========================================================
            // ===================== Instruments =========================
            modelBuilder.Entity<Instrument>().ToTable("Instrument");

            modelBuilder.Entity<Instrument>().HasKey(p => p.Id);
            modelBuilder.Entity<Instrument>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Instrument>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<MusicianInstrument>().ToTable("MusicianInstrument");

            modelBuilder.Entity<MusicianInstrument>()
                .HasKey(pg => new { pg.MusicianId, pg.InstrumentId });
            modelBuilder.Entity<MusicianInstrument>()
                .HasOne(pg => pg.Musician)
                .WithMany(p => p.MusicianInstruments)
                .HasForeignKey(pg => pg.MusicianId);
            modelBuilder.Entity<MusicianInstrument>()
                .HasOne(pg => pg.Instrument)
                .WithMany(g => g.MusicianInstruments)
                .HasForeignKey(pg => pg.InstrumentId);

            // ===========================================================

            // ===================== Searchs =========================
            modelBuilder.Entity<Search>().ToTable("Search");

            modelBuilder.Entity<Search>().HasKey(p => p.Id);
            modelBuilder.Entity<Search>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Search>().Property(s => s.Content);
            modelBuilder.Entity<Search>().Property(s => s.Genre);
            modelBuilder.Entity<Search>().Property(s => s.Instrument);
            modelBuilder.Entity<Search>().Property(s => s.District);
            modelBuilder.Entity<Search>()
                .HasOne(a => a.Account)
                .WithMany(s => s.Searches)
                .HasForeignKey(s => s.AccountId);

            // ===========================================================

            // ======================Publications=========================
            modelBuilder.Entity<Publication>().ToTable("Publications");
            modelBuilder.Entity<Publication>().HasKey(p => p.Id);
            modelBuilder.Entity<Publication>().Property(p=> p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Publication>().Property(p=> p.MediaUrl).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Publication>().Property(p=> p.Content).IsRequired();
            modelBuilder.Entity<Publication>().Property(p => p.PublicationType).IsRequired();
            modelBuilder.Entity<Publication>().Property(p => p.UpdateTime).IsRequired();
            modelBuilder.Entity<Publication>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.Publication)
                .HasForeignKey(p => p.PublicationId);
            // ===========================================================

            // =========================Comments==========================
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Comment>().HasKey(c => c.Id);
            modelBuilder.Entity<Comment>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Comment>().Property(c => c.Text).IsRequired();


            // ======================= Qualifications ====================
            modelBuilder.Entity<Qualification>().ToTable("Qualifications");
            modelBuilder.Entity<Qualification>().HasKey(q => q.Id);
            modelBuilder.Entity<Qualification>().Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Qualification>().Property(q => q.Text).IsRequired();
            modelBuilder.Entity<Qualification>().Property(q => q.Score).IsRequired();

            // ====================== Follow ============================
            modelBuilder.Entity<Follow>().ToTable("Follows");
            modelBuilder.Entity<Follow>
                ().HasKey(f => new { f.FollowerId, f.FollowedId});
            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(f => f.Followers)
                .HasForeignKey(f => f.FollowerId);
            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Followed)
                .WithMany(f => f.Followed)
                .HasForeignKey(f => f.FollowedId);
            // ===========================================================

            // =============== Naming conventions Policy =================
            modelBuilder.ApplySnakeCaseNamingConvention();
            // ===========================================================
        }
    }
}
