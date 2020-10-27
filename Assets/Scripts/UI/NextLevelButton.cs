using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public void GoToNextLevel()
    {
        Time.timeScale = 1;
        Managers.mission.GoToNextTransitionScene();
    }
}
