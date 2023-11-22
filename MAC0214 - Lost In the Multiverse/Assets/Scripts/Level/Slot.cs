using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	[SerializeField] Direction direction;
	[SerializeField] int row = -1;

	private GameObject instantiatedObject = null;
	private GameObject previewObject = null;

	[SerializeField] private bool canPut = true;

	public void OnDrop(DragAndDropItem dragAndDropItem)
	{ 
		if(dragAndDropItem.remover == true && instantiatedObject != null)
		{
			Object.Destroy(this.gameObject.transform.GetChild(0).gameObject);
			return;
		}
		if(dragAndDropItem.prefabToInstantiate == null) return;

		if (!dragAndDropItem || instantiatedObject != null || !canPut) return;
		instantiatedObject = Instantiate(dragAndDropItem.prefabToInstantiate,
										 transform.position,
										 transform.rotation,
										 transform);

		instantiatedObject.GetComponent<DefensiveStructure>().SetDirection(direction);
		instantiatedObject.GetComponent<DefensiveStructure>().SetRow(row);

		instantiatedObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
	}

	public void OnPreview(DragAndDropItem dragAndDropItem)
	{
		if (previewObject != null) return;
		if(dragAndDropItem.previewObject == null) return;

		previewObject = Instantiate(dragAndDropItem.previewObject,
										 transform.position,
										 transform.rotation,
										 transform);

		previewObject.GetComponent<DefensiveStructure>().SetDirection(direction);
		previewObject.GetComponent<DefensiveStructure>().SetRow(row);

		previewObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

	}

	public void DisablePreview()
	{
		if (previewObject == null) return;

		Destroy(previewObject);
	}

	public Direction GetDirection()
	{
		return direction;
	}

	public int GetRow()
	{
		return row;
	}
}
