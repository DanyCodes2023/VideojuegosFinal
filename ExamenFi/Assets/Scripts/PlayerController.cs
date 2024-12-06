using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxBullets = 5;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public TMPro.TextMeshProUGUI bulletText;

    private Rigidbody2D rb;
    private Animator animator;
    private int bulletsRemaining;
    private bool isGrounded;

    void Start()
    {
       
    }

    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

   
}