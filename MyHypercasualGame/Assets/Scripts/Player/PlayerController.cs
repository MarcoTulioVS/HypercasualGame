using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;
using DG.Tweening;
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

    [Header("Coin Setup")]

    public GameObject coinCollector;
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

    public void ChangeHeight(float amount,float duration,float animationDuration,Ease ease)
    {
        //var p = transform.position;
        //p.y = startPosition.y + amount;
        //transform.position = p;

        transform.DOMoveY(startPosition.y + amount,animationDuration).SetEase(ease);
        Invoke("ResetHeight", duration);
    }

    public void ResetHeight()
    {
        //var p = transform.position;
        //p.y = startPosition.y;
        //transform.position = p;

        transform.DOMoveY(startPosition.y, 0.1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
}
