using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMG;
using MMG.DataModels;

namespace TouchPanelControl
{
    public class MMGInputHandler : InputHandler
    {

        void Start()
        {
            MMGInput.onTouch.Swipe().AddListener(onSwipeEvent);
            MMGInput.onClick.KeyDown().AddListener(KeyDown);
            MMGInput.onTouch.DoubleTap().AddListener(TapCount);
        }

        public override void AddClick(Action data)
        {
            SendClick = data;
        }

        public override void AddMove(Action<bool, int> data)
        {
            SendMove = data;
        }

        #region Listen Event

        /// <summary>
        /// Touch Callback.
        /// </summary>
        private void TapCount(Tap tap)
        {
            //Enter
            SendClick();
        }

        private void onSwipeEvent(Swipe swipe)
        {
            switch (swipe.direction)
            {
                case Swipe.Direction.RIGHT:
                    //Swiping Right
                    SendMove(true, 1);
                    break;
                case Swipe.Direction.LEFT:
                    //Swiping Left
                    SendMove(true, -1);
                    break;
                case Swipe.Direction.UP:
                    //Swiping Up
                    SendMove(false, -1);
                    break;
                case Swipe.Direction.DOWN:
                    //Swiping Down
                    SendMove(false, 1);
                    break;
                default: break;
            }
        }

        private void KeyDown(MMGKeyCode keycode)
        {
            switch (keycode)
            {
                case MMGKeyCode.BACK:
                    //Back
                    break;
                case MMGKeyCode.LEFT_UP:
                    //Left / Up
                    break;
                case MMGKeyCode.RIGHT_DOWN:
                    //Right / Down
                    break;
                case MMGKeyCode.CONFIRM:
                    //Enter
                    break;
                case MMGKeyCode.MENU:
                    //Menu
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
