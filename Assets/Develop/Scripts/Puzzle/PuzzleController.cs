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

        private void Update()
		{
			if (InputSystem.Instance.GetLeftMouseButtonClick)
			{
				myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down, 20f, 1 << LayerMask.NameToLayer("Puzzle"));
				if (hit.collider)
				{
					Debug.Log(hit.collider.name);
                    currentSelectedPuzzle = hit.collider.transform;
				}
			}
		}

	}
}