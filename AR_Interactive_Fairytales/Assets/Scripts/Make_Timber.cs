using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Timber : MonoBehaviour
{
    private int straw_count = 0;
    private int log_count = 0;
    private int brick_count = 0;
    private string house_mat1 = "Straw";
    private string house_mat2 = "Log";
    private string house_mat3 = "Brick";


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(straw_count == 3)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(house_mat1))
        {
            straw_count++;
        }
    }
}
