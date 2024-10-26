namespace ArtJamWebApp.Models
{
    public class HomeViewModel
    {
        // Информация за групите
        public List<int> GroupIds { get; set; }
        public List<string> GroupNames { get; set; }

        // Информация за музикантите
        public List<int> MusicianIds { get; set; }
        public List<string> MusicianUsernames { get; set; }

        // Информация за събитията
        public List<int> EventIds { get; set; }
        public List<string> EventNames { get; set; }
        public List<DateTime> EventDates { get; set; }

        // Търсене
        public string SearchQuery { get; set; }
    }
}
