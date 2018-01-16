using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text scoreText;

    public GameObject player;
    public GameObject movingObjects;
    public GameObject playerStart;
    public GameObject mainCamera;
    public GameObject moduleSpawner;

    public GameObject[] modulesPool;

    public float upwardSpeed;


    private float _actualScore;
    private float _scoreDelay;
    private float _camOffset = 15;

    private bool _scoreUp = true;
    private bool _isPlaying = true;

    private void Start()
    {
        BeginingModules();
        Vector3 initPlayerPos = playerStart.transform.position;
        GameObject newPlayer = Instantiate(player, initPlayerPos, playerStart.transform.rotation);
        player = newPlayer;
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
    }
}
