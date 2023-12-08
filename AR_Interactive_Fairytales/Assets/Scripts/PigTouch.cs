using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class PigTouch : MonoBehaviour
{

    [SerializeField] private Material[] materials = new Material[2];
    [SerializeField] private Transform Target;
    public float Speed = 1f;
    private string handTag = "Player";
    //private bool isGrabbing;
    private float skeletonConfidence = 0.0001f;
    [SerializeField] public Text ScriptTxt;
    private int count = 1;
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

        ScriptTxt.text = "touch" + count + "\n" + "score" + (count - (num / 5));

        transform.position = Vector3.MoveTowards(transform.position, Target.position, Mathf.Log10(count) * Time.deltaTime*Speed);
        //transform.Translate(Vector3.right * Time.deltaTime * Mathf.Log10(count));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(handTag))
        {
            //objcectRenderer.sharedMaterial = materials[1];
            count += 1;

            //transform.position = transform.position + new Vector3(1, 0, 0);
            //Handheld.Vibrate();
        }
        else if (other.gameObject.CompareTag("House"))
        {
            //objcectRenderer.sharedMaterial = materials[1];
            Speed = 0; //¸ØÃß±â
            ScriptTxt.text = "µµÂø";
            //transform.position = transform.position + new Vector3(1, 0, 0);
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
}