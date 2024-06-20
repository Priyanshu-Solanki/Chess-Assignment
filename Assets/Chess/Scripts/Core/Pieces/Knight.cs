using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    List<Vector2Int> legalMoves = new List<Vector2Int>();
    public override List<Vector2Int> GetLegalMoves(Vector2Int currentPosition)
    {

        // Knight's legal moves (L-shaped) within the boundaries (0 to 7)
        int[] dx = { 1, 1, 2, 2, -1, -1, -2, -2 };
        int[] dy = { 2, -2, 1, -1, 2, -2, 1, -1 };

        for (int i = 0; i < 8; i++)
        {
            int x = currentPosition.x + dx[i];
            int y = currentPosition.y + dy[i];

            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                AddToList(x, y);
            }
        }

        return legalMoves;
    }

    void AddToList(int x, int y)
    {
        var tile = ChessBoardPlacementHandler.Instance.GetTile(y, x).transform;

        if (tile.tag == "Player")
        {
            return;
        }
        legalMoves.Add(new Vector2Int(x, y));
    }
}