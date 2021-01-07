using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play button
    public Button play;

    // Quit button
    public Button quit;

    // trap material
    public Material trapMat;

    // goal material
    public Material goalMat;

    // colorblind toggle
    public Toggle colorblindMode;

    // Start is called before the first frame update
    void Start()
    {
        Button pBtn = play.GetComponent<Button>();
        pBtn.onClick.AddListener(PlayMaze);
        Button qBtn = quit.GetComponent<Button>();
        qBtn.onClick.AddListener(QuitMaze);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start game from menu
    public void PlayMaze()
    {
        if (colorblindMode.GetComponent<Toggle>().isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene("maze");
    }

    // Quit game from menu
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
