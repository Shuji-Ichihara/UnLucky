using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    //�撣���ČĂяo�����ŁO�O
    public void LoadScene(SceneName.GameName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
