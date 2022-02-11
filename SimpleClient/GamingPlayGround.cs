using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class GamingPlayGround : Form
	{
		WaitingRoom waitingRoom;
    BinaryWriter bWriter;
		public bool IsSpectator { get; set; }
		public bool IsMyTurn { get; set; }
    public bool IsInvitationSender { get; set; }
		public bool IsGameOver { get; set; }

    public GamingPlayGround(WaitingRoom waitingRoom, bool isSpec = false, bool isInvitationSender = false)
		{
			InitializeComponent();
			this.waitingRoom = waitingRoom;
			this.IsSpectator = isSpec;
			if (isSpec) IsMyTurn = false;
      IsInvitationSender = isInvitationSender;
      if (isInvitationSender)
			{
        IsMyTurn = true;
			}
			else
			{
        IsMyTurn = false;
			}
      IsGameOver = false;
      bWriter = new BinaryWriter(waitingRoom.RoomsListForm.ClientForm.ClientNetworkStream);
    }

		private void ON_MOUSE_DOWN()
		{
			while (!IsGameOver)
			{
				if (IsMyTurn)
				{
					// Darw Disk Move

					// Send This Move to Server
				}
			}
		}

    private void SendMyMoveToServer(int col)
		{
			bWriter.Write($"9,Send Move to Server,{col}");
      IsMyTurn = false;
		}
  }
}
