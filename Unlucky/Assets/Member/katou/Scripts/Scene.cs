using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    //頑張って呼び出すんやで＾＾
    public void LoadScene(SceneName.GameName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
