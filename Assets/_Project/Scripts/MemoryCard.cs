using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {

    [SerializeField]
    private GameObject cardBack;

    [SerializeField]
    private Sprite image;

    [SerializeField]
    private SceneController sceneController;

    private int _id;
    public int id
    {
        get { return _id;  }
    }

    public void OnMouseDown()
    {
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }
    }

    public void SetCard(int id, Sprite image)
    {
        string msg = string.Format("MemoryCard.SetCard {0}", id);
        Debug.Log(msg);
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
