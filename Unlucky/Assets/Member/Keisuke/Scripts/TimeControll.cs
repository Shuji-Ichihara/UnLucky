using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControll : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;
    private float timer;

    private void Update()
    {
        if (canMove)
        {
            // 入力を受け付けて移動する処理
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }

        // 3秒ごとにプレイヤーの動きを無効化する
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            Restrained();
        }
    }

    private void Restrained()
    {
        // プレイヤーを拘束する処理をここに記述します
        // 例えば、プレイヤーの移動速度をゼロにしたり、制御を無効化したりします

        canMove = false;
        timer = 0f;
    }
}

