using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstGame 
{
    public class PuzzleController : MonoBehaviour
    {
        //public Transform[] puzzleGroup;

        private Transform currentSelectedPuzzle;
        //public Transform CurrentSelectedPuzzle
        //{
        //    get => currentSelectedPuzzle;
        //    set => currentSelectedPuzzle = value;
        //}

		public Ray myRay;
		public RaycastHit2D hit;

        private bool isInited = false;

        //void Start()
        //{
        //    Init();
        //}

        private void OnEnable()
        {
            isSelected = false;
        }

        public void Init()
        {
            if (isInited)
            {
                return;
            }

            GameManager.Instance.SwitchToDefaultMode += () =>
            {
                this.enabled = false;
            };

            GameManager.Instance.SwitchToGlobeMode += () =>
            {
                StartCoroutine(EnableController());
            };

            GameManager.Instance.SwitchToPartialMode += () =>
            {
                this.enabled = false;
            };

            isInited = true;
        }

        IEnumerator EnableController()
        {
            yield return new WaitForSeconds(2f);
            this.enabled = true;
        }

        private bool isExistPlayer = false;
        public bool IsExistPlayer { get => isExistPlayer; set => isExistPlayer = value; }

        private void Update()
		{
			if (InputSystem.Instance.GetLeftMouseButtonClick)
			{
				myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down, 20f, 1 << LayerMask.NameToLayer("Puzzle"));
				if (hit.collider.tag == "Puzzle")
				{
                    if (isSelected)
                    {
                        ChangeTransform(currentSelectedPuzzle, hit.transform);
                        currentSelectedPuzzle = null;
                        isSelected = false;
                    }
                    else
                    {
                        currentSelectedPuzzle = hit.collider.transform;
                        Debug.Log($"选中的拼图：{hit.collider.name}");
                        isSelected = true;
                    }                  
				}
			}

            if (InputSystem.Instance.GetRightMouseButtonClick)
            {
                myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down, 20f, 1 << LayerMask.NameToLayer("Puzzle"));
                if (hit.collider.tag == "Puzzle")
                {
                    Rotate(hit.transform);
                }
            }
		}

        private bool isSelected = false;

        /// <summary>
        /// 位置交换
        /// </summary>
        /// <param name="from">已经选中的物体</param>
        /// <param name="to">要交换的物体</param>
        private void ChangeTransform(Transform from,Transform to)
        {
            if(from.name == to.name)
            {
                return;
            }

            Vector3 pos = from.position;
            from.position = to.position;
            to.position = pos;
            Debug.Log($"交换 {from.name} 和 {to.name} 的位置");
        }

        /// <summary>
        /// 顺时针旋转90度
        /// </summary>
        /// <param name="trans">要交换的物体</param>
        private void Rotate(Transform trans)
        {
            if(trans.localEulerAngles.z >= 270f)
            {
                trans.localEulerAngles -= new Vector3(0f, 0f, -360f);
            }

            trans.localRotation = Quaternion.Euler(0f, 0f, trans.localEulerAngles.z + 90f);
            Debug.Log($"{trans.name}顺时针旋转90度");
        }
	}
}