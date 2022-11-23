using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    public int hp = 100;
    private CoinSpawner _coinSpawner;
    private int maxCoins = 5;
    private int coins = 0;
    private GameObject _player;
    private float _timer;
    private int _ogTimer;
    private int timeFrequenccy = 1;
    private int hp2;
    private int coin2;

    [SerializeField] private TextMeshProUGUI _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtWin;
    [SerializeField] private Button _btnReiniciar;

    [SerializeField] private Slider _healthBar;

    [SerializeField] private TextMeshProUGUI _hpValue;
    [SerializeField] private TextMeshProUGUI _txtTime;

    private bool win = false;
    [SerializeField] private int level = 0;
    
    //private GameObject _level1ManagerGameObject;
    public static Level1Manager instance;

    private void Awake()
    {
        //InitLevel();
        //_level1ManagerGameObject = GameObject.Find("Game Manager");
        if(instance != null && instance != this){
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        InitLevel();

    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= _ogTimer - timeFrequenccy)
        {
            _ogTimer -= timeFrequenccy;
            _txtTime.text = "Time: " + _ogTimer;
        }

        if (_timer <= 0)
        {
            EndLevel("Time ended! Game Over");
            win = false;
        }
        
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
            win = true;
            if (level == 1)
            {
                EndLevel("Congratulations! Go to level 2");
            }
            else
            {
                EndLevel("YOU WIN!");
            }
        }
    }

    public void GameOver()
    {
        if (level == 1 && win)
        {
            win = false;
            PlayerPrefs.SetInt("level", 2);
            //PlayerPrefs.SetInt("coins", coins);
            //PlayerPrefs.SetInt("hp", hp);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level2");
            hp2 = hp;
            coin2 = coins;

        }
        else if(level == 2 && !win)
        {
            SceneManager.LoadScene("GameOver");
            //PlayerPrefs.SetInt("level", 2);
            hp = hp2;
            coins = coin2;
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            //PlayerPrefs.SetInt("coins", 0);
            //PlayerPrefs.SetInt("hp", 100);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOver");
            
        }
        InitLevel();
        /*
         * else if (level == 1 && !win) ...
         */
    }
    
    public void Damage(int dmgAmount)
    {
        hp -= dmgAmount;
        
        //Debug.Log("You lost " + dmgAmount +"% of your hp");
        //Debug.Log("Hp remaining: " + hp + "%");
        ShowLife();
        if (hp <= 0)
        {
            win = false;
            Destroy(_player);
            Destroy(FindObjectOfType<FollowCamera>());
            Destroy(FindObjectOfType<EnemyMovement>());
            EndLevel("YOU DIED! Game Over");
        }
    }
    
    public void Heal(int heal)
    {
        if (hp != 100)
        {
            if (hp + heal >= 100)
            {
                hp = 100;
            }
            else
            {
                hp += heal;
            }
            ShowLife();
        }
    }
    
    public void ShowLife(){
        _healthBar.value = hp;
        _hpValue.text = _healthBar.value.ToString() + "%";
        if (hp < 50)
        {
            _healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red; 
        }
        if (hp >= 50)
        {
            _healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green; 
        }
    }
    
    private void EndLevel(string message)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _txtWin.text = message;
        _txtWin.gameObject.SetActive(true);
        _btnReiniciar.gameObject.SetActive(true);
        //PAUSAR EL JUEGO
        Time.timeScale = 0;
    }
    
    private void InitLevel()
    {
        _timer = 40;
        _ogTimer = 40;
        win = false;
        //_txtCoins = GameObject.Find("TxtCoins");
        _coinSpawner = FindObjectOfType<CoinSpawner>();
        _txtWin.gameObject.SetActive(false);
        _btnReiniciar.gameObject.SetActive(false);
        _btnReiniciar.onClick.AddListener(GameOver);
        _player = GameObject.FindWithTag("Player");
        _txtTime.text = "Time: " + _ogTimer;
        Time.timeScale = 1;
        
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level",1);
            PlayerPrefs.Save();
        }
        level = PlayerPrefs.GetInt("level");
        
        /*
        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins",0);
            PlayerPrefs.Save(); 
        }
        coins = PlayerPrefs.GetInt("coins");*/
        
        if (level == 2)
        {
            maxCoins = 14;
        }
        _txtCoins.text = "Coins: " + coins + "/" + maxCoins;


        /*if (!PlayerPrefs.HasKey("hp"))
        {
            PlayerPrefs.SetInt("hp",100);
            PlayerPrefs.Save(); 
        }
        hp = PlayerPrefs.GetInt("hp");*/
        ShowLife();
    }
}
