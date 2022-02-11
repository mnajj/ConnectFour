using ShardClassLibrary;
using SimpleClient.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class WaitingRoom : Form
	{
		Room roomData;
		RoomsList roomsListForm;
		BinaryWriter bWriter;

		public bool IsGuest { get; set; }
		public bool IsPlayer { get; set; }
		public int RoomIdx { get; set; }
		public GamingPlayGround GamingPlayGroundForm { get; set; }
		public RoomsList RoomsListForm { get => roomsListForm; }
		public bool IsInvitationSender { get; set; }

		public WaitingRoom(RoomsList roomsListForm, bool isGuest, Room roomData = null, bool isPlayer = true)
		{
			InitializeComponent();
			this.roomsListForm = roomsListForm;
			this.IsGuest = isGuest;
			this.roomData = roomData;
			this.IsPlayer = isPlayer;

			bWriter = new BinaryWriter(roomsListForm.ClientForm.ClientNetworkStream);
		}

		private void WaitingRoom_Load(object sender, EventArgs e)
		{
			if (!IsGuest)
			{
				PlayersListBox.Items.Add($"👑 {roomsListForm.ClientForm.UserName}");
				RoomNameLabel.Text = roomsListForm.CreatedWaitingdRoomName;
			}
			else if (!IsPlayer)
			{
				AddSpacsToGuestView(roomData);
				DimmedSpec();
			}
			else
			{
				AddRoomDataToGuestView(roomData);
			}
		}

		private void DimmedSpec()
		{
			AskCounterForGame.Enabled = false;
			ChooseDiskColorComboBox.Enabled = false;
		}

		public void AddSpacsToGuestView(Room roomData)
		{
			RoomNameLabel.Text = roomData.RoomName;

			for (int i = 0; i < roomData.Players.Count; i++)
			{
				PlayersListBox.Items.Add($"{roomData.Players[i].UserName}");
			}

			for (int i = 0; i < roomData.Spectators.Count; i++)
			{
				SpectatorsBox.Items.Add(roomData.Spectators[i].UserName);
			}
		}

		public void AddRoomDataToGuestView(Room roomData)
		{
			RoomNameLabel.Text = roomData.RoomName;
			if (roomData.RoomOwner != null)
			{
				PlayersListBox.Items.Add($"👑 {roomData.RoomOwner.UserName}");
			}
			PlayersListBox.Items.Add($"{roomsListForm.ClientForm.UserName}");

			for(int i = 0; i < roomData.Spectators.Count; i++)
			{
				SpectatorsBox.Items.Add(roomData.Spectators[i].UserName);
			}
			ChooseDiskColorComboBox.Items.Remove(roomData.RoomOwnerDiskColor);
		}

		public void GetMemberChanges(List<string> newPlayers)
		{
			PlayersListBox.Items.Clear();
			PlayersListBox.Items.Add($"👑 {roomsListForm.ClientForm.UserName}");
			for (int i = 0; i < newPlayers.Count; i++)
			{
				if (newPlayers[i] != roomsListForm.ClientForm.UserName)
				{
					PlayersListBox.Items.Add($"{newPlayers[i]}");
				}
			}
		}

		public void GetSpacMemberChanges(List<string> newSpec)
		{
			SpectatorsBox.Items.Clear();
			for (int i = 0; i < newSpec.Count; i++)
			{
				SpectatorsBox.Items.Add($"{newSpec[i]}");
			}
		}

		public void ShowCounterDialogForm(string counterName, string boardSize)
		{
			CounterRequestDialog reqDlg = new CounterRequestDialog(counterName);
			DialogResult reqDlgRes = reqDlg.ShowDialog();
			if (reqDlgRes == DialogResult.OK)
			{
				bWriter.Write($"7,I accept your request,{RoomIdx}");
				RedirectToGamingRoom(boardSize);
			}
			else
			{
				bWriter.Write($"-7,I refuse your request,{RoomIdx}");
			}
		}

		private void RedirectToGamingRoom(string boardSize)
		{
			if (IsPlayer)
			{
				if (IsInvitationSender)
				{
					GamingPlayGroundForm = new GamingPlayGround(boardSize, this, false, true);
				}
				else
				{
					GamingPlayGroundForm = new GamingPlayGround(boardSize, this);
				}
			}
			else
			{
				GamingPlayGroundForm = new GamingPlayGround(boardSize, this, true, false);
			}
			GamingPlayGroundForm.Show();
			this.Hide();
		}

		public void RecieveMyReqResponse(int header, string counterName, string boardSize)
		{
			if (header == 77)
			{
				if (IsPlayer)
				{
					CounterResponseMsgDialog counterRequestDlg = new CounterResponseMsgDialog(counterName, true);
					counterRequestDlg.ShowDialog();
					RedirectToGamingRoom(boardSize);
				}
				else
				{
					MessageBox.Show("The Game Start!\nYou Can Watch Now");
					RedirectToGamingRoom(boardSize);
				}
			}
			else
			{
				CounterResponseMsgDialog counterRequestDlg = new CounterResponseMsgDialog(counterName, false);
				counterRequestDlg.ShowDialog();
			}
		}

		private void AskCounterForGame_Click(object sender, EventArgs e)
		{
			if (IsPlayer)
			{
				if (ChooseDiskColorComboBox.SelectedItem != null)
				{
					if (roomsListForm.IsRoomCreator)
					{
						string diskColor = ChooseDiskColorComboBox.Text;
						bWriter.Write($"6,send start game request for the counter,{diskColor},{RoomIdx}");
					}
					else
					{
						string diskColor = ChooseDiskColorComboBox.Text;
						bWriter.Write($"6,send start game request for the counter,{diskColor},{RoomIdx},Bla!");
					}
					this.IsInvitationSender = true;
				}
				else
				{
					MessageBox.Show("Please, chosse your disk color first");
				}
			}
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			bWriter = new BinaryWriter(roomsListForm.ClientForm.ClientNetworkStream);
			bWriter.Write($"8,leave current room and get avaliab rooms data,{RoomIdx}");
			roomsListForm.Show();
			this.Close();
		}

		public void GetMembersLeavingChange(string players, string specs)
		{
			PlayersListBox.Items.Clear();
			SpectatorsBox.Items.Clear();

			var splitedPly = players.Split(';');
			var splitedSpc = specs.Split(';');

			foreach (var player in splitedPly)
			{
				PlayersListBox.Items.Add(player);
			}
			foreach (var spec in splitedSpc)
			{
				SpectatorsBox.Items.Add(spec);
			}
		}

		public void AppendNewWatchOnlySpec(string specName)
		{
			if (!SpectatorsBox.Items.Contains(specName))
			{
				SpectatorsBox.Items.Add(specName);
			}
		}
	}
}
