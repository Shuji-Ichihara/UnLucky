using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class test : MonoBehaviour
{
    [SerializeField] private Scene scene;
     bool isSceneChange  =false;


    void Update()
    {
        if (Input.GetKey(KeyCode.J)&&Input.GetKey(KeyCode.A)&&!isSceneChange)
        {
                isSceneChange = true;
                Debug.Log("www");
                scene.sceneChange(SceneName.GameName.Scene2);
                
        }

    
    }
}

    
        
    
    

