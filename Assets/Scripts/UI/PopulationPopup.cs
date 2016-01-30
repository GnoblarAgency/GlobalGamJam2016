using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopulationPopup : MonoBehaviour {


	public Text foodText;
	public Slider foodSlider;


	public Text prisonerText;
	public Slider prisonerSlider;


	private PopulationAssignment pop;


	void Start () 
	{
		pop = PopulationAssignment.instance;

	}

	void OnEnable () 
	{
		pop = PopulationAssignment.instance;
	}

	public void setReverse() //Sets food to be the leftover of prisoner hunting
	{
		if (foodSlider.value != pop.foodAssignment)
		{
			prisonerSlider.value = 1 - foodSlider.value;
			pop.foodAssignment = foodSlider.value;
			pop.prisonerAssignment = prisonerSlider.value;
		}
		else
			if (prisonerSlider.value != pop.prisonerAssignment)
			{
				foodSlider.value = 1 - prisonerSlider.value;
				pop.foodAssignment = foodSlider.value;
				pop.prisonerAssignment = prisonerSlider.value;
			}

		pop.UpdatePopulationAssignment ();

	}	
	


}
