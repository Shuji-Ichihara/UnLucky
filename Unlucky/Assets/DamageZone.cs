using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //// PlayerHealth �͓������ɐ������Ȃ�炩�̂���ɒu������炵���@�H
            //PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            //if (playerHealth != null)
            //{
            //    if (gameObject.CompareTag("SmallDamage"))
            //    {
            //        playerHealth.TakeDamage(1);
            //    }
            //    else if (gameObject.CompareTag("LargeDamage"))
            //    {
            //        playerHealth.TakeDamage(3);
            //    }
            //}
        }
    }
}

