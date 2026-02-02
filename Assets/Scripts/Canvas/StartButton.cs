using UnityEngine;

public class StartButton : MonoBehaviour
{
    // 인스펙터에서 MySceneManager 오브젝트를 드래그해서 연결하세요!
    public MySceneManager sceneManager;

    public void OnStartButtonClicked()
    {
        if (sceneManager != null)
        {
            sceneManager.ChangeScene("Explanation");
        }
        else
        {
            Debug.LogError("SceneManager가 연결되지 않았습니다!");
        }
    }
}