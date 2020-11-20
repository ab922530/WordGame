using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = myButton.GetComponent<Button>();

        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("__WordGame_Scene_0");
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
