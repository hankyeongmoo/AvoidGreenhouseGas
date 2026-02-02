using UnityEngine;
using System.Collections; // 코루틴을 위해 필요합니다!

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Coroutine moveCoroutine;

    public void isGame()
    {
        StopCurrentMove();
        moveCoroutine = StartCoroutine(MoveCamera(3f));
    }

    public void isStart()
    {
        StopCurrentMove();
        moveCoroutine = StartCoroutine(MoveCamera(15f));
    }

    private void StopCurrentMove()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
    }

    // 부드러운 이동을 담당하는 핵심 로직
    IEnumerator MoveCamera(float targetY)
    {
        Vector3 targetPos = new Vector3(transform.position.x, targetY, transform.position.z);

        // 목표 지점에 거의 도달할 때까지 반복 (매 프레임 조금씩 이동)
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null; // 중요! 한 프레임을 쉬고 다음 프레임에 이어서 실행함
        }

        transform.position = targetPos; // 마지막 위치 보정
    }
}