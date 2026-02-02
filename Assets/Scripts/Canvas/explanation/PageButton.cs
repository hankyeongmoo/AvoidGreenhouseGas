using UnityEngine;

public class PageButton : MonoBehaviour
{
    int imageCount = 7;
    public MySceneManager sceneManager;

    public void OnClickNext()
    {
        ExplainImage.currentPage++;
        if (ExplainImage.currentPage >= imageCount)
        {
            if (sceneManager != null)
            {
                sceneManager.ChangeScene("Game");
            }
            else
            {
                Debug.LogError("SceneManager가 연결되지 않았습니다!");
            }
        }
    }

    public void OnClickUndo()
    {
        
        if (ExplainImage.currentPage > 0)
        {
            ExplainImage.currentPage--;
        }
    }
}
