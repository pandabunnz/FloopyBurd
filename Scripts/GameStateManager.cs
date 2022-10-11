using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;  //You can ignore this for now - we will talk about Actions a bit later in this course.
    public static float PillarMoveSpeed { get; private set; } //A read only global property that makes it easy for us to change the move speed of the pillars.

    [SerializeField]
    private GameObject GameOverScreen; //A reference to the GameObject that is the GameOver UI Screen
    [SerializeField]
    private float pillarMovespeed; //This field is exposed in the editor but private to the class, this allows us to adjust the move speed of the pilars in the editor


    private static GameStateManager _instance; //This class is a Singleton - We will also discuss this pattern later in this class.

    
    private int score;
    private string count;

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        //Setup for making this class a Singlton - Don't modify this part of the code.
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }


        //Put other inialization for you game state here
        //PillarMoveSpeed = pillarMoveSpeed


    }



    //These two methods help up to handle the Game being over and restarting. 
    public void GameOver()
    {      
        //Add any logic that you would want to do when the game ends here
        Debug.Log("Game over");
        //This invokes the game over screen - here we are calling all the methods that subscribed to this action. 
        GameObject.FindGameObjectWithTag("Menu").transform.position = new Vector3(400, 200, 0);
        Time.timeScale = 0;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void IncreaseScore()
    {   
        count = GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<UnityEngine.UI.Text>().text;
        score = int.Parse(count) + 1;
        GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        Debug.Log("Score: " + count);
    }

    public static void Restart()
    {
        //This is how you can load scenes from code in Unity. In this case our entire game is in one scene.
        //To restart the game we just reload the scene.
        //Reloading the scene means any object that aren't Singletons will be destroyed and recreated 
        //Effectively re-initalizing them to their basic starting state.
        
    }

}
