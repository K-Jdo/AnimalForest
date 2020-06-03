// K.Joudo. 2020
using UnityEngine;
using UnityEngine.AI;

// キャラクターの基底クラス
// 抽象クラスで作成
public abstract class Character : MonoBehaviour
{
    // アニメーションの状態
    public enum AnimaionType { idol, walk, attack, damage, death }
    // 各種ステータスの構造体
    public struct Status
    {
        public float hp;
        public float power;
        public float speed;
        public float defence;
        public int cost;

        public Status(float h, float p, float s, float d, int c)
        {
            hp = h;
            power = p;
            speed = s;
            defence = d;
            cost = c;
        }
    }

    public AnimaionType type;
    protected GameObject target;    // 攻撃目標
    protected NavMeshAgent agent;   // 目標へのNavMesh
    protected Animator anim;       // アニメーション
    protected Status status;    // 自分のステータス

    
    // TODO ステージが出来たらNavmeshの動作を追加する

    protected virtual void Start()
    {
        // 共通の初期設定
        type = AnimaionType.idol;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        AnimationControl();
        if(type == AnimaionType.walk)
        {
            agent.SetDestination(target.transform.position);
        }
    }


    /// <summary>
    /// アニメーションの変更を制御する
    /// </summary>
    protected virtual void AnimationControl()
    {
        // TODO ここのアニメーション処理はモデル完成後に作る
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance <= 10.0f)
        {
            type = AnimaionType.attack;
            // とりあえず仮
            //anim.SetBool("isAttack", true);
        }
        else if(distance > 10.0f && type == AnimaionType.attack)
        {
            type = AnimaionType.attack;
            // とりあえず仮
            //anim.SetBool("isAttack", false);
        }

        if(status.hp <= 0.0f)
        {
            type = AnimaionType.death;
            // ここで死亡アニメーションを再生
            // 再生が終わると消去
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ターゲットの変更を行うメソッド
    /// </summary>
    protected abstract void ChangeTarget();

    public Status GetStatus() { return status; }

    protected void OnCollisionEnter(Collision collision)
    {
        // 判定方法はとりあえずタグにしてある
        // 今後の作業により変更あるかも
        if (collision.transform.tag.Contains("chara"))
        {
            // ダメージの計算
            // ここうまく動くか不安なので要テスト
            float enemy_power = collision.transform.GetComponent<Character>().GetStatus().power;
            float damage = enemy_power - status.defence;
            if(damage <= 0)
            {
                // 最低値は1
                damage = 1;
            }
            else
            {
                // 乱数によって振れ幅を付ける(-5, 5)
                float r = Random.Range(-5.0f, 6.0f);
                damage += r;
            }

            status.hp -= damage;

            if(type == AnimaionType.walk)
            {
                type = AnimaionType.damage;
            }
        }
    }
}
