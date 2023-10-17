using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	[SerializeField] Direction direction;
	[SerializeField] int row = -1;

	GameObject instantiatedObject = null;

	public void OnDrop(DragAndDropItem dragAndDropItem)
	{
		if (!dragAndDropItem || instantiatedObject != null) return;

		instantiatedObject = Instantiate(dragAndDropItem.prefabToInstantiate,
										 transform.position,
										 transform.rotation,
										 transform);

		instantiatedObject.GetComponent<DefensiveStructure>().SetDirection(direction);
		instantiatedObject.GetComponent<DefensiveStructure>().SetRow(row);

		instantiatedObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
	}
}
