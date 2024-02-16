using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RentABook.Models
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private RentABookDB contextDB = new RentABookDB();
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Book> ListOfBooks { get; set; }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (_selectedBook != value)
                {
                    _selectedBook = value;
                    OnPropertyChanged(nameof(SelectedBook));
                }
            }
        }

        private Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get => _selectedGenre;
            set
            {
                if (_selectedGenre == null || _selectedGenre.GenreName != value.GenreName)
                {
                    _selectedGenre = value;
                    OnPropertyChanged();
                    SearchBooksByGenre(value);
                    DisplayBooksByGenre(value);
                }
            }
        }

        public ObservableCollection<Genre> Genres { get; } = new ObservableCollection<Genre>();
        public ObservableCollection<Book> SearchResult { get; set; }
        public ObservableCollection<Book> SearchResultGenre { get; set; }
        public ObservableCollection<Book> DisplayBookCovers { get; set; }

        private int _rentalDays;
        public int RentalDays
        {
            get { return _rentalDays; }
            set
            {
                _rentalDays = value;
                OnPropertyChanged();
                CalculateTotalAmount();
            }
        }

        private decimal _totalAmount;
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                OnPropertyChanged();
            }
        }


        private string _keyword;
        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                SearchResult.Clear();
                foreach (var item in ListOfBooks)
                {
                    if (item.BookTitle.Contains(_keyword))
                    {
                        SearchResult.Add(item);
                    }
                }
            }
        }

        private Book _newBook;
        public Book NewBook
        {
            get { return _newBook; }
            set
            {
                _newBook = value;
                NotifyPropertyChanged("NewBook");
            }
        }

        public BookViewModel()
        {
            ListOfBooks = new ObservableCollection<Book>();

            SearchResult = new ObservableCollection<Book>();
            SearchResult.Clear();

            SearchResultGenre = new ObservableCollection<Book>();
            SearchResultGenre.Clear();

            var myBooksLocalFromDB = contextDB.Books.ToList();
            foreach (var book in myBooksLocalFromDB)
            {
                ListOfBooks.Add(book);
            }

            NewBook = new Book();
            ListBoxSelectionChangedCommand = new RelayCommand(ListBoxSelectionChanged);

            Genres = new ObservableCollection<Genre>
            {
            new Genre {GenreId= 3, GenreName = "Romance", GenreIconPath = "/Images/icons/romance.png" },
            new Genre {GenreId= 4, GenreName = "Adventure", GenreIconPath = "/Images/icons/adventure.png" },
            new Genre {GenreId= 2, GenreName = "Suspense", GenreIconPath = "/Images/icons/sus.png" },
            new Genre {GenreId= 5, GenreName = "Science Fiction", GenreIconPath = "/Images/icons/scifi.png" },
            new Genre {GenreId= 6, GenreName = "Horror", GenreIconPath = "/Images/icons/horror.png" },
            new Genre {GenreId= 7, GenreName = "Educational", GenreIconPath = "/Images/icons/educ.png" }
            };

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(SelectedGenre))
                {
                    SearchBooksByGenre(SelectedGenre);
                }
            };

            DisplayBookCovers = new ObservableCollection<Book>();
            DisplayBookCovers.Clear();

            DisplayBooksByGenre(null);

            LoadBooksFromDatabase();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int AddBook(Book newBook)
        {
            contextDB.Books.Add(newBook);
            ListOfBooks.Add(newBook);
            contextDB.SaveChanges();
            return newBook.BookId;
        }

        private void SearchBooksByGenre(Genre genre)
        {
            SearchResultGenre.Clear();
            if (genre != null)
            {
                foreach (var book in ListOfBooks)
                {
                    if (book.GenreName == genre.GenreName)
                    {
                        SearchResultGenre.Add(book);
                    }
                }
            }
        }

        private bool _isDuplicateConfirmed;

        public bool IsDuplicateConfirmed
        {
            get { return _isDeleteConfirmed; }
            set
            {
                if (_isDeleteConfirmed != value)
                {
                    _isDeleteConfirmed = value;
                    OnPropertyChanged(nameof(IsDeleteConfirmed));
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RetrieveBookDetails(int bookId)
        {
            SelectedBook = ListOfBooks.FirstOrDefault(b => b.BookId == bookId);
        }

        public void RemoveBook()
        {
            if (IsDeleteConfirmed && SelectedBook != null)
            {
                contextDB.Books.Remove(SelectedBook);
                ListOfBooks.Remove(SelectedBook);
                contextDB.SaveChanges();
            }
        }

        public void UpdateBook()
        {
            if (SelectedBook != null)
            {
                var bookToUpdate = contextDB.Books.Find(SelectedBook.BookId);
                if (bookToUpdate != null)
                {
                    bookToUpdate.BookTitle = SelectedBook.BookTitle;
                    bookToUpdate.BookAuthor = SelectedBook.BookAuthor;
                    bookToUpdate.BookYear = SelectedBook.BookYear;
                    bookToUpdate.BookComment = SelectedBook.BookComment;
                    bookToUpdate.BookRating = SelectedBook.BookRating;
                    bookToUpdate.IsAvailable = SelectedBook.IsAvailable;
                    bookToUpdate.BookGenre = SelectedBook.BookGenre;
                    bookToUpdate.BookCover = SelectedBook.BookCover;
                    bookToUpdate.BookRentPrice = SelectedBook.BookRentPrice;

                    contextDB.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Book not found in the database.");
                }
            }
            else
            {
                MessageBox.Show("Please select a book to update.");
            }
        }

        private bool _isDeleteConfirmed;

        public bool IsDeleteConfirmed
        {
            get { return _isDeleteConfirmed; }
            set
            {
                if (_isDeleteConfirmed != value)
                {
                    _isDeleteConfirmed = value;
                    OnPropertyChanged(nameof(IsDeleteConfirmed));
                }
            }
        }

        public void DuplicateBook()
        {
            if (IsDuplicateConfirmed && SelectedBook != null)
            {

                Book duplicateBook = new Book
                {
                    BookTitle = SelectedBook.BookTitle,
                    BookAuthor = SelectedBook.BookAuthor,
                    BookYear = SelectedBook.BookYear,
                    BookGenre = SelectedBook.BookGenre,
                    BookRating = SelectedBook.BookRating,
                    BookRentPrice = SelectedBook.BookRentPrice,
                    BookCover = SelectedBook.BookCover,
                    BookComment = SelectedBook.BookComment,
                    IsAvailable = SelectedBook.IsAvailable,
                    GenreName = SelectedBook.GenreName
                };

                contextDB.Books.Add(duplicateBook);
                ListOfBooks.Add(duplicateBook);
                contextDB.SaveChanges();
                MessageBox.Show("Book duplicated successfully.");
            }
        }
        public ICommand ListBoxSelectionChangedCommand { get; }

        private void ListBoxSelectionChanged(object obj)
        {
            SelectedBook = obj as Book;
        }

        private Book _selectedSearchResult;
        public Book SelectedSearchResult
        {
            get => _selectedSearchResult;
            set
            {
                if (_selectedSearchResult != value)
                {
                    _selectedSearchResult = value;
                    OnPropertyChanged(nameof(SelectedSearchResult));
                    SelectedBook = value;
                }
            }
        }
        public void SearchBooks(string keyword)
        {
            SearchResult.Clear();
            string lowerKeyword = keyword.ToLower();

            foreach (var book in ListOfBooks)
            {
                string lowerTitle = book.BookTitle.ToLower();

                if (lowerTitle.Contains(lowerKeyword) || book.BookId.ToString().EndsWith(lowerKeyword))
                {
                    SearchResult.Add(book);
                }
            }

            if (SearchResult.Count <= 0)
            {
                MessageBox.Show("No results for this keyword!");
            }
        }


        private void DisplayBooksByGenre(Genre genre)
        {
            DisplayBookCovers.Clear();
            if (genre == null)
            {
                foreach (var book in ListOfBooks)
                {
                    DisplayBookCovers.Add(book);
                }
                return;
            }
            else
            {

                foreach (var book in ListOfBooks)
                {
                    if (book.GenreName == genre.GenreName)
                    {
                        DisplayBookCovers.Add(book);
                    }
                }
            }
        }
        private void LoadBooksFromDatabase()
        {
            var myBooksLocalFromDB = contextDB.Books.ToList();
            foreach (var book in myBooksLocalFromDB)
            {
                ListOfBooks.Add(book);
            }
        }

        public void RentOutBook()
        {
            if (SelectedSearchResult != null && SelectedSearchResult.IsAvailable)
            {
                SelectedSearchResult.IsAvailable = false;
                contextDB.SaveChanges();
                MessageBox.Show("Book rented out successfully!");
            }
            else
            {
                MessageBox.Show("Selected book is not available for rent.");
            }
        }

        private void CalculateTotalAmount()
        {
            if (SelectedSearchResult != null)
            {
                TotalAmount = (decimal)(SelectedSearchResult.BookRentPrice * RentalDays);
            }
        }
    }
}
