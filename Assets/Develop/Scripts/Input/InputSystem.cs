using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FirstGame
{
    /// <summary>
    /// �������
    /// </summary>
    public class InputSystem : MonoBehaviour
    {
        private static InputSystem instance;
        public static InputSystem Instance { get => instance; }

        private float h = 0f;
        /// <summary>
        /// ��ȡǰ���ƶ�������
        /// </summary>
        public float GetMoveInput
        {
            get => h;
        }

        private bool j = false;
        /// <summary>
        /// ��ȡ��Ծʱ������
        /// </summary>
        public bool GetJumpInput
        {
            get => j;
        }

        private bool leftMouseButtonClick = false;
        /// <summary>
        /// ��ȡ�������ĵ��
        /// </summary>
        public bool GetLeftMouseButtonClick { get => leftMouseButtonClick; }

        private bool rightMouseButtonClick = false;
        /// <summary>
        /// ��ȡ����Ҽ�������
        /// </summary>
        public bool GetRightMouseButtonClick { get => rightMouseButtonClick; }

        private PlayMode playMode;

        private bool isInited = false;

        private void Awake()
        {
            instance = this;
        }

        public void Init()
        {
            if (isInited)
            {
                return;
            }

            GameManager.Instance.SwitchToDefaultMode += () =>
            {
                playMode = PlayMode.Default;
            };

            GameManager.Instance.SwitchToGlobeMode += () =>
            {
                playMode = PlayMode.Global;
            };

            GameManager.Instance.SwitchToPartialMode += () =>
            {
                playMode = PlayMode.Partial;
            };

            isInited = true;
        }

        private void Update()
        {
            SwitchInputMode(playMode);
        }

        /// <summary>
        /// �л�����ģʽ
        /// </summary>
        /// <param name="playMode">ģʽ</param>
        private void SwitchInputMode(PlayMode playMode)
        {
            switch (playMode)
            {
                case PlayMode.Partial:
                    // A D �ƶ�����
                    h = Input.GetAxisRaw("Horizontal");

                    // ����ո������Ծ
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        j = true;
                        //Debug.Log("����ո�");
                    }
                    else
                    {
                        j = false;
                    }
                    
                    break;

                case PlayMode.Global:
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Debug.Log("���������");
                        leftMouseButtonClick = true;
                    }
                    else
                    {
                        leftMouseButtonClick = false;
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        //Debug.Log("�������Ҽ�");
                        rightMouseButtonClick = true;
                    }
                    else
                    {
                        rightMouseButtonClick = false;
                    }
                    break;

                default:
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Debug.Log("���������");
                        leftMouseButtonClick = true;
                    }
                    else
                    {
                        leftMouseButtonClick = false;
                    }
                    break;
            }
        }       
    }
}
