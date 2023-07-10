using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

/// <summary>
/// 各ステージのダメージ量
/// </summary>
[System.Serializable]
public struct Damage
{
    public int LargeDamage;
    public int SmallDamage;
}

public class MonoGameManager : SingletonMonoBehaviour<MonoGameManager>
{
    public enum GameSceneState
    {
        Stage1,
        Stage2,
        Stage3,
    }

    private GameSceneState _gameSceneState = GameSceneState.Stage1;

    // プレイヤーキャラ
    [System.NonSerialized]
    public Player1Controller Player1Controller;
    [System.NonSerialized]
    public Player2Controller Player2Controller;
    //　マップ１～3を割り当てる
    [SerializeField]
    private List<GameObject> _map1Objects = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _map2Objects = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _map3Objects = new List<GameObject>();
    //　ダメージ計算
    [SerializeField]
    private List<Damage> _damages = new List<Damage>();

    private int _unluckyNunber = 0;
    // ダメージの計算が完了したかをチェック
    private bool _checkDamagePlayer1 = false;
    private bool _checkDamagePlayer2 = false;

    new private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;
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

    /// <summary>
    /// プレイヤーにダメージを与える処理
    /// </summary>
    private void PlayerDamage()
    {
        if (Player1Controller.IsEntried == true && _checkDamagePlayer1 == false)
        {
            switch (Player1Controller.GamePosition)
            {
                case 0:
                    CalculateDamagePlayer1();
                    break;
                case 1:
                    CalculateDamagePlayer1();
                    break;
                case 2:
                    CalculateDamagePlayer1();
                    break;
                default:
                    break;
            }
            _checkDamagePlayer1 = true;
        }

        if (Player2Controller.IsEntried == true && _checkDamagePlayer2 == false)
        {
            switch (Player2Controller.GamePosition)
            {
                case 0:
                    CalculateDamagePlayer2();
                    break;
                case 1:
                    CalculateDamagePlayer2();
                    break;
                case 2:
                    CalculateDamagePlayer2();
                    break;
                default:
                    break;
            }
            _checkDamagePlayer2 = true;
        }
    }

    /// <summary>
    /// Player1 のダメージ計算
    /// </summary>
    private void CalculateDamagePlayer1()
    {
        int stageNumber = (int)_gameSceneState;
        stageNumber %= _damages.Count;
        // 大ダメージの場合
        if (_unluckyNunber == Player1Controller.GamePosition)
        {
            Player1Controller.AccumulatedDamage += _damages[stageNumber].LargeDamage;
            Debug.Log($"{Player1Controller.AccumulatedDamage} : HP {100 - Player1Controller.AccumulatedDamage}");
        }
        // 小ダメージの場合
        else
        {
            Player1Controller.AccumulatedDamage += _damages[stageNumber].SmallDamage;
            Debug.Log($"{Player1Controller.AccumulatedDamage} : HP {100 - Player1Controller.AccumulatedDamage}");
        }
    }

    /// <summary>
    /// Player2 のダメージ計算
    /// </summary>
    private void CalculateDamagePlayer2()
    {
        int stageNumber = (int)_gameSceneState;
        stageNumber %= _damages.Count;
        if (_unluckyNunber == Player2Controller.GamePosition)
        {
            Player2Controller.AccumulatedDamage += _damages[stageNumber].LargeDamage;
            Debug.Log($"{Player2Controller.AccumulatedDamage}  : HP  {100 - Player2Controller.AccumulatedDamage}");
        }
        else
        {
            Player2Controller.AccumulatedDamage += _damages[stageNumber].SmallDamage;
            Debug.Log($"{Player2Controller.AccumulatedDamage}  : HP  {100 - Player2Controller.AccumulatedDamage}");
        }
    }

    /// <summary>
    /// シーン読み込みが完了した時に呼び出される処理
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        // シーンが切り替わった時に Update が呼び出されない為
        // このタイミングで初期化する
        _checkDamagePlayer1 = false;
        _checkDamagePlayer2 = false;
        // 生成するマップ決め
        int stageNumber = (int)_gameSceneState;
        stageNumber %= _damages.Count;
        switch (stageNumber)
        {
            case (int)GameSceneState.Stage1:
                _unluckyNunber = GenerateMap(_map1Objects);
                break;
            case (int)GameSceneState.Stage2:
                _unluckyNunber = GenerateMap(_map2Objects);
                break;
            case (int)GameSceneState.Stage3:
                _unluckyNunber = GenerateMap(_map3Objects);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// シーンの破棄が完了した時に呼び出される処理
    /// </summary>
    /// <param name="scene"></param>
    private void OnSceneUnLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        _gameSceneState++;
    }
}

