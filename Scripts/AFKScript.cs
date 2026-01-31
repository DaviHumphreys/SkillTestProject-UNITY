using UnityEngine;

public class AFKDetector : MonoBehaviour
{
    public float afkTimeout = 3f;
    private float lastActionTime;
    private bool isAFK = false;

    public GameObject hand;
    void Start()
    {
        lastActionTime = Time.time;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastActionTime = Time.time;
            if (isAFK)
            {
                GameObject _hand = GameObject.FindWithTag("Player");
                if(_hand != null)
                {
                    Destroy(_hand);
                }
                isAFK = false;
            }
        }

        if (!isAFK && Time.time - lastActionTime >= afkTimeout)
        {
            isAFK = true;
            Instantiate(hand, new Vector3(1, 0, -8), Quaternion.Euler(0,0,38), transform);
            
        }
    }
}
