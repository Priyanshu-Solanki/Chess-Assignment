using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    List<Vector2Int> legalMoves = new List<Vector2Int>();
    public override List<Vector2Int> GetLegalMoves(Vector2Int currentPosition)
    {
        bool forwardHit = false;
        bool backwardHit = false;
        bool leftHit = false;
        bool rightHit = false;
        bool forwardRightHit = false;
        bool forwardLeftHit = false;
        bool backwardRightHit = false;
        bool backwardLeftHit = false;

        // Queen's legal moves (combination of rook and bishop movements) within the boundaries (0 to 7)
        for (int i = 1; i <= 7; i++)
        {
            // Rook-like movements
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
                bool hit = AddToList(currentPosition.x, currentPosition.y+i);
                forwardHit = hit;
            }
            if (currentPosition.y - i >= 0 && !backwardHit)
            {
                bool hit = AddToList(currentPosition.x, currentPosition.y - i);
                backwardHit = hit;
            }

            // Bishop-like movements
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
            if(tile.tag == "Enemy")
            {
                legalMoves.Add(new Vector2Int(x, y));
            }
            return true;
        }
        legalMoves.Add(new Vector2Int(x, y));
        return false;
    }
}