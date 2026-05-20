using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        //Debug.Log(value);
        rb.linearVelocity = value.normalized * speed;
        if(value.normalized.x < 0f)
        {
            sprite.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            sprite.localScale = new Vector3(1f, 1f, 1f);
        }
        if(value != Vector2.zero)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        animator.SetFloat("speedY", value.normalized.y);
        animator.SetFloat("speedX", speed * 0.8f);
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            Debug.Log("interact");
            OnAbility?.Invoke(playerIndex);
        }
        
    }
}
