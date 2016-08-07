using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {

    [SerializeField]
    private GameObject cardBack;

    [SerializeField]
    private Sprite image;

    public void OnMouseDown()
    {
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = image;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
