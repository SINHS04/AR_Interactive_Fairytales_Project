using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Make_Timber : MonoBehaviour
{
    private int straw_count = 1;
    private int log_count = 0;
    private int brick_count = 0;
    [SerializeField] public string house_material_tag;

    private int curr_count =0;
    public float Max = 5.0f;
    [SerializeField] public GameObject Message1;
    [SerializeField] public GameObject Message2;
    TextMeshPro text1;
    TextMeshPro text2;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        text1 = Message1.GetComponent<TextMeshPro>();
        text2 = Message2.GetComponent<TextMeshPro>();
        text2.text = curr_count + "/" + Max;
    }

    // Update is called once per frame
    void Update()
    {
        Color curr_color = GetComponent<MeshRenderer>().material.color;
        if(curr_count >= 0 && curr_count<Max)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<MeshRenderer>().material.color = new Color(curr_color.r, curr_color.g, curr_color.b, 1.0f/((Max+1)/(curr_count+1)) );
            text2.text = curr_count + "/" + Max;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == house_material_tag)
        {
            curr_count += 1;
            Destroy(other.gameObject);
        }
    }
}
