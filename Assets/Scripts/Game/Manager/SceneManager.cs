using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [Header("캔버스 설정")]
    public Canvas canvas_start;
    public Canvas canvas_explanation;
    public Canvas canvas_badend;
    public Canvas canvas_goodend;

    [Header("씬 상태")] // 외부에서 접근 가능하도록 static으로 설정
    static public string currentScene = "Start";

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
