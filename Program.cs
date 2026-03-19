// Create the main objects needed for the application
TaskManager manager = new TaskManager();
FileHandling fileHandling = new FileHandling("tasks.txt");
ConsoleUI ui = new ConsoleUI(manager, fileHandling);

// Start the application
ui.Run();