using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class BaseFigure : MonoBehaviour
{
    public Color color = Color.clear;
    protected Cell currentCell = null;
    protected Cell originalCell = null;
    protected RectTransform rectTransform = null;
    protected FigureManager figureManager;

    public virtual void Setup(Color newTeamColor, Color32 newSpriteColor,FigureManager newFigureManager)
    {
        color = newTeamColor;
        figureManager = newFigureManager;

        GetComponent<Image>().color = newSpriteColor;
        rectTransform = GetComponent<RectTransform>();
    }

    public void Place(Cell cell)
    {
        currentCell = cell;
        originalCell = cell;
        currentCell.currentFigure = this;

        transform.position = cell.transform.position;
        gameObject.SetActive(true);
    }

}
