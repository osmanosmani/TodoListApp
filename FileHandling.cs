// Handles saving and reading task data from file
public class FileHandling
{
    // Name of the file (e.g., tasks.txt)
    public string FileName { get; set; }

    // Directory where the file will be stored
    public string DirectoryPath { get; set; }

    // Constructor to initialize file name and directory path
    public FileHandling(string fileName)
    {
        FileName = fileName;
        DirectoryPath = Directory.GetCurrentDirectory();
    }

    // Saves all tasks to file (each line represents one task)
    public void SaveToFile(List<string> lines)
    {
        string path = Path.Combine(DirectoryPath, FileName);

        // Overwrites the file with new data
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }

    // Reads all lines from file and returns them as a list of strings
    public List<string> ReadFromFile()
    {
        string path = Path.Combine(DirectoryPath, FileName);
        List<string> lines = new List<string>();

        // Only read if file exists
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
        }

        return lines;
    }
}