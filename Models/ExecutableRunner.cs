using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jobscheduler.Models
{
    public class ExecutableRunner
    {
        public static void RunExecutable(string executablePath)
        {
            try
            {
                // Create a new process instance
                Process process = new Process();

                // Specify the executable file path
                process.StartInfo.FileName = executablePath;

                // Optionally, you can set other properties of the process
                // For example:
                // process.StartInfo.Arguments = "arg1 arg2"; // Set command-line arguments
                // process.StartInfo.WorkingDirectory = "C:\\path\\to\\working\\directory"; // Set the working directory

                // Start the process
                process.Start();

                // Wait for the process to exit
                process.WaitForExit();

                // Get the exit code of the process
                int exitCode = process.ExitCode;

                // Process the exit code as needed
                Console.WriteLine("Exit Code: " + exitCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
