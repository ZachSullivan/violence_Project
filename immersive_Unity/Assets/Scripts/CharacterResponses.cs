﻿using UnityEngine;
using System.Collections;

public class CharacterResponses : MonoBehaviour {
	public CharacterInteract state;

	public FocusOnPlayer aiLook;

	public GameObject AI;

	private Animator anim;

	public Transform[] waypoints;

	void Start() {
		anim = GetComponent<Animator>();
		}

	public void checkResponse(int caseNum){
		switch(caseNum){
		
		case 1:
			print ("case1 ACTIVATE!");
			//splineMover.startMove();
			//waypointMove.currentWaypoint = waypoints[0];
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			LeaveDialog();
			break;
		
		case 2:
			print ("case2 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"KitchenPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			LeaveDialog();
		break;	
		
		case 3:
			print ("case3 ACTIVATE!");
			LeaveDialog();
			break;
		
		case 4:
			print ("case4 ACTIVATE!");
			LeaveDialog();
			break;

		case 5:
			print ("case5 ACTIVATE!");
			LeaveDialog();
			break;
			
		case 6:
			print ("case6 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			LeaveDialog();
			break;	
			
		case 7:
			print ("case7 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			break;
			
		case 8:
			print ("case8 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			LeaveDialog();
			break;

		case 9:
			print ("case9 ACTIVATE!");
			LeaveDialog();

			break;

		default:
			break;
		}
	}

	void LeaveDialog(){
		state.itemUseable = true;
		
		GameObject.FindWithTag("Description").GetComponent<GUIText>().text = "";
		GameObject.FindWithTag("Description").GetComponent<GUIText>().enabled = false;
		
		GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = true;
		
		print("Exited Dialog!");
	}

	void eventEnd(){
		anim.SetBool("isWalking", false);
		aiLook.enabled = true;
	}
}
