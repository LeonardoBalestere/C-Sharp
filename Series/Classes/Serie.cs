using System;

namespace Series
{
    public class Serie : BaseEntity
    {
        private Genre Genre {get; set;}

        private string Title {get; set;}

        private string Description {get; set;}

        private int Year {get; set;}

        private bool IsDeteled {get; set;}

        public Serie(int id, Genre genre, string title, string description,int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.IsDeteled = false;
        }

        public override string ToString()
        {
            return "Genre: " + this.Genre + Environment.NewLine
            + "Title: " + this.Title + Environment.NewLine 
            + "Description: " + this.Description + Environment.NewLine
            + "Relase year: " + this.Year + Environment.NewLine
            + "Deleted: " +  this.IsDeteled + Environment.NewLine;
        }

        public int getId()
        {
            return this.Id;
        }

        public string getTitle()
        {
            return this.Title;
        }

        public bool getIsDeleted()
        {
            return this.IsDeteled;
        }

        public void Delete(){
            this.IsDeteled = true;
        }
    }
}