using System;

using Godot;

using Vector2 = Godot.Vector2;
using Vector3 = Godot.Vector3;

[GlobalClass]
public partial class PlayerController : CharacterBody3D
{
	[Export]
	public Camera3D camera {get; set;}

	private float currentSpeed = Settings.PlayerSpeed;

	private enum StateEnum { Walk, Run };
	private Enum currentState = StateEnum.Walk;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public void ChangeState(Enum nextState)
	{
		switch (nextState)
		{
			case StateEnum.Run:
				currentSpeed = Settings.PlayerRunSpeed;
				break;
			case StateEnum.Walk:
				currentSpeed = Settings.PlayerSpeed;
				break;
		}

		currentState = nextState;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;
		if (!IsOnFloor()) velocity += GetGravity() * (float)delta;

		if (Input.IsActionJustPressed("Jump") && IsOnFloor()) velocity.Y = Settings.JumpVelocity;
		if (Input.IsActionJustPressed("Sprint"))
		{
			switch (currentState)
			{
				case StateEnum.Walk:
					ChangeState(StateEnum.Run);
					break;
				case StateEnum.Run:
					ChangeState(StateEnum.Walk);
					break;
			}
		}

		Vector2 inputDir = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBack");
		Vector2 direction2D = inputDir.Rotated(-camera.Rotation.Y);
		Vector3 direction = (Transform.Basis * new Vector3(direction2D.X, 0, direction2D.Y)).Normalized();

		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * currentSpeed;
			velocity.Z = direction.Z * currentSpeed;
		}

		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, currentSpeed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, currentSpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
