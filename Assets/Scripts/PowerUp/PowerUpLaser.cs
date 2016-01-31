using UnityEngine;
using System.Collections;

public class PowerUpLaser : PowerUp {

	LineRenderer lineRenderer;

	public override void StartCollectable(CollectableOwner owner)
	{
		base.StartCollectable(owner);
		lineRenderer = GetComponent<LineRenderer> ();	
		lineRenderer.enabled = true;
		owner.playerController.GetComponent<InventaryPowerUp> ().changeTo ("laser");
	}

	public void Update(){
		Vector3 fwd;

		if (owner != null) {
			if (owner.playerController.transform.tag == "Player") {
				float horizontal = Input.GetAxis ("HorizontalWASD");
				float vertical = Input.GetAxis ("VerticalWASD");
				fwd = new Vector3(horizontal, 0, vertical);
			} else if (owner.playerController.transform.tag == "PlayerDefense") {
				float horizontal = Input.GetAxis ("HorizontalArrows");
				float vertical = Input.GetAxis ("VerticalArrows");
				fwd = new Vector3(horizontal, 0, vertical);
			} else {
				return;
			}
			RaycastHit hit;
			Debug.Log (fwd);
			if (Physics.Raycast(transform.position, fwd, out hit)) {
				print("There is something in front of the object!");
				lineRenderer.enabled = true;         
				lineRenderer.SetPosition(0, transform.position); 
				lineRenderer.SetPosition(1, hit.point);

				if (hit.collider.tag == "Player" ||
				    hit.collider.tag == "PlayerDefense") {
					hit.collider.GetComponent<InventaryRune> ().DropRune ();
					FinishCollectable ();
				}
			}

		}
	}

	public override void FinishCollectable()
	{	
		if (owner)
			owner.playerController.GetComponent<InventaryPowerUp> ().changeTo ("none");
		lineRenderer.enabled = false;
		base.FinishCollectable();
	}
}
