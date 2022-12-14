using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Game Manager"));
        PlayerPrefs.DeleteAll();
        _btnPlay.onClick.AddListener(LoadLevel1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadLevel1()
    {
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene("Level1");
    }
}
