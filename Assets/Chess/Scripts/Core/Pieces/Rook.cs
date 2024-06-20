using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    List<Vector2Int> legalMoves = new List<Vector2Int>();
    public override List<Vector2Int> GetLegalMoves(Vector2Int currentPosition)
    {
        bool forwardHit = false;
        bool backwardHit = false;
        bool leftHit = false;
        bool rightHit = false;

        // Rook's legal moves (horizontal and vertical movements) within the boundaries (0 to 7)
        for (int i = 1; i <= 7; i++)
        {
            if (currentPosition.x + i <= 7 && !rightHit)
            {
                bool hit = AddToList(currentPosition.x + i, currentPosition.y);
                rightHit = hit;
            }
            if (currentPosition.x - i >= 0 && !leftHit)
            {
                bool hit = AddToList(currentPosition.x - i, currentPosition.y);
                leftHit = hit;
            }
            if (currentPosition.y + i <= 7 && !forwardHit)
            {
                bool hit = AddToList(currentPosition.x, currentPosition.y + i);
                forwardHit = hit;
            }
            if (currentPosition.y - i >= 0 && !backwardHit)
            {
                bool hit = AddToList(currentPosition.x, currentPosition.y - i);
                backwardHit = hit;
            }
        }

        return legalMoves;
    }

    bool AddToList(int x, int y)
    {
        var tile = ChessBoardPlacementHandler.Instance.GetTile(y, x).transform;
        if (tile.tag == "Player" || tile.tag == "Enemy")
        {
            if (tile.tag == "Enemy")
            {
                legalMoves.Add(new Vector2Int(x, y));
            }
            return true;
        }
        legalMoves.Add(new Vector2Int(x, y));
        return false;
    }
}