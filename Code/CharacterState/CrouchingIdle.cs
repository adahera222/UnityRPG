using System;
	
public class CrouchingIdle : MovementState
{
	
	#region Constructors
	
	/* Default constructor. */
	public CrouchingIdle ()
	{
		
	}
	
	#endregion
	
	#region Movement State Methods
	
	/* A move is performed. */
	public void Move(CharacterState context)
	{
		context.SetMovementState(new CrouchingMoving());
	}
	
	/* Movement is stopped. */
	public void Stop(CharacterState context)
	{
		return;
	}
	
	/* A crouch is performed. */
	public void Crouch(CharacterState context)
	{
		context.SetMovementState(new StandingIdle());
	}
	
	/* A jump is performed. */
	public void Jump(CharacterState context)
	{
		context.SetMovementState(new Jumping());
	}
	
	/* A sprint is performed. */
	public void Sprint(CharacterState context)
	{
		return;
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

