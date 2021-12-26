using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstGame
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Collider2D coll;

        [Header("移动参数")]
        public float speed = 8f;

        float xVelocity;

        [Header("跳跃参数")]
        public float jumpForce = 6f;

        int jumpCount = 1;//跳跃次数

        [Header("状态")]
        public bool isOnGround;

        [Header("环境检测")]
        public LayerMask groundLayer;

        //按键设置
        bool jumpPress;

        private bool isInited = false;

        //void Start()
        //{
        //    Init();
        //}

        public void Init()
        {
            if (isInited)
            {
                return;
            }

            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();

            GameManager.Instance.SwitchToDefaultMode += () =>
            {
                this.enabled = false;
                rb.bodyType = RigidbodyType2D.Static;
            };

            GameManager.Instance.SwitchToGlobeMode += () =>
            {
                this.enabled = false;
                rb.bodyType = RigidbodyType2D.Static;
            };

            GameManager.Instance.SwitchToPartialMode += () =>
            {
                if (GameManager.Instance.currentPlayMode == PlayMode.Default)
                {
                    this.enabled = true;
                    rb.bodyType = RigidbodyType2D.Dynamic;
                }
                else
                {
                    StartCoroutine(EnableController());
                }     
            };

            isInited = true;
        }

        IEnumerator EnableController()
        {
            yield return new WaitForSeconds(2f);
            this.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        void Update()
        {
            if (InputSystem.Instance.GetJumpInput && jumpCount > 0)
            {
                jumpPress = true;
            }
        }

        void FixedUpdate()
        {
            isOnGroundCheck();
            Move();
            Jump();
        }

        void isOnGroundCheck()
        {
            ////判断角色碰撞器与地面图层发生接触
            if (coll.IsTouchingLayers(groundLayer))
            {
                isOnGround = true;
            }
            else
            {
                isOnGround = false;
            }
        }

        void Move()
        {
            xVelocity = InputSystem.Instance.GetMoveInput;

            rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

            //镜面翻转
            if (xVelocity != 0)
            {
                transform.localScale = new Vector3(xVelocity, 1, 1);
            }
        }

        void Jump()
        {
            //在地面上
            if (isOnGround)
            {
                jumpCount = 1;
            }
            //在地面上跳跃
            if (jumpPress && isOnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount--;
                jumpPress = false;
            }
            //在空中跳跃
            else if (jumpPress && jumpCount > 0 && !isOnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount--;
                jumpPress = false;
            }
        }
    }
}
