using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Engine.Services.AssetManagement.Pool
{
    public class Pool
    {
        private readonly Queue<GameObject> _objects;
        private readonly Vector3 _outGamePoint = new Vector3(-25, -25, -25);
        private readonly Lazy<Scene> _rootScene;

        public Pool(string name)
        {
            _objects = new Queue<GameObject>();
            _rootScene = new Lazy<Scene>(() => SceneManager.CreateScene($"[Pool] {name}"));
        }

        public bool HasObjects => _objects.Count > 0;

        public void Push(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.transform.position = _outGamePoint;
            SceneManager.MoveGameObjectToScene(gameObject, _rootScene.Value);
            _objects.Enqueue(gameObject);
        }

        public GameObject Pull(Vector3 at, Quaternion with)
        {
            if (HasObjects == false)
                throw new InvalidOperationException("Not contains any object!");

            var gameObject = _objects.Dequeue();
            gameObject.SetActive(true);
            gameObject.transform.position = at;
            gameObject.transform.rotation = with;
            return gameObject;
        }

        public void Cleanup()
        {
            SceneManager.UnloadSceneAsync(_rootScene.Value);
            _objects.Clear();
        }
    }
}