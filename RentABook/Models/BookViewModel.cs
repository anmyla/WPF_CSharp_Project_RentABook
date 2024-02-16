﻿using System;
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
        public string StatusText1 { get; set; }
        public string StatusText2 { get; set; }
 
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
                if (_selectedGenre != value)
                {
                    _selectedGenre = value;
                    OnPropertyChanged();
                }
            }
        }



        public ObservableCollection<Book> SearchResult { get; set; }

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
            var myBooksLocalFromDB = contextDB.Books.ToList();
            foreach (var book in myBooksLocalFromDB)
            {
                ListOfBooks.Add(book);
            }

            SearchResult = new ObservableCollection<Book>();
            ChangeStatustxt();

            NewBook = new Book();
            ListBoxSelectionChangedCommand = new RelayCommand(ListBoxSelectionChanged);
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
            ChangeStatustxt();
            return newBook.BookId;
        }

        private void ChangeStatustxt()
        {
            StatusText1 = "There are " + contextDB.Books.ToList().Count.ToString() + " in the database";
            NotifyPropertyChanged("StatusText1");
        }

        public ObservableCollection<Genre> Genres { get; } = new ObservableCollection<Genre>
        {
            new Genre { GenreName = "Romance", GenreIconPath = "/Images/icons/romance.png" },
            new Genre { GenreName = "Adventure", GenreIconPath = "/Images/icons/adventure.png" },
            new Genre { GenreName = "Suspense", GenreIconPath = "/Images/icons/sus.png" },
            new Genre { GenreName = "Science Fiction", GenreIconPath = "/Images/icons/scifi.png" },
            new Genre { GenreName = "Horror", GenreIconPath = "/Images/icons/horror.png" },
            new Genre { GenreName = "Educational", GenreIconPath = "/Images/icons/educ.png" }
        };
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
                    // Handle case when the book is not found in the database
                    MessageBox.Show("Book not found in the database.");
                }
            }
            else
            {
                // Handle case when no book is selected
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


    }
}
