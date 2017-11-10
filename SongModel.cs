using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win_forms
{
    public struct change
    {
        public bool author, title, year, genre;
        public change(bool val)
        {
            title = author = year = genre = val;
        }
    }

    [Serializable]
    public class SongModel
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

        public static change Diff(SongModel s1, SongModel s2)
        {
            change mask;
            mask.title = !(s1.Title.Equals(s2.Title));
            mask.author = !(s1.Author.Equals(s2.Author));
            mask.genre = !(s1.Genre.Equals(s2.Genre));
            mask.year = !(s1.Year.Equals(s2.Year));
            return mask;
        }

        public static void SmartUpdate(SongModel dest, SongModel src, change mask)
        {
            if (mask.title)
                dest.Title = src.Title;
            if (mask.author)
                dest.Author = src.Author;
            if (mask.genre)
                dest.Genre = src.Genre;
            if (mask.year)
                dest.Year = src.Year;
        }
    }

    

}
