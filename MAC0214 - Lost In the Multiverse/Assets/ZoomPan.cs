using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ZoomPan : MonoBehaviour
{
    Vector3 MouseScrollStartPos;
    [SerializeField] private Transform myCamera;
    [SerializeField] private Camera mainCam;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float zoomStep, minCamSize, maxCamSize;
    [SerializeField] private Collider2D col;

    private Bounds boundsRenderer;

    private float boundMinX, boundMaxX, boundMinY, boundMaxY;

    void Awake()
    {

        boundsRenderer = col.bounds;
        boundMinX = boundsRenderer.center.x - boundsRenderer.extents.x;
        boundMaxX = boundsRenderer.center.x + boundsRenderer.extents.x;

        boundMinY = boundsRenderer.center.y - boundsRenderer.extents.y;
        boundMaxY = boundsRenderer.center.y + boundsRenderer.extents.y;
    }
    void LateUpdate()
    {


        Vector3 movement = Vector3.zero;

        if(Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            ZoomIn();
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0f )
        {
            ZoomOut();
        }

        if(Input.GetMouseButton(2))
        {
            MouseScrollStartPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            movement = myCamera.position - MouseScrollStartPos;
            //movement = new Vector3(movement.x,0,0); 
        }
        
        //myCamera.position -= movement * moveSpeed;
        myCamera.position = ClampCamera(mainCam.transform.position - movement * moveSpeed);

        
    }

    void ZoomIn()
    {
        float newSize = mainCam.orthographicSize + zoomStep;
        mainCam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
        myCamera.position = ClampCamera(mainCam.transform.position);

    }

    void ZoomOut()
    {
        float newSize = mainCam.orthographicSize - zoomStep;
        mainCam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
        myCamera.position = ClampCamera(mainCam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = mainCam.orthographicSize;
        float camWidht = mainCam.orthographicSize * mainCam.aspect;

        float minX = boundMinX + camWidht;
        float maxX = boundMaxX - camWidht;
        float minY = boundMinY + camHeight;
        float maxY = boundMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);

    }
}
