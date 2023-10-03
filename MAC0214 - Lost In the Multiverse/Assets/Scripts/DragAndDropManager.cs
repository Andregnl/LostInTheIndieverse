using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    private GameObject dragObject;
    private Vector3 mouseOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.CompareTag("DragDrop"))
            {
                dragObject = targetObject.transform.gameObject;
                mouseOffset = dragObject.transform.position - mousePosition;
            }
        }

        if (dragObject)
        {
            dragObject.transform.position = mousePosition + mouseOffset;
        }

        if (Input.GetMouseButtonUp(0) && dragObject)
        {
            ((DragAndDropItem) dragObject.GetComponent(typeof(DragAndDropItem))).Drop();

            mouseOffset = new Vector3(0, 0, 0);
            dragObject = null;
        }
    }
}
