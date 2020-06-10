//S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
