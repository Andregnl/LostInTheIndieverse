using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItem : MonoBehaviour
{
    private Vector3 originPosition;

    public int cost = 50;

	public GameObject prefabToInstantiate;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
    }

    public bool Drop(int playerCurrency)
    {
        if (cost <= playerCurrency)
        {
            SpawnTowerOnGrid();
            transform.position = originPosition;
            return true;
        }

        transform.position = originPosition;
        return false;
    }

    void SpawnTowerOnGrid()
    {
        // Do nothing...
    }
}
