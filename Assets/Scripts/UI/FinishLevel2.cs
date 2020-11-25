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
        option1.GetComponentInChildren<Text>().text = "救我的爱人，白头偕老"; 
        option2.GetComponentInChildren<Text>().text = "救我的恩人，报收留之恩, 从此两清";
        //Managers.mission.SetLevelChoice(false);//for testing only
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
            PlayerPrefs.SetInt("Level2", Managers.Player.score);
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
                textBox.text = "她一见面就告诉我她的真身，但娘子她一心向善，不管他是人是妖，我都爱她。我相约娘子在这月老庙见面，就是为了见证我们的爱情！";
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
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "法海你这是绑架无辜平民！放开我！娘子你快跑！";
                currScene++;
                break;
            case 9:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "法海绑架走了许仙，我该怎么做呢？";
                option1.SetActive(true);
                option2.SetActive(true);
                next.SetActive(false);
                break;
            case 11:
                textBox.text = "看来我的去金山寺一趟了, 为了救他我就大开杀戒了";
                NextLevelButton.SetActive(true);
                break;
            case 12:
                textBox.text = "看来我的去金山寺一趟了, 但我还是自保要紧。";
                NextLevelButton.SetActive(true);
                break;

        }
    }

    private void FalseConversation()
    {
        switch (currScene)
        {
            case 0:
                baiImage.SetActive(true);
                textBox.text = "许郎！万幸万幸，你也安然无恙。没想到会在这月老庙里和你重逢。";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "娘子……";
                currScene = 3;
                break;
            case 3:
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(true);

                textBox.text = "大胆蛇妖！竟敢蛊惑许家公子！";
                currScene++;
                break;
            case 4:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "许郎，这是怎么回事，为什么法海会在这里，这里不是月老庙吗？";
                currScene++;
                break;
            case 5:
                xuxianImage.SetActive(true);
                baiImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "娘子，是我糊涂了，看到你真身后我慌不择路，路上遇到了法海大师……";
                currScene++;
                break;
            case 6:
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(true);
                textBox.text ="白蛇你还不明白吗？人妖终究殊途！还不快束手就擒！";
                currScene++;
                break;
            case 7:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "法海，我与你无冤无仇，何必对我处处紧逼！当真我只会逃跑，拿你没有办法吗！";
                currScene++;
                break;
            case 8:
                baiImage.SetActive(false);
                faHaiImage.SetActive(true);
                textBox.text = "除遍世间妖怪，就是我心所向，佛意所指！贫僧当然知道你法力高强，为了平民百姓，就麻烦许仙你和我走一趟了！";
                currScene++;
                break;
            case 9:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "法海你这是绑架无辜平民！放开我！娘子你快跑！";
                currScene++;
                break;
            case 10:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "法海绑架走了许仙，但是许仙出卖我迎来的法海，我该怎么做呢？";
                option1.SetActive(true);
                option2.SetActive(true);
                next.SetActive(false);
                break;
            case 11:
                textBox.text = "看来我的去金山寺一趟了, 为了救他我就大开杀戒了";
                NextLevelButton.SetActive(true);
                break;
            case 12:
                textBox.text = "看来我的去金山寺一趟了, 但我还是自保要紧。";
                NextLevelButton.SetActive(true);
                break;

        }
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

    public void ChooseLie() //为了报恩
    {
        Managers.mission.SetLevelChoice(false);
        currScene = 12;
        NextConversation();
        option1.SetActive(false);
        option2.SetActive(false);
    }
    public void ChooseTrue()//为了救人
    {
        Managers.mission.SetLevelChoice(true);
        currScene = 11;
        NextConversation();
        option1.SetActive(false);
        option2.SetActive(false);
    }


}
