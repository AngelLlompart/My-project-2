using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button _btnRestart;
    [SerializeField] private Button _btnMenu;
    [SerializeField] private Button _btnQuit;
    // Start is called before the first frame update
    void Start()
    {
        _btnRestart.onClick.AddListener(LoadLevel1);
        _btnMenu.onClick.AddListener(LoadMenu);
        _btnQuit.onClick.AddListener(Quit);
        
        Destroy(GameObject.Find("Game Manager"));
        Destroy(GameObject.Find("Level Audio Manager"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Quit()
    {
        #if UNITY_EDITOR
            if(EditorApplication.isPlaying) 
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        #else
            Application.Quit();
        #endif
    }
}
