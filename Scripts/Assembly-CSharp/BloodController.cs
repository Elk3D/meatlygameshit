using UnityEngine;

public class BloodController : MonoBehaviour
{
	public float bloodSign;

	public GameObject sign1;

	public GameObject sign2;

	public GameObject sign3;

	public GameObject sign4;

	public GameObject sign5;

	public GameObject sign6;

	private void Start()
	{
		bloodSign = Random.Range(1, 6);
	}

	private void Update()
	{
		if (bloodSign == 1f)
		{
			sign1.SetActive(value: true);
		}
		if (bloodSign == 2f)
		{
			sign2.SetActive(value: true);
		}
		if (bloodSign == 3f)
		{
			sign3.SetActive(value: true);
		}
		if (bloodSign == 4f)
		{
			sign4.SetActive(value: true);
		}
		if (bloodSign == 5f)
		{
			sign5.SetActive(value: true);
		}
		if (bloodSign == 6f)
		{
			sign6.SetActive(value: true);
		}
	}
}
