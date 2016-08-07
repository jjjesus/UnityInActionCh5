using UnityEngine;
using System.Collections;
using System;

public class SceneController : MonoBehaviour {

    [SerializeField]
    private MemoryCard originalCard;

    [SerializeField]
    private Sprite[] images;

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;


	// Use this for initialization
	void Start () {
        createCards();
	}

    private void createCards()
    {
        Vector3 startPos = originalCard.transform.position;

        for (int col = 0; col < gridCols; col++)
        {
            for (int row = 0; row < gridRows; row++)
            {
                createNewCard(startPos, col, row);
            }
        }
    }

    private void createNewCard(Vector3 startPos, int col, int row)
    {
        MemoryCard card;
        if (col == 0 && row == 0)
        {
            card = originalCard;
        }
        else
        {
            card = Instantiate(originalCard) as MemoryCard;
        }
        int id = UnityEngine.Random.Range(0, images.Length);
        card.SetCard(id, images[id]);

        float posX = (offsetX * col) + startPos.x;
        float posY = -(offsetY * row) + startPos.y;
        card.transform.position = new Vector3(posX, posY, startPos.z);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
