// K.Joudo. 2020
using System.Collections.Generic;
using System.Linq;
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
    List<Renderer> child_renderer_list = new List<Renderer>();
    [SerializeField] Material damage_material = null;
    const float DAMAGE_TIME = 0.5f;
    float damage_timer;
    bool is_damage;
    protected float range;

    protected Status status;        // 自分のステータス

    // アニメーションの代わりに死亡時間で判定
    protected float death_time;
    protected float attack_time;

    // デバッグ用
    public bool can_speed_change;
    public float debug_speed;
    
    protected virtual void Awake()
    {
        // 共通の初期設定
        animation_type = AnimaionType.walk;
        agent = GetComponent<NavMeshAgent>();

        // アニメーションのためにモデルを子供に置く
        GameObject obj = transform.GetChild(0).gameObject;
        anim = obj.GetComponent<Animator>();
        default_material = GetComponent<Renderer>().material;

        // 子供のレンダラーをすべて取得
        var child_objects = GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();
        foreach(GameObject child in child_objects)
        {
            // レンダラーがなければ削除する
            if (child.GetComponent<Renderer>() == null)
            {
                continue;
            }
            child_renderer_list.Add(child.GetComponent<Renderer>());
        }

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

        AnimationControl();
        
        // ダメージを受けていたらマテリアルを使って表現
        if (is_damage)
        {
            damage_timer += Time.deltaTime;
            if(damage_timer >= DAMAGE_TIME)
            {
                for(int i = 0; i < child_renderer_list.Count; i++)
                {
                    child_renderer_list[i].material = default_material;
                }
                damage_timer = 0.0f;
                is_damage = false;
            }
        }

        // ターゲットがないなら何もしない
        if (target_object == null)
        {
            return;
        }

        // navメッシュの処理ができるかを判定
        if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            agent.SetDestination(target_object.transform.position);
        }

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
    }


    /// <summary>
    /// アニメーションの変更を制御する
    /// </summary>
    private void AnimationControl()
    {
        if(status.hp <= 0.0f)
        {
            Deth();
            return;
        }

        // ターゲットが見つからないならアイドル状態に
        if(target_object == null)
        {
            animation_type = AnimaionType.idol;
            anim.SetBool("isAttack", false);
            anim.SetBool("isIdol", true);
            return;
        }

        float distance = Vector3.Distance(transform.position, target_object.transform.position);

        if(animation_type == AnimaionType.damage)
        {
            return;
        }

        // 近づいたら攻撃
        if(distance <= range)
        {
            animation_type = AnimaionType.attack;
            // とりあえず仮
            anim.SetBool("isAttack", true);
        }
        // 離れれば再び追いかける
        else if (distance > 5.0f || animation_type != AnimaionType.attack)
        {
            animation_type = AnimaionType.walk;
            // とりあえず仮
            anim.SetBool("isAttack", false);
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
        if (attack_time >= 1.5f)
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
            attack_time = 0.0f;
        }
    }

    public Status GetStatus() { return status; }

    /// <summary>
    /// ダメージを受けるメソッド(ダメージ量, ギミックかどうか)
    /// </summary>
    /// <param name="d"></param>
    /// <param name="gimick"></param>
    public void SetDamage(int d, bool gimick = false)
    {
        if (this == null)
        {
            return;
        }
        status.hp -= d;
        // ギミックだと音と、ダメージの表現がなし
        if (gimick && character_type == CharacterType.human)
        {
            return;
        }
        Sound.Instance.PlaySound(Sound.SoundName.damage);
        // 他の部位も色を変更
        for (int i = 0; i < child_renderer_list.Count; i++)
        {
            child_renderer_list[i].material = damage_material;
        }

        is_damage = true;
        // 人間ならタイプをダメージに変更
        if (character_type == CharacterType.human && animation_type != AnimaionType.attack)
        {
            animation_type = AnimaionType.damage;
        }
    }

    protected virtual void Deth()
    {
        animation_type = AnimaionType.death;
        SetSpeed(0);
        Destroy(gameObject);
    }

    public void SetSpeed(float s)
    {
        agent.speed = s;
    }
}
