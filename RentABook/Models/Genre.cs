using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RentABook.Models
{
    public class Genre : INotifyPropertyChanged

    {
        public int GenreId { get; set; }
        private string _genreName;
        public string GenreName
        {
            get { return _genreName; }
            set
            {
                if (_genreName != value)
                {
                    _genreName = value;
                    OnPropertyChanged(nameof(GenreName));
                }
            }
        }

        private string _genreIconPath;
        public string GenreIconPath
        {
            get { return _genreIconPath; }
            set
            {
                if (_genreIconPath != value)
                {
                    _genreIconPath = value;
                    OnPropertyChanged(nameof(GenreIconPath));
                }
            }
        }

        private List<Book> _genreBookList;
        public List<Book> GenreBookList
        {
            get { return _genreBookList; }
            set
            {
                if (_genreBookList != value)
                {
                    _genreBookList = value;
                    OnPropertyChanged(nameof(GenreBookList));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
