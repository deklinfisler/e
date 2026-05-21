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
    void Update()
    {
        if (GetComponent<dash>().dashing == true && GetComponent<dash>().candash == false)
        {
            
            cooldownText.text = GetComponent<dash>().dashcooldowntime.ToString();
        }
       
    }
}
