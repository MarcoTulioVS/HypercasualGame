using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
