using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    public Text highscoreText;

    public GameObject player;
    public GameObject movingObjects;
    public GameObject playerStart;
    public GameObject mainCamera;
    public GameObject moduleSpawner;
    public GameObject gameOverPanel;

    public GameObject[] modulesPool;

    public float upwardSpeed;


    private float _actualScore;
    private float _scoreDelay;
    private float _camOffset = 15;
    private float _highScore;

    private bool _scoreUp = true;
    private bool _isPlaying = true;

    private Text _personalScore;
    private Text _bestScore;

    private void Start()
    {
        BeginingModules(); //Instantiate the first modules

        Vector3 initPlayerPos = playerStart.transform.position;
        GameObject newPlayer = Instantiate(player, initPlayerPos, playerStart.transform.rotation); //Instantiate Player
        player = newPlayer;

        gameOverPanel.SetActive(false);
        _personalScore = gameOverPanel.transform.GetChild(0).GetComponent<Text>(); //Get personnal score Text component for gameover panel
        print("personalScore: " + _personalScore.gameObject.name);
        _bestScore = gameOverPanel.transform.GetChild(1).GetComponent<Text>(); //Get best score Text component for gameover panel
        print("bestScore: " + _bestScore.gameObject.name);

        scoreText.enabled = true;
        highscoreText.enabled = true;

        if (PlayerPrefs.GetFloat("0", _highScore) < 1) //Check player prefs
        {
            PlayerPrefs.SetFloat("0", 0);
        }
        _highScore = PlayerPrefs.GetFloat("0", _highScore);
        highscoreText.text = "Highscore : " + _highScore;

    }

    private void Update()
    {
        if(_isPlaying)
        {
            _scoreDelay += Time.deltaTime;
            movingObjects.transform.position = new Vector3(movingObjects.transform.position.x, player.transform.position.y, movingObjects.transform.position.z);
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, player.transform.position.y + _camOffset, mainCamera.transform.position.z);

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

    public void SpawnNewModule (GameObject moduleToDestroy)
    {
        Destroy(moduleToDestroy.gameObject);
        Instantiate(modulesPool[Random.Range(0, modulesPool.Length)], moduleSpawner.transform.position, Quaternion.identity);
        moduleSpawner.transform.position = new Vector3(moduleSpawner.transform.position.x, moduleSpawner.transform.position.y + 15, moduleSpawner.transform.position.z);
    }

    public void BeginingModules()
    {
        Instantiate(modulesPool[0], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(modulesPool[Random.Range(0, modulesPool.Length)], new Vector3(0, 15, 0), Quaternion.identity);
        Instantiate(modulesPool[Random.Range(0, modulesPool.Length)], new Vector3(0, 30, 0), Quaternion.identity);
        Instantiate(modulesPool[Random.Range(0, modulesPool.Length)], new Vector3(0, 45, 0), Quaternion.identity);
    }

    public void GameOverPanel ()
    {

        gameOverPanel.SetActive(true);
        _personalScore.text = "Score : " + _actualScore;
        scoreText.enabled = false;
        highscoreText.enabled = false;
        if (PlayerPrefs.GetFloat("0", _highScore) < _actualScore)
        {
            _highScore = _actualScore;
            PlayerPrefs.SetFloat("0", _highScore);
            _bestScore.text = "Highscore : " + _highScore;
        }
        else
        {
            PlayerPrefs.SetFloat("0", _highScore);
            _bestScore.text = "Highscore : " + _highScore;
        }
        
    }

    public void RestartLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
