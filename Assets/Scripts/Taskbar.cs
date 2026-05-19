using UnityEngine;
using UnityEngine.UI;

public class Taskbar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField, Range(0, 2)] int index;
    float halfCompleted = 0.33f;
    private void Start()
    {
        ZoneManager.taskbars[index] = this;
    }
    public void UpdateTaskbar(float percentage)
    {
        slider.value = percentage;
        if(percentage >= 1f)
        {

        }
        Debug.Log(percentage * 100f);
    }
}
