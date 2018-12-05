using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnaucuraLogg.Model;
using LiteDB;
namespace UnaucuraLogg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openDB.ShowDialog();
        }

        private void openDB_FileOk(object sender, CancelEventArgs e)
        {
            using (var db = new LiteDatabase(openDB.FileName))
            {
                var customers = db.GetCollection<Logging>("customers");
                var c = customers.FindAll();
                gridDataBoundGrid1.DataSource = c.ToList();
            }
        }
    }
}
