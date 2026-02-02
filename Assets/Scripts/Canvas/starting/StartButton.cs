using UnityEngine;

public class StartButton : MonoBehaviour
{
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