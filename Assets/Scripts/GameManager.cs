using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private CoinSpawner _coinSpawner;
    private int maxCoins = 5;
    private int coins = 0;

    [SerializeField] private TextMeshProUGUI _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtWin;
    [SerializeField] private Button _btnReiniciar;
    // Start is called before the first frame update
    void Start()
    {
        _coinSpawner = FindObjectOfType<CoinSpawner>();
        _txtWin.gameObject.SetActive(false);
        _btnReiniciar.gameObject.SetActive(false);
        _btnReiniciar.onClick.AddListener(ReiniciarNivel);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncrementarMonedas()
    {
        coins++;
        
        _txtCoins.text = "Coins: " + coins + "/" + maxCoins;
        if (coins < maxCoins)
        {
            //Debug.Log( "You have " + coins + " coin/s");
            _coinSpawner.SpawnNewCoin();
        }
        else
        {
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                _txtWin.gameObject.SetActive(true);
                _btnReiniciar.gameObject.SetActive(true);
                //PAUSAR EL JUEGO
                Time.timeScale = 0;
            }
        }
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(0);
    }
}
