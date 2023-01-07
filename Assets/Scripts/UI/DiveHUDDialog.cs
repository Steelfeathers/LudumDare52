using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using FirebirdGames.Utilities;
using FirebirdGames.Utilities.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare52
{
    public class DiveHUDDialog : Dialog
    {
        [SerializeField] private Slider oxygenSlider;
        [SerializeField] private TextMeshProUGUI oxygenReadout;
        [SerializeField] private Slider staminaSlider;
        [SerializeField] private TextMeshProUGUI staminaReadout;
        
        public void UpdateOxygenMeter(float curValue, float maxValue, bool animate=false)
        {
            UpdateMeter(oxygenSlider, oxygenReadout, curValue, maxValue, animate);
        }
        public void UpdateStaminaMeter(float curValue, float maxValue, bool animate=false)
        {
            UpdateMeter(staminaSlider, staminaReadout, curValue, maxValue, animate);
        }
        
        private void UpdateMeter(Slider slider, TextMeshProUGUI textfield, float curValue, float maxValue, bool animate=false)
        {
            textfield.text = $"{(int)curValue}/{(int)maxValue}";
            
            slider.minValue = 0;
            slider.maxValue = maxValue;

            float targetVal = curValue;
            if (animate)
                DOTween.To(() => slider.value, val => slider.value = val, targetVal, 0.2f);
            else
                slider.value = targetVal;
           
        }

        public void OnSettingsClicked()
        {
            Utils.QuitApplication();
        }
    }
}
