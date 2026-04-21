using UnityEngine;

public class QuitGame : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Q))
		{
			Application.Quit();
		}
	}
}
