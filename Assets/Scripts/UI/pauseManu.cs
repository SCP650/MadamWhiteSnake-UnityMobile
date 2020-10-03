using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pauseManu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] Image ToggleBackgroun;
    [SerializeField] Toggle togglePause;
    //[SerializeField] GameObject ToogleCheckMark;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

  
    public void pause(bool isPause)
    {
        pausePanel.SetActive(isPause);
        if (isPause)
        {
            Time.timeScale =0 ;//pause the game
            Managers.Audio.MuteBGM = true;
            ToggleBackgroun.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            Managers.Audio.MuteBGM = false;
            ToggleBackgroun.enabled = true;
        }

    }

    public void resume()
    {
        togglePause.isOn = !togglePause.isOn; 
    }
    public void restart()
    {
       
        Time.timeScale = 1;
        Managers.Audio.MuteBGM = false;
        Managers.mission.RestartCurrent();
       
    }
}
