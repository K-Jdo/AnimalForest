//S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //チェンジ変数
    private bool change = false;
    //動物UI
    [SerializeField]
    private GameObject animal_canvas = null;
    //トラップUI
    [SerializeField]
    private GameObject trap_canvas = null;
    //ポーズUI
    [SerializeField]
    private GameObject pause_panel = null;
    //遊び方UI
    [SerializeField]
    private GameObject help_canvas = null;
    //読み込むシーン番号
    private static int scene_num = 0;

    // Start is called before the first frame update
    public void ChangeClick()
    {
        if (change == false)
        {
            //動物UIを隠す
            animal_canvas.SetActive(false);
            //トラップUIを出す
            trap_canvas.SetActive(true);
            change = true;
        }
        else
        {
            //動物UIを出す
            animal_canvas.SetActive(true);
            //トラップUIを隠す
            trap_canvas.SetActive(false);
            change = false;
        }
    }

    public void PauseClick()
    {
        //ポーズUI表示
        pause_panel.SetActive(true);
        //ストップさせる
        Time.timeScale = 0;
    }
    public void Restart()
    {
        //ポーズUI隠す
        pause_panel.SetActive(false);
        //ストップ解除
        Time.timeScale = 1;
    }

    public void ChangeNextScene()
    {
        //次のシーンをロード
        scene_num++;
        SceneManager.LoadSceneAsync(scene_num);
        
    }

    public void EndScene()
    {
        //タイトルシーンロード
        scene_num = 0;
        SceneManager.LoadSceneAsync(scene_num);
    }

    public void HelpClick()
    {
        //遊び方表示
        help_canvas.SetActive(true);
    }

    public void RemoveHelpClick()
    {
        //遊び方非表示
        help_canvas.SetActive(false);
    }
}
