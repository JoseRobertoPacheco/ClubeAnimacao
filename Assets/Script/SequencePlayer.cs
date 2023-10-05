using System.Collections;
using TMPro;
using UnityEngine;

public class SequencePlayer : MonoBehaviour
{
	public GameObject FadeLogoObject;

	public TextMeshProUGUI Logo1;
	public TextMeshProUGUI Logo2;
	public TextMeshProUGUI Logo3;

	public Camera LocalCamera;

	IEnumerator RotateWheels()
	{
		while (true)
		{
			
		}
	}

	void Start()
	{
		Logo1.gameObject.SetActive(false);
		Logo2.gameObject.SetActive(false);
		Logo3.gameObject.SetActive(false);

		StartCoroutine(StartAnimation());
	}

	IEnumerator StartAnimation()
	{
		yield return new WaitForSeconds(5);

		Logo1.gameObject.SetActive(true);

		yield return new WaitForSeconds(2);

		Logo2.gameObject.SetActive(true);

		yield return new WaitForSeconds(2);

		LeanTween.move(FadeLogoObject, new Vector3(0, 0, 0), 3).setEase(LeanTweenType.easeInOutQuad);

		yield return new WaitForSeconds(4);

		Logo1.gameObject.SetActive(false);
		Logo2.gameObject.SetActive(false);
		Logo3.gameObject.SetActive(true);

		LeanTween.move(FadeLogoObject, new Vector3(0, -20, 0), 3).setEase(LeanTweenType.easeInOutQuad);

		yield return new WaitForSeconds(4);

        FadeLogoObject.SetActive(false);

        void UpdateTextColor(Color color)
		{
			Logo3.color = color;
		}
		LeanTween.value(Logo3.gameObject, UpdateTextColor, Logo3.color, new Color(1, 1, 1, 0f), 1f);

		yield return new WaitForSeconds(1);

		Logo3.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
