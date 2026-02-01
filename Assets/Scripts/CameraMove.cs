using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.currentScene == "Game")
        {
            SoftMove("Game");
        }
    }

    void SoftMove(string targetScene)
    {
        if (targetScene == "Game")
        {
            Vector3 targetPosition = new Vector3(PlayerController.playerPos.position.x, 5f, -10f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 2f * Time.deltaTime);
        }
    }
}
