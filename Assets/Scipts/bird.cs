using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool tamuerto = false;
    private Rigidbody2D rb2d;
    public float upforce = 200f;
    private Animator anim;

    public int oofs = 2;
    private SpriteRenderer spritey;
    private PolygonCollider2D poliCol; 

    // Start is called before the first frame update
    void Start()
    {
        spritey = GetComponent<SpriteRenderer>();
        poliCol = GetComponent<PolygonCollider2D>();
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if  (tamuerto == false)
        {
            if (Input.GetButtonDown("Flap"))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce (new Vector2(0,upforce));
                anim.SetTrigger("Flap");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Column")
        {
            oofs--;
            if (oofs <= 0)
            {
                rb2d.velocity = Vector2.zero;
                tamuerto = true;
                anim.SetTrigger("Die");
                GameController.instance.BirdDied();
            }
            else
            {
                poliCol.enabled = false;
                spritey.color = new Color(1, 0, 0, 0.5f);
                StartCoroutine(EnableBox(1.0F));
            }
        }
        else
        {

            rb2d.velocity = Vector2.zero;
            tamuerto = true;
            anim.SetTrigger("Die");
            GameController.instance.BirdDied(); 
        }
    }
    IEnumerator EnableBox(float waitTime)
    {
         yield return new WaitForSeconds(waitTime);
         poliCol.enabled = true;
         spritey.color = new Color(1, 1, 1, 1);
    }
}
