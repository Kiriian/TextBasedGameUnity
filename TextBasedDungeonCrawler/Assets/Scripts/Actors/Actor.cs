using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Actor : ScriptableObject {

	public string actorName;
	public int maxHealth;
	public int currentHealth;
	public int maxMana;
	public int currentMana;
	public int strength;
	public int intellengence;
	public int defense;
	public int chanceToDodge;
	public int chanceToHit;
	public ICollection<StatusEffect> statEffects = new List<StatusEffect>();
	public ICollection<Skill> skills = new List<Skill>();
	

	/// <summary>
	/// Hurts the actor by the provided amount. Will check if the actor dies as a result.
	/// </summary>
	/// <param name="i">The index.</param>
	public int hurt(int i){
		currentHealth = currentHealth - i;
		return i;
	}
		
	/// <summary>
	/// Heals the actor for the specific amount. Checks for overheal.
	/// </summary>
	/// <param name="i">The index.</param>
	public void heal(int i){
		currentHealth = currentHealth + i;
		if (currentHealth>maxHealth){
			// Just making sure the actor doesn't overheal.
			currentHealth = maxHealth;
		}
	}

	/// <summary>
	/// Inflicts the actor with the provided status effect.
	/// </summary>
	/// <param name="effect">Effect.</param>
	public void inflict(StatusEffect effect){
		// Adds an active status effect to the actor.
		statEffects.Add (effect);
	}

	/// <summary>
	/// Teaches the actor a new skill.
	/// </summary>
	/// <param name="skill">Skill.</param>
	public void learn(Skill skill){
		// Adds a new skill to the actor's available skillset.
		skills.Add(skill);
	}

	public ICollection<StatusEffect> StatEffects {
		get {
			return this.statEffects;
		}
	}

	public ICollection<Skill> Skills {
		get {
			return this.skills;
		}
	}



}
