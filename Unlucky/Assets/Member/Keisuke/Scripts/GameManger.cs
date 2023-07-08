using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
     [SerializeField]
    private GameObject PlayerHealth; 
    private void OnTriggerEnter(Collider other)
    {
        //Player1のタグをつっくて
        if (other.gameObject.tag  == "Player1")
        {
            GameObject playerHealth = GameObject.Find("//��̃v���n�u������");
            //GameObject playerHealth = GameObject.FindGameObjectWithTag("//��̃v���n�u�̃^�O������");
            if (playerHealth != null)
            {
                if (gameObject.CompareTag("SmallDamage"))
                {

                    Player1Controller.AccumulatedDamage += 10;
                               
                 }
                else if (gameObject.CompareTag("LargeDamage"))
                {
                    Player1Controller.AccumulatedDamage += 30;
                }
            }
        }
        //Player2のタグをつっくて
        if (other.gameObject.tag  == "Player2")
        {
            GameObject playerHealth = GameObject.Find("//��̃v���n�u������");
            //GameObject playerHealth = GameObject.FindGameObjectWithTag("//��̃v���n�u�̃^�O������");
            if (playerHealth != null)
            {
                if (gameObject.CompareTag("SmallDamage"))
                {

                    Player2Controller.AccumulatedDamage += 10;
                               
                 }
                else if (gameObject.CompareTag("LargeDamage"))
                {
                    Player2Controller.AccumulatedDamage += 30;
                }
            }
        }
    }
}
