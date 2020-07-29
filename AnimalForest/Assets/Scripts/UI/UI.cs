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
    //遊び方UI
    [SerializeField]
    private GameObject help_canvas = null;
    //遊び方画像の親
    [SerializeField]
    private Transform parent = null;
    //遊び方の子
    private Transform[] child;
    //読み込むシーン番号
    private static int scene_num = 0;
    //遊び方番号
    private int help_num = 1;
    private void Update()
    {
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
        Time.timeScale = 1;
        //次のシーンをロード
        scene_num++;
        SceneManager.LoadSceneAsync(scene_num);


    }

    public void EndScene()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        //タイトルシーンロード
        scene_num = 0;
        SceneManager.LoadSceneAsync(scene_num);
    }

    public void HelpClick()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        //遊び方表示
        help_canvas.SetActive(true);
        child = parent.GetComponentsInChildren<Transform>();
        for (int i = 2; i < child.Length; i++)
        {
            child[i].gameObject.SetActive(false);
        }
    }

    public void RemoveHelpClick()
    {
        Sound.Instance.PlaySound(Sound.SoundName.cansel);
        //遊び方非表示
        help_canvas.SetActive(false);
    }

    public void HelpNextClick()
    {

        if (help_num < child.Length - 1)
        {
            Sound.Instance.PlaySound(Sound.SoundName.decieded);
            child[help_num].gameObject.SetActive(false);
            help_num++;
            child[help_num].gameObject.SetActive(true);
        }
    }

    public void HelpReturnClick()
    {
        if (help_num > 1)
        {
            Sound.Instance.PlaySound(Sound.SoundName.decieded);
            child[help_num].gameObject.SetActive(false);
            help_num--;
            child[help_num].gameObject.SetActive(true);
        }
    }
}
