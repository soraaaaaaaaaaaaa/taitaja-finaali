using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoopInteractable : MonoBehaviour
{
    int requiredPlayers = 2;
    int currentPlayers;
    bool calledByPlayer1;
    bool calledByPlayer2;
    [SerializeField]
    protected UnityEvent onAbility;
    [SerializeField]
    float timer = 2f;
    [SerializeField, Range(0,2)]
    int zone;
    private void Start()
    {
        ZoneManager.AddTask(zone);
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentPlayers++;
            if (currentPlayers == requiredPlayers)
            {
                PlayerController.OnAbility += OnInteract;
            }
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentPlayers--;
            PlayerController.OnAbility -= OnInteract;
        }
    }
    public void OnInteract(int player)
    {
        if(player == 0)
        {
            calledByPlayer1 = true;
        }
        else if(player == 1)
        {
            calledByPlayer2 = true;
        }
        StartCoroutine(InteractTimer(player));
        if(calledByPlayer1 && calledByPlayer2)
        {
            onAbility.Invoke();
        }
    }
    public void PlaceHolderEvent()
    {
        Debug.Log("Co-op placeholder event");
        ZoneManager.TaskCompleted(zone);
        gameObject.SetActive(false);
    }
    IEnumerator InteractTimer(int i)
    {
        yield return new WaitForSeconds(timer);
        if(i == 0)
        {
            calledByPlayer1 = false;
        }
        else if (i==1)
        {
            calledByPlayer2 = false;
        }
    }
}
