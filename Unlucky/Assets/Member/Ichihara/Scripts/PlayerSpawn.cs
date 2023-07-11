using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : SingletonMonoBehaviour<PlayerSpawn>
{
    [SerializeField]
    private List<GameObject> _playerPoints = new List<GameObject>();
    public List<GameObject> PlayerPoints => _playerPoints;

    #region Players
    [SerializeField]
    private GameObject _player1 = null;
    public GameObject Player1 { get; private set; }
    [SerializeField]
    private GameObject _player2 = null;
    public GameObject Player2 { get; private set; }
    #endregion

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

    public void InitGame()
    {
        var player1Controller = _player1.GetComponent<Player1Controller>();
        var player2Controller = _player2.GetComponent<Player2Controller>();
        Player1 = Instantiate(_player1, _playerPoints[player1Controller.GamePosition].transform.position, Quaternion.identity);
        Player2 = Instantiate(_player2, _playerPoints[player2Controller.GamePosition].transform.position, Quaternion.identity);
    }
}
