using System;

public interface ICharacterState
{
	/* Character has moved. */
	void Move();
	
	/* Character has stopped current action. */
	void Stop();
	
	/* Character has crouched. */
	void Crouch();
	
	/* Character has jumped. */
	void Jump();
	
	/* Character has begun to sprint. */
	void Sprint();
	
	/* Character has stopped sprinting. */
	void StopSprint();
	
	/* Character has finished jumping. */
	void DoneJump();
	
	/* Called once per frame. Used to update Character State. */
	void Update(float deltaTime);
}
