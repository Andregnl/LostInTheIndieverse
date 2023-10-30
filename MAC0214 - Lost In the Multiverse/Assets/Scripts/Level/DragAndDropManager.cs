using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropManager : MonoBehaviour
{
    private GameObject dragObject;
    private Vector3 mouseOffset;

    public int playerCurrency = 120;
    private bool canPut = true;
    
    [SerializeField] Text currencyLabel;
    [SerializeField] private MenuManager menu;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrencyLabel();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !menu.IsPaused())
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

            if (dragAndDropItem.Drop(playerCurrency))
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D[] targetObjects = Physics2D.OverlapPointAll(mousePosition);

                if (targetObjects.Length > 0)
                {
                    foreach (var obj in targetObjects)
                    {
                        if (obj.CompareTag("Slot"))
                        {
                            obj.GetComponent<Slot>().OnDrop(dragAndDropItem);
							playerCurrency -= dragAndDropItem.cost;
							UpdateCurrencyLabel();
                        }
                    }
                }
            }

            mouseOffset = new Vector3(0, 0, 0);
            dragObject = null;
        }
    }

    void UpdateCurrencyLabel()
    {
        currencyLabel.text = "Currency: " + playerCurrency;
    }
}
