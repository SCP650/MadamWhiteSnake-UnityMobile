using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2Controller : MonoBehaviour
{
    [SerializeField] AudioClip TransitionBGMTrue;
    [SerializeField] AudioClip TransitionBGMFalse;
    [SerializeField] GameObject playButton;
    [SerializeField] int lookatLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowPlayBtn());
        Managers.Audio.StopMusic();
        if (Managers.mission.GetPlayerChoice(lookatLevel))
        {
            Managers.Audio.PlaySound(TransitionBGMTrue);
        }
        else
        {
            Managers.Audio.PlaySound(TransitionBGMFalse);
        }

    }
    private IEnumerator ShowPlayBtn()
    {
      
        yield return new WaitForSeconds(32);
        playButton.SetActive(true);

    }

    public void playLevel()
    {
        Managers.mission.GoToNextLevel();
    }
}
