//S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Assertions.Must;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //複製したいものを入れる
    public GameObject obj;
    //クリックされたオブジェクトを入れる
    GameObject draged_object;
    //ドラッグしたい画像を入れる
    [SerializeField]
    private Image drag_obj = null;
    //複製した画像
    private Image image_obj;
    //画像複製するための変数
    private Transform image_transform;
    //使うコスト
    public int use_cost;
    //テキストを表示
    public Text use_cost_text;
    //配置上限数
    public int max_num;
    //現在配置している数
    private int obj_num = 0;
    private List<GameObject> obj_nums = new List<GameObject>();
    //レイ
    private Ray ray;
    //クリックされた座標を格納する
    private RaycastHit hit;
    //
    private string obj_name;
    [SerializeField]
    [Header("動物へ使用するギミック")]
    private bool to_animal = false;
    [SerializeField]
    [Header("敵へ使用するギミック")]
    private bool to_enemy = false;
    [SerializeField]
    [Header("ステージへ使用するギミック")]
    private bool to_stage = false;

    private void Start()
    {
        //ボタンにテキスト表示
        use_cost_text.text = use_cost.ToString() + "P";
        //canvasを探す
        image_transform = FindObjectOfType<UI>().transform;
        if (to_animal)
        {
            obj_name = "CharaAnimal";
        }
        if (to_enemy)
        {
            obj_name = "CharaEnemy";
        }
        if (to_stage)
        {
            obj_name = "Stage";
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //画像複製
        image_obj = Instantiate(drag_obj, image_transform);
        image_obj.color = new Color(0.7f, 0.5f, 0.5f, 0.6f);
        image_obj.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //画像をマウスに追従させる
        image_obj.transform.position = Input.mousePosition;
        //スクリーンから見たマウスの座標を得る
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //rayが当たっていたら
        if (Physics.Raycast(ray, out hit))
        {
            //今マウスポインターに当たっているゲームオブジェクト
            draged_object = hit.collider.gameObject;
            //マウスポインターのある場所が指定されたタグであれば
            if (draged_object.CompareTag(obj_name))
            {
                if (CostManager.Instance.cost >= use_cost)
                {
                    if (max_num > obj_num)
                    {
                        image_obj.color = new Color(0.0f, 0.5f, 0.0f, 0.6f);
                    }
                }
            }
            else
            {
                image_obj.color = new Color(0.7f, 0.5f, 0.5f, 0.6f);
            }
        }
        else
        {
            image_obj.color = new Color(0.7f, 0.5f, 0.5f, 0.6f);
        }
        image_obj.transform.SetAsLastSibling();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //複製した画像を削除
        Destroy(image_obj.gameObject);
        //スクリーンから見たマウスの座標を得る
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //rayが当たっていたら
        if (Physics.Raycast(ray, out hit))
        {
            //クリックされた座標
            Vector3 pos = hit.point;
            //ドロップされたゲームオブジェクト
            draged_object = hit.collider.gameObject;
            //ドロップ時が指定されたタグであれば
            if (draged_object.CompareTag(obj_name))
            {
                if (CostManager.Instance.cost >= use_cost)
                {
                    if (max_num > obj_num)
                    {
                        //オブジェクトを複製
                        obj_nums.Add(Instantiate(obj, pos, Quaternion.identity));
                        CostManager.Instance.cost -= use_cost;
                        obj_num++;
                        Sound.Instance.PlaySound(Sound.SoundName.spawn);
                        return;
                    }
                }
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
