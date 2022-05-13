using System;
using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Models;

namespace MovieRentalApp.Repository
{
    public class MovieRentalDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public MovieRentalDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RentalDb.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasOne(staff => staff.Movie)
                .WithMany(movie => movie.Staffs)
                .HasForeignKey(staff => staff.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasOne(movie => movie.Rent)
                .WithMany(rent => rent.Movies)
                .HasForeignKey(movie => movie.RentId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Renter>(entity =>
            {
                entity.HasOne(renter => renter.Rent)
                .WithMany(rent => rent.Renters)
                .HasForeignKey(renter => renter.RentId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            Movie m1 = new Movie() { MovieId = 1, Title = "The Shawshank Redemption", Distributor = "PolyGram Film", Category = "drama", Length = "142 minutes", Language = "english" };
            Movie m2 = new Movie() { MovieId = 2, Title = "The Godfather", Distributor = "Duna Film", Category = "drama", Length = "175 minutes", Language = "english" };
            Movie m3 = new Movie() { MovieId = 3, Title = "The Godfather: Part II", Distributor = "Duna Film", Category = "drama", Length = "202 minutes", Language = "english" };
            Movie m4 = new Movie() { MovieId = 4, Title = "The Dark Knight", Distributor = "InterCom", Category = "action", Length = "152 minutes", Language = "english" };
            Movie m5 = new Movie() { MovieId = 5, Title = "Schindler's List", Distributor = "Duna Film", Category = "drama", Length = "195 minutes", Language = "english" };
            Movie m6 = new Movie() { MovieId = 6, Title = "The Lord of the Rings: The Return of the King", Distributor = "InterCom", Category = "adventure", Length = "201 minutes", Language = "english" };
            Movie m7 = new Movie() { MovieId = 7, Title = "Pulp Fiction", Distributor = "Mokép", Category = "crime", Length = "154 minutes", Language = "english" };
            Movie m8 = new Movie() { MovieId = 8, Title = "The Good, the Bad and the Ugly", Distributor = "Mokép", Category = "western", Length = "161 minutes", Language = "italian" };
            Movie m9 = new Movie() { MovieId = 9, Title = "Fight Club", Distributor = "20th Century Fox", Category = "drama", Length = "139 minutes", Language = "english" };
            Movie m10 = new Movie() { MovieId = 10, Title = "Forrest Gump", Distributor = "Paramount Pictures", Category = "romance", Length = "142 minutes", Language = "english" };

            Rent rent1 = new Rent() { RentId = 1, Order = new DateTime(2020, 02, 24), Price = 2000, RentalStart = new DateTime(2020, 02, 26), RentalEnd = new DateTime(2020, 03, 26), OverrunFee = 800 };
            Rent rent2 = new Rent() { RentId = 2, Order = new DateTime(2020, 06, 02), Price = 2500, RentalStart = new DateTime(2020, 06, 02), RentalEnd = new DateTime(2020, 07, 02), OverrunFee = 1100 };
            Rent rent3 = new Rent() { RentId = 3, Order = new DateTime(2020, 07, 11), Price = 4000, RentalStart = new DateTime(2020, 07, 16), RentalEnd = new DateTime(2020, 08, 30), OverrunFee = 2000 };
            Rent rent4 = new Rent() { RentId = 4, Order = new DateTime(2020, 01, 03), Price = 3300, RentalStart = new DateTime(2020, 01, 21), RentalEnd = new DateTime(2020, 02, 04), OverrunFee = 1500 };
            Rent rent5 = new Rent() { RentId = 5, Order = new DateTime(2020, 10, 17), Price = 2800, RentalStart = new DateTime(2020, 10, 20), RentalEnd = new DateTime(2020, 11, 01), OverrunFee = 700 };
            Rent rent6 = new Rent() { RentId = 6, Order = new DateTime(2020, 02, 04), Price = 1800, RentalStart = new DateTime(2020, 02, 05), RentalEnd = new DateTime(2020, 02, 19), OverrunFee = 500 };
            Rent rent7 = new Rent() { RentId = 7, Order = new DateTime(2020, 08, 28), Price = 3700, RentalStart = new DateTime(2020, 09, 01), RentalEnd = new DateTime(2020, 09, 11), OverrunFee = 1600 };
            Rent rent8 = new Rent() { RentId = 8, Order = new DateTime(2020, 03, 26), Price = 2600, RentalStart = new DateTime(2020, 03, 29), RentalEnd = new DateTime(2020, 04, 12), OverrunFee = 1200 };
            Rent rent9 = new Rent() { RentId = 9, Order = new DateTime(2020, 01, 04), Price = 3500, RentalStart = new DateTime(2020, 01, 09), RentalEnd = new DateTime(2020, 03, 09), OverrunFee = 1800 };
            Rent rent10 = new Rent() { RentId = 10, Order = new DateTime(2020, 11, 20), Price = 2400, RentalStart = new DateTime(2020, 11, 21), RentalEnd = new DateTime(2020, 11, 30), OverrunFee = 1000 };

            Renter renter1 = new Renter() { RenterId = 1, Name = "Nagy Árpád", Postcode = 1227, City = "Budapest", Street = "Liliom", HouseNumber = "15", MembershipStart = new DateTime(2019, 03, 23), MembershipEnd = new DateTime(2020, 11, 23) };
            Renter renter2 = new Renter() { RenterId = 2, Name = "Kovács János", Postcode = 4003, City = "Debrecen", Street = "Tölgy", HouseNumber = "1", MembershipStart = new DateTime(2019, 11, 01), MembershipEnd = new DateTime(2020, 12, 23) };
            Renter renter3 = new Renter() { RenterId = 3, Name = "Tóth Eszter", Postcode = 4400, City = "Nyíregyháza", Street = "Sárkány", HouseNumber = "62", MembershipStart = new DateTime(2019, 06, 02), MembershipEnd = new DateTime(2020, 04, 15) };
            Renter renter4 = new Renter() { RenterId = 4, Name = "Balog Ádám", Postcode = 1012, City = "Budapest", Street = "Palota", HouseNumber = "107", MembershipStart = new DateTime(2019, 12, 29), MembershipEnd = new DateTime(2020, 07, 18) };
            Renter renter5 = new Renter() { RenterId = 5, Name = "Kiss János", Postcode = 6731, City = "Szeged", Street = "Akácfa", HouseNumber = "39", MembershipStart = new DateTime(2019, 10, 11), MembershipEnd = new DateTime(2020, 08, 30) };
            Renter renter6 = new Renter() { RenterId = 6, Name = "Fekete Zoltán", Postcode = 9018, City = "Győr", Street = "Kossuth", HouseNumber = "14", MembershipStart = new DateTime(2019, 04, 11), MembershipEnd = new DateTime(2020, 08, 30) };
            Renter renter7 = new Renter() { RenterId = 7, Name = "Nagy Sarolta", Postcode = 8200, City = "Veszprém", Street = "Juharfa", HouseNumber = "62", MembershipStart = new DateTime(2020, 06, 19), MembershipEnd = new DateTime(2020, 12, 22) };
            Renter renter8 = new Renter() { RenterId = 8, Name = "Eszterházy Ádám", Postcode = 5000, City = "Szolnok", Street = "Andrássy", HouseNumber = "45", MembershipStart = new DateTime(2019, 02, 11), MembershipEnd = new DateTime(2020, 09, 14) };
            Renter renter9 = new Renter() { RenterId = 9, Name = "Dobó Kata", Postcode = 1216, City = "Budapest", Street = "János", HouseNumber = "11", MembershipStart = new DateTime(2020, 07, 02), MembershipEnd = new DateTime(2020, 11, 15) };
            Renter renter10 = new Renter() { RenterId = 10, Name = "Kövér Attila", Postcode = 4027, City = "Debrecen", Street = "Vámház", HouseNumber = "44", MembershipStart = new DateTime(2019, 07, 01), MembershipEnd = new DateTime(2020, 12, 02) };

            Staff s1 = new Staff() { StaffId = 1, Director = "Frank Darabont", MainCharacter = "Morgan Freeman", SupportingCharacters = 14, Cost = 25000000, Studio = "Castle Rock Entertainment" };
            Staff s2 = new Staff() { StaffId = 2, Director = "Francis Ford Coppola", MainCharacter = "Marlon Brando", SupportingCharacters = 22, Cost = 6000000, Studio = "Paramount Pictures" };
            Staff s3 = new Staff() { StaffId = 3, Director = "Frank Darabont", MainCharacter = "Al Pacino", SupportingCharacters = 29, Cost = 13000000, Studio = "Paramount Pictures" };
            Staff s4 = new Staff() { StaffId = 4, Director = "Christopher Nolan", MainCharacter = "Christian Bale", SupportingCharacters = 20, Cost = 185000000, Studio = "Warner Brothers" };
            Staff s5 = new Staff() { StaffId = 5, Director = "Steven Spielberg", MainCharacter = "Liam Neeson", SupportingCharacters = 18, Cost = 22000000, Studio = "Universal Pictures" };
            Staff s6 = new Staff() { StaffId = 6, Director = "Peter Jackson", MainCharacter = "Orlando Bloom", SupportingCharacters = 40, Cost = 94000000, Studio = "New Line Cinema" };
            Staff s7 = new Staff() { StaffId = 7, Director = "Quentin Tarantino", MainCharacter = "Samuel Jackson", SupportingCharacters = 20, Cost = 8000000, Studio = "Miramax" };
            Staff s8 = new Staff() { StaffId = 8, Director = "Sergio Leone", MainCharacter = "Clint Eastwood", SupportingCharacters = 11, Cost = 1200000, Studio = "Produzioni Europee Associate" };
            Staff s9 = new Staff() { StaffId = 9, Director = "David Fincher", MainCharacter = "Brad Pitt", SupportingCharacters = 27, Cost = 63000000, Studio = "Fox 2000 Pictures" };
            Staff s10 = new Staff() { StaffId = 10, Director = "Robert Zemeckis", MainCharacter = "Tom Hanks", SupportingCharacters = 31, Cost = 55000000, Studio = "Paramount Pictures" };

            s1.MovieId = m1.MovieId;
            s2.MovieId = m2.MovieId;
            s3.MovieId = m3.MovieId;
            s4.MovieId = m4.MovieId;
            s5.MovieId = m5.MovieId;
            s6.MovieId = m6.MovieId;
            s7.MovieId = m7.MovieId;
            s8.MovieId = m8.MovieId;
            s9.MovieId = m9.MovieId;
            s10.MovieId = m10.MovieId;

            m1.RentId = rent1.RentId;
            m2.RentId = rent2.RentId;
            m3.RentId = rent3.RentId;
            m4.RentId = rent4.RentId;
            m5.RentId = rent5.RentId;
            m6.RentId = rent6.RentId;
            m7.RentId = rent8.RentId;
            m8.RentId = rent9.RentId;
            m9.RentId = rent7.RentId;
            m10.RentId = rent10.RentId;

            renter1.RentId = rent1.RentId;
            renter2.RentId = rent2.RentId;
            renter3.RentId = rent3.RentId;
            renter4.RentId = rent4.RentId;
            renter5.RentId = rent5.RentId;
            renter6.RentId = rent6.RentId;
            renter7.RentId = rent8.RentId;
            renter8.RentId = rent9.RentId;
            renter9.RentId = rent7.RentId;
            renter10.RentId = rent10.RentId;

            modelBuilder.Entity<Staff>().HasData(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10);
            modelBuilder.Entity<Movie>().HasData(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10);
            modelBuilder.Entity<Rent>().HasData(rent1, rent2, rent3, rent4, rent5, rent6, rent7, rent8, rent9, rent10);
            modelBuilder.Entity<Renter>().HasData(renter1, renter2, renter3, renter4, renter5, renter6, renter7, renter8, renter9, renter10);
        }
    }
}
