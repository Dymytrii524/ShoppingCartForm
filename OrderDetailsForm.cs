using System;
using System.Drawing;
using System.Windows.Forms;
using Computer_Parts_Store.Models;

namespace Computer_Parts_Store.Forms
{
    public partial class OrderDetailsForm : Form
    {
        private Order order;

        public OrderDetailsForm(Order order)
        {
            InitializeComponent();
            this.order = order;
            LoadOrderDetails();
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.btnClose = new Button();
            this.panelOrderInfo = new Panel();
            this.lblOrderNumber = new Label();
            this.lblOrderNumberValue = new Label();
            this.lblOrderDate = new Label();
            this.lblOrderDateValue = new Label();
            this.lblCustomer = new Label();
            this.lblCustomerValue = new Label();
            this.dataGridViewItems = new DataGridView();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colArticle = new DataGridViewTextBoxColumn();
            this.colPrice = new DataGridViewTextBoxColumn();
            this.colQuantity = new DataGridViewTextBoxColumn();
            this.colTotal = new DataGridViewTextBoxColumn();
            this.panelTotal = new Panel();
            this.lblTotalLabel = new Label();
            this.lblTotalValue = new Label();

            this.panelHeader.SuspendLayout();
            this.panelOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Size = new Size(900, 70);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 17);
            this.lblTitle.Text = "Деталі замовлення";

            // btnClose
            this.btnClose.BackColor = Color.FromArgb(192, 57, 43);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(800, 15);
            this.btnClose.Size = new Size(80, 40);
            this.btnClose.Text = "Закрити";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // panelOrderInfo
            this.panelOrderInfo.BackColor = Color.White;
            this.panelOrderInfo.BorderStyle = BorderStyle.FixedSingle;
            this.panelOrderInfo.Controls.Add(this.lblCustomerValue);
            this.panelOrderInfo.Controls.Add(this.lblCustomer);
            this.panelOrderInfo.Controls.Add(this.lblOrderDateValue);
            this.panelOrderInfo.Controls.Add(this.lblOrderDate);
            this.panelOrderInfo.Controls.Add(this.lblOrderNumberValue);
            this.panelOrderInfo.Controls.Add(this.lblOrderNumber);
            this.panelOrderInfo.Location = new Point(20, 90);
            this.panelOrderInfo.Size = new Size(860, 100);

            // lblOrderNumber
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblOrderNumber.Location = new Point(15, 15);
            this.lblOrderNumber.Text = "№ Замовлення:";

            // lblOrderNumberValue
            this.lblOrderNumberValue.AutoSize = true;
            this.lblOrderNumberValue.Font = new Font("Segoe UI", 11F);
            this.lblOrderNumberValue.Location = new Point(150, 15);
            this.lblOrderNumberValue.Text = "";

            // lblOrderDate
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblOrderDate.Location = new Point(15, 45);
            this.lblOrderDate.Text = "Дата замовлення:";

            // lblOrderDateValue
            this.lblOrderDateValue.AutoSize = true;
            this.lblOrderDateValue.Font = new Font("Segoe UI", 11F);
            this.lblOrderDateValue.Location = new Point(170, 45);
            this.lblOrderDateValue.Text = "";

            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblCustomer.Location = new Point(400, 15);
            this.lblCustomer.Text = "Покупець:";

            // lblCustomerValue
            this.lblCustomerValue.AutoSize = true;
            this.lblCustomerValue.Font = new Font("Segoe UI", 11F);
            this.lblCustomerValue.Location = new Point(500, 15);
            this.lblCustomerValue.Text = "";

            // dataGridViewItems
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.BackgroundColor = Color.White;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] {
                this.colProductName,
                this.colArticle,
                this.colPrice,
                this.colQuantity,
                this.colTotal
            });
            this.dataGridViewItems.Location = new Point(20, 210);
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.RowTemplate.Height = 35;
            this.dataGridViewItems.Size = new Size(860, 350);

            // Columns
            this.colProductName.HeaderText = "Назва товару";
            this.colProductName.Name = "colProductName";
            this.colProductName.Width = 400;

            this.colArticle.HeaderText = "Артикул";
            this.colArticle.Name = "colArticle";
            this.colArticle.Width = 100;

            this.colPrice.HeaderText = "Ціна (грн)";
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 120;

            this.colQuantity.HeaderText = "Кількість";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 100;

            this.colTotal.HeaderText = "Сума (грн)";
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 120;

            // panelTotal
            this.panelTotal.BackColor = Color.White;
            this.panelTotal.BorderStyle = BorderStyle.FixedSingle;
            this.panelTotal.Controls.Add(this.lblTotalValue);
            this.panelTotal.Controls.Add(this.lblTotalLabel);
            this.panelTotal.Location = new Point(20, 580);
            this.panelTotal.Size = new Size(860, 80);

            // lblTotalLabel
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotalLabel.Location = new Point(15, 25);
            this.lblTotalLabel.Text = "Загальна сума:";

            // lblTotalValue
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTotalValue.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblTotalValue.Location = new Point(700, 20);
            this.lblTotalValue.Text = "0.00 грн";

            // OrderDetailsForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(900, 680);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.panelOrderInfo);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OrderDetailsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Деталі замовлення";

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelOrderInfo.ResumeLayout(false);
            this.panelOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.ResumeLayout(false);
        }

        private void LoadOrderDetails()
        {
            lblOrderNumberValue.Text = order.OrderNumber;
            lblOrderDateValue.Text = order.OrderDate.ToString("dd.MM.yyyy HH:mm");
            lblCustomerValue.Text = order.CustomerName;

            dataGridViewItems.Rows.Clear();
            foreach (var item in order.Items)
            {
                decimal total = item.PriceAtPurchase * item.Quantity;
                dataGridViewItems.Rows.Add(
                    item.Product.Name,
                    item.Product.Article,
                    item.PriceAtPurchase.ToString("F2"),
                    item.Quantity,
                    total.ToString("F2")
                );
            }

            lblTotalValue.Text = order.TotalAmount.ToString("F2") + " грн";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Panel panelHeader;
        private Label lblTitle;
        private Button btnClose;
        private Panel panelOrderInfo;
        private Label lblOrderNumber;
        private Label lblOrderNumberValue;
        private Label lblOrderDate;
        private Label lblOrderDateValue;
        private Label lblCustomer;
        private Label lblCustomerValue;
        private DataGridView dataGridViewItems;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colArticle;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colTotal;
        private Panel panelTotal;
        private Label lblTotalLabel;
        private Label lblTotalValue;
    }
}