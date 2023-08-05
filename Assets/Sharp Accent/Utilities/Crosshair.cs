using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RM
{
	public class Crosshair : MonoBehaviour
	{
		public float maxSpread = 80;
		public float defaultSpread;
		public float spreadSpeed = 5;
		public float targetSpread;
		public bool independentUpdate = true;
		float curSpread;
		public float currentSpread {
			get {
				return curSpread;
			}
		}
		public Parts[] parts;
		
		float t;

		public static Crosshair singleton;

        public Controller controller;

        public void Init(Controller c)
        {
            controller = c;
        }

        private void Awake()
		{
			singleton = this;
		}

		private void Update()
		{
            Tick(Time.deltaTime);

            if (controller == null)
                return;

            float moving = Mathf.Abs(controller.horizontal +
                controller.vertical + controller.mouseX + controller.mouseY);

            AddSpread(moving);
        }

		public void Tick(float delta)
		{
			t = delta * spreadSpeed;

			if (targetSpread > maxSpread)
				targetSpread = maxSpread;

			curSpread = Mathf.Lerp(curSpread, targetSpread, t);
			for (int i = 0; i < parts.Length; i++)
			{
				Parts p = parts[i];
				p.trans.anchoredPosition = p.pos * curSpread;
			}

			targetSpread = Mathf.Lerp(targetSpread, defaultSpread, delta);
		}

		public void AddSpread(float v)
		{
			targetSpread += v;
		}

		public void LoadDefSpread(float v)
		{
			defaultSpread = v * 100;
		}
	}

	[System.Serializable]
	public class Parts
	{
		public RectTransform trans;
		public Vector2 pos;
	}
}
