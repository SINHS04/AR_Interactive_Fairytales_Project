using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.XR.ARFoundation;

public class UIManipulator : MonoBehaviour
{
    bool isTouching = false; // 중복 터치 방지 isTouching 변수
    bool isUIOff = false;
    [SerializeField] private GameObject scenario;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true); //UI 활성화
        scenario.SetActive(false);  //오브젝트 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        TurnUIOff();
    }
    private void TurnUIOff()
    {
        if (!isTouching && Input.touchCount > 0)   // Touch중이면 중복터치 안되도록 제어
        {
            gameObject.SetActive(false);
            isUIOff = true;
        }
        if(isUIOff)
        {
            scenario.SetActive(true);
        }
    }
}
