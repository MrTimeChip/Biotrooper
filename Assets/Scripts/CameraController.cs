using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 mousePos;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        float newPosX = (mousePos.x + playerTransform.position.x) / 2;
        float newPosY = (mousePos.y + playerTransform.position.y) / 2;
        Vector2 newPoint = new Vector2(newPosX, newPosY);
        Vector2 lerpPoint = Vector2.Lerp(transform.position, newPoint, 0.01f);

        transform.position = new Vector3(lerpPoint.x, lerpPoint.y, transform.position.z);
    }
}
