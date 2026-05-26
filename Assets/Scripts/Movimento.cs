using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private float horizontal;

    private bool facingRight;

    [SerializeField] private float movimentoSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        movimentoSpeed = 10;

        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

    }
    // Melhoria FixedUpdate consome menos recurso da maquina
    void FixedUpdate()
    {
        HandMovimento(horizontal);

        Flip(horizontal);
    }

    void HandMovimento(float horizontal)
    {
        myRigidbody2D.linearVelocity = new Vector2(horizontal * movimentoSpeed, myRigidbody2D.linearVelocity.y);
        //Debug.Log(horizontal);
    }
    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;

            //theScale.x *= theScale.x * -1;
            theScale.x *= -1;

            transform.localScale = theScale;
            Debug.Log("O personagem virou");
        }
    }
    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Objetos")
        {
            Debug.Log("Colidiu com o objeto " + colisao.gameObject.name);
        }

    }

    void OnCollisionExit2D(Collision2D colisao)
    {

        Debug.Log("Saiu da colisão com o objeto");
    }

    void OnCollisionStay2D()
    {
        Debug.Log("Colidindo com o objeto");
    }
    // Função que detecta colisão com objeto TRIGGER
    void OnTriggerEnter2D(Collider2D colisao)
    {
        //Debug.Log("Colidiu com objeto TRIGGER");
        if (colisao.gameObject.tag == "Objetos")
        {
            Destroy(colisao.gameObject);
        }
    }
    // Função que detecta quando o player deixou de colidir com objeto TRIGGER
    void OnTriggerExit2D(Collider2D colisao)
    {
        // Debug.Log("Deixou de colidir com objeto TRIGGER");
    }
    // Função para detectar colisão continua com objeto TRIGGER
    void OnTriggerStay2D(Collider2D colisao)
    {
        // Debug.Log("Player continua colidindo  com objeto TRIGGER");
    }
}
