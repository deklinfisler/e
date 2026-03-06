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
            health.test_dumby -= GetComponentInParent<damagemangeer>().pycomain;
            GetComponentInParent<damagemangeer>().StopCoroutine(GetComponentInParent<damagemangeer>().hitboxCoroutine);
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
