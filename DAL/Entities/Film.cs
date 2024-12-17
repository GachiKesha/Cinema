namespace Films.DAL.Entities
{
    public class Film
    {
        public int FilmID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
