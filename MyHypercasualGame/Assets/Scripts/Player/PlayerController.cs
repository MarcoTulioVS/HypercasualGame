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
    private void Update()
    {
        _pos = target.position;

        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
