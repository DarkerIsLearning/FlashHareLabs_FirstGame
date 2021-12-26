using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FirstGame
{
    /// <summary>
    /// ��Ϸģʽ
    /// </summary>
    public enum PlayMode
    {
        Default = 0,
        Partial, // ��Ҿֲ��ӽ�
        Global // ȫ���ӽ�
    }

    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get => instance; }

        public PlayerController PlayerController { get; private set; }
        public CameraController CameraController { get; private set; }
        public PuzzleController PuzzleController { get; private set; }

        /// <summary>
        /// ��ǰ������ģʽ
        /// </summary>
        public PlayMode currentPlayMode = PlayMode.Default;
        /// <summary>
        /// �л�״̬������
        /// </summary>
        public PlayMode CurrentPlayMode
        {
            get => currentPlayMode;
            set
            {                
                switch (value)
                {
                    case PlayMode.Global:
                        SwitchToGlobeMode?.Invoke();
                    break;
                    case PlayMode.Partial:
                        SwitchToPartialMode?.Invoke();
                    break;
                    default:
                        SwitchToDefaultMode?.Invoke();
                    break;
                }
                currentPlayMode = value;
            }
        }

        public UnityAction SwitchToDefaultMode;
        public UnityAction SwitchToGlobeMode;
        public UnityAction SwitchToPartialMode;

        private bool isInited = false;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            if (isInited)
            {
                return;
            }

            InputSystem.Instance.Init();
            PlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            PlayerController.Init();
            CameraController = Camera.main.GetComponent<CameraController>();
            CameraController.Init();
            //PuzzleController = GameObject.FindWithTag("Puzzle").GetComponent<PuzzleController>();
            //PuzzleController.Init();

            CurrentPlayMode = PlayMode.Default;

            isInited = true;
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Default"))
            {
                CurrentPlayMode = PlayMode.Default;
            }

            if (GUILayout.Button("Global"))
            {
                CurrentPlayMode = PlayMode.Global;
            }

            if (GUILayout.Button("Partial"))
            {
                CurrentPlayMode = PlayMode.Partial;
            }
        }
    }
}