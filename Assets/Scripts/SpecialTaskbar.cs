using System;
using UnityEngine;

public class SpecialTaskbar : MonoBehaviour
{
    RectTransform rect;
    float width;
    public Timer timer;
    private void Awake()
    {
        ZoneManager.globalTaskBar = this;
        rect = GetComponent<RectTransform>();
        width = Mathf.Abs(transform.localPosition.x);
    }
    public void UpdateTaskbar(float percentage)
    {
        transform.localPosition = new Vector2((percentage * width) - width, transform.localPosition.y);
        if (percentage >= 1f)
        {
            ZoneComplete();
        }
        Debug.Log((percentage * 810f) - 810f);
        Debug.Log(transform.localPosition);
    }
    void ZoneComplete()
    {
        Debug.Log("zone complete");
        timer.gameObject.SetActive(false);
        MultiplayerManager.instance.GameWin();
    }
}
