using UnityEngine;
using UnityEngine.UI;

public class Taskbar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField, Range(0, 2)] int index;
    private void Start()
    {
        ZoneManager.taskbars[index] = this;
    }
    public void UpdateTaskbar(float percentage)
    {
        slider.value = percentage;
        Debug.Log(percentage * 100f);
    }
}
