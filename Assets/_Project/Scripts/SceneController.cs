using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    [SerializeField]
    private MemoryCard originalCard;

    [SerializeField]
    private Sprite[] images;

    [SerializeField]
    private GameTurn gameTurn;

    [SerializeField]
    private TextMesh scoreLabel;

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;
    private int[] shuffledCardIds;

    public int Score
    {
        get { return gameTurn.Score; }
        set { gameTurn.Score = value;  }
    }

    public void UpdateScoreLabel(string scoreText)
    {
        scoreLabel.text = scoreText;
    }

    public void Restart()
    {
        //Application.LoadLevel("TableTop");
        SceneManager.LoadScene("TableTop");
    }


	// Use this for initialization
	void Start () {
        gameTurn.SetSceneController(this);
        shuffledCardIds = shuffleCards();
        createCards();
	}

    public bool CanReveal()
    {
        return gameTurn.CanReveal;
    }

    public void CardRevealed(MemoryCard card)
    {
        gameTurn.CardRevealed(card);
    }

    private int[] shuffleCards()
    {
        int[] cardIds = { 0,0,1,1,2,2,3,3 };
        int[] shuffledIds = cardIds.Clone() as int[];
        for (int ii =0; ii < shuffledIds.Length; ii++)
        {
            int tmp = shuffledIds[ii];
            int rand = UnityEngine.Random.Range(ii, shuffledIds.Length);
            shuffledIds[ii] = shuffledIds[rand];
            shuffledIds[rand] = tmp;
        }
        return shuffledIds;
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
        int id = getCardId(col, row);
        card.SetCard(id, images[id]);

        float posX = (offsetX * col) + startPos.x;
        float posY = -(offsetY * row) + startPos.y;
        card.transform.position = new Vector3(posX, posY, startPos.z);
    }

    private int getCardId(int col, int row)
    {
        int index = row * gridCols + col;
        return shuffledCardIds[index];
    }

    // Update is called once per frame
    void Update () {
	
	}
}
