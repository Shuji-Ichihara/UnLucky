using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // プレイヤーキャラ
    private Player1Controller _player1Controller;
    private Player2Controller _player2Controller;
    //　マップ１～3を割り当てる
    [SerializeField]
    private List<GameObject> _map1Objects = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _map2Objects = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _map3Objects = new List<GameObject>();
    //　ダメージ計算
    [SerializeField]
    private int _smallDamage = 10;
    [SerializeField]
    private int _largeDamage = 30;

    private int _unluckyNunber = 0;

    private bool _checkDamagePlayer1 = false;
    private bool _checkDamagePlayer2 = false;

    private void Awake()
    {
        _unluckyNunber = GenerateMap(_map1Objects);
    }
    void Start()
    {
        //_player1Controller = PlayerSpawn.Instance.Player1.GetComponent<Player1Controller>();
        //_player2Controller = PlayerSpawn.Instance.Player2.GetComponent<Player2Controller>();
    }
    void Update()
    {
        PlayerDamage();
    }

    /// <summary>
    /// Map 生成
    /// </summary>
    /// <param name="mapObjects">生成するマップリスト</param>
    /// <returns></returns>
    private int GenerateMap(List<GameObject> mapObjects)
    {
        int num = Random.Range(0, mapObjects.Count);
        Instantiate(mapObjects[num], Vector3.zero, Quaternion.identity);
        return num;
    }

    private void PlayerDamage()
    {
        if (_player1Controller.IsEntried == true && _checkDamagePlayer1 == false)
        {
            switch (_player1Controller.GamePosition)
            {
                case 0:
                    CalculateDamagePlayer1();
                    _checkDamagePlayer1 = true;
                    break;
                case 1:
                    CalculateDamagePlayer1();
                    _checkDamagePlayer1 = true;
                    break;
                case 2:
                    CalculateDamagePlayer1();
                    _checkDamagePlayer1 = true;
                    break;
                default:
                    break;
            }
        }
        if (_player2Controller.IsEntried == true && _checkDamagePlayer2 == false)
        {
            switch (_player2Controller.GamePosition)
            {
                case 0:
                    CalculateDamagePlayer2();
                    _checkDamagePlayer2 = true;
                    break;
                case 1:
                    CalculateDamagePlayer2();
                    _checkDamagePlayer2 = true;
                    break;
                case 2:
                    CalculateDamagePlayer2();
                    _checkDamagePlayer2 = true;
                    break;
                default:
                    break;
            }
        }
    }

    private void CalculateDamagePlayer1()
    {
        
        if (_unluckyNunber == _player1Controller.GamePosition)
        {
            Player1Controller.AccumulatedDamage += _largeDamage;
            Debug.Log($"{Player1Controller.AccumulatedDamage} : HP {100 - Player1Controller.AccumulatedDamage}");
        }
        
        else
        {
            Player1Controller.AccumulatedDamage += _smallDamage;
            Debug.Log($"{Player1Controller.AccumulatedDamage} : HP {100 - Player1Controller.AccumulatedDamage}");
        }
    }

    private void CalculateDamagePlayer2()
    {
        if (_unluckyNunber == _player2Controller.GamePosition)
        {
            Player2Controller.AccumulatedDamage += _largeDamage;
            Debug.Log($"{Player2Controller.AccumulatedDamage}  : HP  {100 - Player2Controller.AccumulatedDamage}");
        }
        else
        {
            Player2Controller.AccumulatedDamage += _smallDamage;
            Debug.Log($"{Player2Controller.AccumulatedDamage}  : HP  {100 - Player2Controller.AccumulatedDamage}");
        }
    }

}
