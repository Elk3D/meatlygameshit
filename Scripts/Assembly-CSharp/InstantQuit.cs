using UnityEngine;

public class InstantQuit : MonoBehaviour
{
	public GameObject player;

	private void Update()
	{
		if (Input.GetKey(KeyCode.Y))
		{
			Application.Quit();
		}
		if (Input.GetKey(KeyCode.N))
		{
			player.GetComponent<player>().pause = false;
		}
	}
}
