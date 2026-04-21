using UnityEngine;

public class NoMouse : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
