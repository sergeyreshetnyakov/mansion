using Godot;

public partial class HUD : Control
{
	public Label Label;
	public Label Message;
    private Timer timer;

    public override void _Ready()
    {
        Label = GetNode<Label>("Label");
		Message = GetNode<Label>("Message");
        timer = GetNode<Timer>("Timer");
    }

    private void OnLabel(string text) {
        Label.Text = text;
    }

    private void OnMessage(string text) {
        Message.Text = text;
        timer.Start();
        timer.Timeout += () => Message.Text = " ";
    }
}
