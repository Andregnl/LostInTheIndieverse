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
			DragAndDropItem dragAndDropItem = (DragAndDropItem) dragObject.GetComponent(typeof(DragAndDropItem));
            dragAndDropItem.Drop();

			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D[] targetObjects = Physics2D.OverlapPointAll(mousePosition);

			if (targetObjects.Length > 0)
			{
				foreach (var obj in targetObjects)
				{
					if (obj.CompareTag("Slot"))
					{
						obj.GetComponent<Slot>().OnDrop(dragAndDropItem);
					}
				}
			}

            mouseOffset = new Vector3(0, 0, 0);
            dragObject = null;
        }
    }
}
