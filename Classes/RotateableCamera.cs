using Godot;

[GlobalClass]
public partial class RotateableCamera : Camera3D
{
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion motion && Input.MouseMode == Input.MouseModeEnum.Captured)
		{
			InputEventMouseMotion mouseMotion = motion;
			Vector3 currentRotation = Rotation;
			currentRotation.Y -= mouseMotion.Relative.X * Settings.MouseYSensitivity;
			currentRotation.X -= mouseMotion.Relative.Y * Settings.MouseXSensitivity;
			currentRotation.X = Mathf.Clamp(currentRotation.X, -Mathf.DegToRad(70), Mathf.DegToRad(70));
			Rotation = currentRotation;
		}
	}
}
