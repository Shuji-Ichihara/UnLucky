using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Bgm : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;

    void Start()
    {
        //GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        //soundManager.GetComponent<SoundManager>().PlayBgm(clip);
    }

    public void Bgm()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        soundManager.GetComponent<Test_SoundManager>().PlayBgm(clip);
    }
}
