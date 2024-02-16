using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;

namespace RentABook.Models
{
    public class GenreViewModel : INotifyPropertyChanged
    {
        private RentABookDB contextDB = new RentABookDB();
        private ObservableCollection<Genre> _listOfGenres;
        internal Genre newGenre;

        public ObservableCollection<Genre> ListOfGenres
        {
            get { return _listOfGenres; }
            set
            {
                _listOfGenres = value;
                OnPropertyChanged();
            }
        }

        public GenreViewModel()
        {
            // Initialize the list of genres
            ListOfGenres = new ObservableCollection<Genre>
            {
            new Genre { GenreName = "Romance", GenreIconPath = "/Images/icons/romance.png" },
            new Genre { GenreName = "Adventure", GenreIconPath = "/Images/icons/adventure.png" },
            new Genre { GenreName = "Suspense", GenreIconPath = "/Images/icons/sus.png" },
            new Genre { GenreName = "Science Fiction", GenreIconPath = "/Images/icons/scifi.png" },
            new Genre { GenreName = "Horror", GenreIconPath = "/Images/icons/horror.png" },
            new Genre { GenreName = "Educational", GenreIconPath = "/Images/icons/educ.png" }
            };
        }



        public void AddGenre(Genre newGenre)
        {
            ListOfGenres.Add(newGenre);
            contextDB.Genres.Add(newGenre); // Add the new genre to the DbContext
            contextDB.SaveChanges(); // Save changes to the database
        }

        public void DeleteGenre(Genre genreToDelete)
        {
            ListOfGenres.Remove(genreToDelete);
            contextDB.Genres.Remove(genreToDelete); // Remove the genre from the DbContext
            contextDB.SaveChanges(); // Save changes to the database
        }

        public void AddBookToGenre(int id, Book newBook)
        {
            var genre = ListOfGenres.FirstOrDefault(g => g.GenreId == id);
            if (genre != null)
            {
                genre.GenreBookList.Add(newBook);
                contextDB.SaveChanges(); // Save changes to the database
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
