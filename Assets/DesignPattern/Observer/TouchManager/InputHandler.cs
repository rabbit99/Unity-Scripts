using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TouchPanelControl
{
    public abstract class InputHandler : MonoBehaviour
    {
        protected Action SendClick;
        protected Action<bool, int> SendMove;

        public virtual void AddClick(Action data)
        {
            
        }

        public virtual void AddMove(Action<bool, int> data)
        {

        }

    }
}