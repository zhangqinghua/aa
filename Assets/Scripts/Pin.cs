using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Pin : MonoBehaviour
{

    public float speed = 15f;
    
    public AudioSource hitAudio;
    public AudioSource deathAudio;

    private Rigidbody2D rb;
    private bool isPinned = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);
    }

    private void Update()
    {
        if (!isPinned)
        {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Rotator")
        {
            transform.SetParent(col.transform);
            hitAudio.Play();
            col.GetComponent<Rotator>().speed *= -1;
            Score.pinCount++;
        }
        else if (col.tag == "Pin")
        {
            // END GAME
            deathAudio.Play();
            FindObjectOfType<GameManager>().EndGame();
        }

        if (transform.parent == null) {
            transform.SetParent(col.transform.parent);
        }

        isPinned = true;
    }

}
