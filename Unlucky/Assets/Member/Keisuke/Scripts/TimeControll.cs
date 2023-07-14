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
            // ���͂��󂯕t���Ĉړ����鏈��
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }

        // 3�b���ƂɃv���C���[�̓����𖳌�������
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            Restrained();
        }
    }

    private void Restrained()
    {
        // �v���C���[���S�����鏈���������ɋL�q���܂�
        // �Ⴆ�΁A�v���C���[�̈ړ����x���[���ɂ�����A����𖳌��������肵�܂�

        canMove = false;
        timer = 0f;
    }
}

