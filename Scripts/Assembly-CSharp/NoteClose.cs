using UnityEngine;

public class NoteClose : MonoBehaviour
{
	public GameObject cam;

	public GameObject NoteUI;

	public GameObject player;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.E))
		{
			NoteUI.SetActive(value: false);
			Time.timeScale = 1f;
			player.GetComponent<player>().reading = false;
			cam.GetComponent<mouseLook>().enabled = false;
		}
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			NoteUI.SetActive(value: false);
			Time.timeScale = 1f;
			player.GetComponent<player>().reading = false;
			cam.GetComponent<mouseLook>().enabled = false;
		}
	}
}
