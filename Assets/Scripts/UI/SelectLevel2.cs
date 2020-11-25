using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel2 : MonoBehaviour
{
    public void GoToLevel2()
    {
        Managers.mission.SetLevelChoice(true);
        Managers.mission.GoToTransition(2);
    }

    public void GoToLevel3()
    {
        Managers.mission.SetLevelChoice(true);
        Managers.mission.SetLevelChoice(false);
        Managers.mission.GoToTransition(3);
    }
}
