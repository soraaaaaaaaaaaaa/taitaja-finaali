using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerManager : MonoBehaviour
{
    [SerializeField] PlayerInputManager playerInputManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerInputManager.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnJoin()
    {
        Debug.Log("Player joined");
    }
    public void OnLeave()
    {
        Debug.Log("Player left");
    }
}
