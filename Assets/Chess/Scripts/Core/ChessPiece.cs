using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public abstract List<Vector2Int> GetLegalMoves(Vector2Int currentPosition);
}
