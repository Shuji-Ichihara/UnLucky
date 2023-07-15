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
    // ステージ管理
    public enum GameSceneState
    {
        Stage1,
        Stage2,
        Stage3,
    }
    // 現在のステート
    public GameSceneState GameState = GameSceneState.Stage1;

    // プレイヤーキャラ
    public GameObject Player1 = null;
    public GameObject Player2 = null;
    public static Player1Controller Player1Controller = null;
    public static Player2Controller Player2Controller = null;

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
    // はずれ番号
    private int _unluckyNunber = 0;
    // ダメージの計算が完了したかをチェック
    private bool _isCheckPlayer1Damage = false;
    private bool _isCheckPlayer2Damage = false;

    private bool _isPlayAnim = false;

    new private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneLoaded += PlayerSpawn.Instance.OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;
    }

    private void Start()
    {
        Player1Controller = Player1.GetComponent<Player1Controller>();
        Player2Controller = Player2.GetComponent<Player2Controller>();
    }

    void Update()
    {
        if (Player1Controller != null && Player2Controller != null)
        {
            PlayerDamage();
        }
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
        if (Player1Controller.IsEntried == true && _isCheckPlayer1Damage == false)
        {
            CalculateDamagePlayer1();
            _isCheckPlayer1Damage = true;
        }
        if (Player2Controller.IsEntried == true && _isCheckPlayer2Damage == false)
        {
            CalculateDamagePlayer2();
            _isCheckPlayer2Damage = true;
        }
    }

    /// <summary>
    /// Player1 のダメージ計算
    /// </summary>
    private void CalculateDamagePlayer1()
    {
        int stageNumber = (int)GameState;
        stageNumber %= _damages.Count;
        // 大ダメージの場合
        if (_unluckyNunber == Player1Controller.GamePosition)
        {
            Player1Controller.AccumulatedDamage += _damages[stageNumber].LargeDamage;
            //Debug.Log("Damage = " + Player1Controller.AccumulatedDamage);
        }
        // 小ダメージの場合
        else
        {
            Player1Controller.AccumulatedDamage += _damages[stageNumber].SmallDamage;
            //Debug.Log("Damage = " + Player1Controller.AccumulatedDamage);
        }
    }

    /// <summary>
    /// Player2 のダメージ計算
    /// </summary>
    private void CalculateDamagePlayer2()
    {
        int stageNumber = (int)GameState;
        stageNumber %= _damages.Count;
        // 大ダメージの場合
        if (_unluckyNunber == Player2Controller.GamePosition)
        {
            Player2Controller.AccumulatedDamage += _damages[stageNumber].LargeDamage;
            //Debug.Log("Damage = " + Player2Controller.AccumulatedDamage);
        }
        // 小ダメージの場合
        else
        {
            Player2Controller.AccumulatedDamage += _damages[stageNumber].SmallDamage;
            //Debug.Log("Damage = " + Player2Controller.AccumulatedDamage);
        }
    }

    /// <summary>
    /// シーン読み込みが完了した時に呼び出される処理
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        // TODO : タイトル,リザルトのシーン名に変更
        if (SceneManager.GetActiveScene().name == "Title"
            || SceneManager.GetActiveScene().name == "ResultScene")
        {
            return;
        }

        // シーンが切り替わった時に Start が呼び出されない為
        // このタイミングで初期化する
        _isCheckPlayer1Damage = false;
        _isCheckPlayer2Damage = false;
        _isPlayAnim = false;
        // 生成するマップ決め
        int stageNumber = (int)GameState;
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
        // 最初のステージになったら、蓄積ダメージを初期化
        if (stageNumber == (int)GameSceneState.Stage1)
        {
            Player1Controller.AccumulatedDamage = 0;
            Player2Controller.AccumulatedDamage = 0;
        }
    }

    /// <summary>
    /// シーンの破棄が完了した時に呼び出される処理
    /// </summary>
    /// <param name="scene"></param>
    private void OnSceneUnLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        // TODO : タイトル,リザルトのシーン名に変更
        if (SceneManager.GetActiveScene().name == "Title"
            || SceneManager.GetActiveScene().name == "ResultScene")
        {
            GameState = 0;
            return;
        }
        GameState++;
    }
}

