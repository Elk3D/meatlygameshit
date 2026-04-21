using UnityEngine;

public class player : MonoBehaviour
{
	public Camera cam;

	public GameObject cameraHolder;

	[SerializeField]
	private float distance = 0.2f;

	[SerializeField]
	private LayerMask mask;

	public GameObject remoteLight;

	public GameObject remoteLightRED;

	public bool hasRemote;

	public GameObject remote;

	public GameObject remotePickup;

	public bool hasFlashlight;

	public GameObject flashlightPickup;

	public GameObject Flashlight;

	public GameObject FlashlightUI;

	public GameObject PeekerRemove;

	public GameObject flashlightmsg;

	public GameObject remotemsg;

	public GameObject itself;

	public GameObject dust;

	public GameObject Meatly;

	public GameObject MeatlyTrigger;

	public GameObject doorKnob;

	public GameObject breakinSFX;

	public GameObject missionStart;

	public GameObject allCodes;

	public GameObject Chest;

	public GameObject ChestOpener;

	public GameObject codesUI;

	public GameObject ChestOpenSFX;

	public GameObject ChestLockedSFX;

	public GameObject EndingShaker;

	public GameObject FallingSFX;

	public GameObject riser;

	public GameObject black;

	public GameObject batteryUI;

	public GameObject thing;

	public GameObject bars;

	public GameObject codeView;

	public bool readyToEnd;

	public GameObject donut;

	public GameObject pauseUI;

	public GameObject donutObject;

	public GameObject joke;

	public GameObject quitter;

	public GameObject Note1;

	public GameObject Note1UI;

	public GameObject Note2UI;

	public GameObject Note3UI;

	public GameObject Note4UI;

	public bool reading;

	public GameObject OldDoor;

	public GameObject NewDoor;

	public bool pause;

	public GameObject Code1;

	public GameObject Code2;

	public GameObject Code3;

	public GameObject Code4;

	public GameObject dashes;

	public GameObject msg1;

	public GameObject msg2;

	public GameObject msg3;

	public GameObject msg4;

	public GameObject msg5;

	public GameObject jumpscare;

	public GameObject jumpscareSFX;

	public GameObject peeker;

	public float codeAmount;

	public bool started;

	public bool alive = true;

	public GameObject Shaker;

	private void Start()
	{
		itself.GetComponent<PlayerMove>().enabled = false;
		cam.GetComponent<mouseLook>().enabled = false;
		cam.GetComponent<CamBob>().enabled = false;
		Invoke("BeginGame", 2f);
	}

