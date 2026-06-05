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
        float x = transform.position.x;
        float y = Mathf.Sin (Time.time * crushfrequency) * crushstrength + originalY;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
