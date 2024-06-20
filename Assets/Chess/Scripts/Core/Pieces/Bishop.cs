using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    List<Vector2Int> legalMoves = new List<Vector2Int>();
    public override List<Vector2Int> GetLegalMoves(Vector2Int currentPosition)
    {
        bool forwardRightHit = false;
        bool forwardLeftHit = false;
        bool backwardRightHit = false;
        bool backwardLeftHit = false;

        // Bishop's legal moves (diagonal movements) within the boundaries (0 to 7)
        for (int i = 1; i <= 7; i++)
        {
            if (currentPosition.x + i <= 7 && currentPosition.y + i <= 7 && !forwardRightHit)
            {
                bool hit = AddToList(currentPosition.x + i, currentPosition.y + i);
                forwardRightHit = hit;
            }
            if (currentPosition.x + i <= 7 && currentPosition.y - i >= 0 && !backwardRightHit)
            {
                bool hit = AddToList(currentPosition.x + i, currentPosition.y - i);
                backwardRightHit = hit;
            }
            if (currentPosition.x - i >= 0 && currentPosition.y + i <= 7 && !forwardLeftHit)
            {
                bool hit = AddToList(currentPosition.x - i, currentPosition.y + i);
                forwardLeftHit = hit;
            }
            if (currentPosition.x - i >= 0 && currentPosition.y - i >= 0 && !backwardLeftHit)
            {
                bool hit = AddToList(currentPosition.x - i, currentPosition.y - i);
                backwardLeftHit = hit;
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
