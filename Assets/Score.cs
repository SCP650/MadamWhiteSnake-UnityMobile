using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
 
 // Use this for initialization
    // void Start () {
    //     GetComponent<Text> ().text = "杀: " + this.score;
    // }
    
    public void incrementScore(int incrementValue) {
        Debug.Log("This score is === " + this.score);
        this.score += incrementValue;
        GetComponent<Text> ().text = "杀杀杀！！！ +1 " ; //+ this.score.ToString();
        // this.score += incrementValue;
        // GetComponent<Text> ().text = "杀: " + this.score;
    }

    public void HideText()
    {
        GetComponent<Text> ().text = "";
    }
    
    public int getScore() {
        return this.score;
    }
}
