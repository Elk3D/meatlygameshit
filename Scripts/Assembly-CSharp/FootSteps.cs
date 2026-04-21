using UnityEngine;

public class FootSteps : MonoBehaviour
{
	[SerializeField]
	private AudioClip[] Clips;

	[SerializeField]
	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Step()
	{
		AudioClip randomClip = GetRandomClip();
		audioSource.PlayOneShot(randomClip);
	}

	private AudioClip GetRandomClip()
	{
		return Clips[Random.Range(0, Clips.Length)];
	}
}
