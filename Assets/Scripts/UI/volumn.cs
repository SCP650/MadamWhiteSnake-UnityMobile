using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumn : MonoBehaviour
{

    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider FXSlider;
    [SerializeField] private AudioClip testClip;

    
    private void Start()
    {
        BGMSlider.maxValue = Managers.Audio.BGMVolume;
     
      
    }
    public void updateBGMVolumn()
    {
        Managers.Audio.BGMVolume = BGMSlider.value;
    }

    public void updateSoundVolumn()
    {
        Managers.Audio.soundVolume = FXSlider.value/5;
        Managers.Audio.PlaySound(testClip);
    }
}
