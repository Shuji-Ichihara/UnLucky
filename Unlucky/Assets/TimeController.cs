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
        
        Debug.Log("�X�^�[�g");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("�X�^�[�g����3�b��");
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
        // �v���C���[���S�����鏈���������ɋL�q���܂�
        // �Ⴆ�΁A�v���C���[�̈ړ����x���[���ɂ�����A����𖳌��������肵�܂�

        isRestrained = true;
        timer = 0f;
    }
}

