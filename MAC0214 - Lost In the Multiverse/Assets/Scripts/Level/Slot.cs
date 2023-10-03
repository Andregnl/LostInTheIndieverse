using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	GameObject instantiatedObject = null;

	public void OnDrop(DragAndDropItem dragAndDropItem)
	{
		if (!dragAndDropItem || instantiatedObject != null) return;

		instantiatedObject = Instantiate(dragAndDropItem.prefabToInstantiate,
										 transform.position,
										 transform.rotation,
										 transform);

		instantiatedObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
	}
}
