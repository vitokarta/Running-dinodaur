using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    
    public float movespeed = 3.5f;
    public float jumpforce = 350.0f;
    public bool isgrounded = false;
    public GameObject groundobject;
    public Color[] colors;

    static public bool Invincible = false;
    private float ftime = 0;
    private Vector2 Movedir;
    private Rigidbody2D m_rigidbody;
    private SpriteRenderer m_sprite;
    private Animator m_animator;
    private CapsuleCollider2D m_collider;

    private int x = 0;
    private float then = 0f;





    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_collider = GetComponent<CapsuleCollider2D>();
        isgrounded = false;
    }
    void Update()
    {
        m_animator.SetBool("isground", isgrounded);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Movedir.x = movespeed;    //向右給x正值
            m_animator.SetFloat("movespeed", 1);
            m_sprite.flipX=false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Movedir.x = -movespeed;   //向左給x負值
            m_animator.SetFloat("movespeed", 1);
            m_sprite.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Movedir.x = 0;   //不動規0
            m_animator.SetFloat("movespeed", 0);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && isgrounded)
        {
            m_rigidbody.AddForce(Vector2.up* jumpforce);
            m_animator.SetTrigger("jump");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_rigidbody.AddForce(Vector2.down * jumpforce*0.1f);
            m_collider.size=new Vector2(1.33f,1.33f);
            m_collider.offset = new Vector2(0f, 0.25f);
        }
        else
        {
            m_collider.size = new Vector2(1.33f, 1.84f);
            m_collider.offset = new Vector2(0f, 0f);
        }
        if(Invincible)
        {
            m_sprite.color = colors[1];
            if (Time.timeSinceLevelLoad-ftime >= 5f)//想间隔的时间
            {
                ftime = 9999f;//计时器复位
                m_sprite.color = colors[0];
                Invincible = false;
            }
            else if (Time.timeSinceLevelLoad - ftime >= 3.5f)
            {
                if(Time.timeSinceLevelLoad - then>0.2f)
                {
                    then = Time.timeSinceLevelLoad;
                    x = x ^ 1;
                }
                m_sprite.color = colors[x];
            }
            else m_sprite.color = colors[1];
        }
        Movedir.y = m_rigidbody.velocity.y; //照原重力下降
        m_rigidbody.velocity = Movedir;
    }

    
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isgrounded = true;
            groundobject = other.gameObject;
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == groundobject)
        {
            isgrounded = false;
            groundobject = null;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("monster") && !Invincible)
        {
            if ((int)(Time.timeSinceLevelLoad * 10.5f) > High_scr.high_score)
                High_scr.high_score = (int)(Time.timeSinceLevelLoad * 10.5f);
            Time.timeScale = 0;
        }
        if (other.gameObject.CompareTag("star"))
        {
            Invincible = true;
            ftime = Time.timeSinceLevelLoad;
        }

    }

}
