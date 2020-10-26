using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishLevel2 : MonoBehaviour
{
    [SerializeField] GameObject EndLevelPanel;
    [SerializeField] Text textBox;
    [SerializeField] GameObject baiImage;
    [SerializeField] GameObject xuxianImage;
    [SerializeField] GameObject faHaiImage;
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
        }
       
    }
    private void TruthConversation()
    {
        switch (currScene)
        {
            case 0:
                baiImage.SetActive(true);
                textBox.text = "许郎！万幸万幸，你也安然无恙。有没有在这里等很久？";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "还好还好，看到娘子安好我就放心了。不过刚才这月老庙里突然来了一个奇怪的和尚……";
                currScene = 3;
                break;
            case 3:
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(true);
       
                textBox.text = "多么感人的情人相会，可惜，人妖终究殊途。许仙，这白娘子可是千年蛇妖啊，你可莫被这妖怪迷了眼睛！";
                currScene++;
                break;
            case 4:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "她一见面就告诉我了，但娘子她一心向善，不管他是人是妖，我都爱她。我相约娘子在这月老庙见面，就是为了见证我们的爱情！";
                currScene++;
                break;
            case 5:
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(true);
                textBox.text = "月老庙？呵，这不过是我设的障眼法罢了，这其实是我的金山寺！";
                currScene++;
                break;
            case 6:
                baiImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "什么？法海，我与你无冤无仇，你竟行此不仁不义之事！当真我只会逃跑，拿你没有办法吗！";
                currScene ++;
                break;
            case 7:
                baiImage.SetActive(false);
                faHaiImage.SetActive(true);
                textBox.text = "除遍世间妖怪，就是我心所向，佛意所指！贫僧当然知道你法力高强，为了平民百姓，就麻烦许仙你和我走一趟了！";
                currScene++;
                break;
            case 8:
                baiImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "法海你这是绑架无辜平民！放开我！娘子你快跑！";
                currScene++;
                break;

        }
    }

    public void NextConversation()
    {
        Managers.mission.SetLevelChoice(true);//for testing only
        if (Managers.mission.GetPlayerChoice(1))
        {
            TruthConversation();
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
