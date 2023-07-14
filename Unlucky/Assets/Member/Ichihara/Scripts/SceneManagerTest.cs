using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerTest : SingletonMonoBehaviour<SceneManagerTest>
{
    private static int SceneCount = 0;

    new private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            int Player1Damage = Player1Controller.AccumulatedDamage;
            int Player2Damage = Player2Controller.AccumulatedDamage;

            if(Player1Damage > Player2Damage)
            {
                SceneManager.LoadSceneAsync("Win_P1");
            }
            else if(Player1Damage < Player2Damage)
            {
                SceneManager.LoadSceneAsync("Win_P2");
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneCount++;
            SceneCount %= SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadSceneAsync(SceneCount);
        }
    }
}
