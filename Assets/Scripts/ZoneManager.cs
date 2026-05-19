using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    // storing tasks in an array for easy managing
    public static int[] zoneTasks = new int[3];
    public static int[] zoneTasksCompleted = new int[3];
    public static List<Taskbar> taskbars;
    public static void AddTask(int i)
    {
        zoneTasks[i]++;
        taskbars[i].UpdateTaskbar((float)zoneTasksCompleted[i] / zoneTasks[i]);
        Debug.Log((float)zoneTasksCompleted[i]/zoneTasks[i] * 100);
    }
    public static void TaskCompleted(int i)
    {
        zoneTasksCompleted[i]++;
        //Debug.Log((float)zoneTasksCompleted[i] / zoneTasks[i] * 100);
    }
    public static void TaskUndone(int i)
    {
        zoneTasksCompleted[i]--;
        Debug.Log((float)zoneTasksCompleted[i] / zoneTasks[i] * 100);
    }
}
