// K.Joudo. 2020
using UnityEngine;
using UnityEngine.AI;

// キャラクターの基底クラス
// 抽象クラスで作成
public abstract class Character : MonoBehaviour
{
    // アニメーションの状態
    public enum AnimaionType { idol, walk, attack, damage, death }

    public enum CharacterType { animal, human, none}
    // 各種ステータスの構造体
    public struct Status
    {
        public int hp;
        public int power;
        public int defence;
        public float speed;
        public int cost;
        public string name;

        public Status(int h, int p, int d, float s, int c, string n)
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
    public CharacterType character_type;
    protected GameObject target_object;    // 攻撃目標
    protected Character target_character;
    protected NavMeshAgent agent;   // 目標へのNavMesh
    protected Animator anim;        // アニメーション

    Material default_material;
    protected Renderer my_renderer;
    [SerializeField] Material damage_material = null;
    const float DAMAGE_TIME = 0.5f;
    float damage_timer;
    bool is_damage;
    protected float range;

    protected Status status;        // 自分のステータス

    // アニメーションの代わりに死亡時間で判定
    protected float death_time;
    protected float attack_time;

    public bool can_speed_change;
    public float debug_speed;
    
    protected virtual void Awake()
    {
        // 共通の初期設定
        animation_type = AnimaionType.walk;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        my_renderer = GetComponent<Renderer>();
        default_material = my_renderer.material;

        range = 2.0f;

        death_time = 0.0f;
        attack_time = 20.0f;
        damage_timer = 0.0f;
        is_damage = false;

        SetSpeed(status.speed);
    }

    protected virtual void Update()
    {
        // デバッグ用のスピード変更
        if (can_speed_change)
        {
            SetSpeed(debug_speed);
        }

        // ターゲットがないなら何もしない
        if (target_object == null)
        {
            return;
        }

        if (is_damage)
        {
            damage_timer += Time.deltaTime;
            if(damage_timer >= DAMAGE_TIME)
            {
                my_renderer.material = default_material;
                damage_timer = 0.0f;
                is_damage = false;
            }
        }

        agent.SetDestination(target_object.transform.position);
        AnimationControl();

        // 死んだら死亡アニメーションが終わるとオブジェクトを消す
        // 今はアニメーションがないから時間経過で消している
        if(animation_type == AnimaionType.death)
        {
            death_time += Time.deltaTime;
            if(death_time >= 3.0)
            {
                Debug.Log($"{status.name}が死んだ");
                Sound.Instance.PlaySound(Sound.SoundName.death);
                Destroy(gameObject);
            }
        }

        if(animation_type == AnimaionType.attack)
        {
            // 攻撃中は移動しない
            agent.velocity = Vector3.zero;
            Attack();
        }
        //Debug.Log($"{status.name}のタイプ{animation_type}");
        //Debug.Log($"{status.name}のvelocity{agent.velocity}");
    }


    /// <summary>
    /// アニメーションの変更を制御する
    /// </summary>
    private void AnimationControl()
    {
        if(status.hp <= 0.0f)
        {
            animation_type = AnimaionType.death;
            // TODO ここで死亡アニメーションを再生
            SetSpeed(0);
            Destroy(gameObject);
            return;
        }

        // TODO ここのアニメーション処理はモデル完成後に作る
        // 今はタイプを変更するだけ
        float distance = Vector3.Distance(transform.position, target_object.transform.position);
        //Debug.Log($"{status.name}の対象との距離{distance}");


        if(animation_type == AnimaionType.damage)
        {
            return;
        }

        // 近づいたら攻撃
        if(distance <= range)
        {
            animation_type = AnimaionType.attack;
            // とりあえず仮
            //anim.SetBool("isAttack", true);
        }
        // 離れれば再び追いかける
        else if (distance > 5.0f)
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
            int damage = status.power - target_character.GetStatus().defence;
            if(damage <= 0)
            {
                damage = 1;
            }
            else
            {
                // 乱数によって振れ幅を付ける(-5, 5)
                int r = Random.Range(-5, 6);
                damage += r;
            }
            target_character.SetDamage(damage);
            //if(target_character.status.hp <= 0)
            //{
            //    target_object = null;
            //}
            attack_time = 0.0f;
        }
    }

    public Status GetStatus() { return status; }
    public virtual void SetDamage(int d)
    {
        //Debug.Log($"{status.name}が当たった。残りHP{status.hp}");
        if (this == null)
        {
            return;
        }
        Sound.Instance.PlaySound(Sound.SoundName.damage);
        my_renderer.material = damage_material;
        is_damage = true;
        status.hp -= d;
        //Debug.Log($"{status.hp}");
        //Debug.Log($"{status.name}:ダメージを受けた！残り{status.hp}");
        if (character_type == CharacterType.human && animation_type != AnimaionType.attack)
        {
            animation_type = AnimaionType.damage;
        }
    }

    public void SetSpeed(float s)
    {
        agent.speed = s;
    }
}
