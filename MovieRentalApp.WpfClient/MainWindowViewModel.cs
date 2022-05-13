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

        private Movie selectedMovie;

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

        public ICommand CreateMovieCommand { get; set; }

        public ICommand DeleteMovieCommand { get; set; }

        public ICommand UpdateMovieCommand { get; set; }

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
                
                SelectedMovie = new Movie();
            }
        }
    }
}
