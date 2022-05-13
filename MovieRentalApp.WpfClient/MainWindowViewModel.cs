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

        private Movie selectedMovie;

        private Rent selectedRent;

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

        public ICommand CreateMovieCommand { get; set; }

        public ICommand DeleteMovieCommand { get; set; }

        public ICommand UpdateMovieCommand { get; set; }

        public ICommand CreateRentCommand { get; set; }

        public ICommand DeleteRentCommand { get; set; }

        public ICommand UpdateRentCommand { get; set; }

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

                SelectedMovie = new Movie();
                SelectedRent = new Rent();
            }
        }
    }
}
