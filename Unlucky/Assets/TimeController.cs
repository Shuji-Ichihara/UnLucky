using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    void Start()
    {
        StartCoroutine("Corou1");
    }

    private IEnumerator Corou1() 
    {
        
        Debug.Log("スタート");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("スタートから3秒後");
    }
    private bool isRestrained;
    private float timer;

    private void Update()
    {
        if (!isRestrained)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                Restrained();
            }
        }
    }

    private void Restrained()
    {
        // プレイヤーを拘束する処理をここに記述します
        // 例えば、プレイヤーの移動速度をゼロにしたり、制御を無効化したりします

        isRestrained = true;
        timer = 0f;
    }
}

