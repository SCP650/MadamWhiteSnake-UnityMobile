using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Button yourButton;
    bool ClickOn;

    bool showBUT;

    // public GameObject BUT;

	void Start () {
        ClickOn = false;
        showBUT = false;
		Button btn = yourButton.GetComponent<Button>();
        btn.GetComponent<Image>().color = Color.clear;
        btn.enabled = false;
        // BUT = GameObject.Find("Button");
        // BUT.SetActive(false);
        
        // GameObject.Find("Button").SetActive(false);

        // Debug.Log("ready");
        // if(showBUT)
        // {
        //     Debug.Log("show But");
        //     GameObject.Find("Button").SetActive(true);
        //     btn.onClick.AddListener(TaskOnClick);
        // }

		
        
        ClickOn = false;
        
	}

	public void TaskOnClick(){
		// Debug.Log ("You have clicked the button!");

        if(Input.touchCount > 0)
        {
            ClickOn = true;
            CLICK();
        }
        else
        {
            ClickOn = false;
            CLICK();
        }
        

        // Debug.Log("Will get here");




	}

    public bool CLICK()
    {
        return ClickOn;
    }


    public void reset()
    {
         Button btn = yourButton.GetComponent<Button>();
         btn.GetComponent<Image>().color = Color.clear;
        btn.enabled = false;
        // CLICK();
    }

    public void showbutton()
    {
        Button btn = yourButton.GetComponent<Button>();
        // GameObject.Find("Button").SetActive(false);
        showBUT = true;
        if(showBUT)
        {
            btn.GetComponent<Image>().color = Color.white;
            btn.enabled = true;
            btn.onClick.AddListener(TaskOnClick);
        }
		
    }

    public void hidedbutton()
    {
        showBUT = false;
        Button btn = yourButton.GetComponent<Button>();
        btn.GetComponent<Image>().color = Color.clear;
        btn.enabled = false;
        
    }



}
