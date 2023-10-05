using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SequencePlayer : MonoBehaviour
{
	public GameObject FadeLogoObject;

	public TextMeshProUGUI Logo1;
    public TextMeshProUGUI Logo2;
	public TextMeshProUGUI Logo3;

    // Start is called before the first frame update
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

		LeanTween.move(FadeLogoObject, new Vector3(0, 0, 0), 3);

        yield return new WaitForSeconds(6);

        Logo1.gameObject.SetActive(false);
        Logo2.gameObject.SetActive(false);
		FadeLogoObject.SetActive(false);

		void UpdateTextColor(Color color)
		{
			Logo3.color = color;
		}

		float OriginalZ = Logo3.gameObject.transform.position.z;
		Logo3.gameObject.transform.position = new Vector3(Logo3.gameObject.transform.position.x, Logo3.gameObject.transform.position.y, 0);

        Logo3.color = new Color(1, 1, 1, 0f);
        Logo3.gameObject.SetActive(true);

		LeanTween.value(gameObject, UpdateTextColor, Logo3.color, new Color(1, 1, 1, 1f), 2);
        LeanTween.moveZ(Logo3.gameObject, OriginalZ, 6);

        yield return new WaitForSeconds(4);

        LeanTween.value(Logo3.gameObject, UpdateTextColor, Logo3.color, new Color(1, 1, 1, 0f), 2);
    }

	// Update is called once per frame
	void Update()
	{
		
	}
}
