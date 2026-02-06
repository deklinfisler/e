using UnityEngine;

public class sliding : MonoBehaviour
{
    [Header("Reference")]
    public Transform orientation;
    public Transform playerobj;
    private Rigidbody rb;
    private PlayerMovement pm;
    /// <summary>
    /// this makes the variables for sliding
    /// </summary>
    [Header("Sliding")]
    public float maxSlideTime;
    public float slideforce;
    private float slideTimer;

    public float slideYScale;
    private float startYScale;
    /// <summary>
    /// this is for the input key to slide
    /// </summary>
    [Header("Input")]
    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInput;
    private bool Sliding;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
        startYScale = playerobj.localScale.y;
    }
    /// <summary>
    /// this makes it so it checks for input every frame causing the player to slide when the key is pressed
    /// </summary>
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0) && pm.isGrounded)
        {
            StartSlide();
        }
        if (Input.GetKeyUp(slideKey) && Sliding)
        {
            StopSlide();
        }
    }
    /// <summary>
    /// this makes the sliding movement smooth
    /// </summary>
    private void FixedUpdate()
    {
        if (Sliding)
            SlidingMovement();
    }
    /// <summary>
    /// this allows force to be applyed when the player starts slidings
    /// </summary>
    private void StartSlide()
    {
        Sliding = true;

        playerobj.localScale = new Vector3 (playerobj.localScale.x, slideYScale, playerobj.localScale.z);
        rb.AddForce(Vector3.down* 5f, ForceMode.Impulse);
        slideTimer = maxSlideTime;
    }
    /// <summary>
    /// this allows the player to slide in any direction
    /// </summary>
    private void SlidingMovement()
    { 
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(inputDirection.normalized*slideforce, ForceMode.Force);
        slideTimer -= Time.deltaTime;

        if (slideTimer <= 0)
            StopSlide();
    }
    private void StopSlide()
    {
        Sliding = false;
        playerobj.localScale = new Vector3(playerobj.localScale.x, startYScale, playerobj.localScale.z);
    }
}

