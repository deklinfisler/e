using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public float hitboxs = 5f;
    public bool Canattack= true;
    

    void Start()
    {
       
        
            Canattack = true;
            Destroy(gameObject, 0.04f);
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.TryGetComponent(out testdumby health))
        {
            health.currentHealth -= GetComponentInParent<damagemangeer>().pycomain;
            GetComponentInParent<damagemangeer>().StopCoroutine(GetComponentInParent<damagemangeer>().hitboxCoroutine);
        }
        //FindFirstObjectByType<AudioSource>().Play(); 
    }
   void Update ()
    {
        if (FindFirstObjectByType<dash>().dashing == true && FindFirstObjectByType<PlayerMovement>().isGrounded == false)
        { 
          StartCoroutine(DashingHitBoxs());


        }
        else
        {
          StopCoroutine(DashingHitBoxs());
        }

        if (GetComponentInParent<dash>().dashing == true)
        {
            Canattack = false;
        }
       
    } 
    IEnumerator DashingHitBoxs()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponentInParent<damagemangeer>().spawnhitbox(2.5f);


    }
}
