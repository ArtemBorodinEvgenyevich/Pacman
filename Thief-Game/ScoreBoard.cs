using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Thief_Game
{
    /// <summary>
    /// Scoreboard WinForm class
    /// </summary>
    public partial class ScoreBoard : Form
    {
        /// <summary>
        /// Scoreboard init
        /// </summary>
        public ScoreBoard()
        {
            var pfc = InitCustomLabelFont();
            this.Font = new Font(pfc.Families[0], 10.2f);
            
            InitializeComponent();

            this.exitButton.Font = new Font(pfc.Families[0], 13.8f);
            this.Score.Font = new Font(pfc.Families[0], 24f);
            this.TotalScore.Font = new Font(pfc.Families[0], 16f);
            this.ScoreTable.Font = new Font(pfc.Families[0], 16f);

            CreateScoreList();

        }

        /// <summary>
        /// External font loader
        /// </summary>
        /// <returns></returns>
        public PrivateFontCollection InitCustomLabelFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(PathInfo.Fonts, "ka1.ttf"));

            return pfc;
        }

        /// <summary>
        /// Scorebord results init and sort
        /// </summary>
        public void CreateScoreList()
        {
            WorldStat results = new WorldStatPickle().DataDeserialize();

            this.TotalScore.Text = String.Format("TOTAL - {0}", results.ScoreTotal);

            int cnt = 0;
            foreach (var item in results.ScoreRecord)
            {
                cnt += 1;
                this.ScoreTable.Items.Add(String.Format("{0}. {1}", cnt, item));
            }
        }

        /// <summary>
        /// Scoreboard load event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            var stats = new WorldStatPickle().DataDeserialize();
        }

        /// <summary>
        /// Exit button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
