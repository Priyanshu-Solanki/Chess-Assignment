using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ChessPiece selectedPiece;
    private List<Vector2Int> highlightedMoves = new List<Vector2Int>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                if (clickedObject.tag == "Player")
                {
                    ChessPiece chessPiece = clickedObject.GetComponent<ChessPiece>();
                    if (chessPiece != null)
                    {
                        ChessBoardPlacementHandler.Instance.ClearHighlights();
                        selectedPiece = chessPiece;
                        Debug.Log(selectedPiece);

                        Vector2Int clickedTile = GetTilePosition(clickedObject);
                        highlightedMoves = selectedPiece.GetLegalMoves(clickedTile);
                        HighlightTiles(highlightedMoves);
                    }
                }
            }
        }
    }

    Vector2Int GetTilePosition(GameObject clickedObject)
    {
        Debug.Log(clickedObject.transform.position);
        //Finding the position of the tile on which the gameobject is placed
        Vector2Int tilePosition = new Vector2Int((int)Mathf.Floor(clickedObject.transform.position.x) + 4, (int)Mathf.Floor(clickedObject.transform.position.y) + 4);
        Debug.Log("Row : " + tilePosition.y + ", Column : " + tilePosition.x);
        return tilePosition;

    }

    private void HighlightTiles(List<Vector2Int> tilesToHighlight)
    {
        foreach (Vector2Int tile in tilesToHighlight)
        {
            Debug.Log("Valid Move : " + tile);
            ChessBoardPlacementHandler.Instance.Highlight(tile.y, tile.x);
        }
    }
}
