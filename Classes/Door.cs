using Godot;
using System;

public partial class Door : InteractableObject
{
	[Export]
	public bool IsLocked { get; set; } = true;
	[Export]
	public string LockedMessage { get; set; } = "The door is jammed";
	[Export]
	public bool IsOpened {get; set;} = false;
	[Export]
	public AnimationPlayer AnimationPlayer {get; set;}

    public override string Interact()
	{
		if (IsLocked)
		{
			return LockedMessage;
		}
		else
		{
			if (IsOpened) AnimationPlayer.PlayBackwards();
			else AnimationPlayer.Play("open");

			IsOpened = !IsOpened;

			return Message;
		}
	}
}
