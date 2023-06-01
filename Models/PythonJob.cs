using System.Diagnostics;
using System.Runtime.CompilerServices;
using Hangfire;

public class PythonJob
{
    // inject IConfiguration service in job class constructor and access it from the job method.
        
    private readonly IConfiguration _configuration;
    public PythonJob(IConfiguration configuration)
    {
        _configuration = configuration;
        string hangfire = _configuration.GetSection("Hangfire").Value;
    }

    public static void RunPythonScript()
    {           
        string pythonExePath = "path/to/python.exe";
        string scriptPath = "path/to/script.py";

        // Create a process to run the Python script
        Process process = new Process();
        process.StartInfo.FileName = pythonExePath;
        process.StartInfo.Arguments = scriptPath;
        process.Start();

        // Wait for the process to exit
        process.WaitForExit();

        // Get the exit code of the process
        int exitCode = process.ExitCode;

        // Process the exit code or perform any other necessary actions
        if (exitCode == 0)
        {
            // Success
            // ...
        }
        else
        {
            // Failure
            // ...
        }
    }
}