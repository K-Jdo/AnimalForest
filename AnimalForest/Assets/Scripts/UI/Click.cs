// S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Click : MonoBehaviour
{
    //複製したいものを入れる
    public GameObject obj;
    //使うコスト
    public int use_cost;
    //テキストを表示
    public Text use_cost_text;
    //配置上限数
    public int max_num;
    //現在配置している数
    private int obj_num = 0;
    private List<GameObject> obj_nums = new List<GameObject>();
    //ツリーを入れる
    private GameObject tree;
    //ポジションを入れる
    private Vector3 pos;
   
    private void Start()
    {

        //ボタンにテキスト表示
        use_cost_text.text = use_cost.ToString() + "P";
        tree = GameObject.Find("wood2");
        pos = tree.transform.position;
        pos.x -= 1f;
        pos.z += 1.5f;
    }

    //ボタンを押したときの処理
    public void OnClicked()
    {
        if (CostManager.Instance.cost >= use_cost)
        {
            if (max_num > obj_num)
            {
                //オブジェクトを複製
                obj_nums.Add(Instantiate(obj, pos, Quaternion.identity));
                AnimalManager.Instance.SetAnimal(obj_nums.Last());
                CostManager.Instance.cost -= use_cost;
                obj_num++;
                Sound.Instance.PlaySound(Sound.SoundName.spawn);
                return;
            }
           
        }  
            Sound.Instance.PlaySound(Sound.SoundName.cansel);
    }

    private void Update()
    {
        for (int i = 0; i < obj_nums.Count; i++)
        {
            if (obj_nums[i] == null)
            {
                obj_nums.RemoveAt(i);
                obj_num -= 1;
            }
        }
    }
}
