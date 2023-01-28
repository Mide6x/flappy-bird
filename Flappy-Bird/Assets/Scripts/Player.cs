using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    

  private Vector3 direction;
  public float gravity = -9.8f;
  public float strength = 5f;

  private void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

//gets called when the first frame starts
  private void Start()
  {
    InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
  }

  private void OnEnable() //update player position to center when game restarts
  {
    Vector3 position = transform.position;
    position.y = 0f;
    transform.position = position;

    direction = Vector3.zero;
  }

  private void Update()
  {
    //function that accepts input from the spacebar and the left mouse button so it changes the position of the player up
     if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
        direction = Vector3.up * strength;
     }

        //for touchscreen devices
     if(Input.touchCount > 0)
     {
        Touch touch = Input.GetTouch(0);

        //ignore any touch other than the first

        if(touch.phase == TouchPhase.Began) {
            direction = Vector3.up * strength;
        }

     }

     //apply gravity to the direction
     direction.y += gravity * Time.deltaTime;
     //update position of player
     transform.position += direction * Time.deltaTime; //constant fps

  }

  private void AnimateSprite()
  {
    spriteIndex++;

    if(spriteIndex >= sprites.Length) {
        spriteIndex = 0;
    }

    spriteRenderer.sprite = sprites[spriteIndex];
  }

  
    //recognise collision
    
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Obstacle"){
      FindObjectOfType<GameManager>().GameOver();
    } else if (other.gameObject.tag == "Scoring"){
      FindObjectOfType<GameManager>().IncreaseScore();
    }
  }
}
