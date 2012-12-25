using System;

public interface MovementState
{
	/* A move input is sent to the state chart. */
	void Move(CharacterState context);
	
	/* A stop input is sent to the state chart. */
	void Stop(CharacterState context);
	
	/* A crouch input is sent to the state chart. */
	void Crouch(CharacterState context);
	
	/* A jump input is sent to the state chart. */
	void Jump(CharacterState context);
	
	/* A sprint input is sent to the state chart. */
	void Sprint(CharacterState context);

	/* Used to identify current state. */
	string State();
}

