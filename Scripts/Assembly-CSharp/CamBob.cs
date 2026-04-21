using UnityEngine;

public class CamBob : MonoBehaviour
{
	public Animator m_Animator;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			m_Animator.SetBool("iswalking", value: true);
		}
		if (!Input.GetKey(KeyCode.W))
		{
			m_Animator.SetBool("iswalking", value: false);
		}
	}
}
