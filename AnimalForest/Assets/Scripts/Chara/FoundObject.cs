// K.Joudo. 2020
using System;
using System.Collections.Generic;
using UnityEngine;

// 参考：うら干物書き
//      【Unity】さあ、索敵を始めよう
namespace MyScript
{
    // 範囲内で発見したオブジェクトを管理するクラス
    class FoundObject
    {
        private GameObject my_object = null;
        public GameObject Obj
        {
            get { return my_object; }
        }
        private bool is_current_found = false;  // 今フレームの索敵情報
        private bool is_prev_found = false;     // 前フレームの索敵情報

        public FoundObject(GameObject obj)
        {
            my_object = obj;
        }

        public Vector3 Position
        {
            get { return Obj != null ? Obj.transform.position : Vector3.zero; }
        }

        public void Update(bool i_isFound)
        {
            is_prev_found = is_current_found;
            is_current_found = i_isFound;
        }

        public bool IsFound()
        {
            // 前回見つからず、今回見つけた場合「発見」
            return is_current_found && !is_prev_found;
        }

        public bool IsLost()
        {
            // 今回見つからず、前回見つかった場合「見失った」
            return !is_current_found && is_prev_found;
        }

        public bool IsCurrentFound()
        {
            return is_current_found;
        }
    }
}
