namespace BugTrackerAPI.Models
{
    // Represents a bug in the system
    public class Bug
    {
        // Unique identifier for each bug
        public int Id { get; set; }

        // Title of the bug
        public string Title { get; set; }

        // Detailed description of the bug
        public string Description { get; set; }

        // Priority level (e.g., Low, Medium, High)
        public string Priority { get; set; }

        // Current status of the bug (e.g., Open, In Progress, Resolved)
        public string Status { get; set; }

        // Date and time when the bug was created
        public DateTime CreatedAt { get; set; }
    }
}