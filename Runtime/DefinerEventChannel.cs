using System.Collections.Generic;
using UnityEngine;

namespace Definer.EventSystem
{
    public abstract class DefinerEventChannel<T> : ScriptableObject
    {
        readonly HashSet<DefinerEventListener<T>> observers = new();
        
        public void Invoke(T value)
        {
            foreach (var observer in observers)
            {
                observer.Raise(value);
            }
        }

        public void Invoke()
        {
            foreach (var observer in observers)
            {
                observer.Raise(default);
            }
        }
        public void Register(DefinerEventListener<T> observer) => observers.Add(observer);
        public void Deregister(DefinerEventListener<T> observer) => observers.Remove(observer);
    }
    
    public readonly struct Empty{}
    [CreateAssetMenu(menuName = "Events/EventChannel")]
    public class DefinerEventChannel : DefinerEventChannel<Empty> {}
    
}