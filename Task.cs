// Represents a single task in the todo list
public class Task
{
    // Task title (short description)
    public string Title { get; set; }

    // Due date in format yyyy-MM-dd
    public string DueDate { get; set; }

    // Project name this task belongs to
    public string Project { get; set; }

    // Indicates whether the task is completed
    public bool IsDone { get; set; }

    // Marks the task as completed
    public void MarkAsDone()
    {
        IsDone = true;
    }

    // Converts the task into a string format for saving to file
    // Format: Title|DueDate|IsDone|Project
    public string ToFileString()
    {
        return $"{Title}|{DueDate}|{IsDone}|{Project}";
    }
}