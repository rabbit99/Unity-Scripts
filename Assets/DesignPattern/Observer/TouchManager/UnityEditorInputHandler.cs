using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TouchPanelControl
{
    public class UnityEditorInputHandler : InputHandler
    {

        #region Variable

        int clickCount;
        float clickTime;

        Vector3 startMousePos;
        Vector3 endMousePos;

        #endregion

        void Start()
        {

        }

        public override void AddClick(Action data)
        {
            SendClick = data;
        }

        public override void AddMove(Action<bool, int> data)
        {
            SendMove = data;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                startMousePos = Input.mousePosition;


            if (Input.GetMouseButtonUp(0))
            {
                endMousePos = Input.mousePosition - startMousePos;

                if (Mathf.Abs(endMousePos.x) + Mathf.Abs(endMousePos.y) < 30f)
                {
                    if (Time.time - clickTime > 0.3f)
                        clickCount = 0;

                    clickCount++;

                    if (clickCount == 2)
                    {
                        //                    Debug.Log("click");
                        clickCount = 0;
                        SendClick();
                    }

                    clickTime = Time.time;
                }
                else
                {
                    if (Mathf.Abs(endMousePos.x) > Mathf.Abs(endMousePos.y))
                    {
                        if (endMousePos.x > 0)
                        {
                            Debug.Log("move right");
                            SendMove(true, 1);
                        }
                        else
                        {
                            Debug.Log("move left");
                            SendMove(true, -1);
                        }
                    }
                    else
                    {
                        if (endMousePos.y > 0)
                        {
                            Debug.Log("move up");
                            SendMove(false, -1);
                        }
                        else
                        {
                            Debug.Log("move down");
                            SendMove(false, 1);
                        }
                    }
                }

                //            Debug.Log(endMousePos);
            }
        }
    }
}
