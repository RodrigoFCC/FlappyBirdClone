using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    public float velocity = 4f;
    private Rigidbody2D rigidbody;

    public GameObject GameOver;

    public AudioClip flySound;
    public AudioClip gameOverSound;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
  
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity; 
            SoundManager.instance.PLaySound(flySound); 
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, rigidbody.velocity.y * rotationSpeed);
    }

    void OnCollisionEnter2D(Collision2D collider) 
    {
        SoundManager.instance.PLaySound(gameOverSound);
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}