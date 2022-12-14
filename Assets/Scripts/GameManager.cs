using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int hp = 100;
    private CoinSpawner _coinSpawner;
    private int maxCoins = 5;
    private int coins = 0;
    private GameObject _player;
    private float _timer = 40;
    private int _ogTimer = 40;
    private int timeFrequenccy = 1;

    [SerializeField] private TextMeshProUGUI _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtWin;
    [SerializeField] private Button _btnReiniciar;

    [SerializeField] private Slider _healthBar;

    [SerializeField] private TextMeshProUGUI _hpValue;
    [SerializeField] private TextMeshProUGUI _txtTime;
    // Start is called before the first frame update
    void Start()
    {
        _coinSpawner = FindObjectOfType<CoinSpawner>();
        _txtWin.gameObject.SetActive(false);
        _btnReiniciar.gameObject.SetActive(false);
        _btnReiniciar.onClick.AddListener(ReiniciarNivel);
        _player = GameObject.FindWithTag("Player");
        _txtTime.text = "Time: " + _ogTimer;
        Time.timeScale = 1;
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
            {
               EndLevel("YOU WIN!");
            }
        }
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public void Damage(int dmgAmount)
    {
        hp -= dmgAmount;
        
        //Debug.Log("You lost " + dmgAmount +"% of your hp");
        //Debug.Log("Hp remaining: " + hp + "%");
        _healthBar.value = hp;
        _hpValue.text = _healthBar.value.ToString() + "%";
        if (hp < 50)
        {
            _healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red; 
        }
        if (hp <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
            if (hp >= 50)
            {
                _healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green; 
            }
            _healthBar.value = hp;
            _hpValue.text = _healthBar.value.ToString() + "%";
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
}
