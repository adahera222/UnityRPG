using System;

public class Jumping : MovementState
{
	
	#region Constructors
	
	/* Default constructor. */
	public Jumping ()
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
		context.SetMovementState(new StandingMoving());
	}
	
	/* A crouch is performed. */
	public void Crouch(CharacterState context)
	{
		return;
	}
	
	/* A jump is performed. */
	public void Jump(CharacterState context)
	{
		return;
	}
	
	/* A sprint is performed. */
	public void Sprint(CharacterState context)
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

