using UnityEngine;
using System.Collections;
using System;

public class GameTurn : MonoBehaviour {

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private int _score;
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public bool CanReveal
    {
        get { return _secondRevealed; }
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        } else
        {
            _secondRevealed = card;
            StartCoroutine(checkMatch());
        }
    }

    private IEnumerator checkMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            _firstRevealed.UnReveal();
            _secondRevealed.UnReveal();
        }
        _firstRevealed = null;
        _secondRevealed = null;
    }
}
