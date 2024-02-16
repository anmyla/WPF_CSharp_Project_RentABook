using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentABook.Models
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int BookId { get; set; }
        private string _bookTitle;
        public string BookTitle
        {
            get { return _bookTitle; }
            set
            {
                if (_bookTitle != value)
                {
                    _bookTitle = value;
                    OnPropertyChanged(nameof(BookTitle));
                }
            }
        }

        private string _bookAuthor;
        public string BookAuthor
        {
            get { return _bookAuthor; }
            set
            {
                if (_bookAuthor != value)
                {
                    _bookAuthor = value;
                    OnPropertyChanged(nameof(BookAuthor));
                }
            }
        }

        private string _bookYear;
        public string BookYear
        {
            get { return _bookYear; }
            set
            {
                if (_bookYear != value)
                {
                    _bookYear = value;
                    OnPropertyChanged(nameof(BookYear));
                }
            }
        }

        private string _bookComment;
        public string BookComment
        {
            get { return _bookComment; }
            set
            {
                if (_bookComment != value)
                {
                    _bookComment = value;
                    OnPropertyChanged(nameof(BookComment));
                }
            }
        }

        private int _bookRating;
        public int BookRating
        {
            get { return _bookRating; }
            set
            {
                if (_bookRating != value)
                {
                    _bookRating = value;
                    OnPropertyChanged(nameof(BookRating));
                }
            }
        }

        private bool _isAvailable;
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                if (_isAvailable != value)
                {
                    _isAvailable = value;
                    OnPropertyChanged(nameof(IsAvailable));
                }
            }
        }

        private Genre _bookGenre;
        public Genre BookGenre
        {
            get { return _bookGenre; }
            set
            {
                if (_bookGenre != value)
                {
                    _bookGenre = value;
                    OnPropertyChanged(nameof(BookGenre));
                }
            }
        }

        private string _bookCover;
        public string BookCover
        {
            get { return _bookCover; }
            set
            {
                if (_bookCover != value)
                {
                    _bookCover = value;
                    OnPropertyChanged(nameof(BookCover));
                }
            }
        }

        private double _bookRentPrice;
        public double BookRentPrice
        {
            get { return _bookRentPrice; }
            set
            {
                if (_bookRentPrice != value)
                {
                    _bookRentPrice = value;
                    OnPropertyChanged(nameof(BookRentPrice));
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
