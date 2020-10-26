using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHint : MonoBehaviour
{
    [SerializeField] Text hintText;
    [SerializeField] string textContent;
    [SerializeField] bool showTurnOff = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (showTurnOff)
            {
                StartCoroutine(ChangeHintText());
            }
            else
            {
                hintText.text = textContent;
            }

        }
    }
 

    private IEnumerator ChangeHintText()
    {
        yield return new WaitForSeconds(3);
        hintText.text = textContent;
   
        hintText.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);
        hintText.text = "";
    }

}
