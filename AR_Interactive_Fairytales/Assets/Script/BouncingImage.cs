using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BouncingImage : MonoBehaviour
{
    public Image bounceImage; // 통통 튀게 만들고자 하는 Image
    public float duration = 1f; // 통통 튀는 주기
    private Vector3 startScale; // 초기 스케일 값
    public float scaleUpRatio = 1.1f; // 확대 비율
    public float scaleDownRatio = 1.0f; // 축소 비율

    private void Start()
    {
        Vector3 originalScale = bounceImage.transform.localScale; // 원래 스케일 값
        startScale = originalScale * scaleDownRatio; // 스케일 축소 값 설정
        Vector3 endScale = originalScale * scaleUpRatio; // 스케일 확대 값 설정

        StartCoroutine(Bounce(endScale));
    }

    IEnumerator Bounce(Vector3 endScale)
    {
        while (true)
        {
            // Scale up (startScale -> endScale)
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float easedStep = EaseOutElastic(t / duration);
                bounceImage.transform.localScale = Vector3.Lerp(startScale, endScale, easedStep);
                yield return null;
            }
            // Scale down (endScale -> startScale)
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float easedStep = EaseInElastic(t / duration);
                bounceImage.transform.localScale = Vector3.Lerp(endScale, startScale, easedStep);
                yield return null;
            }
        }
    }

    float EaseInElastic(float x)
    {
        const float c4 = (2 * Mathf.PI) / 3f;
        return x == 0
          ? 0
          : x == 1
          ? 1
          : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4);
    }

    float EaseOutElastic(float x)
    {
        const float c4 = (2 * Mathf.PI) / 3f;
        return x == 0
          ? 0
          : x == 1
          ? 1
          : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }
}
