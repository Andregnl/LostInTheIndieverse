using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CurrencySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject currencyPrefab;
    [SerializeField] Vector3 minEndPoint, maxEndPoint;
    [SerializeField] float minWaitTime, maxWaitTime;
    [SerializeField] float currencySpeed;

    private float time, nextSpawnTime;

    private float startPoint, endPoint;

    void Awake()
    {
        time = 0.0f;
        nextSpawnTime = Random.Range(minWaitTime, maxWaitTime);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= nextSpawnTime)
        {
            time = 0.0f;
            nextSpawnTime = Random.Range(minWaitTime, maxWaitTime);
            SpawnCurrency();
        }
    }

    void SpawnCurrency()
    {
        Vector3 startPoint, endPoint;

        startPoint = RandomizeStartPoint();
        endPoint = RandomizeEndPoint(startPoint);

        GameObject currencyObject = Instantiate(currencyPrefab, transform.position, Quaternion.identity);
        Currency currency = currencyObject.GetComponent<Currency>();
        currency.SetFallingParameters(startPoint, endPoint,
                                     (endPoint - startPoint).magnitude / currencySpeed);
    }

    Vector3 RandomizeStartPoint()
    {
        float x, y, z;

        x = Random.Range(minEndPoint.x, maxEndPoint.x);
        y = transform.position.y;
        z = 0.0f;

        return new Vector3(x, y, z);
    }

    Vector3 RandomizeEndPoint(Vector3 startPoint)
    {
        float x, y, z;

        x = startPoint.x;
        y = Random.Range(minEndPoint.y, maxEndPoint.y);
        z = 0.0f;

        return new Vector3(x, y, z);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(minEndPoint, maxEndPoint);
    }
}
