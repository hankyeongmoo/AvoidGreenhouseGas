using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 30000;
    public float rotateSpeed = 360f * 10f;
    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // 좌우로 구르려면 회전축은 Vector3.back(또는 forward)이 맞습니다.
        Vector3 torque = Vector3.back * horizontalInput * rotateSpeed * Time.deltaTime;

        // 물리적인 회전력을 가합니다. 
        // 바닥과 접촉해 있다면 마찰력에 의해 자동으로 좌우로 이동합니다.
        rb.AddTorque(torque);
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 GHG에 따라 체력 감소
        if (other.CompareTag("CO2"))
        {
            health -= 1;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("CH4"))
        {
            health -= 21;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("N2O"))
        {
            health -= 310;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("HFCs"))
        {
            health -= Random.Range(140, 11700);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("PFCs"))
        {
            health -= Random.Range(6500, 9200);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("SF6"))
        {
            health -= 23900;
            Destroy(other.gameObject);
        }

        // 체력 0 이하 체크
        if (health <= 0)
        {
            Debug.Log("게임 오버!");
        }
    }
}
