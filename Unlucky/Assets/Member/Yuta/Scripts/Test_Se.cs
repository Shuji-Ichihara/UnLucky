using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_Se : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;

    public void SE()
    {
        if (SceneManager.GetActiveScene().name == "Test1")
        {
            GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
            soundManager.GetComponent<Test_SoundManager>().PlaySe(clip);

            SceneManager.LoadScene("Test2");
        }

        if (SceneManager.GetActiveScene().name == "Test2")
        {
            GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
            soundManager.GetComponent<Test_SoundManager>().PlaySe(clip);

            SceneManager.LoadScene("Test1");
        }
    }
}
