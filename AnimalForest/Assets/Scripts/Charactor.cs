// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キャラクターの基底クラス
// 抽象クラスで作成
public abstract class Charactor : MonoBehaviour
{
    public enum AnimaionType { idol, attack, death }

    protected AnimaionType type;
    protected float hp;
    protected float power;
    protected float speed;
    protected float defence;
    
    // TODO ステージが出来たらNavmeshの動作を追加する

    void Start()
    {
        // 
        type = AnimaionType.idol;
    }

    void Update()
    {
        
    }


}
