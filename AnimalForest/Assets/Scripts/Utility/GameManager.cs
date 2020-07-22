// K.Joudo 2020

// ゲームを管理するクラス
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool Is_clear { private get; set; }
    public bool Is_boss_defeat { private get; set; }
    int tower_count = 3;
    int human_count = 0;

    protected override void Awake()
    {
        base.Awake();
        Is_clear = false;
    }

    private void Update()
    {
        human_count = HumanManager.Instance.GetHumanCount();
        if(tower_count <= 0)
        {
            // タワーがなくなるとゲームオーバーのフラグをたててシーンチェンジ
            Is_clear = false;
        }

        if(Is_boss_defeat && human_count <= 0)
        {
            // ボスを倒し、人間を全滅させるとクリア
            Is_clear = true;
        }
    }


}
