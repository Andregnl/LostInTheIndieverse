using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	[SerializeField] Direction direction;

	GameObject instantiatedObject = null;

	[SerializeField] private bool canPut = true;

	public void OnDrop(DragAndDropItem dragAndDropItem)
	{
		if (!dragAndDropItem || instantiatedObject != null || !canPut) return;

		instantiatedObject = Instantiate(dragAndDropItem.prefabToInstantiate,
										 transform.position,
										 transform.rotation,
										 transform);

		instantiatedObject.GetComponent<DefensiveStructure>().SetDirection(direction);

		instantiatedObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
	}
}
