using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{

public AudioMixer masterMixer;

Canvas canvas;

    
    void Awake()
    {

    canvas = GetComponent<Canvas>();    

    }

    public void SetSfxLvl(float sfxLvl)
    {

        if (canvas)
        {
            masterMixer.SetFloat ("SoundFxVol",sfxLvl);
        }

    }

    public void SetMusicLvl (float musicLvl)
    {

        if (canvas)
        {
            masterMixer.SetFloat("BgMusicVol",musicLvl);
        }
    }
}
