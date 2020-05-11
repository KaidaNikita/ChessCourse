using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.CoreModule;

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;

    public Cell[,] mAllCells = new Cell[8, 8];
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject newCell = Instantiate(mCellPrefab, transform);
           
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 50);
                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x, y].Setup(new Vector2Int(x, y), this);
            }
        }

        for (int x = 0; x < 8; x+=2)
        {
            for (int y = 0; y < 8; y++)
            {
                int offset = (y % 2 != 0) ? 0 : 1;
                int finalX = x + offset;
                mAllCells[finalX, y].GetComponent<Image>().color = new Color32(230, 220, 187, 255);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
