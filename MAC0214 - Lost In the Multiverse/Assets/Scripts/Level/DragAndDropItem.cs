using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItem : MonoBehaviour
{
    private Vector3 originPosition;
	public GameObject prefabToInstantiate;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
    }

    public void Drop()
    {
        SpawnTowerOnGrid();
        transform.position = originPosition;
    }

    void SpawnTowerOnGrid()
    {
        // Do nothing...
    }
}
