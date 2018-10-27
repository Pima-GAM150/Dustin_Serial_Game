using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public int Factor;
    public int LifeSpan;

	
	
    public IEnumerator Disapear()
    {
        while(true)
        {
            yield return new WaitForSeconds(LifeSpan);

            Destroy(this.gameObject);
        }
    }
}
