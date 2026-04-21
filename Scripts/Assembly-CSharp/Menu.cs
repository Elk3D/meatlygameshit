using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public AudioSource sfx;

	public float levelSelect;

	private void Start()
	{
		levelSelect = Random.Range(1, 5);
	}

	private void Update()
	{
		levelSelect = Random.Range(1, 5);
		if (Input.GetKey(KeyCode.Q))
		{
			Application.Quit();
		}
		if (Input.GetKey(KeyCode.M))
		{
			sfx.Play();
		}
		if (Input.GetKey(KeyCode.E))
		{
			if (levelSelect == 1f)
			{
				SceneManager.LoadScene("MainScene");
			}
			if (levelSelect == 2f)
			{
				SceneManager.LoadScene("MainScene 1");
			}
			if (levelSelect == 3f)
			{
				SceneManager.LoadScene("MainScene 2");
			}
			if (levelSelect == 4f)
			{
				SceneManager.LoadScene("MainScene 3");
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			if (levelSelect == 1f)
			{
				SceneManager.LoadScene("MainScene");
			}
			if (levelSelect == 2f)
			{
				SceneManager.LoadScene("MainScene 1");
			}
			if (levelSelect == 3f)
			{
				SceneManager.LoadScene("MainScene 2");
			}
			if (levelSelect == 4f)
			{
				SceneManager.LoadScene("MainScene 3");
			}
		}
		if (Input.GetKey(KeyCode.Return))
		{
			if (levelSelect == 1f)
			{
				SceneManager.LoadScene("MainScene");
			}
			if (levelSelect == 2f)
			{
				SceneManager.LoadScene("MainScene 1");
			}
			if (levelSelect == 3f)
			{
				SceneManager.LoadScene("MainScene 2");
			}
			if (levelSelect == 4f)
			{
				SceneManager.LoadScene("MainScene 3");
			}
		}
	}
}
