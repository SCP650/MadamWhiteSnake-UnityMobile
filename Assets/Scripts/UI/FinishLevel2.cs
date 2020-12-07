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
        option1.GetComponentInChildren<Text>().text = "解救许郎"; 
        option2.GetComponentInChildren<Text>().text = "搭救许仙";
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
            int score = Managers.Player.score;
            if (score > PlayerPrefs.GetInt("Level2", 0))
            {
                PlayerPrefs.SetInt("Level2", score);
            }
        }
       
    }
    private void TruthConversation()
    {
        switch (currScene)
        {
            case 0:
                baiImage.SetActive(true);
                textBox.text = "我来迟了，路上耽搁了一会。是不是在这里等很久了？";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "你没事就好。今晚夜色迥异，让我好生担心……";
                currScene = 3;
                break;
            case 3:
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(true);
       
                textBox.text = "情人相会本是人间喜事，可惜，人妖终究有别。许施主，这白娘子可是千年蛇妖啊，你可莫被这妖怪迷了眼睛！";
                currScene++;
                break;
            case 4:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "人又如何？妖又如何？人身妖心者又何其多！怎么修行之人还不如我一介凡夫看得明白？我与娘子不过是天地间两抹有缘的精魄罢了。";
                currScene++;
                break;
            case 5:
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(true);
                textBox.text = "你可知伦常乖舛，立见消亡？人妖殊途，你们在月老庙究竟结缘，还是遭劫呢？此处不过是老衲的障眼法罢了。";
                currScene++;
                break;
            case 6:
                baiImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "我一心向善，一路忍让，高僧又何必苦苦相逼？当真我只会逃跑，拿你没有办法吗！";
                currScene ++;
                break;
            case 7:
                baiImage.SetActive(false);
                faHaiImage.SetActive(true);
                textBox.text = "大胆白蛇！老衲怎可忍你祸乱世间，败坏纲常？六道轮回，各有所序。许施主，有请了！";
                currScene++;
                break;
            case 8:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "本是我心摇意动，是劫是缘，我一力承担！";
                currScene++;
                break;
            case 9:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "法海带走了许仙，我该怎么做呢？";
                option1.SetActive(true);
                option2.SetActive(true);
                next.SetActive(false);
                break;
            case 11:
                textBox.text = "看来金山寺一行，少不了杀戮了。";
                NextLevelButton.SetActive(true);
                break;
            case 12:
                textBox.text = "金山寺一行还是得小心行事。";
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
                textBox.text = "许郎，我终于追上你了！万幸万幸，你安然无恙，是不是吓到你了？";
                currScene++;
                break;
            case 1:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                textBox.text = "娘子，我……";
                currScene = 3;
                break;
            case 3:
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(true);

                textBox.text = "大胆蛇妖！竟敢蛊惑许施主！";
                currScene++;
                break;
            case 4:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "世间多少不平事你不去管，为何苦苦把我俩来缠？";
                currScene++;
                break;
            case 5:
                xuxianImage.SetActive(true);
                baiImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "人有悔意，天必怜之。人妖殊途，法海大师未尝不是为你我好……";
                currScene++;
                break;
            case 6:
                baiImage.SetActive(false);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(true);
                textBox.text = "笑人生浑如醉乡，回头看无穷惆怅，争惶恐，看空空色色色色空空。许施主已有所了悟，白蛇，勿再痴了。";
                currScene++;
                break;
            case 7:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "佛说慈悲为怀，普渡众生，为何不能对我慈悲？又为何不肯渡我？";
                currScene++;
                break;
            case 8:
                baiImage.SetActive(false);
                faHaiImage.SetActive(true);
                textBox.text = "大胆白蛇！老衲怎可忍你祸乱世间，败坏纲常？ 六道轮回，各有所序。既然如此，许施主，有请了！";
                currScene++;
                break;
            case 9:
                baiImage.SetActive(false);
                xuxianImage.SetActive(true);
                faHaiImage.SetActive(false);
                textBox.text = "娘子，我对你不住，是我懵懂无知，引来灾祸，你千万保重！";
                currScene++;
                break;
            case 10:
                baiImage.SetActive(true);
                xuxianImage.SetActive(false);
                faHaiImage.SetActive(false);
                textBox.text = "法海带走了许仙，我该怎么做呢？";
                option1.SetActive(true);
                option2.SetActive(true);
                next.SetActive(false);
                break;
            case 11:
                textBox.text = "看来金山寺一行，少不了杀戮了。";
                NextLevelButton.SetActive(true);
                break;
            case 12:
                textBox.text = "金山寺一行还是得小心行事。";
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
