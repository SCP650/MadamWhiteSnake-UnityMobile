using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Mytext;
    void Start()
    {

        Text TT = Mytext.GetComponent<Text>();
        TT.enabled = false;
        // TT.color = Color.clear;
        // GetComponent<Text>().color = Color.clear;
    }

    // Update is called once per frame
    public void showText()
    {
        Text TT = Mytext.GetComponent<Text>();
        TT.enabled = true;
        // TT.color = Color.red;
    }

    public void hideText()
    {
        Text TT = Mytext.GetComponent<Text>();
        TT.enabled = false;
    }
}
