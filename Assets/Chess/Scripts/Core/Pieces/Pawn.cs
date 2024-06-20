using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    List<Vector2Int> legalMoves = new List<Vector2Int>();
    public override List<Vector2Int> GetLegalMoves(Vector2Int currentPosition)
    {
        // Placeholder logic for pawn's legal moves
        AddToListForward(currentPosition.x, currentPosition.y + 1);
        if (currentPosition.y == 1)
        {
            AddToListForward(currentPosition.x, currentPosition.y + 2);
        }

        if(currentPosition.x+1<8)
        AddToListDiagonal(currentPosition.x + 1, currentPosition.y + 1);
        if(currentPosition.x-1>=0)
        AddToListDiagonal(currentPosition.x - 1, currentPosition.y + 1);
        
        return legalMoves;
    }

    void AddToListForward(int x, int y)
    {
        var tile = ChessBoardPlacementHandler.Instance.GetTile(y, x).transform;
       
        if (tile.tag != "Player" && tile.tag != "Enemy")
        {
            legalMoves.Add(new Vector2Int(x, y));
        }
    }
    void AddToListDiagonal(int x, int y)
    {
        var tile = ChessBoardPlacementHandler.Instance.GetTile(y, x).transform;

        if (tile.tag == "Enemy")
        {
            legalMoves.Add(new Vector2Int(x, y));
        }
    }
}