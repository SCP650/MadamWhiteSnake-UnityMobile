using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PangBaiTwoController : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullTextA;
    public Text textA;
    public string fullTextB;
    public Text textB;
    public AudioClip panbai;
    public GameObject playButton;
    [SerializeField] int lookatLevel = 1;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowPlayBtn());
        Managers.Audio.StopMusic();
        Managers.Audio.PlaySound(panbai);
        if (Managers.mission.GetPlayerChoice(lookatLevel))
        {
            StartCoroutine(ShowTextA());
        }
        else
        {
            StartCoroutine(ShowTextB());
        }
    }

    private IEnumerator ShowTextA()
    {
        for (int i = 0; i <= fullTextA.Length; i++)
        {
            textA.text = fullTextA.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator ShowTextB()
    {
        for (int i = 0; i <= fullTextB.Length; i++)
        {
            textB.text = fullTextB.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator ShowPlayBtn()
    {
        yield return new WaitForSeconds(2.5f);
        ps.Play();
        yield return new WaitForSeconds(32);
        playButton.SetActive(true);
    }

    public void playLevel()
    {
        Managers.mission.GoToNextLevel();
    }
}
