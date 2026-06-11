using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class crushthem : MonoBehaviour
{
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
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            StartCoroutine(crush());

        }
    }
    IEnumerator crush()
    {
        yield return new WaitForSeconds(3);
        GetComponent<damagemangeer>().spawnhitbox(1.1f);
        float x = transform.position.x;
            float y = Mathf.Sin(Time.time * crushfrequency) * crushstrength + originalY;
            float z = transform.position.z;

            transform.position = new Vector3(x, y, z);

    }
}
