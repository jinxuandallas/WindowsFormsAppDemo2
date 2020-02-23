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
        /// <summary>
        /// 是否按下鼠标左键
        /// </summary>
        private bool cellMouseDown = false;
        /// <summary>
        /// 刚刚是否拖动过
        /// </summary>
        private bool justDrop = false;
        /// <summary>
        /// 拖动的第一个单元格
        /// </summary>
        private DataGridCell firstCell = new DataGridCell(-1, -1);
        /// <summary>
        /// 拖动的上一个经过的单元格
        /// </summary>
        private DataGridCell lastCell;
        /// <summary>
        /// 拖动到的行数（或列数）
        /// </summary>
        private int dropNumber = -1;
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

            if (dropNumber != -1)
            {
                //dgv.ClearSelection();
                if (dropNumber > firstCell.RowNumber)
                {
                    if (e.RowIndex >= firstCell.RowNumber && e.RowIndex <= dropNumber && e.ColumnIndex == firstCell.ColumnNumber)
                    {
                        if (e.RowIndex == firstCell.RowNumber)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);
                            e.Graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(e.CellBounds.Left + 1, e.CellBounds.Top + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                            if (e.Value != null)
                            {
                                e.Graphics.DrawString((e.Value).ToString(), e.CellStyle.Font, new SolidBrush(Color.Black), e.CellBounds.X, e.CellBounds.Y + 5, StringFormat.GenericDefault);
                            }
                            e.Handled = true;
                            return;
                        }
                        else
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);
                            //e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                            //e.Graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(e.CellBounds.Left + 1, e.CellBounds.Top + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                            e.Graphics.DrawLine(new Pen(Color.Green, 2), e.CellBounds.Left + 1, e.CellBounds.Bottom - 1, e.CellBounds.Left + 1, e.CellBounds.Top - 1);

                            e.Graphics.DrawLine(new Pen(Color.Green, 2), e.CellBounds.Right - 1, e.CellBounds.Top - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);

                            //如果当前单元格是拖动到的最后一行
                            if (e.RowIndex == dropNumber)
                                e.Graphics.DrawLine(new Pen(Color.Green, 2), e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                            else
                                e.Graphics.DrawLine(new Pen(Color.DarkGray, 1), e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                            //e.Graphics.DrawLine(new Pen(Color.Green, 2), e.CellBounds.Left - 1, e.CellBounds.Top - 1, e.CellBounds.Right - 1, e.CellBounds.Top - 1);
                            if (e.Value != null)
                            {
                                e.Graphics.DrawString((e.Value).ToString(), e.CellStyle.Font, new SolidBrush(Color.Black), e.CellBounds.X, e.CellBounds.Y + 5, StringFormat.GenericDefault);
                            }
                            //}
                            e.Handled = true;
                            return;
                        }

                    }
                }
            }
            else if (e.RowIndex == dgv.CurrentCell.RowIndex && e.ColumnIndex == dgv.CurrentCell.ColumnIndex)
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
                //label1.Text = "row=" + dgv.CurrentCell.RowIndex + " column=" + dgv.CurrentCell.ColumnIndex;
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
                cellMouseDown = true;

                //按下鼠标，判断刚才是否拖动过，如果是则初始化相应参数，改变CellPainting行为
                if (justDrop)
                {
                    justDrop = false;
                    firstCell.RowNumber = -1;
                    firstCell.ColumnNumber = -1;
                    dropNumber = -1;
                }
                //label1.Text += "CellMouseDown  ";
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

                label1.Text += "CellMouseUp  ";
                //DataGridView dgv = (DataGridView)sender;
                //if (firstCell.RowNumber != -1)
                //    dgv.CurrentCell = dgv.Rows[firstCell.RowNumber].Cells[firstCell.ColumnNumber];
                //恢复初始值
                cellMouseDown = false;
                //firstCell.RowNumber = -1;
                //firstCell.ColumnNumber = -1;
                //dropNumber = -1;
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


            //鼠标到当前单元格右下角时鼠标变成加号
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
            //判断鼠标离开的单元格是当前单元格，如果是则将鼠标图标改成默认
            if (e.ColumnIndex == dgv.CurrentCell.ColumnIndex && e.RowIndex == dgv.CurrentCell.RowIndex)
                dgv.Cursor = Cursors.Default;
            if (cellMouseDown)
            {
                justDrop = true;
                if (firstCell.RowNumber == -1)
                    firstCell = new DataGridCell(e.RowIndex, e.ColumnIndex);
                lastCell = new DataGridCell(e.RowIndex, e.ColumnIndex);
                //label1.Text += "leave row:" + e.RowIndex + " column:" + e.ColumnIndex;
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cellMouseDown)
            {
                if (dropNumber == -1)
                    dropNumber = firstCell.RowNumber;
                if (e.RowIndex != lastCell.RowNumber)
                    dropNumber = e.RowIndex > lastCell.RowNumber ? dropNumber + 1 : dropNumber - 1;
                //label1.Text += "\n enter row:" + e.RowIndex + " column:" + e.ColumnIndex;
                //label1.Text += "\n leave row:" + firstCell.RowNumber + " column:" + firstCell.ColumnNumber;
                label1.Text += "\n first:" + firstCell.RowNumber + " drop:" + dropNumber;
            }
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
