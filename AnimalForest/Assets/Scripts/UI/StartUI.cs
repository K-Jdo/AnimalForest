//S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    //遊び方UI
    [SerializeField]
    private GameObject help_canvas = null;
    //遊び方画像の親
    [SerializeField]
    private Transform parent = null;
    //遊び方の子
    private Transform[] child;
    //遊び方番号
    private int help_num = 1;
    //読み込むシーン番号
    public static int scene_num = 0;

    public void ChangeNextScene()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        //次のシーンをロード
        scene_num++;
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

    public void EndGame()
    {
        Application.Quit();
    }
}
