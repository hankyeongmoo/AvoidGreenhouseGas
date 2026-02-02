using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    [Header("캔버스 설정")]
    public Canvas canvas_start;
    public Canvas canvas_explanation;
    public Canvas canvas_badend;
    public Canvas canvas_goodend;

    [Header("외부 스크립트")]
    public CameraMove cameraMove;

    // static 변수는 유지하되, 값을 바꿀 때 실행될 함수를 만듭니다.
    static public string currentScene = "Start"; // Start, Explanation, BadEnd, GoodEnd

    void Awake()
    {
        // 1. 카메라 스크립트 참조
        if (cameraMove == null)
            cameraMove = GameObject.Find("Main Camera").GetComponent<CameraMove>();
        
        // 2. 초기 화면 설정
        currentScene = "Start";
        RefreshScene();
    }

    void Update()
    {
        if (currentScene == "BadEnd" || currentScene == "GoodEnd")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeScene("Start");
                PlayerController.health = 30000;
                ExplainImage.currentPage = 0;
            }
        }
    }

    // 외부(StartButton 등)에서 호출할 함수
    public void ChangeScene(string newScene)
    {
        currentScene = newScene;
        RefreshScene();
    }

    // 실제 화면을 갱신하는 함수 (필요할 때만 호출)
    private void RefreshScene()
    {
        // 모든 캔버스 우선 끄기
        canvas_start.enabled = false;
        canvas_explanation.enabled = false;
        canvas_badend.enabled = false;
        canvas_goodend.enabled = false;

        // 현재 상태에 맞는 것만 켜기
        if (currentScene == "Start")
        {
            canvas_start.enabled = true;
            cameraMove.isStart();
        }
        else if (currentScene == "Explanation")
        {
            canvas_explanation.enabled = true;
            cameraMove.isGame();
        }
        else if (currentScene == "BadEnd")
        {
            canvas_badend.enabled = true;
        }
        else if (currentScene == "GoodEnd")
        {
            canvas_goodend.enabled = true;
        }
        
        Debug.Log($"화면 갱신 완료: {currentScene}");
    }
}