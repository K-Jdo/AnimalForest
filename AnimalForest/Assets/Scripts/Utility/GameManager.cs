// K.Joudo 2020
using UnityEngine;
using UnityEngine.SceneManagement;

// ゲームを管理するクラス
public class GameManager : MonoBehaviour
{
    public bool Is_clear { private get; set; }
    public bool Is_boss_defeat { private get; set; }
    int tower_count = 3;
    int human_count = 0;

    private void Awake()
    {
        Is_clear = false;
        // シーンを切り替えても消えないようにする
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        human_count = HumanManager.Instance.GetHumanCount();
        if(tower_count <= 0)
        {
            // タワーがなくなるとゲームオーバーのフラグをたててシーンチェンジ
            Is_clear = false;
            SceneManager.LoadScene(3);
        }

        if(Is_boss_defeat && human_count <= 0)
        {
            Is_clear = true;
            SceneManager.LoadScene(3);
        }
    }


}
