using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    // storing tasks in an array for easy managing
    public static int[] zoneTasks = new int[3];
    public static int[] zoneTasksCompleted = new int[3];
    public static Taskbar[] taskbars = new Taskbar[3];
    public static SpecialTaskbar globalTaskBar;
    public static int allTasks;
    public static int allTasksCompleted;
    public static void AddTask(int i)
    {
        zoneTasks[i]++;
        taskbars[i].UpdateTaskbar((float)zoneTasksCompleted[i] / zoneTasks[i]);
        allTasks++;
        globalTaskBar.UpdateTaskbar((float)allTasksCompleted / allTasks);
    }
    public static void TaskCompleted(int i)
    {
        zoneTasksCompleted[i]++;
        allTasksCompleted++;
        taskbars[i].UpdateTaskbar((float)zoneTasksCompleted[i] / zoneTasks[i]);
        globalTaskBar.UpdateTaskbar((float)allTasksCompleted / allTasks);
    }
    public static void TaskUndone(int i)
    {
        zoneTasksCompleted[i]--;
        allTasksCompleted--;
        taskbars[i].UpdateTaskbar((float)zoneTasksCompleted[i] / zoneTasks[i]);
        globalTaskBar.UpdateTaskbar((float)allTasksCompleted / allTasks);
    }
}
