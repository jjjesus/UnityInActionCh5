using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    [SerializeField]
    private MemoryCard originalCard;

    [SerializeField]
    private Sprite[] images;


	// Use this for initialization
	void Start () {
        int id = Random.Range(0, images.Length);
        string msg = string.Format("Setting id to {0}", id);
        Debug.Log(msg);
        originalCard.SetCard(id, images[id]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
