using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class crushthem : MonoBehaviour
{
    public bool crushing;
    public float crushfrequency = 10f;
    public float crushstrength = 10f;
    public PlayerMovement playerMovement;
    private float originalY;
     void Awake()
    {
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
          if (other.TryGetComponent(out testdumby health))
        {
            health.currentHealth -= GetComponentInParent<damagemangeer>().pycocrush;
            GetComponentInParent<damagemangeer>().StopCoroutine(GetComponentInParent<damagemangeer>().hitboxCoroutine);
        }
        if (Input.GetMouseButtonDown(1) && playerMovement.isGrounded == true)
        {
            StartCoroutine(crushhitbox());
            Debug.Log("crush ability activated");
            
            
                //StartCoroutine(thecrushing());

                
            

            
             //float x = transform.position.x;
             //float y = Mathf.Sin(Time.time * crushfrequency) * crushstrength + originalY;
             //float z = transform.position.z;
            //transform.position = new Vector3(x, y, z);
             //Destroy(gameObject, 2f);  
             //crushing = false;
            
        
        }
    }
    //IEnumerator thecrushing()
    //{
    
      //  GetComponent<PlayerMovement>().movmentenabled = false;
       // GetComponent<PlayerMovement>().canjump = false;
       // yield return new WaitForSeconds(3);
        
      


    //}

  

    //spawn crush hitbox and all othe atributes of the crush ability, such as movement disable and jump disable
    IEnumerator crushhitbox()
    {    
        crushing = true;
        GetComponent<damagemangeer>().attacking = false;
         GetComponent<PlayerMovement>().movmentenabled = false;
        GetComponent<PlayerMovement>().canjump = false;
        yield return new WaitForSeconds(3);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0, transform.position.z);
        Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
        rotation.x = transform.position.x;
        rotation.y = Mathf.Sin(Time.time * crushfrequency) * crushstrength + originalY;
        rotation.z = transform.position.z;
           
        GameObject crushhitbox = Instantiate(GetComponent<damagemangeer>().crushhitbox, transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
        crushhitbox.transform.SetParent(transform);
         
        crushing = false;
        yield return new WaitUntil(() => crushing == false);
          yield return new WaitForSeconds(1.5f);
        GetComponent<PlayerMovement>().movmentenabled = true;
        GetComponent<PlayerMovement>().canjump = true;
       GetComponent<damagemangeer>().attacking = true;
    }
}
