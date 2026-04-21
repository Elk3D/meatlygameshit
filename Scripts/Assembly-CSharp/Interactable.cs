using UnityEngine;

public class Interactable : MonoBehaviour
{
	public Animator anim;

	public bool isOpen;

	public GameObject openSFX;

	private void Start()
	{
		isOpen = false;
	}

	private void Update()
	{
		if (isOpen)
		{
			anim.SetBool("open", value: true);
			openSFX.SetActive(value: true);
		}
	}
}
