using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : SingletonMonoBehaviour<PlayerSpawn>
{
    [SerializeField]
    private List<GameObject> _playerPoints = new List<GameObject>();
    public List<GameObject> PlayerPoints => _playerPoints;

    // Start is called before the first frame update
    new private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// シーン読み込み時に走るデリゲート
    /// ゲームシーン以外は読み込まない処理を他のスクリプトで記述してほしい。
    /// </summary>
    /// <param name="scene">デリゲート型の引数</param>
    /// <param name="mode">デリゲート型の引数</param>
    public void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        // TODO : タイトル,リザルトのシーン名に変更
        if (SceneManager.GetActiveScene().name == "TitleScene"
            || SceneManager.GetActiveScene().name == "ResultScene")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            return;
        }
        InitGame();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// オブジェクトのインスタンス生成
    /// </summary>
    public void InitGame()
    {
        GameObject player1Object = MonoGameManager.Instance.Player1;
        GameObject player2Object = MonoGameManager.Instance.Player2;
        var player1Controller = player1Object.GetComponent<Player1Controller>();
        var player2Controller = player2Object.GetComponent<Player2Controller>();
        MonoGameManager.Instance.Player1 = Instantiate(player1Object,
            _playerPoints[player1Controller.GamePosition].transform.position, Quaternion.identity);
        MonoGameManager.Instance.Player2 = Instantiate(player2Object,
            _playerPoints[player2Controller.GamePosition].transform.position, Quaternion.identity);
    }
}
