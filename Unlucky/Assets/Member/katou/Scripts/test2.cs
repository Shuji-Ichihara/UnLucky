using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    [SerializeField] private Scene scene;

    float second;
    void Update()
    {
        
        second += Time.deltaTime;
        Debug.Log("second");
        if(second > 10)
        {
            scene.LoadScene(SceneName.GameName.Scene3);
        }
    }
}
    