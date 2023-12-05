using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Timber : MonoBehaviour
{
    private int count = 0;
    private string handTag = "Straw";


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 3)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(handTag))
        {
            count++;
        }
    }
}
