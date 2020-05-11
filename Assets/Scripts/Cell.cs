using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image mOutlineImage;
    [HideInInspector]
    public Vector2Int mBoardPosition = Vector2Int.zero;
    [HideInInspector]
    public Board board = null;
    [HideInInspector]
    public RectTransform mRectTransform = null;

    public void Setup(Vector2Int newmBoardPosition, Board newboard)
    {
        mBoardPosition = newmBoardPosition;
        board = newboard;

        mRectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
