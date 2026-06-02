using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class cooldowntimer : MonoBehaviour
{
    public float cooldownTime = 5f; 
    public TMPro.TMP_Text cooldownText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{while (GetComponent<dash>().candash == false)
    //    {
    //        cooldownTime -= Time.deltaTime;
    //        cooldownText.text = cooldownTime.ToString("F1") + "s";
            //if (cooldownTime <= 0f)
            //{
            //    GetComponent<dash>().candash = true;
            //    cooldownTime = 5f; // Reset the cooldown time for the next dash
            //    cooldownText.text = ""; // Clear the cooldown text
                //if (GameObject.Find("runThemDown").GetComponent<TMPro.TMP_Text>().text == "0")
                //{ 
                //GetComponent<Canvas>().enabled = false; // Hide the cooldown text
                //}
        //    }
            
        //}
        //if (GetComponent<dash>().dashing == false && GetComponent<dash>().candash == true)
        //{

        //    cooldownText.text += GetComponent<dash>().dashcooldowntime.ToString();
        //}

    //}
}
