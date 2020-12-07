using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishLevel3 : MonoBehaviour
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
        option1.GetComponentInChildren<Text>().text = "好";
        option2.GetComponentInChildren<Text>().text = "还是算了";
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
            if (score > PlayerPrefs.GetInt("Level3", 0))
            {
                PlayerPrefs.SetInt("Level3", score);
            }
        }
       
    }

    private void TruthConversation()
    {
        switch (currScene)
        {
            case 0:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "白姑娘……罪灾皆因我而起，如若修行能消解佛门对你的偏见，我也是甘愿的。";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                textBox.text = "我不羡佛也不羡仙，许郎，姻缘天定，谁人能断？";
                currScene++;
                break;
            case 2:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "我都听你的。江南梅雨时节，白姑娘又不带伞……";
                option1.SetActive(true);
                option2.SetActive(true);
                next.SetActive(false);
                currScene++;
                break;
            case 3:
                option1.SetActive(false);
                option2.SetActive(false);
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
            
                textBox.text = "感谢游玩，欲登顶雷峰塔，敬请期待2.0版本。在此之前，可再次游玩，试试得到不同的结局哦~";
             break;
            

        }
    }

    private void FalseConversation()
    {
        switch (currScene)
        {
            case 0:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                textBox.text = "什么人间美眷，朝朝暮暮，不过虚情假意罢了。";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "都说妖无情无义，倘若你不思恩情，也就无需救我；倘若你绝情背义，何至水漫金山……白姑娘，是我狭隘了……";
                currScene++;
                break;
            case 2:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                textBox.text = "前世恩，今生缘，缘起缘灭一念间。对于你，我恩情已报，缘已了尽了。";
          
                currScene++;
                break;
            case 3:
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
              
                textBox.text = "Beta游戏结束，感谢游玩。欲登顶雷峰塔，敬请期待发布版本。在此之前，可再次游玩，试试得到不同的结局哦~";
                break;


        }
    }
    public void NextConversation()
    {
        //Managers.mission.SetLevelChoice(true);
        //Managers.mission.SetLevelChoice(false);
        if (Managers.mission.GetPlayerChoice(2))
        {
            TruthConversation();
        }
        else
        {
            FalseConversation();
        }
    }

   


}
