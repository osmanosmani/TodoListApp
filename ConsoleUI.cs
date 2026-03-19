// Handles all user interaction in the console
public class ConsoleUI
{
    private TaskManager manager;
    private FileHandling fileHandling;

    // Constructor to connect ConsoleUI with TaskManager and FileHandling
    public ConsoleUI(TaskManager manager, FileHandling fileHandling)
    {
        this.manager = manager;
        this.fileHandling = fileHandling;
    }

    // Starts the application menu loop
    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowTasks(manager.GetTasks());
                    break;

                case "2":
                    ShowTasks(manager.SortByDate());
                    break;

                case "3":
                    ShowTasks(manager.SortByProject());
                    break;

                case "4":
                    AddTaskFlow();
                    break;

                case "5":
                    EditTaskFlow();
                    break;

                case "6":
                    MarkTaskDoneFlow();
                    break;

                case "7":
                    RemoveTaskFlow();
                    break;

                case "8":
                    SaveAndQuit();
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Displays the main menu
    public void ShowMenu()
    {
        Console.WriteLine("===== TODO LIST MENU =====");
        Console.WriteLine("1. Show all tasks");
        Console.WriteLine("2. Show tasks sorted by date");
        Console.WriteLine("3. Show tasks sorted by project");
        Console.WriteLine("4. Add task");
        Console.WriteLine("5. Edit task");
        Console.WriteLine("6. Mark task as done");
        Console.WriteLine("7. Remove task");
        Console.WriteLine("8. Save and quit");
        Console.Write("Choose an option: ");
    }

    // Adds a new task based on user input
    public void AddTaskFlow()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine();

        Console.Write("Enter due date (yyyy-MM-dd): ");
        string dueDate = Console.ReadLine();

        Console.Write("Enter project name: ");
        string project = Console.ReadLine();

        Task task = new Task
        {
            Title = title,
            DueDate = dueDate,
            Project = project,
            IsDone = false
        };

        manager.AddTask(task);
        Console.WriteLine("Task added successfully.");
    }

    // Edits an existing task
    public void EditTaskFlow()
    {
        ShowTasks(manager.GetTasks());

        Console.Write("Enter task index to edit: ");
        int index = int.Parse(Console.ReadLine());

        Task existingTask = manager.FindTask(index);

        if (existingTask != null)
        {
            Console.Write("Enter new title: ");
            string title = Console.ReadLine();

            Console.Write("Enter new due date (yyyy-MM-dd): ");
            string dueDate = Console.ReadLine();

            Console.Write("Enter new project name: ");
            string project = Console.ReadLine();

            Task updatedTask = new Task
            {
                Title = title,
                DueDate = dueDate,
                Project = project,
                IsDone = existingTask.IsDone
            };

            manager.EditTask(index, updatedTask);
            Console.WriteLine("Task updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }

    // Marks a task as completed
    public void MarkTaskDoneFlow()
    {
        ShowTasks(manager.GetTasks());

        Console.Write("Enter task index to mark as done: ");
        int index = int.Parse(Console.ReadLine());

        manager.MarkTaskDone(index);
        Console.WriteLine("Task marked as done.");
    }

    // Removes a task from the list
    public void RemoveTaskFlow()
    {
        ShowTasks(manager.GetTasks());

        Console.Write("Enter task index to remove: ");
        int index = int.Parse(Console.ReadLine());

        manager.RemoveTask(index);
        Console.WriteLine("Task removed successfully.");
    }

    // Displays tasks in a readable format
    public void ShowTasks(List<Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        Console.WriteLine("===== TASK LIST =====");

        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsDone ? "Done" : "Pending";
            Console.WriteLine($"{i}. {tasks[i].Title} | {tasks[i].DueDate} | {tasks[i].Project} | {status}");
        }
    }

    // Saves all tasks to file and exits
    public void SaveAndQuit()
    {
        List<string> lines = new List<string>();

        foreach (Task task in manager.GetTasks())
        {
            lines.Add(task.ToFileString());
        }

        fileHandling.SaveToFile(lines);
        Console.WriteLine("Tasks saved successfully. Goodbye!");
    }
}