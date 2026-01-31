using UnityEngine;
using System.Collections;

public class SmoothScaler : MonoBehaviour
{
    public float duration = 2f; 
    public float targetScaleValue = 0.5f; 

    void Start()
    {
        StartCoroutine(ScaleOverTime(duration, targetScaleValue));
    }

    private IEnumerator ScaleOverTime(float duration, float scale)
    {
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.one * scale; 
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsed += Time.deltaTime;
            yield return null; 
        }
        transform.localScale = endScale; 
    }
}
