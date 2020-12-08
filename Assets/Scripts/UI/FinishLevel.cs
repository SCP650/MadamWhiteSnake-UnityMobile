using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishLevel : MonoBehaviour
{
    [SerializeField] GameObject EndLevelPanel;
    [SerializeField] Text textBox;
    [SerializeField] GameObject baiImage;
    [SerializeField] GameObject xuxianImage;
    [SerializeField] GameObject option1;
    [SerializeField] GameObject option2;
    [SerializeField] GameObject next;
    [SerializeField] GameObject NextLevelButton;

    private int currScene;

    private void Start()
    {
        EndLevelPanel.SetActive(false);
        currScene = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.tag == "Player")
        {
            //Managers.mission.ReachObjective();
            Time.timeScale = 0;
            Managers.Audio.StopMusic();
            EndLevelPanel.SetActive(true);
            NextConversation();
            int score = Managers.Player.score;
            if (score > PlayerPrefs.GetInt("Level1", 0))
            {
                PlayerPrefs.SetInt("Level1", score);
            }
            
        }

        

    }

    public void NextConversation()
    {
        switch (currScene)
        {
            case 0:
                baiImage.SetActive(true);
                textBox.text = "多谢许郎赠伞之恩。";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "江南梅雨时节，外出还需小心。白姑娘，这些和尚为何追你？";
                option1.SetActive(true);
                option2.SetActive(true);
                next.SetActive(false);
                break;
            case 3:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                next.SetActive(true);
                textBox.text = "我本是青城山潜心修炼的小白蛇，此次下山是为了悬壶济世，积善行德；奈何佛法不容。";
                currScene = 6;
                    break;
            case 4:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                next.SetActive(true);
                textBox.text = "事出紧急，个中缘由暂时不便一一告知。";
                currScene = 5;
                    break;
            case 5:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "端午在即，出家人怎好徒增杀孽！你受伤了？药铺尚有些许医药，如果姑娘不嫌弃……";
                currScene = 7;
                break;
            case 6:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "上天有好生之德，我虽只是小小郎中，亦是懂这个道理的。他们要追上来了！快进来躲避一下。";
                currScene = 7;
                break;
            case 7:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                textBox.text = "多谢许郎收留！";
                NextLevelButton.SetActive(true);
                next.SetActive(false);
                break;

        }
    }

    public void ChooseLie()
    {
        Managers.mission.SetLevelChoice(false);
        currScene = 4;
        NextConversation();
        option1.SetActive(false);
        option2.SetActive(false);
    }
    public void ChooseTrue()
    {
        Managers.mission.SetLevelChoice(true);
        currScene = 3;
        NextConversation();
        option1.SetActive(false);
        option2.SetActive(false);
    }


}
