using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeLanguage : MonoBehaviour
{
    public Font Chinese;
    public Font English;
    public Text title;
    public Text start;
    public Text setting;
    public Text thanks;
    public Text SFVolumn;
    public Text BGMVolumn;
    private bool isEnglish = false;

    public void ToggleLanguage()
    {
        isEnglish = !isEnglish;
        title.text = isEnglish ? "White Snake" : "白蛇·纸伞";
        start.text = isEnglish ? "Start Game" : "开始游戏";
        setting.text = isEnglish ? "Settings" : "游戏设置";
        thanks.text = isEnglish ? "Developers" : "开发鸣谢";
        SFVolumn.text = isEnglish ? "Sound Effect Volume" : "音效音量";
        BGMVolumn.text = isEnglish ? "BGM Volume" : "背景音量";

     
        title.font = isEnglish? English:Chinese;
        start.font = isEnglish ? English : Chinese;
        setting.font = isEnglish ? English : Chinese;
        thanks.font = isEnglish ? English : Chinese;
        SFVolumn.font = isEnglish ? English : Chinese;
        BGMVolumn.font= isEnglish ? English : Chinese;

    }
}
