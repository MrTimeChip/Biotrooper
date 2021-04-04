using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 mousePos;
    public Transform playerTransform;
    private Camera _mainCamera;

    private float _xBordersDistance;
    private float _yBordersDistance;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        
        CalculateBorders();
    }

    private void CalculateBorders()
    {
        var dist = (transform.position - _mainCamera.transform.position).z;
        var leftBorder = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        
        var upperBorder = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = _mainCamera.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        _xBordersDistance = rightBorder - leftBorder; 
        _yBordersDistance = bottomBorder - upperBorder;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = _mainCamera.ScreenToWorldPoint(mousePos);
        var playerX = playerTransform.position.x;
        var playerY = playerTransform.position.y;

        var xMin = playerX - _xBordersDistance / 2f;
;       var xMax = playerX + _xBordersDistance / 2f;

        var yMin = playerY - _yBordersDistance / 2f;
        var yMax = playerY + _yBordersDistance / 2f;

        float newPosX, newPosY;
        if (Inventory.isInventoryOpened)
        {
            newPosX = Mathf.Clamp((playerTransform.position.x), xMin, xMax);
            newPosY = Mathf.Clamp((playerTransform.position.y), yMin, yMax);
        }
        else
        {
            newPosX = Mathf.Clamp((mousePos.x + playerTransform.position.x) / 2, xMin, xMax);
            newPosY = Mathf.Clamp((mousePos.y + playerTransform.position.y) / 2, yMin, yMax);
        }
        
        var newPoint = new Vector2(newPosX, newPosY);
        var lerpPoint = Vector2.Lerp(transform.position, newPoint, 0.01f);

        transform.position = new Vector3(lerpPoint.x, lerpPoint.y, transform.position.z);
    }
}
