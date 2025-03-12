using Godot;

[GlobalClass]
public partial class InteractableObject : AnimatableBody3D
{
	[Export]
	public string Label {get; set; } = "Interact";
	[Export]
	public string Message {get; set; } = "Interacted";

	public virtual string Interact() {
		return Message;
	} 
}
