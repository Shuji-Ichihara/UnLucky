using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    [SerializeField] private Scene scene;

    // Update is called once per frame

    //  ŒÄ‚Ño‚µ•ûAŠæ’£‚Á‚Ä‚ËOO
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                scene.LoadScene(SceneName.GameName.Scene2);
            }
        }
        
    }
}
