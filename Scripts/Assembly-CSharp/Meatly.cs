using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Meatly : MonoBehaviour
{
	public GameObject player;

	public GameObject itself;

	private NavMeshAgent nav;

	public GameObject Shaker;

	public GameObject chaseMusic;

	public AudioClip[] footsounds;

	public Transform eyes;

	public Transform head;

	private AudioSource sound;

	public AudioSource growl;

	private Animator anim;

	private string state = "idle";

	private bool alive = true;

	private float wait;

	private bool highAlert;

	private float alertness = 10f;

	public GameObject deathCam;

	public Transform camPos;

	private PlayerMove playerMove;

	private void Start()
	{
		playerMove = player.GetComponent<PlayerMove>();
		nav = GetComponent<NavMeshAgent>();
		sound = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		nav.speed = 1f;
		anim.speed = 1.2f;
	}

	public void footsteps(int _num)
	{
		sound.clip = footsounds[_num];
		sound.Play();
	}

	public void checkSight()
	{
		if (alive && Physics.Linecast(eyes.position, player.transform.position, out var hitInfo) && hitInfo.collider.gameObject.name == "Player" && state != "kill")
		{
			state = "chase";
			nav.speed = 4.5f;
			anim.speed = 1f;
		}
	}

	private void Update()
	{
		Debug.DrawLine(eyes.position, player.transform.position, Color.green);
		if (!alive)
		{
			return;
		}
		anim.SetFloat("velocity", nav.velocity.magnitude);
		if (state == "idle" && state != "chase")
		{
			chaseMusic.SetActive(value: false);
			anim.SetBool("running", value: false);
			Vector3 vector = Random.insideUnitSphere * alertness;
			NavMesh.SamplePosition(base.transform.position + vector, out var hit, 20f, -1);
			if (highAlert)
			{
				NavMesh.SamplePosition(player.transform.position + vector, out hit, 20f, -1);
				alertness += 5f;
				if (alertness > 5f)
				{
					highAlert = false;
					nav.speed = 1f;
					anim.speed = 1.2f;
				}
			}
			nav.SetDestination(hit.position);
			state = "walk";
		}
		if (state == "walk")
		{
			anim.SetBool("looking", value: false);
			if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
			{
				state = "search";
				wait = 5f;
			}
		}
		if (state == "search")
		{
			if (wait > 0f)
			{
				wait -= Time.deltaTime;
				anim.SetBool("looking", value: true);
			}
			else
			{
				anim.SetBool("looking", value: false);
				state = "idle";
			}
		}
		if (state == "chase")
		{
			chaseMusic.SetActive(value: true);
			anim.SetBool("running", value: true);
			anim.SetBool("looking", value: false);
			nav.destination = player.transform.position;
			if (Vector3.Distance(base.transform.position, player.transform.position) > 10f)
			{
				highAlert = false;
				nav.speed = 1f;
				anim.speed = 1.2f;
				anim.SetBool("looking", value: false);
				state = "idle";
			}
			else if (nav.remainingDistance <= nav.stoppingDistance + 1f && !nav.pathPending)
			{
				state = "kill";
				anim.SetBool("looking", value: false);
				anim.SetBool("death", value: true);
				playerMove.enabled = false;
				deathCam.SetActive(value: true);
				deathCam.transform.position = Camera.main.transform.position;
				deathCam.transform.rotation = Camera.main.transform.rotation;
				Camera.main.gameObject.SetActive(value: false);
				nav.destination = itself.transform.position;
				nav.speed = 0f;
				Invoke("reset", 3f);
			}
		}
		if (state == "kill")
		{
			anim.SetBool("looking", value: false);
			anim.SetBool("death", value: true);
			Object.Instantiate(Shaker, base.transform.position, base.transform.rotation);
			deathCam.transform.position = Vector3.Slerp(deathCam.transform.position, camPos.position, 10f * Time.deltaTime);
			deathCam.transform.rotation = Quaternion.Slerp(deathCam.transform.rotation, camPos.rotation, 10f * Time.deltaTime);
			anim.speed = 1f;
			anim.SetBool("death", value: true);
			nav.SetDestination(deathCam.transform.position);
		}
		if (state == "hunt" && nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
		{
			state = "search";
			wait = 5f;
			highAlert = true;
			alertness = 5f;
			checkSight();
		}
	}

	private void reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
