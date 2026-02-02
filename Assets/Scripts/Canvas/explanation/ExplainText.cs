using UnityEngine;
using TMPro;

public class ExplainText : MonoBehaviour
{
    public TextMeshProUGUI myText;

    // ExplainImage.currentPage
    void Update()
    {
        myText.text = (ExplainImage.currentPage + 1).ToString() + " / 7";
    }
}
