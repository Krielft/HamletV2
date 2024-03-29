﻿
using UnityEngine;

namespace LTX.Internal
{
    public class MonoSingletonFactory<T> : ISingletonFactory<T> where T : MonoBehaviour, ISingleton
    {
        public virtual T CreateSingleton()
        {
            string fullName = typeof(T).ToString();
            var nameArray = fullName.Split('.');
            string name = nameArray[nameArray.Length - 1] + " Instance";
            var singletonObject = new GameObject(name);
            Debug.Log($"{name} was created because none was found", singletonObject);
            return singletonObject.AddComponent<T>();
        }
    }
}