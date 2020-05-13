using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BaseFigure : EventTrigger
{
    public Color color = Color.clear;
    protected Cell currentCell = null;
    protected Cell originalCell = null;
    protected RectTransform rectTransform = null;
    protected FigureManager figureManager;

    protected Vector3Int mMovement = Vector3Int.one;
    protected List<Cell> hightlightedCells = new List<Cell>();

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

    private void CreateCellPath(int xDiraction, int yDiraction, int movement)
    {
        int currentX = currentCell.mBoardPosition.x;
        int currentY = currentCell.mBoardPosition.y;

        for (int i = 1; i < movement; i++)
        {
            currentX += xDiraction;
            currentY += yDiraction;
        }
        hightlightedCells.Add(currentCell.board.mAllCells[currentX, currentY]);
    }

    protected virtual void CheckPathing()
    {
        CreateCellPath(1, 0, mMovement.x);
        CreateCellPath(-1, 0, mMovement.x);

        CreateCellPath(0, 1, mMovement.y);
        CreateCellPath(0, -1, mMovement.y);

        CreateCellPath(1, 1, mMovement.z);
        CreateCellPath(-1, 1, mMovement.z);

        CreateCellPath(-1, -1, mMovement.z);
        CreateCellPath(1, -1, mMovement.z);
    }

    protected void ShowCells()
    {
        foreach (Cell cell in hightlightedCells)
        {
            cell.mOutlineImage.enabled = true;
        }
    }

    protected void ClearCells()
    {
        foreach (Cell cell in hightlightedCells)
        {
            cell.mOutlineImage.enabled = false;
        }
        hightlightedCells.Clear();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        CheckPathing();

        ShowCells();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        transform.position += (Vector3)eventData.delta;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ClearCells();
    }

}
