using System;
	
public class StandingMoving : MovementState
{
	
	#region Constructors
	
	/* Default constructor. */
	public StandingMoving ()
	{
		
	}
	
	#endregion
	
	#region Movement State Methods
	
	/* A move is performed. */
	public void Move(CharacterState context)
	{
		return;
	}
	
	/* Movement is stopped. */
	public void Stop(CharacterState context)
	{
		context.SetMovementState(new StandingIdle());
	}
	
	/* A crouch is performed. */
	public void Crouch(CharacterState context)
	{
		context.SetMovementState(new CrouchingMoving());
	}
	
	/* A jump is performed. */
	public void Jump(CharacterState context)
	{
		context.SetMovementState(new Jumping());
	}
	
	/* A sprint is performed. */
	public void Sprint(CharacterState context)
	{
		context.SetMovementState(new Sprinting());
	}
	
	/* The current state is complete. */
	public void Complete(CharacterState context)
	{
		return;
	}
	
	/* Returns the current state. */
	public string State()
	{
		return GetType().ToString();
	}
	
	#endregion

}

