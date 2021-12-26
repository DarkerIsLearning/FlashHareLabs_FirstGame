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
                // 切换到UI相机
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
        /// 两相机之间切换
        /// </summary>
        /// <param name="from">要关闭的相机</param>
        /// <param name="to">要开启的相机</param>
        public void SwitchVisualCamera(GameObject from, GameObject to)
        {
            from.SetActive(false);
            to.SetActive(true);
        } 
    }
}