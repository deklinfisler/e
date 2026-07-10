using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class crushthem : MonoBehaviour
{
    public bool crushing;
    public float crushfrequency = 10f;
    public float crushstrength = 10f;
    private float originalY;
     void Awake()
    {
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2) && GetComponent<PlayerMovement>().isGrounded == true)
        {
            crushing= true;

            if (crushing == true)
            {
                StartCoroutine(thecrushing());

                StartCoroutine(crushhitbox());
            }

             //transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
             //float x = transform.position.x;
             //float y = Mathf.Sin(Time.time * crushfrequency) * crushstrength + originalY;
             //float z = transform.position.z;
            //transform.position = new Vector3(x, y, z);
             //Destroy(gameObject, 2f);  
             //crushing = false;
            
        
        }
    }
    IEnumerator thecrushing()
    {
    
        GetComponent<PlayerMovement>().movmentenabled = false;
        GetComponent<PlayerMovement>().canjump = false;
        yield return new WaitForSeconds(3);
        
      


    }

  

    //spawn crush hitbox and all othe atributes of the crush ability, such as movement disable and jump disable
    IEnumerator crushhitbox()
    {    
        
        Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;

        GameObject crushhitbox = Instantiate(GetComponent<damagemangeer>().crushhitbox, transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
        crushhitbox.transform.SetParent(transform);
        crushing = false;
        yield return new WaitUntil(() => crushing == false);
          yield return new WaitForSeconds(1.5f);
        GetComponent<PlayerMovement>().movmentenabled = true;
        GetComponent<PlayerMovement>().canjump = true;
       
    }
}
