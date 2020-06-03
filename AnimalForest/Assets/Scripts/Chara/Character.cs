// K.Joudo. 2020
using UnityEngine;
using UnityEngine.AI;

// キャラクターの基底クラス
// 抽象クラスで作成
public abstract class Character : MonoBehaviour
{
    // アニメーションの状態
    public enum AnimaionType { idol, walk, attack, damage, death }

    protected enum CharacterType { animal, human}
    // 各種ステータスの構造体
    public struct Status
    {
        public float hp;
        public float power;
        public float defence;
        public float speed;
        public int cost;
        public string name;

        public Status(float h, float p, float d, float s, int c, string n)
        {
            hp = h;
            power = p;
            defence = d;
            speed = s;
            cost = c;
            name = n;
        }
    }

    public AnimaionType animation_type;
    protected CharacterType character_type;
    protected GameObject target_object;    // 攻撃目標
    protected Character target_character;
    protected NavMeshAgent agent;   // 目標へのNavMesh
    protected Animator anim;        // アニメーション
    protected Status status;        // 自分のステータス

    // アニメーションの代わりに死亡時間で判定
    protected float death_time;
    protected float attack_time;

    
    protected virtual void Start()
    {
        // 共通の初期設定
        animation_type = AnimaionType.walk;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        death_time = 0.0f;
        attack_time = 0.0f;
    }

    protected virtual void Update()
    {
        agent.SetDestination(target_object.transform.position);
        AnimationControl();

        // 死んだら死亡アニメーションが終わるとオブジェクトを消す
        // 今はアニメーションがないから時間経過で消している
        if(animation_type == AnimaionType.death)
        {
            death_time += Time.deltaTime;
            if(death_time >= 3.0)
            {
                Debug.Log("死んだ");
                Destroy(gameObject);
            }
        }

        if(animation_type == AnimaionType.attack)
        {
            Attack();
        }
        Debug.Log($"{status.name}のタイプ{animation_type}");
        //Debug.Log($"{status.name}のvelocity{agent.velocity}");
    }


    /// <summary>
    /// アニメーションの変更を制御する
    /// </summary>
    void AnimationControl()
    {
        // TODO ここのアニメーション処理はモデル完成後に作る
        // 今はタイプを変更するだけ
        float distance = Vector3.Distance(transform.position, target_object.transform.position);
        //Debug.Log($"{status.name}の対象との距離{distance}");

        if(status.hp <= 0.0f)
        {
            animation_type = AnimaionType.death;
            // ここで死亡アニメーションを再生
        }

        if(animation_type == AnimaionType.damage)
        {
            return;
        }

        // 近づいたら攻撃
        if(distance <= 10.0f)
        {
            animation_type = AnimaionType.attack;
            // とりあえず仮
            //anim.SetBool("isAttack", true);
            // 攻撃中は移動しない
            agent.velocity = Vector3.zero;
        }
        // 離れれば再び追いかける
        else if(distance > 10.0f)
        {
            animation_type = AnimaionType.walk;
            // とりあえず仮
            //anim.SetBool("isAttack", false);
        }

    }

    /// <summary>
    /// ターゲットの変更を行うメソッド
    /// </summary>
    protected abstract void ChangeTarget();

    /// <summary>
    /// 攻撃を行うメソッド
    /// </summary>
    protected virtual void Attack()
    {
        attack_time += Time.deltaTime;
        // 攻撃のアニメーションが終わると攻撃が完了
        // アニメーションが出来たらこの条件に変えておく
        //if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && 
        //    anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        if(attack_time >= 1.5f)
        {
            float damage = status.power - target_character.GetStatus().defence;
            if(damage <= 0)
            {
                damage = 1;
            }
            else
            {
                // 乱数によって振れ幅を付ける(-5, 5)
                float r = Random.Range(-5.0f, 6.0f);
                damage += r;
            }
            target_character.SetDamege(damage);

            attack_time = 0.0f;
        }
    }

    public Status GetStatus() { return status; }
    public void SetDamege(float d)
    {
        status.hp -= d;
        Debug.Log($"{status.name}:ダメージを受けた！残り{status.hp}");
        if(character_type == CharacterType.human)
        {
            animation_type = AnimaionType.damage;
        }
    }
}
