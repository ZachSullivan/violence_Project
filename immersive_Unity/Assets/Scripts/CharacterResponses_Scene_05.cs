﻿using System.IO;
using System;

using UnityEngine;
using System.Collections;

public class CharacterResponses_Scene_05 : MonoBehaviour {
	public CharacterInteract_Scene_05 state;
	public FocusOnPlayer aiLook;
	public GameObject AI;
	public DialogGUI_Scene_05 dialogue;
	//public Transform targetLook;

	private Animator anim;
	private Animator animTV;
	private Animator animKitchen;
	public GameObject Player;

	int choiceCounter;
	bool isSitting;
	string currentAiLocation;
	int maxChoiceNum;

	void Start() {
		anim = GetComponent<Animator>();
		//animTV = GameObject.Find("TVOn_0").GetComponent<Animator>();
		currentAiLocation = "default";
		maxChoiceNum = 2;
		//Player = GameObject.Find("FirstPersonController");
	}

	void Update(){

		isSitting = anim.GetBool("isSitting");
		print ("isSitting = " + isSitting);
		print ("ChoiceCounter = " + choiceCounter);
		print ("Current Location = " + currentAiLocation);

	}

	public void checkResponse(int caseNum){
		switch(caseNum){
		
		case 1:
			print ("case1 ACTIVATE!");
			//GameObject.Find("radial_background").GetComponent<MeshRenderer>().enabled = false;
			//GameObject.Find ("radial_background").GetComponentInChildren<MeshRenderer>().enabled = false;
			//May want to use case inside case statement

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
			break;
		
		case 2:
			print ("case2 ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
		break;	
		
		case 3:
			print ("case3 ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
			break;
		
		case 4:
			print ("case4 ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
			break;

		case 5:
			print ("case5 ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
			break;
			
		case 6:
			print ("case6 ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
			break;	
			
		case 7:
			print ("case7 ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
			break;
			
		case 8:
			print ("case8 ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}

			choiceCounter++;
			LeaveDialog();
			break;

		case 9:
			print ("case9 ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}

			choiceCounter++;
			LeaveDialog();
			break;

		default:
			break;
		}
	}
	
	void AddToFile(){
		//StreamWriter sw = new StreamWriter("TestFile.txt");
		StreamWriter sw = File.AppendText ("TestFile.txt");
		sw.Write (",");
		sw.Write (choiceCounter);
		sw.Close ();
	}

	void LeaveDialog(){
		state.itemUseable = true;
		
		//GameObject.FindWithTag("Description").GetComponent<GUIText>().text = "";
		//GameObject.FindWithTag("Description").GetComponent<GUIText>().enabled = false;
		
		GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = true;

		AddToFile();

		print("Exited Dialog!");
	}

	void tvEventEnd(){

		anim.SetBool("isWalking", false);
		eventEnd ();
		//anim.SetBool("interact", true);
		/*if(anim.GetFloat("interactTime") == 0.12){
			animTV.SetBool("isTVOn", true);
			anim.SetBool("interact", false);
		}*/
		animTV.SetBool("isTVOn", true);
		iTweenEvent.GetEvent(AI,"SitEvent").Play();
		anim.SetBool("isWalking", true);
	}

	void kitchenEventEnd(){

		anim.SetBool("interact", true);
		eventEnd ();
	}

	void chairEventEnd(){

		//transform.LookAt(new Vector3(targetLook.position.x, transform.position.y, targetLook.position.z));
	
		anim.SetBool("isSitting", true);
		eventEnd ();
	}
	
	void eventEnd(){
		
		if (choiceCounter == maxChoiceNum){
			iTween.CameraFadeAdd ();
			iTween.CameraFadeFrom (1,1);
			//Application.Quit();
			Application.LoadLevel ("Menu"); 
		}
		
		anim.SetBool("isWalking", false);
		state.itemUseable = false;
		//Uncomment to let the AI look at you when he's done walking
		//aiLook.enabled = true;
	}
}