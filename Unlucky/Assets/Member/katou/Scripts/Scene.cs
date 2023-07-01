using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class Scene : MonoBehaviour
{ 
     public static Scene scene;
     
      public GameObject fade;
      public GameObject fadeCanvas;
     void Start()
    {
        if(scene == null){
         var obj =   GameObject.FindObjectOfType<Scene>();
             scene =  obj.GetComponent<Scene>() ;
            }
            else{
                Destroy(this);
            }
        
        DontDestroyOnLoad(gameObject);
          if (!Fade.isFadeInstance)//isFadeInstanceは後で用意する
        {
            Instantiate(fade);
        }

        Invoke("findFadeObject", 0.02f);//起動時用にCanvasの召喚をちょっと待つ
    }

    public void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvasをみつける
        fadeCanvas.GetComponent<Fade>().fadeIn();//フェードインフラグを立てる
    }

    public async void sceneChange(SceneName.GameName scene)//ボタン操作などで呼び出す
    {
        fadeCanvas.GetComponent<Fade>().fadeOut();//フェードアウトフラグを立てる
        await Task.Delay(200);//暗転するまで待つ
        SceneManager.LoadScene(scene.ToString());//シーンチェンジ
        
    }
}