	private void BeginGame()
	{
		msg1.SetActive(value: true);
		itself.GetComponent<PlayerMove>().enabled = true;
		cam.GetComponent<mouseLook>().enabled = true;
		cam.GetComponent<CamBob>().enabled = true;
		started = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "eyes")
		{
			other.transform.parent.GetComponent<Meatly>().checkSight();
			Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
		}
		if (other.gameObject.name == "opener")
		{
			remoteLight.SetActive(value: true);
			remoteLightRED.SetActive(value: false);
		}
		if (other.gameObject.name == "RemotePickUp")
		{
			hasRemote = true;
			remotemsg.SetActive(value: true);
			Object.Destroy(remotePickup);
		}
		if (other.gameObject.name == "flashlightPickUp")
		{
			hasFlashlight = true;
			flashlightmsg.SetActive(value: true);
			FlashlightUI.SetActive(value: true);
			Flashlight.GetComponent<Flashlight>().hasFlashlight = true;
			Object.Destroy(flashlightPickup);
		}
		if (other.gameObject.name == "MeatlyTrigger")
		{
			Meatly.SetActive(value: true);
			MeatlyTrigger.SetActive(value: false);
			Object.Destroy(MeatlyTrigger);
		}
		if (other.gameObject.name == "PeekerRemove")
		{
			breakinSFX.SetActive(value: true);
			Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
			peeker.GetComponent<Animator>().SetBool("seen", value: true);
			dust.SetActive(value: true);
			Object.Destroy(PeekerRemove);
		}
		if (other.gameObject.name == "EndingShaker")
		{
			FallingSFX.SetActive(value: true);
			batteryUI.SetActive(value: false);
			riser.GetComponent<Animator>().SetBool("rise", value: true);
			Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
			Invoke("Black", 11f);
			Object.Destroy(EndingShaker);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "opener")
		{
			remoteLight.SetActive(value: false);
			remoteLightRED.SetActive(value: true);
		}
	}

	private void Black()
	{
		Invoke("Joke", 5f);
		black.SetActive(value: true);
		GetComponent<Flashlight>().enabled = false;
		GetComponent<Flashlight>().enabled = false;
		cam.GetComponent<CamBob>().enabled = false;
		cameraHolder.GetComponent<FootSteps>().enabled = false;
	}

	private void Joke()
	{
		Invoke("Quitter", 5f);
		joke.SetActive(value: true);
	}

	private void Quitter()
	{
		quitter.SetActive(value: true);
	}

	private void Update()
	{
		if (reading)
		{
			Flashlight.GetComponent<Flashlight>().lit = false;
		}
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			pause = !pause;
		}
		if (pause)
		{
			pauseUI.SetActive(value: true);
			Time.timeScale = 0f;
			cam.GetComponent<mouseLook>().enabled = false;
		}
		if (!pause)
		{
			pauseUI.SetActive(value: false);
			if (started && !reading)
			{
				Time.timeScale = 1f;
				cam.GetComponent<mouseLook>().enabled = true;
			}
		}
		if (codeAmount >= 4f && !readyToEnd)
		{
			ChestOpener.SetActive(value: true);
			msg3.SetActive(value: true);
		}
		if (hasRemote)
		{
			remote.SetActive(value: true);
		}
		else
		{
			remote.SetActive(value: false);
		}
		Ray ray = new Ray(cam.transform.position, cam.transform.forward);
		Debug.DrawRay(ray.origin, ray.direction * distance);
		if (!Physics.Raycast(ray, out var hitInfo, distance, mask))
		{
			return;
		}
		if (hitInfo.collider.GetComponent<Code1>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				Code1.SetActive(value: true);
				codeAmount += 1f;
				hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				Code1.SetActive(value: true);
				codeAmount += 1f;
				hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
			}
		}
		if (hitInfo.collider.GetComponent<Code2>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				jumpscare.GetComponent<Animator>().SetBool("jumpscare", value: true);
				jumpscareSFX.SetActive(value: true);
				Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
				Code2.SetActive(value: true);
				codeAmount += 1f;
				hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				jumpscare.GetComponent<Animator>().SetBool("jumpscare", value: true);
				jumpscareSFX.SetActive(value: true);
				Code2.SetActive(value: true);
				Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
				codeAmount += 1f;
				hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
			}
		}
		if (hitInfo.collider.GetComponent<Code3>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				Code3.SetActive(value: true);
				codeAmount += 1f;
				hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				Code3.SetActive(value: true);
				codeAmount += 1f;
				hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
			}
		}
		if (hitInfo.collider.GetComponent<Code4>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				Code4.SetActive(value: true);
				codeAmount += 1f;
				hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				Code4.SetActive(value: true);
				codeAmount += 1f;
				hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
			}
		}
		if (hitInfo.collider.GetComponent<Note1>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				Note1UI.SetActive(value: true);
				reading = true;
				Time.timeScale = 0f;
				cam.GetComponent<mouseLook>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				Note1UI.SetActive(value: true);
				Time.timeScale = 0f;
				reading = true;
				cam.GetComponent<mouseLook>().enabled = false;
			}
		}
		if (hitInfo.collider.GetComponent<Note2>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				Note2UI.SetActive(value: true);
				reading = true;
				Time.timeScale = 0f;
				cam.GetComponent<mouseLook>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				Note2UI.SetActive(value: true);
				Time.timeScale = 0f;
				reading = true;
				cam.GetComponent<mouseLook>().enabled = false;
			}
		}
		if (hitInfo.collider.GetComponent<Note3>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				Note3UI.SetActive(value: true);
				reading = true;
				Time.timeScale = 0f;
				cam.GetComponent<mouseLook>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				Note3UI.SetActive(value: true);
				Time.timeScale = 0f;
				reading = true;
				cam.GetComponent<mouseLook>().enabled = false;
			}
		}
		if (hitInfo.collider.GetComponent<Note4>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				Note4UI.SetActive(value: true);
				reading = true;
				Time.timeScale = 0f;
				cam.GetComponent<mouseLook>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				Note4UI.SetActive(value: true);
				Time.timeScale = 0f;
				reading = true;
				cam.GetComponent<mouseLook>().enabled = false;
			}
		}
		if (hitInfo.collider.GetComponent<lockedDoor>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				if (readyToEnd)
				{
					msg5.SetActive(value: true);
				}
				Object.Instantiate(doorKnob, base.transform.position, base.transform.rotation);
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				if (readyToEnd)
				{
					msg5.SetActive(value: true);
				}
				Object.Instantiate(doorKnob, base.transform.position, base.transform.rotation);
			}
		}
		if (hitInfo.collider.GetComponent<MissionStart>() != null)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				msg2.SetActive(value: true);
				Object.Destroy(missionStart);
				allCodes.SetActive(value: true);
				dashes.SetActive(value: true);
				ChestLockedSFX.SetActive(value: true);
			}
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				msg2.SetActive(value: true);
				Object.Destroy(missionStart);
				allCodes.SetActive(value: true);
				ChestLockedSFX.SetActive(value: true);
				dashes.SetActive(value: true);
			}
		}
		if (hitInfo.collider.GetComponent<ChestOpener>() != null)
		{
			if (Input.GetKey(KeyCode.E))
			{
				readyToEnd = true;
				bars.SetActive(value: true);
				donutObject.SetActive(value: true);
				ChestOpener.SetActive(value: false);
				Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
				Chest.GetComponent<Animator>().SetBool("open", value: true);
				Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
				ChestOpenSFX.SetActive(value: true);
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				readyToEnd = true;
				bars.SetActive(value: true);
				donutObject.SetActive(value: true);
				ChestOpener.SetActive(value: false);
				codeView.SetActive(value: true);
				Chest.GetComponent<Animator>().SetBool("open", value: true);
				ChestOpenSFX.SetActive(value: true);
				Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
				codesUI.SetActive(value: false);
			}
		}
		if (hitInfo.collider.GetComponent<Ending>() != null)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				msg4.SetActive(value: true);
				OldDoor.SetActive(value: false);
				donut.SetActive(value: true);
				Meatly.SetActive(value: false);
				NewDoor.SetActive(value: true);
				thing.SetActive(value: false);
			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				OldDoor.SetActive(value: false);
				Meatly.SetActive(value: false);
				donut.SetActive(value: true);
				msg4.SetActive(value: true);
				NewDoor.SetActive(value: true);
				thing.SetActive(value: false);
			}
		}
		if (hitInfo.collider.GetComponent<Interactable>() != null)
		{
			if (hasRemote && Input.GetKey(KeyCode.E))
			{
				hitInfo.collider.GetComponent<Interactable>().isOpen = true;
			}
			if (Input.GetKey(KeyCode.Mouse0) && hasRemote)
			{
				hitInfo.collider.GetComponent<Interactable>().isOpen = true;
			}
		}
	}
}
