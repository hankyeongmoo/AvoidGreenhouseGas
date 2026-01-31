using UnityEngine;

public class moveGHG : MonoBehaviour
{
    public float speed = 5f;
    public float addSpeed = 0.1f;

    void FixedUpdate()
    {
        // 이동
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        speed += addSpeed * Time.deltaTime;

        // 화면 밖으로 나가면 오브젝트 제거
        if (transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}
