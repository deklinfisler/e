using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class dash : MonoBehaviour
{
    public bool candash;
    public bool dashing;
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
                    dashing = true;
                }
            }
        }
        if (GetComponent<PlayerMovement>().isGrounded == false&&dashing == true)
        {
            GetComponent<PlayerMovement>().speed = 1f;
        }
        if (GetComponent<PlayerMovement>().isGrounded == true)
        {
            dashing = false;
            GetComponent<PlayerMovement>().speed = 5f;
        }
    }

    IEnumerator dashcooldown()
    {
        candash = false;

        yield return new WaitForSeconds(dashcooldowntime);
        
        candash = true;
        //if (candash == false)
        //{

        //    dashcooldowntime = 18f;
        //}
        //else if (candash == true)
        //{

        //    candash = true;
        //}
    }
}
