using System.Collections;
using System.Threading;
using Unity.Hierarchy;
using UnityEngine;

public class dash : MonoBehaviour
{
    public bool candash;
    public bool dashing;
    public float dashSpeed = 100f;
    public float dashcooldowntime = 18f;
    public float hitwall = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerMovement>().isGrounded == false && GetComponent<damagemangeer>().wideopen == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
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
            GetComponent<PlayerMovement>().topSpeed = 1f;
        }
        if (GetComponent<PlayerMovement>().isGrounded == true)
        {
            dashing = false;
            GetComponent<PlayerMovement>().topSpeed = 17f;
        }
        if (dashing == true&&GetComponent<PlayerMovement>().isGrounded ==false)
        {
            StartCoroutine(movementWallCooldown());
        }
        if (dashing == true)
        {
         GetComponent<damagemangeer>().attacking = false;
            StartCoroutine(dashhitboxs());
        }
    }

    IEnumerator dashcooldown()
    {
        candash = false;

        yield return new WaitForSeconds(dashcooldowntime);
        
        candash = true;
    }

    IEnumerator movementWallCooldown()
    {
        GetComponent<PlayerMovement>().movmentenabled = false;
        yield return new WaitForSeconds(hitwall);
        GetComponent<PlayerMovement>().movmentenabled = true;
    }
    IEnumerator dashhitboxs()
    { 
        Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
        rotation.x = 0;
        rotation.z = 0; 

        GameObject dashhitbox = Instantiate(GetComponent<damagemangeer>().hitbox, transform.position, Quaternion.identity);
        dashhitbox.transform.SetParent(transform);

        yield return new WaitUntil(() => dashing = false);
    }
}
