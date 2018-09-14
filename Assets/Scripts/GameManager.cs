using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public static GameManager instance = null;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;
    private int skulls = 0;
    private Scene scene;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pressStart;
    [SerializeField] private Text score;

    public bool PlayerActive
    {
        get { return playerActive; }
    }
    public bool GameOver
    {
        get { return gameOver; }
    }
    public bool GameStarted
    {
        get { return gameStarted; }
    }
    public int GameScore
    {
        get { return skulls; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        // Assert.IsNotNull(mainMenu);
    }


    void Start () {
        scene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void PlayerCollided()
    //{
    //    gameOver = true;
    //}

    //public void PlayerStartedGame()
    //{
    //    pressStart.SetActive(false);
    //    playerActive = true;
    //}

    //public void EnterGame()
    //{
    //    pressStart.SetActive(true);
    //    gameOverMenu.SetActive(false);
    //    mainMenu.SetActive(false);
    //    gameStarted = true;
    //}
    //public void EnterGameOver()
    //{
    //    score.text = skulls.ToString();
    //    gameOverMenu.SetActive(true);
    //    gameOver = true;
    //}
    //public void PlayerScored()
    //{
    //    skulls += 1;
    //}

    //public void Replay()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    //}
    //public void MainMenu()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    //}

}
