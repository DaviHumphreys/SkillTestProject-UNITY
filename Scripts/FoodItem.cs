using UnityEngine;
using System.Collections.Generic;

public class FoodItem : MonoBehaviour
{
    public FoodType type;
    private SlotManager slotManager;
    private bool clicked;

    Timer _t;

    void Start()
    {
        _t = FindObjectOfType<Timer>();
    }    

    public void Init(SlotManager manager)
    {
        slotManager = manager;
    }

    void OnMouseDown()
    {
        if(_t.timer > 0)
        {
            
            AudioManager.Instance.PlaySound(AudioManager.SoundType.Food);
            AudioManager.Instance.PlaySound(AudioManager.SoundType.Food2);
            if (clicked) return;
            clicked = true;

            Debug.Log("Clicou em: " + name);
            slotManager.AddFood(this);
            }
        }

    public void MoveTo(Vector3 pos)
    {
        StopAllCoroutines();
        StartCoroutine(MoveRoutine(pos));
    }
    
    public void PlayFeedback()
    {
        StopAllCoroutines();
        StartCoroutine(FeedbackRoutine());
    }
    System.Collections.IEnumerator FeedbackRoutine()
    {
        

        float t = 0;
        Vector3 start = transform.localScale;

        while (t < 1f)
        {
            t += Time.deltaTime * 10f;
            float s = Mathf.Lerp(1f, 1.3f, Mathf.Sin(t * Mathf.PI));
            transform.localScale = start * s;
            yield return null;
        }

        transform.localScale = start;
    }

    System.Collections.IEnumerator MoveRoutine(Vector3 target)
    {
        float t = 0;
        Vector3 start = transform.position;

        while (t < 2f)
        {
            t += Time.deltaTime * 2.8f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
    }
}

