using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    public float timeLimit;
    public TMP_Text timerText;
    void Awake()
    {

        timerText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (timer < 0f)
        {
            MultiplayerManager.instance.GameLose();
        }
    }
}
