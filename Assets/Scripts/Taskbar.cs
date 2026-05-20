using UnityEngine;
using UnityEngine.UI;

public class Taskbar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField, Range(0, 2)] int index;
    public GameObject healing;
    public GameObject complete;
    float halfCompleted = 0.33f;
    public Timer timer;
    public float extraTime = 120f;
    private void Awake()
    {
        ZoneManager.taskbars[index] = this;
    }
    public void UpdateTaskbar(float percentage)
    {
        slider.value = percentage;
        if(percentage >= 1f)
        {
            ZoneComplete();
        }
        else if(percentage >= halfCompleted)
        {
            healing.SetActive(true);
        }
        Debug.Log(percentage * 100f);
    }
    void ZoneComplete()
    {
        complete.SetActive(true);
        timer.timer += extraTime;
        Debug.Log("zone complete");
    }
}
