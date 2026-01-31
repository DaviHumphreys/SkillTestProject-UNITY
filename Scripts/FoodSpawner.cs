using UnityEngine;



public class FoodSpawner : MonoBehaviour
{
    
    public SlotManager slotManager;

    [Header("Prefabs")]
    public GameObject hamburgerPrefab;
    public GameObject iceCreamPrefab;
    public GameObject friesPrefab;

    [Header("Amounts")]
    public int hamburgers = 15;
    public int iceCreams = 15;
    public int fries = 15;

    [Header("Spawn Area")]
    public float areaWidth = 2f;
    public float areaHeight = 3.5f;

    void Start()
    {
        AudioManager.Instance.ChangeMusic(AudioManager.SoundType.Background);
        Spawn(hamburgerPrefab, hamburgers);
        Spawn(iceCreamPrefab, iceCreams);
        Spawn(friesPrefab, fries);
    }

    void Spawn(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(-areaWidth, areaWidth*2);
            float y = Random.Range(-areaHeight, areaHeight);
            float rot = Random.Range(0f, 360f);

            Vector3 pos = new Vector3(x, y, Random.Range(-7, 10));

            var go = Instantiate(prefab, pos, Quaternion.Euler(0,0,Random.Range(0,360)), transform);
            var item = go.GetComponent<FoodItem>();
            item.Init(slotManager);

        }
    }
}

