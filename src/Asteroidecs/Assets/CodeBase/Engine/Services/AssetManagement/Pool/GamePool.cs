using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Engine.Services.AssetManagement.Pool
{
    public class GamePool
    {
        private readonly Transform _container;
        private readonly Queue<GameObject> _objects;

        public GamePool(Transform container)
        {
            _container = container;
            _objects = new Queue<GameObject>();
        }

        public bool HasObjects => 
            _objects.Count > 0;

        public void Push(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.transform.parent = _container;
            _objects.Enqueue(gameObject);
        }

        public GameObject Pull()
        {
            if (HasObjects == false)
                throw new InvalidOperationException("Not contains any object!");
            
            var gameObject = _objects.Dequeue();
            gameObject.transform.parent = null;
            gameObject.SetActive(true);
            return gameObject;
        }

        public void Cleanup()
        {
            while (HasObjects)
            {
                var gameObject = _objects.Dequeue();
                Object.Destroy(gameObject);
            }
            _objects.Clear();
        }
    }
}