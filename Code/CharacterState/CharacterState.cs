using System;

public class CharacterState : ICharacterState
{
	
	#region Fields
	
	/* Current movement state. */
	MovementState _movementState;
	
	/* Attributes for this character. */
	MovementAttributes _movementAttributes;
	
	#endregion
	
	#region Constructors
	
	/* Constructor that takes in a parameter of type Attributes to be the 
	 * attributes of this character. */
	public CharacterState(MovementAttributes movementAttributes)
	{
		_movementAttributes = movementAttributes;
		_movementState = new StandingIdle();
	}
	
	#endregion
	
	#region Update Method
	
	/* Update is called once per frame. Updates character's states and uses
	  * parameter delta time, which is the amount of time in seconds from last
	  * update call. */
	public void Update (float deltaTime) 
	{
		#region Movement State Update
		
		/* Get current state. */
		string movementState = _movementState.State();
		
		/* If Sprinting, decrease energy. */
		if(movementState == "Sprinting")
		{
			/* If not at sprinting speed, then change current speed to be sprint speed. */
			if(_movementAttributes.currentSpeed != _movementAttributes.sprintingSpeed)
			{
				_movementAttributes.currentSpeed = _movementAttributes.sprintingSpeed;
			}
			
			/* Decrease energy by proper amount. */
			_movementAttributes.currentEnergy -= deltaTime * _movementAttributes.sprintCost;
			
			/* If out of energy, stop sprinting. */
			if(_movementAttributes.currentEnergy <= 0)
			{
				Stop();
				_movementAttributes.fatigued = true;
			}
		}
		/* If not moving. */
		else if((movementState == "StandingIdle") || (movementState == "CrouchingIdle"))
		{	
			/* If not at max energy, regenerate energy. */
			if(_movementAttributes.currentEnergy < _movementAttributes.maxEnergy)
			{
				_movementAttributes.currentEnergy += deltaTime * _movementAttributes.idleEnergyRegenRate;
			}
		}
		/* If moving, but not sprinting. */
		else if((movementState == "StandingMoving") || (movementState == "CrouchingMoving"))
		{
			/* Apply walking speed if needed. */
			if((movementState == "StandingMoving") && (_movementAttributes.currentSpeed != _movementAttributes.walkingSpeed))
			{
				_movementAttributes.currentSpeed = _movementAttributes.walkingSpeed;
			}
			/* Apply crouching speed if needed. */
			else if ((movementState == "CrouchingMoving") && (_movementAttributes.currentSpeed != _movementAttributes.crouchingSpeed))
			{
				_movementAttributes.currentSpeed = _movementAttributes.crouchingSpeed;
			}
			/* If not at max energy, regenerate 0.75 of energy regen rate because still moving. */
			if(_movementAttributes.currentEnergy < _movementAttributes.maxEnergy)
			{
				_movementAttributes.currentEnergy += deltaTime * _movementAttributes.movingEnergyRegenRate;
			}
		}
		/* If jumping. */
		else
		{
			
		}
		
		/* If fatigued and now past fatigue threshold, no longer fatigued. */
		if((_movementAttributes.currentEnergy > _movementAttributes.fatigueThreshold) &&(_movementAttributes.fatigued))
		{
			_movementAttributes.fatigued = false;
		}	
		
		/* Clamp the current energy to max energy. */
		if(_movementAttributes.currentEnergy > _movementAttributes.maxEnergy)
		{
			_movementAttributes.currentEnergy = _movementAttributes.maxEnergy;
		}
		
		#endregion
		
	}
	
	#endregion
	
	#region Other Methods
	
	/* Used to send Move input to the movement state chart. */
	public void Move()
	{
		_movementState.Move(this);
	}
	
	/* Used to send Stop input to the movement state chart. */
	public void Stop()
	{
		_movementState.Stop(this);
	}
	
	/* Used to send Crouch input to the movement state chart. */
	public void Crouch()
	{
		_movementState.Crouch(this);	
	}
	
	/* Used to send Jump input to the movement state chart. */
	public void Jump()
	{
		_movementState.Jump(this);
	}
	
	/* Used to send Sprint input to the movement state chart. */
	public void Sprint()
	{
		/* If not fatigued, sprint. */
		if(!_movementAttributes.fatigued)
		{
			_movementState.Sprint(this);
		}
	}
	
	/* Used to stop the character from sprinting. */
	public void StopSprint()
	{
		/* If sprinting, then stop it. */
		if(_movementState.State() == "Sprinting")
		{
			_movementState.Stop(this);
		}
	}
	
	/* Used to alert the state component when the character is done jumping. */
	public void DoneJump()
	{	
		/* If jumping, then complete jump. */
		if(_movementState.State() == "Jumping")
		{
			_movementState.Stop(this);
		}
	}
	
	/* Used to set the state. */
	public void SetMovementState(MovementState state)
	{
		_movementState = state;
	}
	
	#endregion
	
}
