namespace Hospital.Areas.Doctor.Models
{
    public class FullCalendarEvent
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Url { get; set; } // Optional: Link to more details
                                        // Add more properties as needed
    }

}
