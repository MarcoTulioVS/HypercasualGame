using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;
public class PlayerController : Singleton<PlayerController>
{

    [Header("Lerp")]

    public Transform target;

    public float lerpSpeed = 1f;

    public float speed;
    private float currentSpeed;

    private Vector3 _pos;
    private bool _canRun;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public GameObject endScreen;
    public GameObject startScreen;

    public TextMeshProUGUI uiTextPowerUp;

    private Vector3 startPosition;

    public bool invincible;
    private void Start()
    {
        startPosition = transform.position;
        ResetSpeed();
    }
    private void Update()
    {
        if (!_canRun)
        {
            return;
        }
        _pos = target.position;

        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invincible)
            {
                EndGame();
            }
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == tagToCheckEndLine)
        {
           
            EndGame();
        }
    }

    public void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
        startScreen.SetActive(false);
    }

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        currentSpeed = f;   
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }

    public void SetInvincible(bool value)
    {
        invincible = value;
    }
}
