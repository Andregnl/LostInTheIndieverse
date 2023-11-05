using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Currency : MonoBehaviour
{
    public int worth = 25;

    [SerializeField] float moveDuration = 1.0f;
	[SerializeField] AudioSource audioSource;

	private bool wasPickedUp = false;

	void OnEndPickUp()
	{
		Destroy(gameObject);
	}

    void GoTowards(Transform otherTransform)
    {
        transform.DOMove(otherTransform.position, moveDuration).OnComplete(OnEndPickUp);
    }

	public void PickUp(Transform otherTransform, DragAndDropManager dragManager)
	{
		if (wasPickedUp) return;

		wasPickedUp = true;
		dragManager.UpdateCurrency(worth);
		audioSource.Play();
		GoTowards(otherTransform);
	}

	public void SetFallingParameters(Vector3 startPoint, Vector3 endPoint, float duration)
	{
		transform.position = startPoint;
		transform.DOMove(endPoint, duration);
	}
}
