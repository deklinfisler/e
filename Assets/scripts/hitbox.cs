using UnityEngine;

public class hitbox : MonoBehaviour
{
    public float hitboxs = 5f;
    public bool Canattack;
    

    void Start()
    {
        Canattack = true;
        Destroy(gameObject, 0.4f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (Canattack == true)
        { 

        if (other.TryGetComponent(out testdumby health))
        {
            health.test_dumby -= GetComponentInParent<damagemangeer>().pycomain;
        }
        }
    }
   void Update ()
    {

        if (GetComponentInParent<dash>().dashing == true)
        {
            Canattack = false;
        }

    }
}
