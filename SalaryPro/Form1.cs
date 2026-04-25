using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SalaryPro
{
    public partial class Form1 : Form
    {
        private string configPath = "settings.txt";
        private MenuStrip mainMenu;
        private List<string> vendors = new List<string> {
            "[207] Pc.Lviv", "[212] eLaptop", "[33] PXL", "[37] Fortserg1",
            "[241] Gadgetusa", "[11] It-Technolodgy", "[213] IT-Lviv",
            "[233] LPStore", "[224] SvChoice"
        };

        private List<ActualizationRecord> actualizations = new List<ActualizationRecord>();

        public Form1()
        {
            // Встановлюємо українську мову для календаря та системи
            var culture = new CultureInfo("uk-UA");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            InitializeComponent();
            InitializeMainMenu();
            LoadWindowSettings();
            ApplyModernTheme();

            // Налаштування форматів календаря
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "dd MMM yyyy";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "dd MMM yyyy";

            // Прибираємо фокус при старті
            this.Activated += (s, e) => { this.ActiveControl = null; };

            rtbReport.Font = new Font("Segoe UI", 11f);
            txtPriceBot.Text = "0";
            lblActCount.Text = "Актуалізацій немає";

            dgvVendors.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvVendors.AllowUserToAddRows = false;
            dgvVendors.RowHeadersVisible = false;

            // Події таблиці
            dgvVendors.CellValueChanged += dgvVendors_CellValueChanged;
            dgvVendors.CurrentCellDirtyStateChanged += dgvVendors_CurrentCellDirtyStateChanged;
            dgvVendors.EditingControlShowing += dgvVendors_EditingControlShowing;
            dgvVendors.CellEndEdit += dgvVendors_CellEndEdit;
            dgvVendors.KeyDown += dgvVendors_KeyDown;

            txtPriceBot.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
            txtPriceBot.Click += (s, e) => txtPriceBot.SelectAll();

            this.FormClosing += (s, e) => SaveWindowSettings();

            InitializeTable();
        }

        private void InitializeMainMenu()
        {
            mainMenu = new MenuStrip { BackColor = Color.White, Font = new Font("Segoe UI", 9f) };

            var fileItem = new ToolStripMenuItem("Файл");
            fileItem.DropDownItems.Add("Зберегти звіт", null, (s, e) => SaveReport(false));
            fileItem.DropDownItems.Add("Зберегти як...", null, (s, e) => SaveReport(true));
            fileItem.DropDownItems.Add(new ToolStripSeparator());
            fileItem.DropDownItems.Add("Очистити все", null, btnClear_Click);
            fileItem.DropDownItems.Add(new ToolStripSeparator());
            fileItem.DropDownItems.Add("Вихід", null, (s, e) => Application.Exit());

            var projectItem = new ToolStripMenuItem("Проєкт");
            projectItem.DropDownItems.Add("Згенерувати звіт", null, btnGenerate_Click);
            projectItem.DropDownItems.Add("Копіювати результат", null, btnCopy_Click);

            var toolsItem = new ToolStripMenuItem("Інструменти");
            toolsItem.DropDownItems.Add("Редагувати постачальників", null, btnEditVendors_Click);
            toolsItem.DropDownItems.Add("Менеджер актуалізацій", null, btnAddActualization_Click);

            mainMenu.Items.AddRange(new ToolStripItem[] { fileItem, projectItem, toolsItem });
            this.MainMenuStrip = mainMenu;
            this.Controls.Add(mainMenu);
        }

        private void SaveReport(bool saveAs)
        {
            if (string.IsNullOrWhiteSpace(rtbReport.Text))
            {
                ShowCenteredMessage("Спочатку згенеруйте звіт!");
                return;
            }
            string start = dtpStart.Value.ToString("dd.MM");
            string end = dtpEnd.Value.ToString("dd.MM");
            string fileName = $"Звіт {start}-{end}.txt";

            if (saveAs)
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Text Files|*.txt", FileName = fileName };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, rtbReport.Text);
                    ShowCenteredMessage("Збережено!");
                }
            }
            else
            {
                string path = System.IO.Path.Combine(Application.StartupPath, fileName);
                System.IO.File.WriteAllText(path, rtbReport.Text);
                ShowCenteredMessage($"Збережено у папку програми:\n{fileName}");
            }
        }

        private void ApplyModernTheme()
        {
            this.BackColor = Color.FromArgb(249, 249, 249);
            dgvVendors.BackgroundColor = Color.White;
            dgvVendors.GridColor = Color.FromArgb(230, 230, 230);
            dgvVendors.EnableHeadersVisualStyles = false;
            dgvVendors.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvVendors.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9f);

            SetupModernButton(btnGenerate, Color.FromArgb(0, 120, 212), Color.White);
            SetupModernButton(btnCopy, Color.FromArgb(235, 235, 235), Color.Black);
            SetupModernButton(btnClear, Color.FromArgb(235, 235, 235), Color.Black);
            SetupModernButton(btnEditVendors, Color.FromArgb(245, 245, 245), Color.FromArgb(80, 80, 80));
        }

        private void SetupModernButton(Button btn, Color backColor, Color textColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = textColor;
            btn.Cursor = Cursors.Hand;
        }

        private void InitializeTable()
        {
            dgvVendors.Rows.Clear();
            dgvVendors.RowTemplate.Height = 30;
            dgvVendors.Columns[0].Width = 160;
            dgvVendors.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            for (int i = 1; i <= 4; i++)
            {
                dgvVendors.Columns[i].Width = 55;
                dgvVendors.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvVendors.Columns[5].Width = 80;
            dgvVendors.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendors.Columns[5].ReadOnly = true;

            foreach (var v in vendors) dgvVendors.Rows.Add(v, "0", "0", "0", "0", "0");
            foreach (DataGridViewColumn col in dgvVendors.Columns) col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void ShowCenteredMessage(string message, string title = "SalaryPro")
        {
            Form f = new Form { Text = title, Size = new Size(260, 140), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, BackColor = Color.White };
            Label lbl = new Label { Text = message, Dock = DockStyle.Top, Height = 65, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9.5f) };
            Button btn = new Button { Text = "ОК", Size = new Size(80, 32), Location = new Point(90, 65), BackColor = Color.FromArgb(0, 120, 212), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btn.Click += (s, e) => f.Close();
            f.Controls.Add(btn); f.Controls.Add(lbl);
            f.ShowDialog();
        }

        public void btnAddActualization_Click(object sender, EventArgs e)
        {
            Form managerForm = new Form { Text = "Менеджер актуалізацій", Size = new Size(550, 520), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, BackColor = Color.White };
            Button btnAdd = new Button { Text = "+ Додати нового", Dock = DockStyle.Top, Height = 45, BackColor = Color.FromArgb(242, 247, 252), ForeColor = Color.FromArgb(0, 95, 184), FlatStyle = FlatStyle.Flat };
            DataGridView dgv = new DataGridView { Dock = DockStyle.Fill, AllowUserToAddRows = false, RowHeadersVisible = false, BackgroundColor = Color.White, BorderStyle = BorderStyle.None, EditMode = DataGridViewEditMode.EditOnEnter };
            dgv.Columns.Add("V", "Постачальник"); dgv.Columns.Add("C15", "Зміни (15)"); dgv.Columns.Add("C5", "Зняття (5)");
            dgv.Columns[0].ReadOnly = true;

            foreach (var act in actualizations)
            {
                int c15 = 0, c5 = 0;
                var m15 = Regex.Match(act.Formula, @"(\d+)\*15");
                var m5 = Regex.Match(act.Formula, @"(\d+)\*5");
                if (m15.Success) c15 = int.Parse(m15.Groups[1].Value);
                if (m5.Success) c5 = int.Parse(m5.Groups[1].Value);
                dgv.Rows.Add(act.VendorName, c15, c5);
            }

            Panel p = new Panel { Dock = DockStyle.Bottom, Height = 110 };
            Button bS = new Button { Text = "Зберегти", Dock = DockStyle.Top, Height = 55, BackColor = Color.FromArgb(0, 120, 212), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button bD = new Button { Text = "Видалити", Dock = DockStyle.Fill, BackColor = Color.FromArgb(255, 244, 244), ForeColor = Color.FromArgb(196, 43, 28), FlatStyle = FlatStyle.Flat };
            p.Controls.Add(bD); p.Controls.Add(bS);

            btnAdd.Click += (s, a) => ShowAddVendorDialog(dgv);
            bD.Click += (s, a) => { if (dgv.CurrentRow != null) dgv.Rows.Remove(dgv.CurrentRow); };
            bS.Click += (s, a) =>
            {
                actualizations.Clear();
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    int c15 = 0, c5 = 0;
                    int.TryParse(r.Cells[1].Value?.ToString(), out c15);
                    int.TryParse(r.Cells[2].Value?.ToString(), out c5);
                    if (c15 + c5 > 10) { ShowCenteredMessage("Сумарно не більше 10 дій!"); return; }
                    if (c15 + c5 > 0)
                    {
                        string fml = (c15 > 0 ? $"{c15}*15" : "") + (c15 > 0 && c5 > 0 ? "+" : "") + (c5 > 0 ? $"{c5}*5" : "");
                        actualizations.Add(new ActualizationRecord { VendorName = r.Cells[0].Value.ToString(), TotalSum = (c15 * 15) + (c5 * 5), Formula = fml });
                    }
                }
                UpdateActualizationLabel(); managerForm.Close();
            };
            managerForm.Controls.Add(dgv); managerForm.Controls.Add(btnAdd); managerForm.Controls.Add(p);
            managerForm.ShowDialog();
        }

        private void ShowAddVendorDialog(DataGridView targetDgv)
        {
            Form f = new Form { Text = "Додати", Size = new Size(300, 180), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, BackColor = Color.White };
            ComboBox cb = new ComboBox { Left = 20, Top = 25, Width = 245, DropDownStyle = ComboBoxStyle.DropDownList };
            cb.Items.AddRange(vendors.ToArray()); if (cb.Items.Count > 0) cb.SelectedIndex = 0;
            Button b = new Button { Text = "Додати", Left = 20, Top = 75, Width = 245, Height = 40, BackColor = Color.FromArgb(0, 120, 212), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            b.Click += (s, a) =>
            {
                foreach (DataGridViewRow r in targetDgv.Rows) if (r.Cells[0].Value?.ToString() == cb.Text) { ShowCenteredMessage("Вже в списку!"); return; }
                targetDgv.Rows.Add(cb.Text, 0, 0); f.Close();
            };
            f.Controls.Add(cb); f.Controls.Add(b); f.ShowDialog();
        }

        private void UpdateActualizationLabel()
        {
            if (actualizations.Count == 0) lblActCount.Text = "Актуалізацій немає";
            else lblActCount.Text = $"Подано ({actualizations.Count}): " + string.Join(", ", actualizations.Select(a => a.VendorName));
        }

        public void btnGenerate_Click(object sender, EventArgs e)
        {
            string start = dtpStart.Value.ToString("dd.MM"), end = dtpEnd.Value.ToString("dd.MM");
            string report = $"Розрахунок ({start} - {end})\n"; int total = 0;
            foreach (DataGridViewRow row in dgvVendors.Rows)
            {
                int sum = Convert.ToInt32(row.Cells[5].Value ?? 0);
                if (sum > 0)
                {
                    List<string> pts = new List<string>(); int[] rts = { 55, 30, 15, 5 };
                    for (int i = 0; i < 4; i++) { int c = Convert.ToInt32(row.Cells[i + 1].Value ?? 0); if (c > 0) pts.Add($"{c}*{rts[i]}"); }
                    report += $"\n{row.Cells[0].Value}\n{string.Join("+", pts)}={sum}"; total += sum;
                }
            }
            if (int.TryParse(txtPriceBot.Text, out int pc) && pc > 0) { report += $"\n\nПеревірка в боті\n{pc}*10={pc * 10}"; total += pc * 10; }
            if (actualizations.Any())
            {
                report += "\n\nАктуалізація товарів:";
                foreach (var act in actualizations) { report += $"\n{act.VendorName}\n{act.Formula}={act.TotalSum}"; total += act.TotalSum; }
            }
            report += $"\n\nРазом: {total}"; rtbReport.Text = report;
        }

        public void btnCopy_Click(object sender, EventArgs e) { if (!string.IsNullOrWhiteSpace(rtbReport.Text)) { Clipboard.SetText(rtbReport.Text.Replace("*", "×")); ShowCenteredMessage("Скопійовано!"); } }

        public void btnClear_Click(object sender, EventArgs e) { if (MessageBox.Show("Очистити все?", "SalaryPro", MessageBoxButtons.YesNo) == DialogResult.Yes) { txtPriceBot.Text = "0"; actualizations.Clear(); rtbReport.Clear(); InitializeTable(); UpdateActualizationLabel(); } }

        public void btnEditVendors_Click(object sender, EventArgs e) { Form f = new Form { Text = "Постачальники", Size = new Size(350, 500), StartPosition = FormStartPosition.CenterParent, BackColor = Color.White }; TextBox t = new TextBox { Multiline = true, Dock = DockStyle.Fill, Text = string.Join(Environment.NewLine, vendors), ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 10) }; Button b = new Button { Text = "Зберегти", Dock = DockStyle.Bottom, Height = 45, BackColor = Color.FromArgb(0, 120, 212), ForeColor = Color.White, FlatStyle = FlatStyle.Flat }; b.Click += (s, a) => { f.DialogResult = DialogResult.OK; f.Close(); }; f.Controls.Add(t); f.Controls.Add(b); if (f.ShowDialog() == DialogResult.OK) { vendors = t.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList(); InitializeTable(); } }

        private void SaveWindowSettings() { try { string d = $"{this.Location.X};{this.Location.Y};{this.Size.Width};{this.Size.Height}"; System.IO.File.WriteAllText(configPath, d); } catch { } }
        private void LoadWindowSettings() { try { if (System.IO.File.Exists(configPath)) { string[] p = System.IO.File.ReadAllText(configPath).Split(';'); this.StartPosition = FormStartPosition.Manual; this.Location = new Point(int.Parse(p[0]), int.Parse(p[1])); this.Size = new Size(int.Parse(p[2]), int.Parse(p[3])); } } catch { this.StartPosition = FormStartPosition.CenterScreen; } }

        private void dgvVendors_CellValueChanged(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0 && e.ColumnIndex >= 1 && e.ColumnIndex <= 4) { int t = 0; int[] r = { 55, 30, 15, 5 }; for (int i = 0; i < 4; i++) { var v = dgvVendors.Rows[e.RowIndex].Cells[i + 1].Value; if (v != null && int.TryParse(v.ToString(), out int c)) t += c * r[i]; } dgvVendors.Rows[e.RowIndex].Cells[5].Value = t; } }
        private void dgvVendors_CurrentCellDirtyStateChanged(object sender, EventArgs e) { if (dgvVendors.IsCurrentCellDirty) dgvVendors.CommitEdit(DataGridViewDataErrorContexts.Commit); }
        private void dgvVendors_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) { TextBox tb = e.Control as TextBox; if (tb != null) { tb.KeyPress -= NumericCheck; tb.MaxLength = 4; if (dgvVendors.CurrentCell.ColumnIndex >= 1 && dgvVendors.CurrentCell.ColumnIndex <= 4) tb.KeyPress += NumericCheck; } }
        private void NumericCheck(object sender, KeyPressEventArgs e) { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
        private void dgvVendors_CellEndEdit(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0 && e.ColumnIndex >= 1 && e.ColumnIndex <= 4) { var c = dgvVendors.Rows[e.RowIndex].Cells[e.ColumnIndex]; if (c.Value == null || string.IsNullOrWhiteSpace(c.Value.ToString())) c.Value = "0"; } }
        private void dgvVendors_KeyDown(object sender, KeyEventArgs e) { if ((e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) && dgvVendors.CurrentCell != null && dgvVendors.CurrentCell.ColumnIndex >= 1 && dgvVendors.CurrentCell.ColumnIndex <= 4) { dgvVendors.CurrentCell.Value = "0"; e.Handled = true; } }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class ActualizationRecord { public string VendorName { get; set; } public int TotalSum { get; set; } public string Formula { get; set; } }
}