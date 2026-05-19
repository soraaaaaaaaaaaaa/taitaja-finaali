using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class MultiplayerManager : MonoBehaviour
{
    [SerializeField] PlayerInputManager playerInputManager;
    public List<GameObject> players;
    public float splitScreenDistance = 10f;
    public GameObject cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerInputManager.
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count == 2)
        {
            
            if (Vector2.Distance(players[0].transform.position, players[1].transform.position) > splitScreenDistance)
            {
                playerInputManager.splitScreen = true;
                cam.SetActive(false);
            }
            else
            {
                playerInputManager.splitScreen = false;
                cam.SetActive(true);
                cam.transform.position = (players[0].transform.position + players[1].transform.position) * 0.5f;
            }
        }
        else
        {
            if(players.Count == 1)
            {
                cam.transform.position = players[0].transform.position;
            }
            playerInputManager.splitScreen = false;
            cam.SetActive(true);
        }
        
    }
    public void OnJoin(PlayerInput playerInput)
    {
        Debug.Log("Player joined");
        var tempPlayer = playerInput.GetComponent<PlayerController>();
        if (tempPlayer != null)
        {
            tempPlayer.playerIndex = players.Count;
        }
        players.Add(playerInput.gameObject);
        
    }
    public void OnLeave()
    {
        Debug.Log("Player left");
    }
}
