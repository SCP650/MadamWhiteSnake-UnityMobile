using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PangBaiTypeWrite : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    public Text text;
    public AudioClip panbai;
    public GameObject playButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
        StartCoroutine(ShowPlayBtn());
        Managers.Audio.StopMusic();
        Managers.Audio.PlaySound(panbai);
    }

    private IEnumerator ShowText()
    {
        for(int i = 0; i <= fullText.Length; i++)
        {
            text.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator ShowPlayBtn()
    {
        yield return new WaitForSeconds(35);
        playButton.SetActive(true);
    }

    public void playLevel()
    {
        Managers.mission.GoToNextLevel();
    }
}
