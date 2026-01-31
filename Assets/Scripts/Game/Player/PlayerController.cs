using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 30000;
    public float rotateSpeed = 100f;
    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rotation = Vector3.up * horizontalInput * rotateSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
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
        else if (other.CompareTag("HFC"))
        {
            health -= Random.Range(140, 11700);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("PFC"))
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
