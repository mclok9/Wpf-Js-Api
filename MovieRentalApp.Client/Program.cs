using System;
using System.Linq;
using MovieRentalApp.Models;
using ConsoleTools;
using System.Collections.Generic;

namespace MovieRentalApp.Client
{
    class Program
    {
        static RestService rest;

        static void Read(string entity)
        {
            if (entity == "movie")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                string number = Console.ReadLine();

                if (number != null)
                {
                    int id = int.Parse(number, null);
                    Movie movie = rest.Get<Movie>(id, "movie");

                    Console.WriteLine("\n The selected movie: \n");
                    Console.WriteLine(movie.MovieId + " - " + movie.Title + " - " + movie.Distributor);
                    Console.WriteLine(movie.Category + " - " + movie.Length + " - " + movie.Language + " - " + movie.RentId);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong input. It is not a number.");
                    Console.ReadLine();
                }
            }
            else if (entity == "rent")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                string number = Console.ReadLine();

                if (number != null)
                {
                    int id = int.Parse(number, null);
                    Rent rent = rest.Get<Rent>(id, "rent");

                    Console.WriteLine("\n The selected rent: \n");
                    Console.WriteLine(rent.RentId + " - " + rent.Order + " - " + rent.Price);
                    Console.WriteLine(rent.RentalStart + " - " + rent.RentalEnd + " - " + rent.OverrunFee);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong input. It is not a number.");
                    Console.ReadLine();
                }
            }
            else if (entity == "renter")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                string number = Console.ReadLine();

