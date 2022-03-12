using System;
using System.Collections;
using CodeBase.Core.Gameplay.Components.Weapon;
using UnityEngine;

namespace CodeBase.Engine.Components
{
    public class LaserReloadView : MonoBehaviour, IReloadView
    {
        public Transform View;
        public float ReloadedValue = 0.9f;
        public float LeftPoint = -0.1151f;
        
        public void ApplyProgress(float percents)
        {
            var scale = View.localScale;
            scale.x = ReloadedValue * percents;
            View.localScale = scale;

            var position = View.localPosition;
            position.x = Mathf.Lerp(LeftPoint, 0f, percents);
            View.localPosition = position;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                StartCoroutine(Reloading());
        }

        private IEnumerator Reloading()
        {
            var t = 0f;
            while (t < 1)
            {
                t += Time.deltaTime;
                ApplyProgress(t);
                yield return null;
            }
        }
    }
}