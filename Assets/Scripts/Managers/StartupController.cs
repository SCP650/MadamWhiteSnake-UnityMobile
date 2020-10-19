using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartupController : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private GameObject startupCanvas;
    [SerializeField] private GameObject loadingCanvas;
    [SerializeField] private List<GameObject> UITexts;
    [SerializeField] private int jumpToScene;
   //[SerializeField] private Animator _animator;


    private void Awake()
    {
        Messenger<int, int>.AddListener(StartupEvent.MANAGERS_PROGRESS, OnManagerProgress);
        Messenger.AddListener(StartupEvent.MANAGERS_STARTED, OnManagerStarted);
     
    }

    private void OnDestroy()
    {
        Messenger<int, int>.RemoveListener(StartupEvent.MANAGERS_PROGRESS, OnManagerProgress);
        Messenger.RemoveListener(StartupEvent.MANAGERS_STARTED, OnManagerStarted);

    }

    private void OnManagerProgress(int numReady, int numFinished)
    {
        float percent =(float) numReady / numFinished;
        progressBar.value = percent;
    }

    private void OnManagerStarted()
    {
        //Managers.mission.GoToNext();
        loadingCanvas.SetActive(false);
        startupCanvas.SetActive(true);
        Managers.Audio.PlayIntroMusic();
        StartCoroutine(showUIText());

    }

    private IEnumerator showUIText()
    {
        yield return new WaitForSeconds(4);
        foreach(GameObject text in UITexts)
        {
            text.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Managers.mission.GoToNextLevel();//for testing
        }else if (Input.GetKeyDown("2"))
        {
            Managers.mission.GoToLevel(2);
        }
    }

}
