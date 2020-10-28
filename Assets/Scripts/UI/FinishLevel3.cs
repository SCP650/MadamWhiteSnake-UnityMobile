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
            case 3:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "我爱的是你的灵魂，又怎会介意你的皮囊？现在法海已死，娘子，我们回家吧。";
                option1.SetActive(true);
                option2.SetActive(true);
                next.SetActive(false);
                currScene++;
                break;
            case 4:
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
                NextLevelButton.SetActive(true);
                textBox.text = "游戏结束，感谢游玩";
             break;
            

        }
    }

    private void FalseConversation()
    {

    }
    public void NextConversation()
    {

        if (Managers.mission.GetPlayerChoice(1))
        {
            TruthConversation();
        }
        else
        {
            FalseConversation();
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
