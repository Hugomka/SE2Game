using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SE2Game.Entities;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game
{
    public partial class SE2GameForm : Form
    {
        private long timeStarted;

        public SE2GameForm()
        {
            InitializeComponent();

            // Fill the combobox with all available AIs. Note that we do
            // something strange here: we also add a string to the list,
            // meaning that we have unrelated types in the combobox. See the
            // CreateWorld method below to find out why.
            foreach (Type t in Util.AvailableMoveLogics())
            {
                cmbAI.Items.Add(Util.NewMoveLogic(t));
            }
            cmbAI.Items.Add("Any AI");
            cmbAI.SelectedItem = "Any AI";

            CreateWorld(false);

            cmbAI.SelectedIndexChanged += cmbAI_SelectedIndexChanged;
        }


        private void picGameWorld_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                World.Instance.Draw(e.Graphics);
            }
            catch { }
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            World.Instance.Update();
            lbHP.Text = Convert.ToString(World.Instance.Player.Hitpoints);
            picGameWorld.Refresh();

            if (World.Instance.GameOver)
            {
                SetGameRunning(false);
                MessageBox.Show(String.Format("You were killed! Time survived: {0:0.0} seconds.",
                                              (World.Instance.Time - timeStarted) / 1000.0));
            }
            else if (World.Instance.GameWon)
            {
                SetGameRunning(false);
                MessageBox.Show(String.Format("Victory! Time taken: {0:0.0} seconds.",
                                              (World.Instance.Time - timeStarted) / 1000.0));
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timeStarted = World.Instance.Time;
            SetGameRunning(true);
        }

        private void SetGameRunning(bool running)
        {
            bool gamePlayed = World.Instance.GameWon || World.Instance.GameOver;

            timerAnimation.Enabled = running;
            btnRandomMap.Enabled = !running;
            btnOpenFile.Enabled = !running;
            btnReset.Enabled = !running && gamePlayed;
            nudEnemyCount.Enabled = !running && gamePlayed;
            cmbAI.Enabled = !running && gamePlayed;

            // The start button is enabled by interaction with controls
            btnStart.Enabled = false;
        }

        private void btnRandomMap_Click(object sender, EventArgs e)
        {
            WorldResize();
            CreateWorld(true);
            btnStart.Enabled = true;
            this.Text = "SE2GameForm";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CreateWorld(false);
            btnStart.Enabled = true;
            btnReset.Enabled = false;
        }

        private void nudEnemyCount_ValueChanged(object sender, EventArgs e)
        {
            CreateWorld(false);
        }

        private void cmbAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateWorld(false);
        }

        private void CreateWorld(bool createNewMap)
        {
            try
            {
                // Variable to hold the type of AI to use
                Type moveLogic = null;

                // Variable to hold the selected item in the combobox. Note that,
                // as the selected item is cast to IMoveLogic, it might fail as the
                // combobox also contains a string. As the only string in the
                // combobox indicates a random AI, we can use that fact to differ
                // between a specific or any AI.
                AI.IMoveLogic selected = cmbAI.SelectedItem as AI.IMoveLogic;

                // Check if the cast succeeded
                if (selected != null)
                {
                    // If so, get the type of the selected movelogic
                    moveLogic = selected.GetType();
                }

                World.Instance.Create(picGameWorld.ClientSize,
                                      Convert.ToInt32(nudEnemyCount.Value),
                                      moveLogic,
                                      createNewMap,
                                      null);
            }
            catch (InvalidMapException IME)
            {
                IME.GetType();
                MessageBox.Show(IME.Message, "Error Invalid Map", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                picGameWorld.Refresh();
            }
        }

        /// <summary>
        /// In Game Form's size of 613 x 545: 
        /// Picturebox Game World's size is 481 x 481 with 15 x 15 cells.
        /// If the Game Form resizes, then the Game World also resizes.
        /// </summary>
        private void WorldResize()
        {
            Console.Write(" Game Form size: " + SE2GameForm.ActiveForm.Size);
            Console.WriteLine(" Game World size: " + picGameWorld.Size);
            int fSizeX = 613, fSizeY = 545, pSizeX = 481, pSizeY = 481, cellrow = 15;
            picGameWorld.Width = (this.Size.Width - (fSizeX - pSizeX)) / (pSizeX / cellrow) * (pSizeX / cellrow) + (pSizeX % cellrow);
            picGameWorld.Height = (this.Size.Height - (fSizeY - pSizeY)) / (pSizeY / cellrow) * (pSizeY / cellrow) + (pSizeY % cellrow);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                DialogResult result = openDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.Text = "SE2GameForm " + openDialog.SafeFileName;

                    Type moveLogic = null;
                    AI.IMoveLogic selected = cmbAI.SelectedItem as AI.IMoveLogic;
                    if (selected != null)
                    {
                        moveLogic = selected.GetType();
                    }

                    World.Instance.Create(picGameWorld.ClientSize,
                                      Convert.ToInt32(nudEnemyCount.Value),
                                      moveLogic,
                                      true,
                                      openDialog.FileName);
                }
            }
            catch (InvalidMapException IME)
            {
                IME.GetType();
                MessageBox.Show(IME.Message, "Error Invalid Map", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                picGameWorld.Refresh();
            }
        }
    }
}
