using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SpecialTaskbar : MonoBehaviour
{
    private void Awake()
    {
        ZoneManager.globalTaskBar = this;
    }
    public void UpdateTaskbar(float percentage)
    {
        transform.position = new Vector2(percentage * 810f - 810, transform.position.y);
        if (percentage >= 1f)
        {
            ZoneComplete();
        }
        Debug.Log(percentage * 100f);
    }
    void ZoneComplete()
    {
        Debug.Log("zone complete");
    }
}
