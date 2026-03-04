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
    public bool attacking;

    public float damageresistance = 25;

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

        if (dead == true)
        {
            GetComponent<PlayerMovement>().topSpeed = 0;

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
            GetComponent<PlayerMovement>().topSpeed = 22;
        }

        if (reviveable == true && Input.GetKeyDown(KeyCode.E))
        {
            downed = true;
            health = 55;
        }

        if (downed == true)
        {
            reviveable = true;
            GetComponent<PlayerMovement>().topSpeed = 6;
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


        if (Input.GetMouseButtonDown(0) && attacking == false)
        {
            StartCoroutine(spawnhitboxes());
        }

    }


    private void spawnhitbox(float scale)
    {
        Vector3 position = transform.position + Camera.main.transform.forward * 2;
        position.y = transform.position.y;

        Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;

        GameObject hit = Instantiate(hitbox, position, Quaternion.Euler(rotation));
        hit.transform.SetParent(transform);
        hit.transform.localScale = new Vector3(scale, scale, scale);
        

        StartCoroutine(pycomaincooldown());
    }

    IEnumerator spawnhitboxes()
    {
        if
        {
            spawnhitbox(1);
            yield return new WaitForSeconds(0.05f);
            spawnhitbox(1.1f);
            yield return new WaitForSeconds(0.05f);
            spawnhitbox(1.2f);
            yield return new WaitForSeconds(0.05f);
            spawnhitbox(1.2f);
            yield return new WaitForSeconds(0.05f);
            spawnhitbox(1.3f);
        }
    }

    IEnumerator InvulnerableTimer()
    {
        yield return new WaitForSeconds(5);
        invulnerable = false;

    }

    IEnumerator pycomaincooldown()
    {
        attacking = true;
        yield return new WaitForSeconds(pycomaincool);
        attacking = false;
    }

}
