using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExplainImage : MonoBehaviour
{
    [SerializeField] public List<Sprite> images;
    static public int currentPage = 0;
    public Image myImage;
    
    void Awake()
    {
        currentPage = 0;
    }

    void Update()
    {
        if (currentPage < 7)
        {
            myImage.sprite = images[currentPage];
        }
    }
}
