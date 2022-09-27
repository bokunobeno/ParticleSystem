using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulllet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private GameObject decal;

    [SerializeField] private float bulletSpeed = 20f, LifeSpan = 2f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= LifeSpan)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.GetContact(0);
        GameObject impact = Instantiate(decal, contact.point + contact.normal * 0.001f, Quaternion.LookRotation(contact.normal));
        Destroy(impact , 4f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            Destroy(gameObject);
        Destroy(gameObject);
    }
}
