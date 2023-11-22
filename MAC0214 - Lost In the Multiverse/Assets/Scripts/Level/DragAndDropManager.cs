using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragAndDropManager : MonoBehaviour
{
    private GameObject dragObject;
    private Vector3 mouseOffset;
	private Slot currentPreview = null;

    public int playerCurrency = 120;

    [SerializeField] TextMeshProUGUI currencyLabel;
    [SerializeField] Transform currencyTextTransform;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrencyLabel();
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
            else if (targetObject && targetObject.CompareTag("Currency"))
            {
                Currency currency = targetObject.GetComponent<Currency>();

                currency.PickUp(currencyTextTransform, this);
            }
        }

        if (dragObject)
        {
            DragAndDropItem dragAndDropItem = (DragAndDropItem) dragObject.GetComponent(typeof(DragAndDropItem));

            dragObject.transform.position = mousePosition + mouseOffset;
            Collider2D[] targetObjects = Physics2D.OverlapPointAll(mousePosition);

			bool reachedSlot = false;
			foreach (var targetObject in targetObjects)
			{
				if (targetObject && targetObject.CompareTag("Slot"))
				{
					Slot slot = targetObject.GetComponent<Slot>();
					targetObject.GetComponent<Slot>().OnPreview(dragAndDropItem);

					if (currentPreview != null && currentPreview != slot)
						currentPreview.DisablePreview();

					currentPreview = targetObject.GetComponent<Slot>();
					reachedSlot = true;
				}
			}

			if (!reachedSlot && currentPreview != null) currentPreview.DisablePreview();
        }
		else
		{
			if (currentPreview != null) currentPreview.DisablePreview();
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
                            UpdateCurrency(-dragAndDropItem.cost);
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
        currencyLabel.text = "$ " + playerCurrency;
    }

    public void UpdateCurrency(int amount){
        playerCurrency += amount;
        UpdateCurrencyLabel();
    }
}
