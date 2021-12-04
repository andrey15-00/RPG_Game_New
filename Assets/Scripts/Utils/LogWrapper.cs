using UnityEngine;

public static class LogWrapper
{
    public static void Log(string message)
    {
        Debug.Log(message);
    }

    public static void LogError(string message)
    {
        Debug.LogError(message);
    }
}