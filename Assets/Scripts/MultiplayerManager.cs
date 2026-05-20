using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class MultiplayerManager : MonoBehaviour
{
    [SerializeField] PlayerInputManager playerInputManager;
    public List<GameObject> players;
    public float splitScreenDistance = 10f;
    public GameObject cam;
    private Vector3 cameraPositionSpeed;
    [SerializeField]
    private float smoothTime = 0.1f;
    Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }
    void LateUpdate()
    {
        if (players.Count == 2)
        {
            var cameraTargetPosition = (players[0].transform.position + players[1].transform.position) * 0.5f; ;
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraTargetPosition, ref cameraPositionSpeed, smoothTime);
            //cam.transform.position = (players[0].transform.position + players[1].transform.position) * 0.5f;
            if (Vector2.Distance(players[0].transform.position, players[1].transform.position) > splitScreenDistance)
            {
                playerInputManager.splitScreen = true;
                mainCamera.enabled = false;
            }
            else
            {
                playerInputManager.splitScreen = false;
                mainCamera.enabled = true;
            }
        }
        else
        {
            if(players.Count == 1)
            {
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, players[0].transform.position, ref cameraPositionSpeed, smoothTime);
                //cam.transform.position = players[0].transform.position;
            }
            playerInputManager.splitScreen = false;
            mainCamera.enabled = true;
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
