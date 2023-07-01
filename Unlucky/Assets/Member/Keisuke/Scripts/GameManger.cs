using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{

    private Player1Controller _player1Controller;
    private Player2Controller _player2Controller;

    [SerializeField]
    private List<GameObject> _map1Objects = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _map2Objects = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _map3Objects = new List<GameObject>();

    [SerializeField]
    private int SmallDamage = 10;
    [SerializeField]
    private int LargeDamage = 30;

    private void Awake()
    {
        GenerateMap(_map1Objects);
    }
    void Start()
    {
        _player1Controller = PlayerSpawn.Instance.Player1.GetComponent<Player1Controller>();
        _player2Controller = PlayerSpawn.Instance.Player2.GetComponent<Player2Controller>();
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
    private void GenerateMap(List<GameObject> mapObjects)
    {
        int num = Random.Range(0, mapObjects.Count);
        Instantiate(mapObjects[num], Vector3.zero, Quaternion.identity);
    }

    private void PlayerDamage()
    {
        if (_player1Controller.IsEntried == true)
        {
            Player1Controller.AccumulatedDamage += 10;

            switch (_player1Controller.GamePosition)
            {
                case 0:
                    //後で変更する
                    Player1Controller.AccumulatedDamage += 10;
                    break;
                case 1:
                    //後で変更する
                    Player1Controller.AccumulatedDamage += 10;
                    break;
                case 2:
                    //後で変更する
                    Player1Controller.AccumulatedDamage += 10;
                    break;
                default:
                    break;
            }
        }
        if (_player2Controller.IsEntried == true)
        {
            Player2Controller.AccumulatedDamage += 10;

            switch (_player2Controller.GamePosition)
            {
                case 0:
                    //後で変更する
                    Player2Controller.AccumulatedDamage += 10;
                    break;
                case 1:
                    //後で変更する
                    Player2Controller.AccumulatedDamage += 10;
                    break;
                case 2:
                    //後で変更する
                    Player2Controller.AccumulatedDamage += 10;
                    break;
                default:
                    break;
            }
        }
    }

}
