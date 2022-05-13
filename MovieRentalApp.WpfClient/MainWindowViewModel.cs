using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MovieRentalApp.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace MovieRentalApp.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Movie> Movies { get; set; }

        public RestCollection<Rent> Rents { get; set; }

        public RestCollection<Renter> Renters { get; set; }

        private Movie selectedMovie;

        private Rent selectedRent;

        private Renter selectedRenter;

        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                if (value != null)
                {
                    selectedMovie = new Movie()
                    {
                        MovieId = value.MovieId,
                        Title = value.Title,
                        Distributor = value.Distributor,
                        Category = value.Category,
                        Length = value.Length,
                        Language = value.Language,
                        RentId = value.RentId
                    };
                    OnPropertyChanged();
                    (DeleteMovieCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Rent SelectedRent
        {
            get { return selectedRent; }
            set
            {
                if (value != null)
                {
                    selectedRent = new Rent()
                    {
                        RentId = value.RentId,
                        Order = value.Order,
                        Price = value.Price,
                        RentalStart = value.RentalStart,
                        RentalEnd = value.RentalEnd,
                        OverrunFee = value.OverrunFee
                    };
                    OnPropertyChanged();
                    (DeleteRentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Renter SelectedRenter
        {
            get { return selectedRenter; }
            set
            {
                if (value != null)
                {
                    selectedRenter = new Renter()
                    {
                        RenterId = value.RenterId,
                        Name = value.Name,
                        Postcode = value.Postcode,
                        City = value.City,
                        Street = value.Street,
                        HouseNumber = value.HouseNumber,
                        MembershipStart = value.MembershipStart,
                        MembershipEnd = value.MembershipEnd,
                        RentId = value.RentId
                    };
                    OnPropertyChanged();
                    (DeleteRenterCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateMovieCommand { get; set; }

        public ICommand DeleteMovieCommand { get; set; }

        public ICommand UpdateMovieCommand { get; set; }

        public ICommand CreateRentCommand { get; set; }

        public ICommand DeleteRentCommand { get; set; }

        public ICommand UpdateRentCommand { get; set; }

        public ICommand CreateRenterCommand { get; set; }

        public ICommand DeleteRenterCommand { get; set; }

        public ICommand UpdateRenterCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Movies = new RestCollection<Movie>("http://localhost:12229/", "movie", "hub");
                Rents = new RestCollection<Rent>("http://localhost:12229/", "rent", "hub");
                Renters = new RestCollection<Renter>("http://localhost:12229/", "renter", "hub");

                CreateMovieCommand = new RelayCommand(() =>
                {
                    Movies.Add(new Movie()
                    {
                        Title = SelectedMovie.Title,
                        Category = SelectedMovie.Category,
                        Length = SelectedMovie.Length,
                        RentId = SelectedMovie.RentId
                    });
                });

                UpdateMovieCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Movies.Update(SelectedMovie);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteMovieCommand = new RelayCommand(() =>
                {
                    Movies.Delete(SelectedMovie.MovieId);
                },
                () =>
                {
                    return SelectedMovie != null;
                });

                CreateRentCommand = new RelayCommand(() =>
                {
                    Rents.Add(new Rent()
                    {
                        Order = SelectedRent.Order,
                        Price = SelectedRent.Price,
                        OverrunFee = SelectedRent.OverrunFee
                    });
                });

                UpdateRentCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Rents.Update(SelectedRent);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteRentCommand = new RelayCommand(() =>
                {
                    Rents.Delete(SelectedRent.RentId);
                },
                () =>
                {
                    return SelectedRent != null;
                });

                CreateRenterCommand = new RelayCommand(() =>
                {
                    Renters.Add(new Renter()
                    {
                        Name = SelectedRenter.Name,
                        City = SelectedRenter.City,
                        Postcode = SelectedRenter.Postcode,
                        RentId = SelectedRenter.RentId
                    });
                });

                UpdateRenterCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Renters.Update(SelectedRenter);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteRenterCommand = new RelayCommand(() =>
                {
                    Renters.Delete(SelectedRenter.RenterId);
                },
                () =>
                {
                    return SelectedRenter != null;
                });

                SelectedMovie = new Movie();
                SelectedRent = new Rent();
                SelectedRenter = new Renter();
            }
        }
    }
}
