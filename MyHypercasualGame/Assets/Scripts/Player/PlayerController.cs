using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Lerp")]

    public Transform target;

    public float lerpSpeed = 1f;

    public float speed;

    private Vector3 _pos;
    private bool _canRun;

    public string tagToCheckEnemy = "Enemy";

    private void Start()
    {
        _canRun = true;
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
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            _canRun = false;
        }
    }
}
