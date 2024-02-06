using System;

public class Logger
{
    private static Logger instance;
  //  private static readonly object lockObject = new object();

    private Logger()
    {
    }

    public static Logger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Logger();
                /*   lock (lockObject)
                   {
                       if (instance == null)
                       {
                           instance = new Logger();
                       }
                   }*/
            }
            return instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}

class Program
{
    static void Main()
    {
        Logger logger = Logger.Instance;
        Logger logger1 = Logger.Instance;

        logger.Log("Logger Entry point 1");
        logger.Log("Logger Entry point 2");
 

        // Using the same logger instance throughout the application
    }
}

