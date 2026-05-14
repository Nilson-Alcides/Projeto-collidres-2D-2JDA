using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    private float horizontal;

    [SerializeField] private float movimentoSpeed;

    private bool facingRigth; // Virado para direita

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        movimentoSpeed = 10;

        facingRigth = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        //HandMovimento(horizontal);
        //Debug.Log(horizontal);
    }
    void HandMovimento(float horizontal)
    {
       myRigidbody.linearVelocity = new Vector2(horizontal * movimentoSpeed, myRigidbody.linearVelocity.y);
        Debug.Log(horizontal);

    }
    void FixedUpdate()
    {
        HandMovimento(horizontal);

        Flip(horizontal);
    }
    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRigth || horizontal < 0 && facingRigth)
        {
            facingRigth = !facingRigth;
            Vector2 theScale = transform.localScale;

            //theScale.x *= theScale.x * -1;
            theScale.x *= -1;

            transform.localScale = theScale;
           // Debug.Log("O personagem virou");
        }
    }
    void OnCollisionEnter2D()
    {
        Debug.Log("Colidiu com o objeto");
    }
    void OnCollisionExit2D()
    {
        Debug.Log("Deixou de Colidir com o objeto");
    }

}