                if (number != null)
                {
                    int id = int.Parse(number, null);
                    Renter renter = rest.Get<Renter>(id, "renter");

                    Console.WriteLine("\n The selected renter: \n");
                    Console.WriteLine(renter.RenterId + " - " + renter.Name + " - " + renter.Postcode + " - " + renter.City + " - " + renter.Street);
                    Console.WriteLine(renter.HouseNumber + " - " + renter.MembershipStart + " - " + renter.MembershipEnd + " - " + renter.RentId);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong input. It is not a number.");
                    Console.ReadLine();
                }
            }
            else if (entity == "staff")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                string number = Console.ReadLine();

                if (number != null)
                {
                    int id = int.Parse(number, null);
                    Staff staff = rest.Get<Staff>(id, "staff");

                    Console.WriteLine("\n The selected staff: \n");
                    Console.WriteLine(staff.StaffId + " - " + staff.Director + " - " + staff.MainCharacter);
                    Console.WriteLine(staff.SupportingCharacters + " - " + staff.Cost + " - " + staff.Studio + " - " + staff.MovieId);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong input. It is not a number.");
                    Console.ReadLine();
                }
            }
        }

        static void Create(string entity)
        {
            if (entity == "movie")
            {
                Console.WriteLine("Enter the title here: ");
                string title = Console.ReadLine();

                Console.WriteLine("Enter the distributor here: ");
                string distributor = Console.ReadLine();

                Console.WriteLine("Enter the category here: ");
                string category = Console.ReadLine();

                Console.WriteLine("Enter the length here(__ minutes): ");
                string length = Console.ReadLine();

                Console.WriteLine("Enter the language here: ");
                string language = Console.ReadLine();

                Console.WriteLine("Enter the rentId here(between 1 and 10): ");
                int rentId = int.Parse(Console.ReadLine(), null);

                rest.Post(new Movie() { Title = title, Distributor = distributor, Category = category, Length = length, Language = language, RentId = rentId }, "movie");

                Console.WriteLine("\n The movie successfully created. \n");
                Console.ReadLine();
            }
            else if (entity == "rent")
            {
                Console.WriteLine("Enter the order here(YYYY, MM, DD): ");
                DateTime order = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the price here: ");
                int price = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the start of the rental here(YYYY, MM, DD): ");
                DateTime rentalStart = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the end of the rental here(YYYY, MM, DD): ");
                DateTime rentalEnd = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the overrun fee here: ");
                int overrunFee = int.Parse(Console.ReadLine(), null);

                rest.Post(new Rent() { Order = order, Price = price, RentalStart = rentalStart, RentalEnd = rentalEnd, OverrunFee = overrunFee }, "rent");

                Console.WriteLine("\n The rent successfully created. \n");
                Console.ReadLine();
            }
            else if (entity == "renter")
            {
                Console.WriteLine("Enter the name here: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the postcode here: ");
                int postcode = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the city here: ");
                string city = Console.ReadLine();

                Console.WriteLine("Enter the street here: ");
                string street = Console.ReadLine();

                Console.WriteLine("Enter the house number here: ");
                string houseNumber = Console.ReadLine();

                Console.WriteLine("Enter the start of the membership here(YYYY, MM, DD): ");
                DateTime membershipStart = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the end of the membership here(YYYY, MM, DD): ");
                DateTime membershipEnd = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the rentId here(between 1 and 10): ");
                int rentId = int.Parse(Console.ReadLine(), null);

                rest.Post(new Renter() { Name = name, Postcode = postcode, City = city, Street = street, HouseNumber = houseNumber, MembershipStart = membershipStart, MembershipEnd = membershipEnd, RentId = rentId }, "renter");

                Console.WriteLine("\n The renter successfully created. \n");
                Console.ReadLine();
            }
            else if (entity == "staff")
            {
                Console.WriteLine("Enter the director here: ");
                string director = Console.ReadLine();

                Console.WriteLine("Enter the main character here: ");
                string mainCharacter = Console.ReadLine();

                Console.WriteLine("Enter the number of supporting characters here: ");
                int supportingCharacters = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the cost here: ");
                int cost = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the studio here: ");
                string studio = Console.ReadLine();

                Console.WriteLine("Enter the movieId here(between 1 and 10): ");
                int movieId = int.Parse(Console.ReadLine(), null);

                rest.Post(new Staff() { Director = director, MainCharacter = mainCharacter, SupportingCharacters = supportingCharacters, Cost = cost, Studio = studio, MovieId = movieId }, "staff");

                Console.WriteLine("\n The staff successfully created. \n");
                Console.ReadLine();
            }
        }

        static void List(string entity)
        {
            if (entity == "movie")
            {
                List<Movie> movies = rest.Get<Movie>("movie");
                foreach (var movie in movies)
                {
                    Console.WriteLine(movie.MovieId + " - " + movie.Title + " - " + movie.Distributor);
                    Console.WriteLine(movie.Category + " - " + movie.Length + " - " + movie.Language + " - " + movie.RentId);
                }
                Console.ReadLine();
            }
            else if (entity == "rent")
            {
                List<Rent> rents = rest.Get<Rent>("rent");
                foreach (var rent in rents)
                {
                    Console.WriteLine(rent.RentId + " - " + rent.Order + " - " + rent.Price);
                    Console.WriteLine(rent.RentalStart + " - " + rent.RentalEnd + " - " + rent.OverrunFee);
                }
                Console.ReadLine();
            }
            else if (entity == "renter")
            {
                List<Renter> renters = rest.Get<Renter>("renter");
                foreach (var renter in renters)
                {
                    Console.WriteLine(renter.RenterId + " - " + renter.Name + " - " + renter.Postcode + " - " + renter.City + " - " + renter.Street);
                    Console.WriteLine(renter.HouseNumber + " - " + renter.MembershipStart + " - " + renter.MembershipEnd + " - " + renter.RentId);
                }
                Console.ReadLine();
            }
            else if (entity == "staff")
            {
                List<Staff> staffs = rest.Get<Staff>("staff");
                foreach (var staff in staffs)
                {
                    Console.WriteLine(staff.StaffId + " - " + staff.Director + " - " + staff.MainCharacter);
                    Console.WriteLine(staff.SupportingCharacters + " - " + staff.Cost + " - " + staff.Studio + " - " + staff.MovieId);
                }
                Console.ReadLine();
            }
        }

        static void Update(string entity)
        {
            if (entity == "movie")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                Movie one = rest.Get<Movie>(id, "movie");

                Console.WriteLine("The old title: " + one.Title);
                Console.WriteLine("Enter the new title here: ");
                string newTitle = Console.ReadLine();

                Console.WriteLine("The old distributor: " + one.Distributor);
                Console.WriteLine("Enter the new distributor here: ");
                string newDistributor = Console.ReadLine();

                Console.WriteLine("The old category: " + one.Category);
                Console.WriteLine("Enter the new category here: ");
                string newCategory = Console.ReadLine();

                Console.WriteLine("The old length: " + one.Length);
                Console.WriteLine("Enter the new length here(__ minutes): ");
                string newLength = Console.ReadLine();

                Console.WriteLine("The old language: " + one.Language);
                Console.WriteLine("Enter the new language here: ");
                string newLanguage = Console.ReadLine();

                Console.WriteLine("The old rentId: " + one.RentId);
                Console.WriteLine("Enter the new rentId here(between 1 and 10): ");
                int newRentId = int.Parse(Console.ReadLine(), null);

                one.Title = newTitle;
                one.Distributor = newDistributor;
                one.Category = newCategory;
                one.Length = newLength;
                one.Language = newLanguage;
                one.RentId = newRentId;
                rest.Put(one, "movie");

                Console.WriteLine("The update was successful.");
                Console.ReadLine();
            }
            else if (entity == "rent")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                Rent one = rest.Get<Rent>(id, "rent");

                Console.WriteLine("The old order: " + one.Order);
                Console.WriteLine("Enter the new order here (YYYY, MM, DD): ");
                DateTime newOrder = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old price: " + one.Price);
                Console.WriteLine("Enter the new price here: ");
                int newPrice = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old rentalStart: " + one.RentalStart);
                Console.WriteLine("Enter the new start of the rental here (YYYY, MM, DD): ");
                DateTime newRentalStart = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old rentalEnd: " + one.RentalEnd);
                Console.WriteLine("Enter the new end of the rental here (YYYY, MM, DD): ");
                DateTime newRentalEnd = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old overrun fee: " + one.OverrunFee);
                Console.WriteLine("Enter the new overrun fee here: ");
                int newOverrunFee = int.Parse(Console.ReadLine(), null);

                one.Order = newOrder;
                one.Price = newPrice;
                one.RentalStart = newRentalStart;
                one.RentalEnd = newRentalEnd;
                one.OverrunFee = newOverrunFee;
                rest.Put(one, "rent");

                Console.WriteLine("The update was successful.");
                Console.ReadLine();
            }
            else if (entity == "renter")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                Renter one = rest.Get<Renter>(id, "renter");

                Console.WriteLine("The old name: " + one.Name);
                Console.WriteLine("Enter the new name here: ");
                string newName = Console.ReadLine();

                Console.WriteLine("The old post code: " + one.Postcode);
                Console.WriteLine("Enter the new postcode here: ");
                int newPostcode = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old city: " + one.City);
                Console.WriteLine("Enter the new city here: ");
                string newCity = Console.ReadLine();

                Console.WriteLine("The old street: " + one.Street);
                Console.WriteLine("Enter the new street here: ");
                string newStreet = Console.ReadLine();

                Console.WriteLine("The old house number: " + one.HouseNumber);
                Console.WriteLine("Enter the new house number here: ");
                string newHouseNumber = Console.ReadLine();

                Console.WriteLine("The old membershipStart: " + one.MembershipStart);
                Console.WriteLine("Enter the new start of the membership here (YYYY, MM, DD) : ");
                DateTime newMembershipStart = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old membershipEnd: " + one.MembershipEnd);
                Console.WriteLine("Enter the new end of the membership here (YYYY, MM, DD) : ");
                DateTime newMembershipEnd = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old rentId: " + one.RentId);
                Console.WriteLine("Enter the new rentId here(between 1 and 10): ");
                int newRentId = int.Parse(Console.ReadLine(), null);

                one.Name = newName;
                one.Postcode = newPostcode;
                one.City = newCity;
                one.Street = newStreet;
                one.HouseNumber = newHouseNumber;
                one.MembershipStart = newMembershipStart;
                one.MembershipEnd = newMembershipEnd;
                one.RentId = newRentId;
                rest.Put(one, "renter");

                Console.WriteLine("The update was successful.");
                Console.ReadLine();
            }
            else if (entity == "staff")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                Staff one = rest.Get<Staff>(id, "staff");

                Console.WriteLine("The old director: " + one.Director);
                Console.WriteLine("Enter the new director here: ");
                string newDirector = Console.ReadLine();

                Console.WriteLine("The old main character: " + one.MainCharacter);
                Console.WriteLine("Enter the new main character here: ");
                string newMainCharacter = Console.ReadLine();

                Console.WriteLine("The old number of supporting characeters: " + one.SupportingCharacters);
                Console.WriteLine("Enter the new number of supporting characters here: ");
                int newSupportingCharacters = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old cost: " + one.Cost);
                Console.WriteLine("Enter the new cost here: ");
                int newCost = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("The old studio: " + one.Studio);
                Console.WriteLine("Enter the new studio here: ");
                string newStudio = Console.ReadLine();

                Console.WriteLine("The old movieId: " + one.MovieId);
                Console.WriteLine("Enter the new movieId here(between 1 and 10): ");
                int newMovieId = int.Parse(Console.ReadLine(), null);

                one.Director = newDirector;
                one.MainCharacter = newMainCharacter;
                one.SupportingCharacters = newSupportingCharacters;
                one.Cost = newCost;
                one.Studio = newStudio;
                one.MovieId = newMovieId;
                rest.Put(one, "staff");

                Console.WriteLine("The update was successful.");
                Console.ReadLine();
            }
        }

        static void Delete(string entity)
        {
            if (entity == "movie")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                rest.Delete(id, "movie");
                Console.WriteLine("The selected Id successfully deleted.");
                Console.ReadLine();
            }
            else if (entity == "rent")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                rest.Delete(id, "rent");
                Console.WriteLine("The selected Id successfully deleted.");
                Console.ReadLine();
            }
            else if (entity == "renter")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                rest.Delete(id, "renter");
                Console.WriteLine("The selected Id successfully deleted.");
                Console.ReadLine();
            }
            else if (entity == "staff")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                rest.Delete(id, "staff");
                Console.WriteLine("The selected Id successfully deleted.");
                Console.ReadLine();
            }
        }

        //static MovieLogic movieLogic;
        //static RentLogic rentLogic;
        //static RenterLogic renterLogic;
        //static StaffLogic staffLogic;

        /*static void Read(string entity)
        {
            if (entity == "movie")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                string number = Console.ReadLine();

                if (number != null)
                {
                    int id = int.Parse(number, null);
                    //if (id > 0 && id < 11)
                    //{
                        var movie = movieLogic.Read(id);

                        Console.WriteLine("\n The selected movie: \n");
                        Console.WriteLine("MovieId - Title - Distributor - Category - Length - Language - RentId");
                        Console.WriteLine(movie.MovieId + " - " + movie.Title + " - " + movie.Distributor);
                        Console.WriteLine(movie.Category + " - " + movie.Length + " - " + movie.Language + " - " + movie.RentId);
                        Console.ReadLine();
                    //}
                    //else
                    //{
                    //    Console.WriteLine("The selected Id does not exist.");
                    //    Console.ReadLine();
                    //}
                }
                else
                {
                    Console.WriteLine("Wrong input. It is not a number.");
                    Console.ReadLine();
                }
            }
            else if (entity == "rent")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                string number = Console.ReadLine();

                if (number != null)
                {
                    int id = int.Parse(number, null);
                    //if (id > 0 && id < 11)
                    //{
                        var rent = rentLogic.Read(id);

                        Console.WriteLine("\n The selected rent: \n");
                        Console.WriteLine("RentId - Order - Price - RentalStart - RentalEnd - OverrunFee");
                        Console.WriteLine(rent.RentId + " - " + rent.Order + " - " + rent.Price);
                        Console.WriteLine(rent.RentalStart + " - " + rent.RentalEnd + " - " + rent.OverrunFee);
                        Console.ReadLine();
                    //}
                    //else
                    //{
                    //    Console.WriteLine("The selected Id does not exist.");
                    //    Console.ReadLine();
                    //}
                }
                else
                {
                    Console.WriteLine("Wrong input. It is not a number.");
                    Console.ReadLine();
                }
            }
            else if (entity == "renter")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                string number = Console.ReadLine();

                if (number != null)
                {
                    int id = int.Parse(number, null);
                    //if (id > 0 && id < 11)
                    //{
                        var renter = renterLogic.Read(id);

                        Console.WriteLine("\n The selected renter: \n");
                        Console.WriteLine("RenterId - Name - Postcode - City - Street - HouseNumber - MembershipStart - MembershipEnd - RentId");
                        Console.WriteLine(renter.RenterId + " - " + renter.Name + " - " + renter.Postcode + " - " + renter.City + " - " + renter.Street);
                        Console.WriteLine(renter.HouseNumber + " - " + renter.MembershipStart + " - " + renter.MembershipEnd + " - " + renter.RentId);
                        Console.ReadLine();
                    //}
                    //else
                    //{
                    //    Console.WriteLine("The selected Id does not exist.");
                    //    Console.ReadLine();
                    //}
                }
                else
                {
                    Console.WriteLine("Wrong input. It is not a number.");
                    Console.ReadLine();
                }
            }
            else if (entity == "staff")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                string number = Console.ReadLine();

                if (number != null)
                {
                    int id = int.Parse(number, null);
                    //if (id > 0 && id < 11)
                    //{
                        var staff = staffLogic.Read(id);

                        Console.WriteLine("\n The selected staff: \n");
                        Console.WriteLine("StaffId - Director - MainCharacter - SupportingCharacters - Cost - Studio - MovieId");
                        Console.WriteLine(staff.StaffId + " - " + staff.Director + " - " + staff.MainCharacter);
                        Console.WriteLine(staff.SupportingCharacters + " - " + staff.Cost + " - " + staff.Studio + " - " + staff.MovieId);
                        Console.ReadLine();
                    //}
                    //else
                    //{
                    //    Console.WriteLine("The selected Id does not exist.");
                    //    Console.ReadLine();
                    //}
                }
                else
                {
                    Console.WriteLine("Wrong input. It is not a number.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Nem megfelelő!");
                Console.ReadLine();
            }
        }

        static void List(string entity)
        {
            if (entity == "movie")
            {
                var items = movieLogic.ReadAll();
                Console.WriteLine("MovieId - Title - Distributor - Category - Length - Language - RentId");

                foreach (var movie in items)
                {
                    Console.WriteLine(movie.MovieId + " - " + movie.Title + " - " + movie.Distributor);
                    Console.WriteLine(movie.Category + " - " + movie.Length + " - " + movie.Language + " - " + movie.RentId);
                }

                Console.ReadLine();
            }
            else if (entity == "rent")
            {
                var items = rentLogic.ReadAll();
                Console.WriteLine("RentId - Order - Price - RentalStart - RentalEnd - OverrunFee");

                foreach (var rent in items)
                {
                    Console.WriteLine(rent.RentId + " - " + rent.Order + " - " + rent.Price);
                    Console.WriteLine(rent.RentalStart + " - " + rent.RentalEnd + " - " + rent.OverrunFee);
                }

                Console.ReadLine();
            }
            else if (entity == "renter")
            {
                var items = renterLogic.ReadAll();
                Console.WriteLine("RenterId - Name - Postcode - City - Street - HouseNumber - MembershipStart - MembershipEnd - RentId");

                foreach (var renter in items)
                {
                    Console.WriteLine(renter.RenterId + " - " + renter.Name + " - " + renter.Postcode + " - " + renter.City + " - " + renter.Street);
                    Console.WriteLine(renter.HouseNumber + " - " + renter.MembershipStart + " - " + renter.MembershipEnd + " - " + renter.RentId);
                }

                Console.ReadLine();
            }
            else if (entity == "staff")
            {
                var items = staffLogic.ReadAll();
                Console.WriteLine("StaffId - Director - MainCharacter - SupportingCharacters - Cost - Studio - MovieId");

                foreach (var staff in items)
                {
                    Console.WriteLine(staff.StaffId + " - " + staff.Director + " - " + staff.MainCharacter);
                    Console.WriteLine(staff.SupportingCharacters + " - " + staff.Cost + " - " + staff.Studio + " - " + staff.MovieId);
                }

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Nem megfelelő!");
                Console.ReadLine();
            }
        }

        static void Create(string entity)
        {
            if (entity == "movie")
            {
                Console.WriteLine("Enter the title here: ");
                string title = Console.ReadLine();

                Console.WriteLine("Enter the distributor here: ");
                string distributor = Console.ReadLine();

                Console.WriteLine("Enter the category here: ");
                string category = Console.ReadLine();

                Console.WriteLine("Enter the length here(__ minutes): ");
                string length = Console.ReadLine();

                Console.WriteLine("Enter the language here: ");
                string language = Console.ReadLine();

                Console.WriteLine("Enter the rentId here(between 1 and 10): ");
                int rentId = int.Parse(Console.ReadLine(), null);

                Movie item = new Movie() { Title = title, Distributor = distributor, Category = category, Length = length, Language = language, RentId = rentId };
                movieLogic.Create(item);

                Console.WriteLine("\n The movie successfully created. \n");
                Console.ReadLine();
            }
            else if (entity == "rent")
            {
                Console.WriteLine("Enter the order here(YYYY, MM, DD): ");
                DateTime order = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the price here: ");
                int price = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the start of the rental here(YYYY, MM, DD): ");
                DateTime rentalStart = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the end of the rental here(YYYY, MM, DD): ");
                DateTime rentalEnd = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the overrun fee here: ");
                int overrunFee = int.Parse(Console.ReadLine(), null);

                Rent item = new Rent() { Order = order, Price = price, RentalStart = rentalStart, RentalEnd = rentalEnd, OverrunFee = overrunFee };
                rentLogic.Create(item);

                Console.WriteLine("\n The rent successfully created. \n");
                Console.ReadLine();
            }
            else if (entity == "renter")
            {
                Console.WriteLine("Enter the name here: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the postcode here: ");
                int postcode = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the city here: ");
                string city = Console.ReadLine();

                Console.WriteLine("Enter the street here: ");
                string street = Console.ReadLine();

                Console.WriteLine("Enter the house number here: ");
                string houseNumber = Console.ReadLine();

                Console.WriteLine("Enter the start of the membership here(YYYY, MM, DD): ");
                DateTime membershipStart = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the end of the membership here(YYYY, MM, DD): ");
                DateTime membershipEnd = DateTime.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the rentId here(between 1 and 10): ");
                int rentId = int.Parse(Console.ReadLine(), null);

                Renter item = new Renter() { Name = name, Postcode = postcode, City = city, Street = street, HouseNumber = houseNumber, MembershipStart = membershipStart, MembershipEnd = membershipEnd, RentId = rentId };
                renterLogic.Create(item);

                Console.WriteLine("\n The renter successfully created. \n");
                Console.ReadLine();
            }
            else if (entity == "staff")
            {
                Console.WriteLine("Enter the director here: ");
                string director = Console.ReadLine();

                Console.WriteLine("Enter the main character here: ");
                string mainCharacter = Console.ReadLine();

                Console.WriteLine("Enter the number of supporting characters here: ");
                int supportingCharacters = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the cost here: ");
                int cost = int.Parse(Console.ReadLine(), null);

                Console.WriteLine("Enter the studio here: ");
                string studio = Console.ReadLine();

                Console.WriteLine("Enter the movieId here(between 1 and 10): ");
                int movieId = int.Parse(Console.ReadLine(), null);

                Staff item = new Staff() { Director = director, MainCharacter = mainCharacter, SupportingCharacters = supportingCharacters, Cost = cost, Studio = studio, MovieId = movieId };
                staffLogic.Create(item);

                Console.WriteLine("\n The staff successfully created. \n");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Nem megfelelő!");
                Console.ReadLine();
            }
        }

        static void Update(string entity)
        {
            if (entity == "movie")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                //if (id > 0 && id < 11)
                //{
                    var old = movieLogic.Read(id);
                    var one = movieLogic.Read(id);

                    Console.WriteLine("The old title: " + old.Title);
                    Console.WriteLine("Enter the new title here: ");
                    string newTitle = Console.ReadLine();

                    Console.WriteLine("The old distributor: " + old.Distributor);
                    Console.WriteLine("Enter the new distributor here: ");
                    string newDistributor = Console.ReadLine();

                    Console.WriteLine("The old category: " + old.Category);
                    Console.WriteLine("Enter the new category here: ");
                    string newCategory = Console.ReadLine();

                    Console.WriteLine("The old length: " + old.Length);
                    Console.WriteLine("Enter the new length here(__ minutes): ");
                    string newLength = Console.ReadLine();

                    Console.WriteLine("The old language: " + old.Language);
                    Console.WriteLine("Enter the new language here: ");
                    string newLanguage = Console.ReadLine();

                    Console.WriteLine("The old rentId: " + old.RentId);
                    Console.WriteLine("Enter the new rentId here(between 1 and 10): ");
                    int newRentId = int.Parse(Console.ReadLine(), null);

                    one.Title = newTitle;
                    one.Distributor = newDistributor;
                    one.Category = newCategory;
                    one.Length = newLength;
                    one.Language = newLanguage;
                    one.RentId = newRentId;

                    movieLogic.Update(one);
                    Console.WriteLine("The update was successful.");
                    Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("The selected Id does not exist.");
                //    Console.ReadLine();
                //}
            }
            else if (entity == "rent")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                //if (id > 0 && id < 11)
                //{
                    var old = rentLogic.Read(id);
                    var one = rentLogic.Read(id);

                    Console.WriteLine("The old order: " + old.Order);
                    Console.WriteLine("Enter the new order here (YYYY, MM, DD): ");
                    DateTime newOrder = DateTime.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old price: " + old.Price);
                    Console.WriteLine("Enter the new price here: ");
                    int newPrice = int.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old rentalStart: " + old.RentalStart);
                    Console.WriteLine("Enter the new start of the rental here (YYYY, MM, DD): ");
                    DateTime newRentalStart = DateTime.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old rentalEnd: " + old.RentalEnd);
                    Console.WriteLine("Enter the new end of the rental here (YYYY, MM, DD): ");
                    DateTime newRentalEnd = DateTime.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old overrun fee: " + old.OverrunFee);
                    Console.WriteLine("Enter the new overrun fee here: ");
                    int newOverrunFee = int.Parse(Console.ReadLine(), null);

                    one.Order = newOrder;
                    one.Price = newPrice;
                    one.RentalStart = newRentalStart;
                    one.RentalEnd = newRentalEnd;
                    one.OverrunFee = newOverrunFee;

                    rentLogic.Update(one);
                    Console.WriteLine("The update was successful.");
                    Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("The selected Id does not exist.");
                //    Console.ReadLine();
                //}
            }
            else if (entity == "renter")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                //if (id > 0 && id < 11)
                //{
                    var old = renterLogic.Read(id);
                    var one = renterLogic.Read(id);

                    Console.WriteLine("The old name: " + old.Name);
                    Console.WriteLine("Enter the new name here: ");
                    string newName = Console.ReadLine();

                    Console.WriteLine("The old post code: " + old.Postcode);
                    Console.WriteLine("Enter the new postcode here: ");
                    int newPostcode = int.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old city: " + old.City);
                    Console.WriteLine("Enter the new city here: ");
                    string newCity = Console.ReadLine();

                    Console.WriteLine("The old street: " + old.Street);
                    Console.WriteLine("Enter the new street here: ");
                    string newStreet = Console.ReadLine();

                    Console.WriteLine("The old house number: " + old.HouseNumber);
                    Console.WriteLine("Enter the new house number here: ");
                    string newHouseNumber = Console.ReadLine();

                    Console.WriteLine("The old membershipStart: " + old.MembershipStart);
                    Console.WriteLine("Enter the new start of the membership here (YYYY, MM, DD) : ");
                    DateTime newMembershipStart = DateTime.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old membershipEnd: " + old.MembershipEnd);
                    Console.WriteLine("Enter the new end of the membership here (YYYY, MM, DD) : ");
                    DateTime newMembershipEnd = DateTime.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old rentId: " + old.RentId);
                    Console.WriteLine("Enter the new rentId here(between 1 and 10): ");
                    int newRentId = int.Parse(Console.ReadLine(), null);

                    one.Name = newName;
                    one.Postcode = newPostcode;
                    one.City = newCity;
                    one.Street = newStreet;
                    one.HouseNumber = newHouseNumber;
                    one.MembershipStart = newMembershipStart;
                    one.MembershipEnd = newMembershipEnd;
                    one.RentId = newRentId;

                    renterLogic.Update(one);
                    Console.WriteLine("The update was successful.");
                    Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("The selected Id does not exist.");
                //    Console.ReadLine();
                //}
            }
            else if (entity == "staff")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                //if (id > 0 && id < 11)
                //{
                    var old = staffLogic.Read(id);
                    var one = staffLogic.Read(id);

                    Console.WriteLine("The old director: " + old.Director);
                    Console.WriteLine("Enter the new director here: ");
                    string newDirector = Console.ReadLine();

                    Console.WriteLine("The old main character: " + old.MainCharacter);
                    Console.WriteLine("Enter the new main character here: ");
                    string newMainCharacter = Console.ReadLine();

                    Console.WriteLine("The old number of supporting characeters: " + old.SupportingCharacters);
                    Console.WriteLine("Enter the new number of supporting characters here: ");
                    int newSupportingCharacters = int.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old cost: " + old.Cost);
                    Console.WriteLine("Enter the new cost here: ");
                    int newCost = int.Parse(Console.ReadLine(), null);

                    Console.WriteLine("The old studio: " + old.Studio);
                    Console.WriteLine("Enter the new studio here: ");
                    string newStudio = Console.ReadLine();

                    Console.WriteLine("The old movieId: " + old.MovieId);
                    Console.WriteLine("Enter the new movieId here(between 1 and 10): ");
                    int newMovieId = int.Parse(Console.ReadLine(), null);

                    one.Director = newDirector;
                    one.MainCharacter = newMainCharacter;
                    one.SupportingCharacters = newSupportingCharacters;
                    one.Cost = newCost;
                    one.Studio = newStudio;
                    one.MovieId = newMovieId;

                    staffLogic.Update(one);
                    Console.WriteLine("The update was successful.");
                    Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("The selected Id does not exist.");
                //    Console.ReadLine();
                //}
            }
            else
            {
                Console.WriteLine("Nem megfelelő!");
                Console.ReadLine();
            }
        }

        static void Delete(string entity)
        {
            if (entity == "movie")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                //if (id > 0 && id < 11)
                //{
                    movieLogic.Delete(id);
                    Console.WriteLine("The selected Id successfully deleted.");
                    Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("The selected Id does not exist.");
                //    Console.ReadLine();
                //}
            }
            else if (entity == "rent")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                //if (id > 0 && id < 11)
                //{
                    rentLogic.Delete(id);
                    Console.WriteLine("The selected Id successfully deleted.");
                    Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("The selected Id does not exist.");
                //    Console.ReadLine();
                //}
            }
            else if (entity == "renter")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                //if (id > 0 && id < 11)
                //{
                    renterLogic.Delete(id);
                    Console.WriteLine("The selected Id successfully deleted.");
                    Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("The selected Id does not exist.");
                //    Console.ReadLine();
                //}
            }
            else if (entity == "staff")
            {
                Console.WriteLine("Enter the selected Id(between 1 and 10): ");
                int id = int.Parse(Console.ReadLine(), null);

                //if (id > 0 && id < 11)
                //{
                    staffLogic.Delete(id);
                    Console.WriteLine("The selected Id successfully deleted.");
                    Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("The selected Id does not exist.");
                //    Console.ReadLine();
                //}
            }
            else
            {
                Console.WriteLine("Nem megfelelő!");
                Console.ReadLine();
            }*/

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:12229/", "movie");

            //var ctx = new MovieRentalDbContext();

            //var movieRepo = new MovieRepository(ctx);
            //var rentRepo = new RentRepository(ctx);
            //var renterRepo = new RenterRepository(ctx);
            //var staffRepo = new StaffRepository(ctx);

            //movieLogic = new MovieLogic(movieRepo);
            //rentLogic = new RentLogic(rentRepo);
            //renterLogic = new RenterLogic(renterRepo);
            //staffLogic = new StaffLogic(staffRepo);

            var movieSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Read", () => Read("movie"))
                .Add("List", () => List("movie"))
                .Add("Create", () => Create("movie"))
                .Add("Delete", () => Delete("movie"))
                .Add("Update", () => Update("movie"))
                .Add("Exit", ConsoleMenu.Close);

            var rentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Read", () => Read("rent"))
                .Add("List", () => List("rent"))
                .Add("Create", () => Create("rent"))
                .Add("Delete", () => Delete("rent"))
                .Add("Update", () => Update("rent"))
                .Add("Exit", ConsoleMenu.Close);

            var renterSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Read", () => Read("renter"))
                .Add("List", () => List("renter"))
                .Add("Create", () => Create("renter"))
                .Add("Delete", () => Delete("renter"))
                .Add("Update", () => Update("renter"))
                .Add("Exit", ConsoleMenu.Close);

            var staffSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Read", () => Read("staff"))
                .Add("List", () => List("staff"))
                .Add("Create", () => Create("staff"))
                .Add("Delete", () => Delete("staff"))
                .Add("Update", () => Update("staff"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Movies", () => movieSubMenu.Show())
                .Add("Rents", () => rentSubMenu.Show())
                .Add("Renters", () => renterSubMenu.Show())
                .Add("Staffs", () => staffSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
