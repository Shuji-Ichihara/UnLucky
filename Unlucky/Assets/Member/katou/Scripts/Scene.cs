using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    //Šæ’£‚Á‚ÄŒÄ‚Ño‚·‚ñ‚â‚ÅOO
    public void LoadScene(SceneName.GameName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
