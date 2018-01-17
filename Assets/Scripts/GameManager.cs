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
    private bool _isPlaying = false;

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

        if (PlayerPrefs.GetFloat("0", _highScore) < 1) //Check si il a des PlayerPrefs
        {
            PlayerPrefs.SetFloat("0", 0);
        }
        _highScore = PlayerPrefs.GetFloat("0", _highScore); //Set la valeur du highscore en fonction des PlayerPrefs
        highscoreText.text = "Highscore : " + _highScore; // Set le texte à l'écran

    }

    private void Update()
    {
        if(_isPlaying) //vérifie si le jeu est en pause ou non
        {
            _scoreDelay += Time.deltaTime;
            movingObjects.transform.position = new Vector3(movingObjects.transform.position.x, player.transform.position.y, movingObjects.transform.position.z); // bouge les colliders + camera offset + module recycler
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, player.transform.position.y + _camOffset, mainCamera.transform.position.z);

            if (_scoreDelay >= 0.5f) // incrementation du score toutes les 0.5 sec
            {
                UpdateScore(1);
                _scoreDelay = 0;
            }
        }        
    }

    public void UpdateScore (float newScore) // fonction de mise à jour du score
    {
        _actualScore += newScore;
        scoreText.text = "Score : " + _actualScore; // Affichage à l'écran du score
    }

    public bool GetIsPlaying() //GETTER
    {
        return _isPlaying;
    }

    public bool SetIsPlaying(bool playState) //SETTER
    {
        _isPlaying = playState;
        return _isPlaying;
    }

    public void SpawnNewModule (GameObject moduleToDestroy) //Recycle les modules en détruisant le module le plus bas et en en recréant un au dessus de la caméra du joueur
    {
        Destroy(moduleToDestroy.gameObject);
        Instantiate(modulesPool[Random.Range(0, modulesPool.Length)], moduleSpawner.transform.position, Quaternion.identity);
        moduleSpawner.transform.position = new Vector3(moduleSpawner.transform.position.x, moduleSpawner.transform.position.y + 15, moduleSpawner.transform.position.z);
    }

    public void BeginingModules() //Créer les modules de base avec toujours le même premier module
    {
        Instantiate(modulesPool[0], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(modulesPool[Random.Range(0, modulesPool.Length)], new Vector3(0, 15, 0), Quaternion.identity);
        Instantiate(modulesPool[Random.Range(0, modulesPool.Length)], new Vector3(0, 30, 0), Quaternion.identity);
        Instantiate(modulesPool[Random.Range(0, modulesPool.Length)], new Vector3(0, 45, 0), Quaternion.identity);
    }

    public void GameOverPanel () //Fait apparaitre l'écran de fin de partie
    {

        gameOverPanel.SetActive(true);
        _personalScore.text = "Score : " + _actualScore;
        scoreText.enabled = false;
        highscoreText.enabled = false;
        if (PlayerPrefs.GetFloat("0", _highScore) < _actualScore) // Vérifie si le score actuel est + important que le highscore et modifie ce dernier
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

    public void RestartLevel(int index) //Restart du niveau
    {
        SceneManager.LoadScene(index);
    }
}
