//S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    public void EndScene()
    {
        Sound.Instance.PlaySound(Sound.SoundName.decieded);
        //タイトルシーンロード
        StartUI.scene_num = 0;
        SceneManager.LoadSceneAsync(StartUI.scene_num);
    }
}
