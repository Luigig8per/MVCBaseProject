using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinesLayer;


namespace ViewLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsGeneric theClassGeneric = new clsGeneric();
            IDictionary<string, string> parametersDictionary = new Dictionary<string, string>();

            clsBusinessProcess clsBusiness = new clsBusinessProcess();
            //parametersDictionary.Add("@timeStart", theClassGeneric.dateUrl(dateTimePicker1.Value));
            //parametersDictionary.Add("@timeEnd", theClassGeneric.dateUrl(dateTimePicker2.Value));

            parametersDictionary.Add("id_event","648605");

            dataGridView1.DataSource = clsBusiness.ExeSPWithResults("get_date_from_event_id", parametersDictionary);

            textBox1.Text = clsBusiness.ExeSPWithResults("get_date_from_event_id", parametersDictionary).Rows[0][0].ToString();

        }
    }
}
