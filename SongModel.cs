using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win_forms
{
    class SongModel
    {
        private static int last_id = 0;

        public int _id;
        public string _title, _author, _genre;
        public int _rec_year;

        public SongModel(string title, string author, string genre, int year)
        {
            _id = ++last_id;
            _title = title;
            _author = author;
            _genre = genre;
            _rec_year = year;
        }
        
        public int Id { get { return _id; } }

        public string Title { get { return _title; } set { _title = value; } }
        public string Author { get { return _author; } set { _author = value; } }
        public string Genre { get { return _genre; } set { _genre = value; } }

        public int Year { get { return _rec_year; } set { _rec_year = value; } }
    }
}
