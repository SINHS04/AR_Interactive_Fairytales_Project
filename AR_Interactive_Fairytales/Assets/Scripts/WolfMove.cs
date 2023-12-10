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

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        //objcectRenderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        ManomotionManager.Instance.ShouldCalculateGestures(true);


       
        if (isFire)
        {
            movedoor();
        }
        else
        {
            movedown();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Fire"))       //태그 이름 확인
        {
            isFire = true;
            //DownSpeed = 0; //stop the wolf
            //Handheld.Vibrate();
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
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