using UnityEngine;

public class AttachTo : MonoBehaviour
{
	public Transform target;

	private void Awake()
	{
		transform.parent = target;
		GetComponent<RectTransform>().position = transform.parent.position;
	}
}