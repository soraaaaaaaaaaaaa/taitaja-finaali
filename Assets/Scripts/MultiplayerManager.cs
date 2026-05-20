using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class MultiplayerManager : MonoBehaviour
{
    [SerializeField] PlayerInputManager playerInputManager;
    public List<GameObject> players;
    public List<PlayerController> playerControllers;
    public float splitScreenDistance = 10f;
    public GameObject cam;
    private Vector3 cameraPositionSpeed;
    [SerializeField]
    private float smoothTime = 0.1f;
    Camera mainCamera;
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    public Bounds cameraZone;
    float width;
    float height;
    public static MultiplayerManager instance;
    public Timer timer;
    public GameObject pressToJoin;
    public GameObject startBounds;
    public GameObject winScreen;
    public GameObject loseScreen;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        mainCamera = Camera.main;
        height = mainCamera.orthographicSize;
        width = height * mainCamera.aspect;
        SetBounds(cameraZone);
    }
    public void SetBounds(Bounds bounds)
    {
        minY = bounds.min.y + height;
        minX = bounds.min.x + width;
        maxY = bounds.max.y - height;
        maxX = bounds.max.x - width;
    }
    void LateUpdate()
    {
        if (players.Count == 2)
        {
            var cameraTargetPosition = (players[0].transform.position + players[1].transform.position) * 0.5f; ;
            cameraTargetPosition = new Vector3(Mathf.Clamp(cameraTargetPosition.x, minX, maxX), Mathf.Clamp(cameraTargetPosition.y, minY, maxY), cameraTargetPosition.z);
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
                var cameraTargetPosition = players[0].transform.position;
                cameraTargetPosition = new Vector3(Mathf.Clamp(cameraTargetPosition.x, minX, maxX), Mathf.Clamp(cameraTargetPosition.y, minY, maxY), cameraTargetPosition.z);
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraTargetPosition, ref cameraPositionSpeed, smoothTime);
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
            if(players.Count == 0)
            {
                tempPlayer.animator = tempPlayer.bunnyAnimator;
                tempPlayer.bearSprite.SetActive(false);
            }
            else
            {
                tempPlayer.animator = tempPlayer.bearAnimator;
                tempPlayer.bunnySprite.SetActive(false);
            }
            playerControllers.Add(tempPlayer);
            players.Add(playerInput.gameObject);
        }
        if (players.Count == 2)
        {
            GameStart();
        }




    }
    public void GameStart()
    {
        startBounds.SetActive(false);
        pressToJoin.SetActive(false);
        timer.gameObject.SetActive(true);
    }
    public void GameLose()
    {
        players[0].SetActive(false);
        players[1].SetActive(false);
        timer.gameObject.SetActive(false);
        loseScreen.SetActive(true);
    }
    public void GameWin()
    {
        players[0].SetActive(false);
        players[1].SetActive(false);
        timer.gameObject.SetActive(false);
        winScreen.SetActive(true);
    }
    public void OnLeave()
    {
        Debug.Log("Player left");
    }
}
