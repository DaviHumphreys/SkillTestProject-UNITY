using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodCounter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI hText;
    [SerializeField] TextMeshProUGUI iText;
    [SerializeField] TextMeshProUGUI fText;
    GameObject[] hamburgers;
    GameObject[] icecreams;
    GameObject[] fries;

    public int h;
    public int i;
    public int f;

    // Update is called once per frame
    void Update()
    {
        hamburgers = GameObject.FindGameObjectsWithTag("Hamburger");
        icecreams = GameObject.FindGameObjectsWithTag("IceCream");
        fries = GameObject.FindGameObjectsWithTag("Fries");
        hText.text = (hamburgers.Length -1).ToString();
        iText.text = (icecreams.Length -1).ToString();
        fText.text = (fries.Length -1).ToString();
        h = hamburgers.Length -1;
        i = icecreams.Length -1;
        f = fries.Length -1;
    }
}
