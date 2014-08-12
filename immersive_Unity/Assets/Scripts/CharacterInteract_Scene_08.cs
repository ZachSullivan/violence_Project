using UnityEngine;
using System.Collections;

public class CharacterInteract_Scene_08 : MonoBehaviour {

	//public materials Material;

	public Transform targetFollow;
	
	//public GameObject head;
	//public GameObject spine;

	//public GUIText target;
	
	public bool itemUseable = true;
	
	private Quaternion localRotation;


	//private float maxHeadRot, maxSpineRot;
	//public float smooth = 0.3F;
	//public float distance = 5.0F;
	Animator anim;
	bool isSitting;
	Vector3 adjustRot = new Vector3(0, -90, -90);

	Quaternion saveRotation;
		
	bool rotationReset = false;
	//bool used to check if the children of radial_background need to be shown
	bool hideMenu = false;
	int damp = 5;

	void Start(){
		//renderer.material = new Material(Material.defaultMaterial);
		saveRotation = GameObject.FindWithTag("Player").transform.rotation;

		anim = GetComponent<Animator>();


	}

	void Awake(){
		//maxHeadRot = 85.0f;
		//maxSpineRot = 35.0f;
	}

	void Update(){
		isSitting = anim.GetBool ("isSitting");

		if(!itemUseable){

			GetComponent<DialogGUI_Scene_08>().enabled = true;

			GameObject.Find("radial_background").GetComponent<MeshRenderer>().enabled = true;
			GameObject.Find ("radial_dial").GetComponent<MeshRenderer>().enabled = true;
			hideMenu = false;
			ToggleMenu();

			GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>().enabled = false;
			GameObject.FindWithTag("Player").GetComponent<SmoothLook>().enabled = true;
			GameObject.FindWithTag("Player").GetComponent<MouseLook>().enabled = false;
			rotationReset = true;

			//Now that the object has been used, it must always face towards the player.
			if(targetFollow != null && isSitting != true){
              		
				 	var lookPos = targetFollow.position - transform.position;
					lookPos.y = 0;
					
					var rotationAngle = Quaternion.LookRotation (lookPos);
					transform.rotation = Quaternion.Slerp ( transform.rotation, rotationAngle, Time.deltaTime * damp);
			}
			else{
				//Don't look at player
			}
		}
		//If the player has left the interaction with the object,
		//then allow the player to move and look around again.
		else if(rotationReset){
		
			GetComponent<DialogGUI_Scene_08>().enabled = false;

			GameObject.Find("radial_background").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find ("radial_dial").GetComponent<MeshRenderer>().enabled = false;
			hideMenu = true;
			ToggleMenu();


			GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>().enabled = true;
			GameObject.FindWithTag("Player").GetComponent<MouseLook>().enabled = true;
			GameObject.FindWithTag("Player").GetComponent<SmoothLook>().enabled = false;
			GameObject.FindWithTag("Player").transform.rotation = saveRotation;
			rotationReset = false;
		}
	}
	
	void FixedUpdate(){
		//target.text = "";
		//renderer.material = Material.defaultMaterial;
	}

	//If the player moves into range of the object,
	//have the object glow and display text to interact.d
	public void OnLookEnter(){

		if(itemUseable){

			//target.text = "Talk E";
			//renderer.material = Material.glowMaterial;

			//if(Input.GetKeyDown(KeyCode.E) || (Input.GetButton("Interact"))){
			if(Input.GetKeyDown(KeyCode.E)){

				GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = false;
				//GameObject.FindWithTag ("Description").GetComponent<GUIText>().enabled = true;

				itemUseable = false; 
			}
		}
	}

	void ToggleMenu(){
		Component[] meshRenderers;
		meshRenderers = GameObject.Find ("radial_background").GetComponentsInChildren <MeshRenderer>();
		if(hideMenu == false){
			foreach (MeshRenderer menuRend in meshRenderers) { 
				menuRend.enabled = true; 
			}
		}

		else if(hideMenu == true){
			foreach (MeshRenderer menuRend in meshRenderers) { 
				menuRend.enabled = false; 
			}
		}
		//GameObject.Find("radial_background").GetComponent<MeshRenderer>().enabled = false;
		//GameObject.Find ("radial_dial").GetComponent<MeshRenderer>().enabled = false;
	}
}
