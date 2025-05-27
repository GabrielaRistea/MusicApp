    namespace Music_App.DTOs
    {
        public class GenreDto
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public ICollection<SongDTO> Songs { get; set; }
            public ICollection<string> SongTitle { get; set; }

    }
    }
