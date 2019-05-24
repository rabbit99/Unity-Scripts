using UnityEngine;
using System.Collections;

namespace TouchPanelControl
{
    public interface ITouchCallback  {

        GameObject Target { get;}
        void OnMoveX (int dir);
        void OnMoveY (int dir);
        void OnClick ();
    }
}
