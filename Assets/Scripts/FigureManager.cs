using System;
using System.Collections.Generic;
using UnityEngine;

public class FigureManager : MonoBehaviour
{
    public GameObject figurePrefab;

    private List<BaseFigure> whiteFigures = null;
    private List<BaseFigure> blackFigures = null;

    private string[] figureOrder = new string[16]
     {
        "P", "P", "P", "P", "P", "P", "P", "P",
        "R", "KN", "B", "K", "Q", "B", "KN", "R"
     };

    private Dictionary<string, Type> figureLibrary = new Dictionary<string, Type>()
    {
        {"P",  typeof(Pawn)},
        {"R",  typeof(Rook)},
        {"KN", typeof(Knight)},
        {"B",  typeof(Bishop)},
        {"K",  typeof(King)},
        {"Q",  typeof(Queen)}
    };

    public void Setup(Board board)
    {
        whiteFigures = CreateFigures(Color.white, new Color32(80, 124, 159, 255), board);
        blackFigures = CreateFigures(Color.black, new Color32(210, 95, 64, 255), board);

        PlaceFigures(1, 0, whiteFigures, board);
        PlaceFigures(6, 7, blackFigures, board);
    }

    private List<BaseFigure> CreateFigures(Color teamColor, Color32 spriteColor, Board board)
    {
        List<BaseFigure> newFigures = new List<BaseFigure>();
        for (int i = 0; i < figureOrder.Length; i++)
        {
            GameObject newFigure = Instantiate(figurePrefab);
            newFigure.transform.SetParent(transform);

            newFigure.transform.localScale = new Vector3(1, 1, 1);
            newFigure.transform.localRotation = Quaternion.identity;

            string key = figureOrder[i];
            Type figureType = figureLibrary[key];

            BaseFigure figure = (BaseFigure)newFigure.AddComponent(figureType);
            newFigures.Add(figure);

            figure.Setup(teamColor, spriteColor, this);
        }
        return newFigures;
    }

    private void PlaceFigures(int pawnRow, int royaltyRow, List<BaseFigure> pieces, Board board)
    {
        for (int i = 0; i < 8; i++)
        {
            pieces[i].Place(board.mAllCells[i, pawnRow]);

            pieces[i+8].Place(board.mAllCells[i, royaltyRow]);
        }
    }
}
