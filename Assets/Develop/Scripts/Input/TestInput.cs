using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstGame 
{
    public class TestInput : MonoBehaviour
    {
        private void Update()
        {
            //Debug.Log($"前后移动输入：{InputSystem.Instance.GetMoveInput}");
            //Debug.Log($"跳跃输入：{InputSystem.Instance.GetJumpInput}");
            //Debug.Log($"鼠标左键输入：{InputSystem.Instance.GetLeftMouseButtonInput}");
            //Debug.Log($"鼠标右键输入：{InputSystem.Instance.GetRightMouseButtonInput}");
            //if (InputSystem.Instance.GetLeftMouseButtonClick)
            //{
            //    Debug.Log("获取到鼠标左键的点击");
            //}
            //if (InputSystem.Instance.GetRightMouseButtonClick)
            //{
            //    Debug.Log("获取到鼠标右键的点击");
            //}

            //rb2D.MovePosition(rb2D.position + new Vector2(InputSystem.Instance.GetMoveInput, 0f) * speed * Time.deltaTime);
            //Debug.Log(InputSystem.Instance.GetJumpInput);
            //rb2D.MovePosition(new Vector2(0f, InputSystem.Instance.GetJumpInput));
        }
    }
}