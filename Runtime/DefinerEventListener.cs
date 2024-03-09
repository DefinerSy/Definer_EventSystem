using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Definer.EventSystem
{
    public class DefinerEventListener<T> : MonoBehaviour
    {
        [FormerlySerializedAs("eventChannel")] [SerializeField] DefinerEventChannel<T> definerEventChannel;
        [SerializeField] UnityEvent<T> unityEvent;

        protected void Awake()
        {
            definerEventChannel.Register(this);
        }

        protected void OnDestroy()
        {
            definerEventChannel.Deregister(this);
        }

        public void Raise(T value)
        {
            unityEvent?.Invoke(value);
        }
    }
    public class DefinerEventListener : DefinerEventListener<Empty>{}
}