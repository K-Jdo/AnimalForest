//S.T.
using JetBrains.Annotations;
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
    //クリアUI
    [SerializeField]
    private GameObject clear_panel = null;
    //オーバーUI
    [SerializeField]
    private GameObject over_panel = null;
    //遊び方画像の親
    [SerializeField]
    private Transform parent = null;
    //遊び方の子
    private Transform[] child;
    private int tower_count;

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        tower_count = TowerManager.Instance.GetTowerNumber();
        if (GameManager.Instance.Is_clear)
        {
            Time.timeScale = 0;
            clear_panel.SetActive(true);
            child = parent.GetComponentsInChildren<Transform>();
            for (int i = TowerManager.Instance.GetTowerNumber() + 1; i < child.Length; i++)
            {
                child[i].gameObject.SetActive(false);
            }
        }
        if (tower_count <= 0)
        {
            Time.timeScale = 0;
            over_panel.SetActive(true);
        }
    }


    public void ChangeClick()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
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
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        //ポーズUI表示
        pause_panel.SetActive(true);
        //ストップさせる
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        //ポーズUI隠す
        pause_panel.SetActive(false);
        //ストップ解除
        Time.timeScale = 1;
    }

    public void ChangeNextScene()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        //次のシーンをロード
        StartUI.scene_num++;
        SceneManager.LoadSceneAsync(StartUI.scene_num);
    }

    public void EndScene()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        //タイトルシーンロード
        StartUI.scene_num = 0;
        SceneManager.LoadSceneAsync(StartUI.scene_num);
    }

    public void SceneRestart()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        SceneManager.LoadSceneAsync(StartUI.scene_num);
    }
}
