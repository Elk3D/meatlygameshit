using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
	public float lifetime;

	private void Start()
	{
	}

	private void Update()
	{
		Object.Destroy(base.gameObject, lifetime);
	}
}
