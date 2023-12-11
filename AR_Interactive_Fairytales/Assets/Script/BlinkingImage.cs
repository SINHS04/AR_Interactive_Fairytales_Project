using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    public Image touchImage; // 깜빡거리게 만들고자 하는 Image
    public float duration = 1f; // 깜빡거리는 주기

    private void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            // Fade out (image -> transparent)
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                touchImage.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, t / duration));
                yield return null;
            }
            // Fade in (transparent -> image)
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                touchImage.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, t / duration));
                yield return null;
            }
        }
    }
}
