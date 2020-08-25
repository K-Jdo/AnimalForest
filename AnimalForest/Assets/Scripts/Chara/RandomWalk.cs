// K.Joudo. 2020
using UnityEngine;
// タイトル画面でランダムに動く用
public class RandomWalk : MonoBehaviour
{
    [SerializeField] float walk_time = 5.0f;
    float elapsed_walk_time;
    [SerializeField] float rotate_time = 3.0f;
    float elapsed_rotate_time;
    [SerializeField] float speed = 0.01f;
    Vector3 move_vector;
    bool is_walk;
    bool is_rotate;

    const float STAGE_SIZE_X = 8.0f;
    const float STAGE_SIZE_Y = 6.0f;
    private void Awake()
    {
        elapsed_walk_time = 0.0f;
        elapsed_rotate_time = 9999.0f;
        move_vector = new Vector3(0.0f, 0.0f, speed);

        is_walk = true;
        is_rotate = false;

        // 最初に回転
        transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
    }

    void Update()
    {
        // 適当に動かす   
        if (is_walk)
        {
            // バウンスボールと同じ要領で壁際で反転
            if (transform.position.x >= STAGE_SIZE_X ||
                transform.position.x <= -STAGE_SIZE_X)
            {
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
            if (transform.position.z >= STAGE_SIZE_Y ||
                transform.position.z <= -STAGE_SIZE_Y)
            {
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }

            transform.Translate(move_vector);
            elapsed_walk_time += Time.deltaTime;
        }

        // 適当に回転
        if (is_rotate)
        {
            transform.Rotate(0.0f, 0.3f, 0.0f);
            elapsed_rotate_time += Time.deltaTime;
        }

        // 移動を終えたら回転
        if (elapsed_walk_time >= walk_time && is_walk)
        {
            is_walk = false;
            is_rotate = true;
            elapsed_rotate_time = 0.0f;
        }
        // 回転し終えたら移動
        else if (elapsed_rotate_time >= rotate_time && is_rotate)
        {
            is_rotate = false;
            is_walk = true;
            elapsed_walk_time = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
