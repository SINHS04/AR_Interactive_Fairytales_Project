using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARImageTracking : MonoBehaviour
{
    public Text TrackingPage;
    //public Text CreatedImage;
    public float _timer;    // 몇 초 Limited 상태이면 이미지를 비활성화 할 건지 지정 (현재는 필요x)
    public ARTrackedImageManager trackedImageManager;
    public List<GameObject> _objectList = new List<GameObject>();
    private Dictionary<string, GameObject> _prefabDic = new Dictionary<string, GameObject>();
    private List<ARTrackedImage> _trackedImg = new List<ARTrackedImage>();
    private List<float> _trackedTimer = new List<float>();
    void Awake()
    {
        TrackingPage.text = "None";
        //CreatedImage.text = "None";

        foreach (GameObject obj in _objectList)
        {
            string tName = obj.name;
            _prefabDic.Add(tName, obj); // 이름을 이용하여 access가 가능
        }

    }

    void Update()
    {
        if (_trackedImg.Count >= 0)   // 이미지를 트래킹 중이면
        {
            List<ARTrackedImage> tNumList = new List<ARTrackedImage>();
            for (var i = 0; i < _trackedImg.Count; i++)
            {
                if (_trackedImg[i].trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
                // TrackingState가 Limited일 때
                {
                    //if (_trackedTimer[i] > 0.03){}
                    string name = _trackedImg[i].referenceImage.name;
                    GameObject tObj = _prefabDic[name];
                    tObj.SetActive(false);
                    //CreatedImage.text = "Removed " + name;
                    //tNumList.Add(_trackedImg[i]);   // 트래킹을 중지 할 이미지 목록에 추가

                    /*else
                    {
                        _trackedTimer[i] += Time.deltaTime;     // Timer 중첩
                        text1.text = (i.ToString() + ", " + _trackedTimer[i].ToString());
                    }
                    */

                }
            }

            if (tNumList.Count > 0)
            {
                for (var i = 0; i < tNumList.Count; i++)
                {
                    int num = _trackedImg.IndexOf(tNumList[i]);
                    _trackedImg.Remove(_trackedImg[num]);       // 트래킹하고있는 이미지에서 삭제
                    TrackingPage.text = "Removed" + name + "\n" + _trackedImg.Count;
                    // _trackedTimer.Remove(_trackedTimer[num]);   // 타이머 트래킹 중지
                }
            }
        }
        
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        //trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)    // add, update, remove
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            if (!_trackedImg.Contains(trackedImage))    // 이미지가 리스트에 없을 경우
            {
                string name = trackedImage.referenceImage.name;
                _trackedImg.Add(trackedImage);
                TrackingPage.text = "Tracking" + name;
                _trackedTimer.Add(0);
            }
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (!_trackedImg.Contains(trackedImage))    // 이미지가 리스트에 없을 경우
            {
                _trackedImg.Add(trackedImage);
                _trackedTimer.Add(0);
            }
            else                                        // 이미지가 리스트에 이미 있을 경우
            {
                int num = _trackedImg.IndexOf(trackedImage);
                _trackedTimer[num] = 0;
            }
            UpdateImage(trackedImage);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name; // 인자로 넘겨받은 trakcedImage의 이름을 가져옴
        GameObject tObj = _prefabDic[name];             // Dic에서 오브젝트를 가져옴
        // 이미지의 위치로 오브젝트 소환
        tObj.transform.position = trackedImage.transform.position;
        tObj.transform.rotation = trackedImage.transform.rotation;
        tObj.SetActive(true);
        //CreatedImage.text = "Create " + name;
    }
}
