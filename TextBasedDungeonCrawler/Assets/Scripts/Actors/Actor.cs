using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : ScriptableObject {

	public string actorName;
	public int maxHealth;
	public int currentHealth;
	public int maxMana;
	public int currentMana;
	private ICollection<StatusEffect> statEffects;
	private ICollection<Skill> skills;
	

	/// <summary>
	/// Hurts the actor by the provided amount. Will check if the actor dies as a result.
	/// </summary>
	/// <param name="i">The index.</param>
	public void hurt(int i){
		currentHealth = currentHealth - i;
		if (currentHealth <= 0){
			// Implement method for killing an actor here.
		}
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
