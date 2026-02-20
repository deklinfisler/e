using UnityEngine;

public class damagemangeer : MonoBehaviour
{
    public bool onelife;
    public bool downed;


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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
