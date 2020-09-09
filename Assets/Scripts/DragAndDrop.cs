using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    private GameObject _selectedPiece = null;
    private bool _isDragging;

    // Start is called before the first frame update
    void Start()
    {
        var sprite = Resources.Load<Sprite>("image.png");
        var images = GameObject.FindGameObjectsWithTag("image");
        foreach (var image in images)
        {
            image.GetComponent<Image>().sprite = sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            var isAPiece = hit.transform.CompareTag("piece");
            var isInRightPosition = hit.transform.GetComponent<PiecePosition>().InRightPosition;
            if (isAPiece && !isInRightPosition)
            {
                _selectedPiece = hit.transform.gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _selectedPiece = null;
            _isDragging = false;
        }

        if (_isDragging && !_selectedPiece.GetComponent<PiecePosition>().InRightPosition)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newMousePoint = new Vector3(mousePoint.x, mousePoint.y, 0);
            _selectedPiece.transform.position = newMousePoint;
        }
    }
}