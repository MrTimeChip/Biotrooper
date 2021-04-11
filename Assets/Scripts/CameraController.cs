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

    [SerializeField]
    private float _leftLimit;
    [SerializeField]
    private float _rightLimit;
    [SerializeField]
    private float _bottomLimit;
    [SerializeField]
    private float _topLimit;


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

        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit),
                Mathf.Clamp(transform.position.y, _bottomLimit, _topLimit),
                transform.position.z
            ); 
    }

    private void OnDrawGizmos()
    {
        _mainCamera = Camera.main;
        CalculateBorders();

        float leftLim = _leftLimit - _xBordersDistance / 2f;
        float rightLim = _rightLimit + _xBordersDistance / 2f;
        float bottomLim = _bottomLimit - _yBordersDistance / 2f;
        float topLim = _topLimit + _yBordersDistance / 2f;

        Gizmos.color = Color.red;
        // Left
        Gizmos.DrawLine(new Vector2(leftLim, bottomLim), new Vector2(leftLim, topLim));
        // Right
        Gizmos.DrawLine(new Vector2(rightLim, bottomLim), new Vector2(rightLim, topLim));
        // Top
        Gizmos.DrawLine(new Vector2(leftLim, topLim), new Vector2(rightLim, topLim));
        // Down
        Gizmos.DrawLine(new Vector2(leftLim, bottomLim), new Vector2(rightLim, bottomLim));
    }
}
