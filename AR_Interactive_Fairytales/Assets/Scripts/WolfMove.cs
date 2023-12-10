using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

[RequireComponent(typeof(BoxCollider))]
public class WolfMove : MonoBehaviour
{

    [SerializeField] private Transform Fireplace;
    [SerializeField] private Transform door;
    private float DownSpeed = 1.0f;
    private float RunSpeed = 3.0f;

    private bool isFire = false;

    private float skeletonConfidence = 0.0001f;
    public float time;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        //objcectRenderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        num = ((int)time);

        ManomotionManager.Instance.ShouldCalculateGestures(true);

        /*var currentGesture = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger;


        if (currentGesture == ManoGestureTrigger.GRAB_GESTURE)
        {
            isGrabbing = true;

        }

        else if (currentGesture == ManoGestureTrigger.RELEASE_GESTURE)
        {
            isGrabbing = false;
            transform.parent = null;
        }*/

        bool hasConfidence = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.confidence > skeletonConfidence;

        if (!hasConfidence)
        {
            //objcectRenderer.sharedMaterial = materials[0];

        }

        if (isFire)
        {
            movedoor();
        }
        else
        {
            movedown();
        }

        //ScriptTxt.text = "touch" + count + "\n" + "score" + (count - (num / 5));

        
        //transform.Translate(Vector3.right * Time.deltaTime * Mathf.Log10(count));
    }

    private void OnTriggerEnter(Collider other)
    {
        isFire = true;
        if (other.gameObject.CompareTag("Fire"))       //태그 이름 확인
        {
            //objcectRenderer.sharedMaterial = materials[1];
            DownSpeed = 0; //stop the wolf
            //Handheld.Vibrate();
        }

        /*else if (isGrabbing)
        {
            transform.parent = other.gameObject.transform;
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (other.gameObject.CompareTag(handTag) *//*&& isGrabbing*//*)
        {
            transform.parent = other.gameObject.transform;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        //transform.parent = null;

        //objcectRenderer.sharedMaterial = materials[0];
    }
    private void movedown()
    {
        transform.position = Vector3.MoveTowards(transform.position, Fireplace.position, Time.deltaTime * DownSpeed);
    }
    private void movedoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, door.position, Time.deltaTime * RunSpeed);
    }
}