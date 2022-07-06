using System;
using System.Collections;
using CodeBase.Core.Gameplay.Components.Weapon;
using UnityEngine;

namespace CodeBase.Engine.Components
{
    public class LaserReloadView : MonoBehaviour, IReloadView
    {
        public Transform View;
        public float ReloadedValueScale = 0.9f;
        public float WhenEmptyPosition = -0.1151f;

        public void ApplyProgress(float percents)
        {
            var scale = View.localScale;
            scale.x = ReloadedValueScale * percents;
            View.localScale = scale;

            var position = View.localPosition;
            position.x = Mathf.Lerp(WhenEmptyPosition, 0f, percents);
            View.localPosition = position;
        }
    }
}