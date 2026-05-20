using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    int forPlayer;
    [SerializeField]
    protected UnityEvent onAbility;
    [SerializeField, Range(0, 2)]
    int zone;
    public GameObject canInteractSprite;
    private void Start()
    {
        ZoneManager.AddTask(zone);
    }
    protected void OnDisable()
    {
        PlayerController.OnAbility -= OnInteract;
        canInteractSprite.SetActive(false);
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            var playerController = collision.GetComponent<PlayerController>();
            if(playerController.playerIndex == forPlayer)
            {
                PlayerController.OnAbility += OnInteract;
                canInteractSprite.SetActive(true);
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
                canInteractSprite.SetActive(false);
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
        ZoneManager.TaskCompleted(zone);
        gameObject.SetActive(false);

    }
}
