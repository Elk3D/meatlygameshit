using UnityEngine;

public class DeactivateAfterSeconds : MonoBehaviour
{
	public GameObject thisObject;

	private void Start()
	{
		Invoke("SetFalse", 1f);
	}

	private void Update()
	{
	}

	private void SetFalse()
	{
		thisObject.SetActive(value: false);
	}
}
