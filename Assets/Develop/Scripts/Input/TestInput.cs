using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstGame 
{
    public class TestInput : MonoBehaviour
    {
        private void Update()
        {
            //Debug.Log($"ǰ���ƶ����룺{InputSystem.Instance.GetMoveInput}");
            //Debug.Log($"��Ծ���룺{InputSystem.Instance.GetJumpInput}");
            //Debug.Log($"���������룺{InputSystem.Instance.GetLeftMouseButtonInput}");
            //Debug.Log($"����Ҽ����룺{InputSystem.Instance.GetRightMouseButtonInput}");
            //if (InputSystem.Instance.GetLeftMouseButtonClick)
            //{
            //    Debug.Log("��ȡ���������ĵ��");
            //}
            //if (InputSystem.Instance.GetRightMouseButtonClick)
            //{
            //    Debug.Log("��ȡ������Ҽ��ĵ��");
            //}

            //rb2D.MovePosition(rb2D.position + new Vector2(InputSystem.Instance.GetMoveInput, 0f) * speed * Time.deltaTime);
            //Debug.Log(InputSystem.Instance.GetJumpInput);
            //rb2D.MovePosition(new Vector2(0f, InputSystem.Instance.GetJumpInput));
        }
    }
}