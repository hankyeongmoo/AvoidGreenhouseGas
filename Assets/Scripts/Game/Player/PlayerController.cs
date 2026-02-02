using Unity.VectorGraphics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 상태")]
    static public int health;

    [Header("이동")]
    public float rotateSpeed = 360f * 10f;
    public float dashForce = 300f;
    public float dashCooldown = 3f;
    public float timer = 0f;
    private Rigidbody rb;
    float horizontalInput;

    [Header("플레이어 위치")]
    static public Transform playerPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        health = 30000;
    }

    void Update()
    {
        if (MySceneManager.currentScene == "Game")
        {
            playerPos = transform;
            horizontalInput = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (timer >= dashCooldown)
                {
                    rb.AddForce(new Vector3 (horizontalInput, 0.5f, 0f) * dashForce);
                    timer = 0f;
                }
            }
        }
        else if(MySceneManager.currentScene == "Explanation" || MySceneManager.currentScene == "Start")
        {
            horizontalInput = 0f;
            transform.position = new Vector3(0f, 1f, 0f);
            transform.rotation = Quaternion.identity;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        // 좌우 회전 (이동)
        Vector3 torque = Vector3.back * horizontalInput * rotateSpeed * Time.deltaTime;
        rb.AddTorque(torque);
    }
}
