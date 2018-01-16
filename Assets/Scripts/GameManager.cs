using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    public GameObject player;
    public GameObject movingObjects;
    public GameObject playerStart;

    private float _actualScore;
    private float _scoreDelay;

    private bool _scoreUp = true;
    private bool _isPlaying = true;

    private void Start()
    {
        Vector3 initPlayerPos = playerStart.transform.position;
        GameObject newPlayer = Instantiate(player, initPlayerPos, playerStart.transform.rotation);
    }

    private void Update()
    {
        if(_isPlaying)
        {
            _scoreDelay += Time.deltaTime;

            if (_scoreDelay >= 0.5f)
            {
                UpdateScore(1);
                _scoreDelay = 0;
            }
        }        
    }

    public void UpdateScore (float newScore)
    {
        _actualScore += newScore;
        scoreText.text = "Score : " + _actualScore;
    }

    public bool GetIsPlaying()
    {
        return _isPlaying;
    }

    public bool SetIsPlaying(bool playState)
    {
        _isPlaying = playState;
        return _isPlaying;
    }
}
