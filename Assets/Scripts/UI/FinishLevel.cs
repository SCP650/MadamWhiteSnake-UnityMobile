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
            PlayerPrefs.SetInt("Level1", Managers.Player.score);
        }

        

    }

    public void NextConversation()
    {
        switch (currScene)
        {
            case 0:
                baiImage.SetActive(true);
                textBox.text = "多谢许郎赠伞之情。";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "又见面了...这些和尚为什么追你?";
                option1.SetActive(true);
                option2.SetActive(true);
                next.SetActive(false);
                break;
            case 3:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                next.SetActive(true);
                textBox.text = "我若实情告知，如有冒犯之处，先谢罪为敬。我本是青城山修炼千年的白蛇妖，此次下山是为悬壶救人，积善行德，奈何佛法不容。";
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
                textBox.text = "端午在即，自是安康要紧，哪有以众欺寡的道理. 你受伤了？铺里尚有医药二三，粗茶淡饭，如果姑娘不嫌弃...";
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
                textBox.text = "多谢许郎收留!";
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
