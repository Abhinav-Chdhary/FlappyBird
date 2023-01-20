using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; //Array for bird animation
    private int startIndex; //to keep track of states of sprite
    private Vector3 direction; //direction of movement of bird
    public float gravity = -9.8f; //to customize gravity
    public float strength = 5f; //strength of bird
    public AudioSource ScoreSound;
    public AudioSource jumpSound;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(Animate), 0.15f, 0.15f);
        // to repeatedly change state of bird
        // InvokeRepeating(nameof(functionName), time, frequency);
    }
    //function to reset position when Game Over
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            jumpSound.Play();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                jumpSound.Play();
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void Animate()
    {
        startIndex++;
        if (startIndex >= sprites.Length)
        {
            startIndex= 0; //to start over once again
        }
        spriteRenderer.sprite = sprites[startIndex];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.gameObject.tag == "Scoring")
        {
            ScoreSound.Play();
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
