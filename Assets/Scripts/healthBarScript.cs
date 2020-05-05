using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxHealth(float health)
	{
		//healthInt = (int)health;
		slider.maxValue = (int)health;
		slider.value = (int)health;

		fill.color = gradient.Evaluate(1f);
	}

    // Start is called before the first frame update
    public void setHealth(float health)
    {
    	//healthInt = (int)health;
		fill.color = gradient.Evaluate(slider.normalizedValue);

    	slider.value = (int)health;
    }
}
