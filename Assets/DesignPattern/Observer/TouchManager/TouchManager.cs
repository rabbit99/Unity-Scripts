using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TouchPanelControl
{
    public class TouchManager : MonoBehaviour
    {

        #region Variable

        int clickCount;
        float clickTime;

        Vector3 startMousePos;
        Vector3 endMousePos;

        private bool isLeft = false;

        InputHandler inputHandler;

        List<ITouchCallback> leftcallbackList = new List<ITouchCallback>();
        List<ITouchCallback> rightcallbackList = new List<ITouchCallback>();

        #endregion

        #region Proerty

        static public TouchManager Instance { get; private set; }

        public bool IsLeft
        {
            get
            {
                return isLeft;
            }

            set
            {
                //if (!HasRightList() && value == false)
                //{
                //    foreach(var go in rightcallbackList)
                //    {
                //        if (go.Target.activeSelf)
                //            continue;
                //        else
                //            break;
                //    }
                //    return;
                //}
                SendClearAllHighLight();

                isLeft = value;
                Debug.Log("TouchManager be change, bool IsLeft =" + isLeft);
                SendHighLight();
            }
        }

        public List<ITouchCallback> GetLocalCallBackList()
        {
            //Debug.Log("TouchManager.Instance.isLeft = " + IsLeft);
            return IsLeft ? leftcallbackList : rightcallbackList;
        }

        public bool HasLeftList()
        {
            return leftcallbackList.Count != 0 ? true : false;
        }

        public bool HasRightList()
        {
            return rightcallbackList.Count != 0 ? true : false;
        }

        #endregion

        #region Observer Behaviour

        public void AddLeftCallback(ITouchCallback callback)
        {
            if (!leftcallbackList.Exists(x => x.Target.Equals(callback.Target)))
                leftcallbackList.Add(callback);
            Debug.Log("AddLeftCallback = " + callback.Target.name);
        }

        public void AddRightCallback(ITouchCallback callback)
        {
            if (!rightcallbackList.Exists(x => x.Target.Equals(callback.Target)))
                rightcallbackList.Add(callback);
            Debug.Log("AddRightCallback = " + callback.Target.name);
        }

        public void RemoveLeftCallback(ITouchCallback callback)
        {
            leftcallbackList.Remove(callback);
            Debug.Log("RemoveLeftCallback = " + callback.Target.name);
        }

        public void RemoveRightCallback(ITouchCallback callback)
        {
            rightcallbackList.Remove(callback);
            Debug.Log("RemoveRightCallback = " + callback.Target.name);
        }

        #endregion

        #region Unity Behaviour ＆ Init

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        void Start()
        {
            DontDestroyOnLoad(gameObject);
#if UNITY_ANDROID && !UNITY_EDITOR
            inputHandler = gameObject.AddComponent<MMGInputHandler>();
            //inputHandler = gameObject.AddComponent<UnityEditorInputHandler>();
#elif UNITY_EDITOR
            inputHandler = gameObject.AddComponent<UnityEditorInputHandler>();
#endif
            if (inputHandler != null)
            {
                inputHandler.AddClick(SendClick);
                inputHandler.AddMove(SendMove);
            }
        }

#endregion

        #region Action Behaviour

        void SendClick()
        {
            for (int i = 0; i < GetLocalCallBackList().Count; i++)
                StartCoroutine(DelaySendClick(GetLocalCallBackList()[i]));
        }

        IEnumerator DelaySendClick(ITouchCallback callback)
        {
            Debug.Log("callback.Target = " + callback.Target.name);
            if (!callback.Target.activeSelf)
                yield break;

            yield return null;

            callback.OnClick();
        }

        void SendMove(bool isX, int dir)
        {
            Debug.Log(" GetLocalCallBackList().Count = "+ GetLocalCallBackList().Count);
            for (int i = 0; i < GetLocalCallBackList().Count; i++)
            {
                if (!GetLocalCallBackList()[i].Target.activeSelf)
                    continue;

                if (isX)
                {
                    Debug.Log("GetLocalCallBackList " + GetLocalCallBackList()[i].Target.name);
                    GetLocalCallBackList()[i].OnMoveX(dir);
                }
                else
                    GetLocalCallBackList()[i].OnMoveY(dir);
            }
        }

        void SendHighLight()
        {
            for (int i = 0; i < GetLocalCallBackList().Count; i++)
            {
                int oldindex = GetLocalCallBackList()[i].Target.GetComponent<ButtonSelect>().OldIndex;
                GetLocalCallBackList()[i].Target.GetComponent<ButtonSelect>().SetSelectBtn(oldindex); 
            }
        }

        void SendClearAllHighLight()
        {
            for (int i = 0; i < GetLocalCallBackList().Count; i++)
            {
                GetLocalCallBackList()[i].Target.GetComponent<ButtonSelect>().Switch_Off_AllBtn();
            }
        }

        #endregion

    }
}
