using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pauseManu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] Image ToggleBackgroun;
    [SerializeField] Toggle togglePause;
    [SerializeField] GameObject resumeButton; 
    [SerializeField] Text pauseDeathText;
    //[SerializeField] GameObject ToogleCheckMark;
    // Start is called before the first frame update
    private void Awake()
    {
        Messenger.AddListener(GameEvent.LEVEL_FAILED, death);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.LEVEL_FAILED, death);
    }

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
            pauseDeathText.text = "暂停";
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
        Managers.Player.Respawn();
        Time.timeScale = 1;
        Managers.Audio.MuteBGM = false;
        Managers.mission.RestartCurrent();
       
    }

    public void death()
    {
        pause(true);
        pauseDeathText.text = "缘分未到";
        togglePause.gameObject.SetActive(false);
        resumeButton.SetActive(false);
    }
}
