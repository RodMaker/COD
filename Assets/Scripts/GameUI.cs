using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RM
{
    public class GameUI : MonoBehaviour
    {
        public TextMeshProUGUI currentBullets;
        public TextMeshProUGUI maxBullets;

        public GameObject interactionObj;
        public TextMeshProUGUI interactionText;
        public Slider interactionSlider;

        public static GameUI singleton;

        private void Awake()
        {
            singleton = this;
        }

        Controller controller;

        public void Init(Controller c)
        {
            controller = c;
        }

        private void LateUpdate()
        {
            if (controller== null) return;

            currentBullets.text = controller.currentWeapon.currentBullets.ToString();
            maxBullets.text = controller.currentWeapon.maxBulletsCarrying.ToString();

            if (controller.interactionAmount > 0)
            {
                interactionObj.SetActive(true);
                interactionText.text = controller.interactionText;
                interactionSlider.maxValue = controller.interactionMaxAmount;
                interactionSlider.value = controller.interactionAmount;
            }
            else
            {
                interactionObj.SetActive(false);
            }
        }
    }
}
