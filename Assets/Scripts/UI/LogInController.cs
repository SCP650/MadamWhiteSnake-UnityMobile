using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInController : MonoBehaviour
{
    [SerializeField] GameObject EnterName;
    [SerializeField] GameObject EnterEmail;
    [SerializeField] GameObject PlayBtn;
    [SerializeField] InputField name;
    [SerializeField] InputField email;

    [SerializeField] GameObject[] btns;
    private void Start()
    {
        EnterName.SetActive(false);
        EnterEmail.SetActive(false);
        PlayBtn.SetActive(false);
        name.text = PlayerPrefs.GetString("EnterName", "");
        email.text = PlayerPrefs.GetString("EnterEmail", "");
    }

    public void ClickFirstPlay()
    {
        EnterName.SetActive(true);
        EnterEmail.SetActive(true);
        PlayBtn.SetActive(true);
        foreach (GameObject btn in btns)
        {
            //btn.SetActive(false);
            Destroy(btn);
        }
       
    }

    public void ClickSecondPlay()
    {
        Debug.Log(name.text);
        PlayerPrefs.SetString("EnterName", name.text);
        PlayerPrefs.SetString("EnterEmail", email.text);
        Managers.mission.GoToNextTransitionScene();
    }
}
