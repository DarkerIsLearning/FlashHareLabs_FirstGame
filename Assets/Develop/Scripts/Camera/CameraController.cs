using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstGame
{
    public class CameraController : MonoBehaviour
    {
        public GameObject vc_Globel;
        public GameObject vc_Partial;

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

            GameManager.Instance.SwitchToDefaultMode += () =>
            {
                // �л���UI���
            };

            GameManager.Instance.SwitchToGlobeMode += () =>
            {
                SwitchVisualCamera(vc_Partial, vc_Globel);
            };

            GameManager.Instance.SwitchToPartialMode += () =>
            {
                SwitchVisualCamera(vc_Globel, vc_Partial);
            };

            isInited = true;
        }

        /// <summary>
        /// �����֮���л�
        /// </summary>
        /// <param name="from">Ҫ�رյ����</param>
        /// <param name="to">Ҫ���������</param>
        public void SwitchVisualCamera(GameObject from, GameObject to)
        {
            from.SetActive(false);
            to.SetActive(true);
        } 
    }
}