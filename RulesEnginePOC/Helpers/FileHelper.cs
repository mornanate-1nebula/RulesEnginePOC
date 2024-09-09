using System.Text.Json;

namespace RulesEnginePOC.Helpers;

public static class FileHelper
{

    public static void WriteFile<TContent>(string[] filePaths, TContent content)
    {
        var path = string.Join("/", filePaths);

        try
        {
            var stringyContent = JsonSerializer.Serialize(content);
            File.WriteAllText(path, stringyContent);
        }
        catch (IOException ex)
        {
            throw new IOException($"An error occurred while writing to the file '{path}': {ex.Message}", ex);
        }
    }
    
    public static string ReadFile(string[] filePaths)
    {
        var path = string.Join("/", filePaths);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"The file was not found in the file path '{path}'");
        }

        try
        {
            return File.ReadAllText(path);
        }
        catch (IOException ex)
        {
            throw new IOException($"An error occurred while reading the file '{path}': {ex.Message}", ex);
        }
    }
    
    public static TDataType ReadFileIntoType<TDataType>(string[] filePaths) where TDataType : class
    {
        var rawWorkFlow = ReadFile(filePaths);
        var result = JsonSerializer.Deserialize<TDataType>(rawWorkFlow);

        if (result == null)
        {
            throw new Exception($"Failed to parse to type");
        }

        return result;
    }
    
    public static TDataType[] ReadFilesIntoType<TDataType>(string[] folderPath) where TDataType : class, new()
    {
        List<TDataType> response = new();
        
        var path = string.Join("\\", folderPath);
        string[] filePaths = Directory.GetFiles(path);

        foreach (var filePath in filePaths)
        {
            var rawWorkFlow = ReadFile(new []{ filePath });
            var result = JsonSerializer.Deserialize<TDataType[]>(rawWorkFlow);

            if (result == null)
            {
                throw new Exception($"Failed to parse to type");
            }
            
            response.AddRange(result);
        }
        
        return response.ToArray();
    }
    
}