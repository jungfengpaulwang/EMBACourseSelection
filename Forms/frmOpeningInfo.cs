using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using DevComponents.DotNetBar.Controls;

namespace CourseSelection.Forms
{
    public partial class frmOpeningInfo : BaseForm
    {
        private AccessHelper Access;
        private ErrorProvider errorProvider1;
        private List<dynamic> ItemRowSource = new List<dynamic>();

        public frmOpeningInfo()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmOpeningTime_Load);
        }

        private void frmOpeningTime_Load(object sender, EventArgs e)
        {
            this.Access = new AccessHelper();

            errorProvider1 = new ErrorProvider();
            
            //  DataGridView 事件
            this.dgvData.DataError += new DataGridViewDataErrorEventHandler(dgvData_DataError);
            this.dgvData.CurrentCellDirtyStateChanged += new EventHandler(dgvData_CurrentCellDirtyStateChanged);
            this.dgvData.CellEnter += new DataGridViewCellEventHandler(dgvData_CellEnter);
            this.dgvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
            this.dgvData.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_RowHeaderMouseClick);
            this.dgvData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvData_MouseClick);

            this.ItemRowSource.Clear();
            
            this.ItemRowSource.Add(new { Name = "第一階段", ID = 1 });
            this.ItemRowSource.Add(new { Name = "第二階段", ID = 2 });
            this.ItemRowSource.Add(new { Name = "加退選", ID = 0 });
            
            this.cboItem.DataSource = this.ItemRowSource;

            this.cboItem.ValueMember = "ID";
            this.cboItem.DisplayMember = "Name";

            this.InitSchoolYearNumberUpDown(this.nudSchoolYear);
            this.InitSemesterCombobox(this.cboSemester);
            this.InitOpeningInfo();
            this.dgvData.CurrentCell = null;
        }

        private void InitSemesterCombobox(ComboBoxEx cboSemester)
        {
            this.cboSemester.DataSource = CourseSelection.DataItems.SemesterItem.GetSemesterList();
            this.cboSemester.ValueMember = "Value";
            this.cboSemester.DisplayMember = "Name";

            this.cboSemester.SelectedValue = K12.Data.School.DefaultSemester;
        }

        private void InitSchoolYearNumberUpDown(NumericUpDown nudSchoolYear)
        {
            nudSchoolYear.Maximum = 999;
            nudSchoolYear.Minimum = 0;
            nudSchoolYear.Value = decimal.Parse(K12.Data.School.DefaultSchoolYear);
        }

        private void Varify(DataGridView dgv)
        {
            dgv.EndEdit();
            string error_message = string.Empty;
            Dictionary<string, List<DataGridViewCell>> dicCells = new Dictionary<string, List<DataGridViewCell>>();
            this.errorProvider1.Clear();
            if (string.IsNullOrEmpty(this.cboSemester.Text))
                this.errorProvider1.SetError(this.cboSemester, "必填。");
            //if (this.dgvData.Rows.Count == 0 || (this.dgvData.Rows.Count == 1 && this.dgvData.Rows[0].IsNewRow))
            //{
            //    errorProvider1.SetError(this.dgvData, "請設定資料再儲存。");
            //    return;
            //}
            foreach (string key in dicCells.Keys)
            {
                if (dicCells[key].Count > 1)
                {
                    dicCells[key].ForEach(x => x.ErrorText = "次別重覆。");
                }
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;

                row.Cells[0].ErrorText = "";
                row.Cells[1].ErrorText = "";
                row.Cells[2].ErrorText = "";

                string key = row.Cells[0].Value + "";
                if (!dicCells.ContainsKey(key))
                    dicCells.Add(key, new List<DataGridViewCell>());

                dicCells[key].Add(row.Cells[0]);
                
                DateTime begin_date_time;
                DateTime end_date_time;

                if (!DateTime.TryParse(row.Cells[1].Value + "", out begin_date_time))
                    row.Cells[1].ErrorText = "開始時間格式錯誤。範例：2013/6/22 00:01";

                if (!DateTime.TryParse(row.Cells[2].Value + "", out end_date_time))
                    row.Cells[2].ErrorText = "結束時間格式錯誤。範例：2013/7/31 23:59";

                if (DateTime.TryParse(row.Cells[1].Value + "", out begin_date_time) && DateTime.TryParse(row.Cells[2].Value + "", out end_date_time))
                {
                    if (begin_date_time >= end_date_time)
                        row.Cells[1].ErrorText = "開始時間不得大於或等於結束時間。";
                }
            }
            foreach (DataGridViewRow row in this.dgvData.Rows)
            {
                if (row.IsNewRow)
                    continue;

                DateTime begin_date_time_1;
                DateTime end_date_time_1;
                DateTime begin_date_time_2;
                DateTime end_date_time_2;
                foreach (DataGridViewRow row2 in this.dgvData.Rows)
                {
                    if (row2.IsNewRow)
                        continue;

                    if (row.Index == row2.Index)
                        continue;

                    if (DateTime.TryParse(row.Cells[1].Value + "", out begin_date_time_1) && DateTime.TryParse(row.Cells[2].Value + "", out end_date_time_1) && DateTime.TryParse(row2.Cells[1].Value + "", out begin_date_time_2) && DateTime.TryParse(row2.Cells[2].Value + "", out end_date_time_2))
                    {
                        if ((begin_date_time_1 >= begin_date_time_2 && begin_date_time_1 <= end_date_time_2) || (begin_date_time_2 >= begin_date_time_1 && begin_date_time_2 <= end_date_time_1))
                        {
                            row.Cells[1].ErrorText = "開始時間重疊。";
                            row2.Cells[1].ErrorText = "開始時間重疊。";
                        }
                        if ((end_date_time_1 >= begin_date_time_2 && end_date_time_1 <= end_date_time_2) || (end_date_time_2 >= begin_date_time_1 && end_date_time_2 <= end_date_time_1))
                        {
                            row.Cells[2].ErrorText = "結束時間重疊。";
                            row2.Cells[2].ErrorText = "結束時間重疊。";
                        }
                    }
                }
            }
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvData.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvData.SelectedCells.Count == 1)
            {
                dgvData.BeginEdit(true);
                if (dgvData.CurrentCell != null && dgvData.CurrentCell.GetType().ToString() == "System.Windows.Forms.DataGridViewComboBoxCell")
                    (dgvData.EditingControl as ComboBox).DroppedDown = true;  //自動拉下清單
            }
        }

        private void dgvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvData.CurrentCell = null;
            dgvData.Rows[e.RowIndex].Selected = true;
        }

        private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvData.CurrentCell = null;
        }

        private void dgvData_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                dgvData.CurrentCell = null;
                dgvData.SelectAll();
            }
        }

        private void InitOpeningInfo()
        {
            try
            {
                List<UDT.CSOpeningInfo> records = Access.Select<UDT.CSOpeningInfo>();

                if (records == null || records.Count == 0)
                    return;

                records.ForEach((x) =>
                {
                    List<object> source = new List<object>();

                    source.Add(x.Item);
                    source.Add(x.BeginTime.ToString("yyyy/MM/dd HH:mm"));
                    source.Add(x.EndTime.ToString("yyyy/MM/dd HH:mm"));

                    int idx = this.dgvData.Rows.Add(source.ToArray());
                    this.nudSchoolYear.Value = decimal.Parse(x.SchoolYear.ToString());
                    this.cboSemester.SelectedValue = x.Semester.ToString();
                });
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            this.Varify(this.dgvData);
            if (!string.IsNullOrEmpty(errorProvider1.GetError(this.dgvData) + errorProvider1.GetError(this.cboSemester)))
            {
                MessageBox.Show("請修正錯誤再儲存。");
                return;
            }
            foreach (DataGridViewRow row in this.dgvData.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (!string.IsNullOrEmpty(row.Cells[0].ErrorText) || !string.IsNullOrEmpty(row.Cells[1].ErrorText) || !string.IsNullOrEmpty(row.Cells[2].ErrorText))
                {
                    MessageBox.Show("請修正錯誤再儲存。");
                    return;
                }
            }

            try
            {
                this.Save.Enabled = false;
                List<UDT.CSOpeningInfo> records = Access.Select<UDT.CSOpeningInfo>();

                records.ForEach(x => x.Deleted = true);
                records.SaveAll();

                records.Clear();
                foreach (DataGridViewRow row in this.dgvData.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    UDT.CSOpeningInfo record = new UDT.CSOpeningInfo();

                    record.Item = int.Parse(row.Cells[0].Value + "");
                    DateTime startTime = DateTime.Parse(row.Cells[1].Value + "");
                    record.BeginTime = startTime;

                    DateTime endTime = DateTime.Parse(row.Cells[2].Value + "");
                    if ((endTime.Hour + endTime.Minute + endTime.Second) == 0)
                        record.EndTime = endTime.AddDays(1).AddSeconds(-1);
                    else
                        record.EndTime = endTime;

                    record.SchoolYear = int.Parse(this.nudSchoolYear.Value + "");
                    record.Semester = int.Parse(CourseSelection.DataItems.SemesterItem.GetSemesterByName(this.cboSemester.Text).Value + "");

                    records.Add(record);
                }
                records.SaveAll();
                Agent.Event.CSOpeningInfo.RaiseAfterUpdateEvent(sender, e);
                MsgBox.Show("儲存成功");
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.Save.Enabled = true;
            }
        }
    }
}
