using System.Collections;
using UnityEngine;

public class dash : MonoBehaviour
{
    public bool candash;
    public float dashSpeed = 100f;
    public float dashcooldowntime = 18f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerMovement>().isGrounded == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (GetComponent<PlayerMovement>().isGrounded == false && candash == true)
                {
                    Vector3 dashDirection = Camera.main.transform.forward;
                    GetComponent<Rigidbody>().AddForce(dashDirection * dashSpeed, ForceMode.VelocityChange);

                    StartCoroutine(dashcooldown());
                }
            }
        }
    }

    IEnumerator dashcooldown()
    {
        candash = false;

        yield return new WaitForSeconds(dashcooldowntime);

        candash = true;
    }
}
