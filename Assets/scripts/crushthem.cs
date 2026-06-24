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
             StartCoroutine(crushhitbox());
             if(crushing == true)
            {
             transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
             GetComponent<damagemangeer>().spawnhitbox(1.1f);
             StartCoroutine(crush());  
             GetComponent<damagemangeer>().spawnhitbox(1.1f);
             float x = transform.position.x;
             float y = Mathf.Sin(Time.time * crushfrequency) * crushstrength + originalY;
             float z = transform.position.z;

             transform.position = new Vector3(x, y, z);
             Destroy(gameObject, 2f);  
             crushing = false;
            }
        
        }
    }
    IEnumerator crush()
    {
        yield return new WaitForSeconds(3);
        crushing = true;
                //Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
        //rotation.x = 0;
       // rotation.z = 0;

        //GameObject crushthemhitbox = Instantiate(GetComponent<damagemangeer>().hitbox, transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
        //crushthemhitbox.transform.SetParent(transform);
    }
    IEnumerator crushhitbox()
    {
        yield return new WaitForSeconds(3);
        GetComponent<damagemangeer>().spawnhitbox(1.1f);
    }
}
