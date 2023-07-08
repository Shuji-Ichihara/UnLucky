using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test2 : MonoBehaviour
{
    [SerializeField] private Scene scene;

    float second;
    bool isSceneChange  =false;
    void FixedUpdate()
    {
        
        second += Time.fixedDeltaTime;
        Debug.Log("second");
        if(second > 10 && !isSceneChange)
       {
                 isSceneChange = true;
                scene.sceneChange(SceneName.GameName.Scene3);
     }
    }
    
}
