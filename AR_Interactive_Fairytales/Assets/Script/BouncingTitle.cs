using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BouncingTitle : MonoBehaviour
{
    public Image bounceImage; // 통통 튀게 만들고자 하는 Image
    public float duration = 1f; // 통통 튀는 주기
    private Vector3 endScale; // 최종 스케일 값

    private void Start()
    {
        endScale = bounceImage.transform.localScale; // 최종 스케일 값 설정 (원래 이미지의 비율)
        bounceImage.transform.localScale = new Vector3(0, 0, 0); // 이미지의 스케일을 0으로 설정
        StartCoroutine(Bounce());
    }

    IEnumerator Bounce()
    {
        // Scale up (0 -> endScale)
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float easedStep = EaseOutElastic(t / duration);
            bounceImage.transform.localScale = Vector3.Lerp(Vector3.zero, endScale, easedStep);
            yield return null;
        }
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
