using System;

public class MovementAttributes
{
	/* Max energy. */
	public float maxEnergy;
	
	/* Speed while walking. */
	public float walkingSpeed;
	
	/* Speed while sprinting. */
	public float sprintingSpeed;
	
	/* Speed while crouching. */
	public float crouchingSpeed;
	
	/* Current speed. */
	public float currentSpeed;
	
	/* Energy cost of sprinting for 1 second. */
	public float sprintCost;
	
	/* Energy to be regenerated after 1 second of idle time. */
	public float idleEnergyRegenRate;
	
	/* Energy to be regenerated after 1 second of moving time. */
	public float movingEnergyRegenRate;
	
	/* The current amount of energy. */
	public float currentEnergy;
	
	/* The point at which entity is no longer fatigued. */
	public float fatigueThreshold;
	
	/* Determines if the entity is fatigued. */
	public bool fatigued;
	
	/* Default constructor. */
	public MovementAttributes ()
	{
		currentSpeed = 0;
		currentEnergy = maxEnergy;
		fatigued = false;
	}
	
	
}

