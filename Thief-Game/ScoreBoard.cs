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
    public partial class ScoreBoard : Form
    {

        public Font TextFont;

        public ScoreBoard()
        {
            // Почему-то не работает.
            //-----------------------------
            //this.SetDesktopLocation(X, Y);
            //-----------------------------

            // Инициализируем собственный шрифт
            var pfc = InitCustomLabelFont();
            this.Font = new Font(pfc.Families[0], 10.2f); // maybe delete?
            
            InitializeComponent();

            this.exitButton.Font = new Font(pfc.Families[0], 13.8f);
            this.Score.Font = new Font(pfc.Families[0], 24f);
            this.TotalScore.Font = new Font(pfc.Families[0], 16f);
            this.ScoreTable.Font = new Font(pfc.Families[0], 16f);

            CreateScoreList();

        }

        public PrivateFontCollection InitCustomLabelFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(PathInfo.Fonts, "ka1.ttf"));

            return pfc;
        }

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

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            var stats = new WorldStatPickle().DataDeserialize();
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
