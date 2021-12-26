using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FirstGame
{
    /// <summary>
    /// 输入管理
    /// </summary>
    public class InputSystem : MonoBehaviour
    {
        private static InputSystem instance;
        public static InputSystem Instance { get => instance; }

        private float h = 0f;
        /// <summary>
        /// 获取前后移动的输入
        /// </summary>
        public float GetMoveInput
        {
            get => h;
        }

        private bool j = false;
        /// <summary>
        /// 获取跳跃时的输入
        /// </summary>
        public bool GetJumpInput
        {
            get => j;
        }

        private bool leftMouseButtonClick = false;
        /// <summary>
        /// 获取鼠标左键的点击
        /// </summary>
        public bool GetLeftMouseButtonClick { get => leftMouseButtonClick; }

        private bool rightMouseButtonClick = false;
        /// <summary>
        /// 获取鼠标右键的输入
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
        /// 切换输入模式
        /// </summary>
        /// <param name="playMode">模式</param>
        private void SwitchInputMode(PlayMode playMode)
        {
            switch (playMode)
            {
                case PlayMode.Partial:
                    // A D 移动输入
                    h = Input.GetAxisRaw("Horizontal");

                    // 点击空格键，跳跃
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        j = true;
                        //Debug.Log("点击空格");
                    }
                    else
                    {
                        j = false;
                    }
                    
                    break;

                case PlayMode.Global:
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Debug.Log("点击鼠标左键");
                        leftMouseButtonClick = true;
                    }
                    else
                    {
                        leftMouseButtonClick = false;
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        //Debug.Log("点击鼠标右键");
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
                        //Debug.Log("点击鼠标左键");
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
