using UnityEngine;

public class testdumby : MonoBehaviour
{
    public Color minHealth;
    public Color maxHealth;
    public int maxhealth;
    [HideInInspector]public int currentHealth;
    public TMPro.TextMeshProUGUI damagetext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxhealth;
        Canvas.ForceUpdateCanvases();
    }

    // Update is called once per frame
    void Update()
    {
       
        Canvas.ForceUpdateCanvases();
        damagetext.text = "damage: " + currentHealth;
        damagetext.color = Color.Lerp(minHealth, maxHealth, (float)currentHealth / maxhealth);
    }
}
