using UnityEngine;

public class moveGHG : MonoBehaviour
{
    [Header("속도 설정")]
    public float speed = 5f;
    public float addSpeed = 0.1f;

    [Header("데미지 설정")]
    private int damage;
    public int damageMax;
    public int damageMin;

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

        // 플레이어 위치 기준으로 가까운 범위 내에 있을 때에만 충돌 계산
        if (PlayerController.playerPos.position.x + 1.5f > transform.position.x
            && transform.position.x > PlayerController.playerPos.position.x - 1.5f
            && transform.position.y < 2.5f)
        {
            float distance = Vector3.Distance(transform.position, PlayerController.playerPos.position);
            if (distance < 1.5f)
            {
                damage = Random.Range(damageMin, damageMax + 1);
                PlayerController.health -= damage;

                // 체력 0 이하 체크
                if (PlayerController.health <= 0)
                {
                    SceneManager.currentScene = "BadEnd";
                    Debug.Log("배드 엔딩");
                }

                Destroy(gameObject);
            }
        }
    }
}
