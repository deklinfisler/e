

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 17f;
    public float topSpeed = 17f;
    public bool clamping;
    public float jumpForce = 10f;
    private Rigidbody rb;
    public bool isGrounded;
    public bool movmentenabled;
    public bool walking;
    public bool running;
    void Start()
    {
        movmentenabled = true; 
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
        if (movmentenabled == true)
{
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = Camera.main.transform.right * moveHorizontal + Camera.main.transform.forward * moveVertical;
            movement.y = 0;
            rb.AddForce(movement * acceleration);

            if (GetComponent<dash>().dashing == true)
            {
                clamping = false;
            }
            else
            {
                clamping = true;
            }

            if (clamping)
            {
                rb.linearVelocity = new Vector3(
                Mathf.Clamp(rb.linearVelocity.x, -topSpeed, topSpeed),
                rb.linearVelocity.y,
                Mathf.Clamp(rb.linearVelocity.z, -topSpeed, topSpeed)

            );
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            if (Input.GetKey(KeyCode.LeftShift) == true)
            {
                running = true;
                walking = false;
            }
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                running = false;
                walking = true;
            }
            if (running == true)
            {
                if (isGrounded == false)
                {
                    topSpeed = 15f;
                }
                if (isGrounded == true)
                {
                    topSpeed = 17f;
                }
            }
            if (walking == true)
            {
                if (isGrounded == false)
                {
                    topSpeed = 8f;
                }
                if (isGrounded == true)
                {
                    topSpeed = 10f;
                }
            }
        }
    }

        void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;

            }
        }
}