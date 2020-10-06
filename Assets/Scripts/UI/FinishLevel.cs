using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishLevel : MonoBehaviour
{
    [SerializeField] GameObject EndLevelPanel;
    [SerializeField] Text textBox;
    [SerializeField] Image character1;
    [SerializeField] Image character2;
    [SerializeField] Button option1;
    [SerializeField] Button option2;
    [SerializeField] GameObject next;
    //[SerializeField] enum Orientation { Left, Right, Top, Bottom }
    private void Start()
    {
        EndLevelPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.tag == "Player")
        {
            //Managers.mission.ReachObjective();
            Time.timeScale = 0;
            Managers.Audio.StopMusic();
            EndLevelPanel.SetActive(true);

        }
       
    }
}
