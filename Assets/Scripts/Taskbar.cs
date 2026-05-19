using UnityEngine;

public class Taskbar : MonoBehaviour
{
    private void Start()
    {
        ZoneManager.taskbars.Add(this);
    }
    public void UpdateTaskbar(float percentage)
    {
        Debug.Log(percentage * 100f);
    }
}
