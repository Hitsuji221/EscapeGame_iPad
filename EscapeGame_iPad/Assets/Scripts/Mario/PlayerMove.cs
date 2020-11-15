using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    bool forwardmove;
    bool backmove;
    bool rightmove;
    bool leftmove;

    //関数呼び出し
    [SerializeField] GameManage gameManage;
    [SerializeField] LayerMask blockLayer;
    //ボタン
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject jumpButton;
    //SE音
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip itemGet;
    AudioSource audioSource;

    Rigidbody2D rigidbody2D;
    float speed;

    //  動かしたいプレイヤー
    bool right = false;
    //  右ボタンを押しているかの真偽値
    bool left = false;
    //  左ボタンを押しているかの真偽値

    //実験
    float walkForce = 15.0f;
    float maxWalkSpeed = 2.0f;
    bool push;
    bool boolLeft;
    bool boolRight;
    float scale2 = 0.2f;
    float jumpForce = 45000;

    //ジャンプ
    float jumpPower = 45000;

    //クリア数字
    int clear = 0;

    public enum MOVE_DIRECTION
    {
        STOP,
        LEFT,
        RIGHT,
    }
    MOVE_DIRECTION moveDirection = MOVE_DIRECTION.STOP;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        this.push = false;
        this.boolLeft = false;
        this.boolRight = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = gameObject.transform.localScale;
        float jumpForce = 680.0f;

        float x = Input.GetAxis("Horizontal");
        if (x == 0)
        {
            //止まる
            moveDirection = MOVE_DIRECTION.STOP;
        }
        else if (x > 0)
        {
            //右に移動
            moveDirection = MOVE_DIRECTION.RIGHT;
            scale.x = 100; // そのまま（右向き）
            gameObject.transform.localScale = scale;

        }

        else if (x < 0)
        {
            //左に移動
            moveDirection = MOVE_DIRECTION.LEFT;
            scale.x = -100; // そのまま（左向き）
            gameObject.transform.localScale = scale;

        }

        if (IsGround() && Input.GetKeyDown("space"))
        {
            Jump();
        }

        // 左・右ボタン長押し用
        if (!this.push)
        {
            this.boolRight = false;
            this.boolLeft = false;
        }

        // 左・右キー押下処理
        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);
        if (Input.GetKey(KeyCode.RightArrow) || boolRight)
        {
            // 右キー押下時
            this.rigidbody2D.AddForce(transform.right * this.walkForce * 700);
            scale.x = 100; // そのまま（右向き）
            if (speedx < this.maxWalkSpeed)
            {
                this.rigidbody2D.AddForce(transform.right * this.walkForce * 700);
                scale.x = 100;
                gameObject.transform.localScale = scale;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || boolLeft)
        {
            // 左キー押下時
            this.rigidbody2D.AddForce(transform.right * this.walkForce * -700);
            scale.x = -100; // 左向き
            if (speedx < this.maxWalkSpeed)
            {
                this.rigidbody2D.AddForce(transform.right * this.walkForce * -700);
                scale.x = -100;
                gameObject.transform.localScale = scale;
            }
        }
        //クリア後
        if (clear == 3)
        {
            Debug.Log("Clear!!!!!");
            SceneManager.LoadScene("AfterRoom5");
        }
    }

    // 左移動ボタン離した時
    public void LButtonPushUp()
    {
        this.push = false;
    }

    // 左移動ボタン押下時
    public void LButtonPushDown()
    {
        this.boolLeft = true;
        this.push = true;
    }

    // 右移動ボタン離した時
    public void RButtonPushUp()
    {
        this.push = false;
    }

    // 右移動ボタン押下時
    public void RButtonPushDown()
    {
        this.boolRight = true;
        this.push = true;
    }

    public void JumpButtonDown()
    {
        if (IsGround())
        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
            audioSource.PlayOneShot(jump);
        }

    }

    private void FixedUpdate()
    {
        switch (moveDirection)
        {
            case MOVE_DIRECTION.STOP:
                speed = 0;
                break;
            case MOVE_DIRECTION.LEFT:
                speed = -200;
                break;
            case MOVE_DIRECTION.RIGHT:
                speed = 200;
                break;
        }
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpPower);
    }

    bool IsGround()
    {
        Debug.DrawLine(transform.position - transform.right * 0.2f, transform.position - transform.up * 0.1f);
        Debug.DrawLine(transform.position + transform.right * 0.2f, transform.position - transform.up * 0.1f);
        //地面に触れている間
        return Physics2D.Linecast(transform.position - transform.right * 0.2f, transform.position - transform.up * 0.1f, blockLayer) ||
            Physics2D.Linecast(transform.position + transform.right * 0.2f, transform.position - transform.up * 0.1f, blockLayer);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ゲームオーバー
        if(collision.gameObject.tag == "Trap")
        {
            Debug.Log("GameOver");
            gameManage.GameOver();

        }


        //雑巾の消失
        if (collision.gameObject.tag == "Zoukin")
        {
            collision.gameObject.GetComponent<ItemManager>().GetZoukin();
        }
        //新聞の消失
        if (collision.gameObject.tag == "Shinbun")
        {
            collision.gameObject.GetComponent<ItemManager>().GetShinbun();
        }
        //汚ナプキンの消失
        if (collision.gameObject.tag == "BadNapukin")
        {
            collision.gameObject.GetComponent<ItemManager>().GetBadNapukin();
        }
        //タオルの消失
        if (collision.gameObject.tag == "Towel")
        {
            collision.gameObject.GetComponent<ItemManager>().GetTowel();
            clear += 1;
            audioSource.PlayOneShot(itemGet);
        }
        //ハンカチの消失
        if (collision.gameObject.tag == "Handkerchief")
        {
            collision.gameObject.GetComponent<ItemManager>().GetHandkerchief();
            clear += 1;
            audioSource.PlayOneShot(itemGet);
        }
        //タオルの消失
        if (collision.gameObject.tag == "Napkin")
        {
            collision.gameObject.GetComponent<ItemManager>().GetNapkin();
            clear += 1;
            audioSource.PlayOneShot(itemGet);
        }
    }
}
