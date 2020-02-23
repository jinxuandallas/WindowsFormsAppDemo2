using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo2
{
    public partial class Form1 : Form
    {
        private bool mouseDown = false;
        public Form1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            for (int i = 0; i < 5; i++)
                dt.Columns.Add();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < 5; j++)
                    dr[j] = rnd.Next(100);
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridView dgv = (DataGridView)sender;
        //    //dgv[e.ColumnIndex,e.RowIndex].Style.
        //}

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex == dgv.CurrentCell.RowIndex && e.ColumnIndex == dgv.CurrentCell.ColumnIndex)
            {
                ///*正式代码
                Brush gridBrush = new SolidBrush(Color.Green);
                //using (Pen gridLinePen = new Pen(gridBrush))
                //{
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);
                //e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                e.Graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(e.CellBounds.Left + 1, e.CellBounds.Top + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                //e.Graphics.DrawLine(new Pen(Color.Green, 2), e.CellBounds.Left - 1, e.CellBounds.Bottom - 1, e.CellBounds.Left - 1, e.CellBounds.Top - 1);
                //e.Graphics.DrawLine(new Pen(Color.Green, 2), e.CellBounds.Left - 1, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                //e.Graphics.DrawLine(new Pen(Color.Green, 2), e.CellBounds.Right - 1, e.CellBounds.Top - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                //e.Graphics.DrawLine(new Pen(Color.Green, 2), e.CellBounds.Left - 1, e.CellBounds.Top - 1, e.CellBounds.Right - 1, e.CellBounds.Top - 1);
                if (e.Value != null)
                {
                    e.Graphics.DrawString((e.Value).ToString(), e.CellStyle.Font, new SolidBrush(Color.Black), e.CellBounds.X, e.CellBounds.Y + 5, StringFormat.GenericDefault);
                }
                //}
                e.Handled = true;
                //*/
                label1.Text = "row=" + dgv.CurrentCell.RowIndex + " column=" + dgv.CurrentCell.ColumnIndex;
            }
            //else
            //{
            //    Brush gridBrush = new SolidBrush(Color.Green);
            //    using (Pen gridLinePen = new Pen(gridBrush))
            //    {
            //        e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);
            //        //e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            //        e.Graphics.DrawLine(new Pen(Color.Black, 2), e.CellBounds.Left, e.CellBounds.Bottom, e.CellBounds.Left, e.CellBounds.Top);
            //        e.Graphics.DrawLine(new Pen(Color.Black, 2), e.CellBounds.Left, e.CellBounds.Bottom, e.CellBounds.Right, e.CellBounds.Bottom);
            //        e.Graphics.DrawLine(new Pen(Color.Black, 2), e.CellBounds.Right, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Bottom);
            //        e.Graphics.DrawLine(new Pen(Color.Black, 2), e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
            //        if (e.Value != null)
            //        {
            //            e.Graphics.DrawString((e.Value).ToString(), e.CellStyle.Font, new SolidBrush(Color.Black), e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault);
            //        }
            //    }
            //    e.Handled = true;
            //}
        }

        //private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        //{
        //    label1.Text = "DragDrop";
        //}

        //private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{

        //}

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                label1.Text += "CellMouseDown  ";
                label1.Text = ((DataGridView)sender).Cursor == Cursors.Cross ? "cross" : "default";



                //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                //messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "X", e.X);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                //messageBoxCS.AppendLine();
                //MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
                label1.Text += "CellMouseUp  ";
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "X", e.X);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "CellMouseMove Event");
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex == dgv.CurrentCell.ColumnIndex && e.RowIndex == dgv.CurrentCell.RowIndex)
            {
                //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                //messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "X", e.X);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta);
                //messageBoxCS.AppendLine();
                //messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                //messageBoxCS.AppendLine();
                //MessageBox.Show(messageBoxCS.ToString(), "CellMouseMove Event");
                //label1.Text = messageBoxCS.ToString();

                ///*
                if (dgv.Cursor == Cursors.Default && MouseinCorner(dgv, e.X, e.Y))
                    dgv.Cursor = Cursors.Cross;
                if (dgv.Cursor == Cursors.Cross && !MouseinCorner(dgv, e.X, e.Y))
                    dgv.Cursor = Cursors.Default;
                //*/
            }

            //if (mouseDown)
            //label1.Text += "CellMouseMove  ";
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //判断鼠标离开的单元格是不是当前单元格，如果是则将鼠标图标改成默认
            if (e.ColumnIndex == dgv.CurrentCell.ColumnIndex && e.RowIndex == dgv.CurrentCell.RowIndex)
                dgv.Cursor = Cursors.Default;
            if (mouseDown)
                label1.Text += "CellMouseLeave  ";
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //失败，只能在进入单元格时判断，不符合要求
            //DataGridView dgv = (DataGridView)sender;
            //if (e.ColumnIndex == dgv.CurrentCell.ColumnIndex && e.RowIndex == dgv.CurrentCell.RowIndex&& MouseinCorner(dgv))
            //    dgv.Cursor = Cursors.Cross;
        }

        //private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        //{
        //    label1.Text += "DragEnter\t";
        //}

        /// <summary>
        /// 判断鼠标是否在单元格右下角，以便进入拖拽模式
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool MouseinCorner(DataGridView dgv, int x, int y)
        {
            //因x,y,r皆是单元格内相对坐标，所以无需进行转换，直接进行判断
            Rectangle r = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false);

            //Point p = dgv.PointToClient(Form1.MousePosition);
            //Point p = new Point(x, y);
            return x > r.Width - 5 && y > r.Height - 5;
        }
    }
}
