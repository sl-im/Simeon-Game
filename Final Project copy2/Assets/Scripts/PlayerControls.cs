using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerControls : MonoBehaviour
{
    public LayerMask groundLayer;
    public float groundCheckDist = 1.0f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float gravityScale = 3f;
    
    public CharacterController controller; 
    public float speed = 5f;
    public float rotationSpeed = 5f;
    private Vector3 moveDirections = Vector3.zero;
   
    public Rigidbody rb;

    public int health;

    private EnemyFollow enemy;

    private bool isGrounded = true;
    
    private Vector3 velocity;

    // Start is called before the first frame update
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        enemy = FindObjectOfType<EnemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = transform.TransformDirection(movement);

        controller.Move(movement * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isGrounded = false;
            Jump();
        }

        ApplyGravity();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity * gravityScale);
    }

    void ApplyGravity()
    {

        isGrounded = controller.isGrounded || IsGrounded();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * gravityScale * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDist, groundLayer);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            health = health - enemy.damage;
            if(health <=0)
            {
                GameManager.Instance.GameOver();
                Destroy(gameObject); 
            }
        }
    }
}
