using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    public int playerIndex;
    public static event Action<int> OnAbility;
    public Animator animator;
    public Animator bearAnimator;
    public Animator bunnyAnimator;
    public Transform sprite;
    public GameObject bunnySprite;
    public GameObject bearSprite;
    public bool freeze;
    public Vector2 movementValue;
    public AudioSource audioSource;
    public AudioClip water;
    public AudioClip plant;
    public AudioClip plantRemove;
    public AudioClip trash;
    public AudioClip jingle;
    public AudioClip saw;
    public AudioClip crafting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!freeze)
        {
            rb.linearVelocity = movementValue.normalized * speed;
            if (movementValue.normalized.x < 0f)
            {
                sprite.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                sprite.localScale = new Vector3(1f, 1f, 1f);
            }
            if (movementValue != Vector2.zero)
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("walking", false);
            }
            animator.SetFloat("speedY", movementValue.normalized.y);
            animator.SetFloat("speedX", speed * 0.8f);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!freeze)
        {
            var value = context.ReadValue<Vector2>();
            movementValue = value;
            //Debug.Log(value);
            
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(!freeze){
            if (context.started)
            {
                Debug.Log("interact");
                OnAbility?.Invoke(playerIndex);
            }
        }
        
    }
}
