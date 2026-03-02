using System.Collections;
using UnityEngine;

public class damagemangeer : MonoBehaviour
{
    public bool onelife;
    public bool downed;
    public bool dead;
    public bool reviveable;
    public bool revived;
    public bool invulnerable;
    public bool lastlife;
    public bool iframes;
    public bool alive;
    public bool notdowned;

    public int health = 190;

    public bool leaching;
    public int healingtick = 5;

    public int fealnopain = 45;

    public int brotherstuncooldown = 12;
    public int brotherstunA = 3;
    public int selfdamageA = 35;
    public int brotherstunB = 4;
    public int selfdamageB = 30;
    public int brotherstunC = 5;
    public int selfdamageC = 45;

    public int recuerunspeed = 30;
    public int recueduration = 7;
    public int recuewindup = 6;


    public int pycomain = 20;
    public int pycomainwindup = 1;
    public int pycomaincool = 3;
    public int pycodash = 10;
    public int pycocrush = 40;
    public int crushwindup = 4;
    public int nomercy = 10;

    public GameObject hitbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if ( dead == true )
        {
            GetComponent<PlayerMovement>().speed = 0;

        }
        if (lastlife == true && health == 0)
        {
            dead = true;
        }
        if (revived == true)
        {
            downed = false;
            invulnerable = true;
            StartCoroutine(InvulnerableTimer());
        }
        if (invulnerable == true)
        {
            iframes = true;
            GetComponent<PlayerMovement>().speed = 22;
        }
        if (reviveable == true && Input.GetKeyDown(KeyCode.E)) 
        {
            revived = false;
            downed = true;
            health = 50;
        }
        if (downed == true)
        {
            reviveable = true;
            GetComponent<PlayerMovement>().speed = 6;
        }
        if (health <= 0 && onelife == true) 
        {
            downed = true;
           
        }
        if (downed == true)
        {
            lastlife = true;
            reviveable = true;
        }
        if (Input.GetMouseButtonDown(0)) {
            GameObject hit = Instantiate(hitbox, transform.position + transform.forward * 2, transform.rotation);
            hit.transform.SetParent(transform);
        }
    }
    IEnumerator InvulnerableTimer()
    {
        yield return new WaitForSeconds(5);
        invulnerable = false;

    }
}
