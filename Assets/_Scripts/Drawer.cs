using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

	public float speed = 1f;
	public bool moveX = true;

	private bool isOpen;
	private Vector3 closed;
	private Vector3 open;
	private Vector3 target;
	private Coroutine cor;

	// Use this for initialization
	private void Start()
	{
		isOpen = false;
		closed = transform.position;
		if (moveX)
			open = transform.position + (Vector3.left * 0.5f);
		else
			open = transform.position + (Vector3.forward * 0.5f);
		target = closed;
	}

	public void Activate()
	{
		if (cor != null)
			StopCoroutine(cor);

		if (isOpen)
			target = closed;
		else
			target = open;

		cor = StartCoroutine("Move");
		isOpen = !isOpen;
	}

	private IEnumerator Move()
	{
		while (Vector3.Distance(transform.position, target) != 0)
		{
			if (Vector3.Distance (transform.position, target) > Time.deltaTime * speed)
				transform.Translate ((target - transform.position).normalized * Time.deltaTime * speed);
			else
				transform.position = target;
			yield return null;
		}
	}
}
