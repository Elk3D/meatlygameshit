using UnityEngine;

public class Flashlight : MonoBehaviour
{
	public bool lit;

	public GameObject flashlight;

	public GameObject flashlightSFX;

	public GameObject flashlightSFXOFF;

	public float battery;

	public GameObject UI25;

	public GameObject UI25RED;

	public GameObject UI50;

	public GameObject UI75;

	public GameObject UI100;

	public GameObject border;

	public GameObject borderRED;

	public GameObject words;

	public GameObject peeker;

	public GameObject dust;

	public bool hasFlashlight;

	public bool Seen;

	private void Start()
	{
		battery = 100f;
	}

	private void Update()
	{
		if (battery <= 0f)
		{
			lit = false;
			flashlight.SetActive(value: false);
			flashlightSFXOFF.SetActive(value: true);
			UI25.SetActive(value: false);
			UI25RED.SetActive(value: false);
			UI50.SetActive(value: false);
			UI75.SetActive(value: false);
			UI100.SetActive(value: false);
			border.SetActive(value: false);
			borderRED.SetActive(value: true);
		}
		if (battery <= 25f && battery >= 1f)
		{
			UI25.SetActive(value: false);
			UI25RED.SetActive(value: true);
			UI50.SetActive(value: false);
			UI75.SetActive(value: false);
			UI100.SetActive(value: false);
			border.SetActive(value: false);
			borderRED.SetActive(value: true);
		}
		if (battery <= 50f && battery >= 26f)
		{
			UI25.SetActive(value: true);
			UI25RED.SetActive(value: false);
			UI50.SetActive(value: true);
			UI75.SetActive(value: false);
			UI100.SetActive(value: false);
			border.SetActive(value: true);
			borderRED.SetActive(value: false);
		}
		if (battery <= 75f && battery >= 51f)
		{
			UI25.SetActive(value: true);
			UI25RED.SetActive(value: false);
			UI50.SetActive(value: true);
			UI75.SetActive(value: true);
			UI100.SetActive(value: false);
			border.SetActive(value: true);
			borderRED.SetActive(value: false);
		}
		if (battery <= 100f && battery >= 76f)
		{
			UI25.SetActive(value: true);
			UI25RED.SetActive(value: false);
			UI50.SetActive(value: true);
			UI75.SetActive(value: true);
			UI100.SetActive(value: true);
			border.SetActive(value: true);
			borderRED.SetActive(value: false);
		}
		if (battery >= 1f && hasFlashlight && Input.GetKeyUp(KeyCode.Mouse1))
		{
			lit = !lit;
			if (!Seen)
			{
				dust.SetActive(value: true);
				Seen = true;
			}
		}
		if (battery >= 1f && hasFlashlight && Input.GetKeyUp(KeyCode.F))
		{
			lit = !lit;
			if (!Seen)
			{
				dust.SetActive(value: true);
				Seen = true;
			}
		}
		if (lit)
		{
			flashlight.SetActive(value: true);
			flashlightSFX.SetActive(value: true);
			flashlightSFXOFF.SetActive(value: false);
			battery -= 0.5f * Time.deltaTime;
		}
		if (!lit)
		{
			flashlight.SetActive(value: false);
			flashlightSFX.SetActive(value: false);
			flashlightSFXOFF.SetActive(value: true);
		}
		if (Seen)
		{
			peeker.GetComponent<Animator>().SetBool("seen", value: true);
		}
	}
}
