using System;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;

        private void Start() {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
            //Added linr for giving tag to tile based on the gameobject placed on it
            ChessBoardPlacementHandler.Instance.GetTile(row, column).tag = gameObject.tag;
        }
    }
}