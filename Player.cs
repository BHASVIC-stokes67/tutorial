using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private bool isTouchingGround = true;

    private float movementX;

    private Rigidbody2D body;
    private SpriteRenderer SR;
    private Animator anim;

    private string walkAnim = "Walk";
    private string groundTag = "Ground";
    private string enemyTag = "Enemy";

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        AnimatePlayer();
    }

    void Move()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            isTouchingGround = false;
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isTouchingGround = true;
        }
        if(collision.gameObject.CompareTag(enemyTag))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Destroy(gameObject);
        }
    }

    void AnimatePlayer()
    {
        if (movementX > 0f) //right
        {
            anim.SetBool(walkAnim, true);
            SR.flipX = false;
        }
        else if (movementX < 0f) //left
        {
            anim.SetBool(walkAnim, true);
            SR.flipX = true;
        }
        else
        {
            anim.SetBool(walkAnim, false);
        }
    }
}
