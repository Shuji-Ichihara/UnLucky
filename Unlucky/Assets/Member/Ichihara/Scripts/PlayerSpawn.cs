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
        if (SceneManager.GetActiveScene().name == "Title"
            || SceneManager.GetActiveScene().name == "ResultScene")
        {
            return;
        }
        InitGame();
    }

    /// <summary>
    /// オブジェクトのインスタンス生成
    /// </summary>
    public void InitGame()
    {
        GameObject player1Object = Instantiate(MonoGameManager.Instance.Player1);
        GameObject player2Object = Instantiate(MonoGameManager.Instance.Player2);
        MonoGameManager.Player1Controller = player1Object.GetComponent<Player1Controller>();
        MonoGameManager.Player2Controller = player2Object.GetComponent<Player2Controller>();
        player1Object.transform.position = _playerPoints[MonoGameManager.Player1Controller.GamePosition].transform.position;
        player2Object.transform.position = _playerPoints[MonoGameManager.Player2Controller.GamePosition].transform.position;
    }
}
