// Handles all operations related to task management
public class TaskManager
{
    // Internal list that stores all tasks in memory
    private List<Task> tasks = new List<Task>();

    // Adds a new task to the list
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    // Updates an existing task at a specific index
    public void EditTask(int index, Task updatedTask)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index] = updatedTask;
        }
    }

    // Removes a task from the list by index
    public void RemoveTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
        }
    }

    // Marks a specific task as completed
    public void MarkTaskDone(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].MarkAsDone();
        }
    }

    // Finds and returns a task by index
    public Task FindTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            return tasks[index];
        }

        return null;
    }

    // Returns all tasks
    public List<Task> GetTasks()
    {
        return tasks;
    }

    // Returns tasks sorted by due date
    public List<Task> SortByDate()
    {
        return tasks.OrderBy(t => t.DueDate).ToList();
    }

    // Returns tasks sorted by project name
    public List<Task> SortByProject()
    {
        return tasks.OrderBy(t => t.Project).ToList();
    }
}