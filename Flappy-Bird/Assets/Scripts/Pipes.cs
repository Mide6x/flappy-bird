using UnityEngine;

public class Pipes : MonoBehaviour
{
  public float speed = 5f;

  //remove pipe from screen
  //var represents left edge of screen
    private float leftEdge;

//edge point
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

  private void Update()
  {
    transform.position += Vector3.left * speed * Time.deltaTime;

    if (transform.position.x < leftEdge)
    {
        Destroy(gameObject);
    }
  } 


}
