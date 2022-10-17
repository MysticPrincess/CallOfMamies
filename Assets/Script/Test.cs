using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public Transform origin;
	public GameObject obj;
	private Vector3 target;
	public Camera cam;
	public float speed = 0.5f;

	
	void Start()
	{

		target = transform.position;
	}

	public void Launch()
    {
		GameObject instantiatedObject;
		Ray ray;
		RaycastHit hit;

		ray = cam.ScreenPointToRay(Input.mousePosition);
		Vector3 pos;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			pos = hit.point;
			instantiatedObject = Instantiate(obj, origin.position, Quaternion.identity);
			float dist = Vector3.Distance(instantiatedObject.transform.position, pos);
			Debug.Log(dist);
			StartCoroutine(LerpPosition(instantiatedObject.transform, pos, speed * dist));
		}
	}

	IEnumerator LerpPosition(Transform obj, Vector3 targetPosition, float duration)
	{
		float time = 0;
		Vector3 startPosition = obj.transform.position;
		while (time < duration)
		{
			obj.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		obj.transform.position = targetPosition;
	}
}
