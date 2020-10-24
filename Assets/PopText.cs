using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.GetComponent<TextMesh>().text = "Hello World";
    }
}
