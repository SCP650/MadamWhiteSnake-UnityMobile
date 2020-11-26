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
                textBox.text = "这么危险，娘子你何必来救我。";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                textBox.text = "纵使千难万险，如果我不来救你，我会愧疚一辈子。谢谢你，知道我是妖怪还依然和我在一起。";
                currScene++;
                break;
            case 2:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "我爱的是你的灵魂，又怎会介意你的皮囊？现在法海已死，娘子，我们回家吧。";
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
            
                textBox.text = "Beta游戏结束，欲登顶雷峰塔，敬请期待发布版本。在此之前，可再次游玩，试试得到不同的结局哦~";
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
                textBox.text = "看到许郎安然无恙，我就放心了";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "娘子，我其实是喜欢你的，只是当时一时受惊昏了头，才带法海捉拿你，让你至于这样的危险之中";
                currScene++;
                break;
            case 2:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                textBox.text = "许郎，你喜欢的不是我白蛇，是为人身的白娘子罢了。借伞之恩，你予我的救命之恩，今天，从此我们两不相欠，江湖再见罢。";
          
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
