using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public Button myButton;
    public Button endGame;
    public Button restart;
    public GameObject endButtonImage;
    public GameObject buttonImage;
    public GameObject restartButtonImage;
    public int levelCount = 0;
    public Text gameOver;

    // Start is called before the first frame update
   
    void Start()
    {
        Button btn = myButton.GetComponent<Button>();
        
        btn.onClick.AddListener(TaskOnClick);
        
        buttonImage.gameObject.SetActive(true);
        endButtonImage.gameObject.SetActive(false);
        restartButtonImage.gameObject.SetActive(false);
    }
    void TaskOnClick()
    {
        levelCount++;

        WordGame.CLEARALL();
       WordGame.START();
        print(levelCount);
    }
    void TaskOnClick2()
    {

        WordGame.CLEARALL();
        gameOver.text = "GAME OVER";

        restartButtonImage.gameObject.SetActive(true);
        Button restartbtn = restart.GetComponent<Button>();
        restartbtn.onClick.AddListener(TaskOnClick3);


    }
    void TaskOnClick3()
    {

        SceneManager.LoadScene("__WordGame_Scene_0");


    }

    // Update is called once per frame
    void Update()
    {
        if(levelCount == 2)
        {
            buttonImage.gameObject.SetActive(false);
         
            endButtonImage.gameObject.SetActive(true);
            Button endbtn = endGame.GetComponent<Button>();
            endbtn.onClick.AddListener(TaskOnClick2);
        }
    }
}
