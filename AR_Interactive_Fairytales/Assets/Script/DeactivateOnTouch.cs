using UnityEngine;

public class DeactivateOnTouch : MonoBehaviour
{
    public GameObject targetObject; // 비활성화할 대상 오브젝트

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 화면을 터치했을 때
        {
            DeactivateObject(targetObject); // targetObject를 비활성화
        }
    }

    public void DeactivateObject(GameObject targetObject)
    {
        targetObject.SetActive(false);
    }
}
