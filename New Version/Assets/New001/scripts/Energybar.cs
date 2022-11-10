using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Teddy
{
    ///<summary>
    ///電力條
    ///</summary>
    public class Energybar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxEnergy(int energy)
        {
            slider.maxValue = energy;
            slider.value = energy;
        
        }
        public void SetEnergy(int energy)
        {
            slider.value = energy;
        }
        
    }
}
