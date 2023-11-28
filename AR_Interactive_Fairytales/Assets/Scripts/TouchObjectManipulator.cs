using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class TouchObjectManipulator : MonoBehaviour
{

    [SerializeField] private Material[] materials = new Material[2];
    private Renderer objcectRenderer;
    private string handTag = "Player";
    //private bool isGrabbing;
    private float skeletonConfidence = 0.0001f;
    [SerializeField] public Text ScriptTxt;
    private int count = 0;
    public float time;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        objcectRenderer = GetComponent<Renderer>();

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
            objcectRenderer.sharedMaterial = materials[0];

        }

        ScriptTxt.text = "터치회수" + count + "\n" + "점수" + (count - (num / 5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(handTag))
        {
            objcectRenderer.sharedMaterial = materials[1];
            count += 1;
            
            //Handheld.Vibrate();
        }

        /*else if (isGrabbing)
        {
            transform.parent = other.gameObject.transform;
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(handTag) /*&& isGrabbing*/)
        {
            transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = null;
        objcectRenderer.sharedMaterial = materials[0];
    }
}