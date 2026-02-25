using UnityEngine;

public class testdumby : MonoBehaviour
{
    public int test_dumby;
    public TMPro.TextMeshProUGUI damagetext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damagetext.text = "damage: " + test_dumby;
    }
}
