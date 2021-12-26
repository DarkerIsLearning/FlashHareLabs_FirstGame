using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstGame
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Collider2D coll;

        [Header("�ƶ�����")]
        public float speed = 8f;

        float xVelocity;

        [Header("��Ծ����")]
        public float jumpForce = 6f;

        int jumpCount = 1;//��Ծ����

        [Header("״̬")]
        public bool isOnGround;

        [Header("�������")]
        public LayerMask groundLayer;

        //��������
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
            ////�жϽ�ɫ��ײ�������ͼ�㷢���Ӵ�
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

            //���淭ת
            if (xVelocity != 0)
            {
                transform.localScale = new Vector3(xVelocity, 1, 1);
            }
        }

        void Jump()
        {
            //�ڵ�����
            if (isOnGround)
            {
                jumpCount = 1;
            }
            //�ڵ�������Ծ
            if (jumpPress && isOnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount--;
                jumpPress = false;
            }
            //�ڿ�����Ծ
            else if (jumpPress && jumpCount > 0 && !isOnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount--;
                jumpPress = false;
            }
        }
    }
}
