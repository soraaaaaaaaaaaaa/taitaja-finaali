using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    int forPlayer;
    [SerializeField]
    protected UnityEvent onAbility;
    protected void OnDisable()
    {
        PlayerController.OnAbility -= OnInteract;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            var playerController = collision.GetComponent<PlayerController>();
            if(playerController.playerIndex == forPlayer)
            {
                PlayerController.OnAbility += OnInteract;
            }
            
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var playerController = collision.GetComponent<PlayerController>();
            if (playerController.playerIndex == forPlayer)
            {
                PlayerController.OnAbility -= OnInteract;
            }
        }
    }
    public void OnInteract(int player)
    {
        if (forPlayer == player)
        {
            onAbility.Invoke();
        }
    }
    public void PlaceHolderEvent()
    {
        Debug.Log("Placeholder event");
    }
}
